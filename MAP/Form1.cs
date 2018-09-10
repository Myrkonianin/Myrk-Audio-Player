using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace MAP
{
    public partial class Form1 : Form
    {

        public int indexToMove = 0;
        public string[] args;

        public Form1()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            //string tmp = " ";
            //for (int i = 0; i < args.Length; i++)
            //{
            //    tmp += i.ToString() + " - " + args[i] + "\n";
            //}
            //MessageBox.Show(tmp);
            if (args.Length > 1)
            {
                try
                {

                    for (int i = 0; i < playList.Items.Count - 1; i++)
                    {
                        playList.Items.RemoveAt(i);
                    }

                    v.files.Add(args[1]);
                    
                        playList.Items.Add(v.GetFileName(args[1]));
                    playList.SelectedIndex = 0;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void addSong(string song)
        {
            v.files.Add(song);

            TagModel tm = new TagModel(song);             
            if (v.tagSongShow)
            {
                playList.Items.Add(tm.artist + "-" + tm.title);
            }
            else
                playList.Items.Add(v.GetFileName(song));
        }
        private void createSettingsFile()
        {
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            try
            {
                ssettings settingss = new ssettings();
                StreamWriter sw = new StreamWriter(docsPath + "\\settings.json");
                if (!File.Exists(docsPath + "\\settings.json"))
                {
                    File.Create(docsPath + "\\settings.json");
                }
                string sett = JsonConvert.SerializeObject(settingss);

                sw.Write(sett);
                sw.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings ssettings = new settings();
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            StreamReader sr;

            basslib.InitBass();
            ssettings newsettings = new ssettings();

            if (!File.Exists(docsPath + "\\settings.json"))
            {
                createSettingsFile();
            }
            else
            {
                sr = new StreamReader(v.docsPath + "\\settings.json");
                
                string tmp = " "; tmp = sr.ReadToEnd();
                sr.Close();
                if (tmp.Contains("\\"))
                {
                    tmp = Regex.Replace(tmp,@"\\", @"\\");
                }

                newsettings = JsonConvert.DeserializeObject<ssettings>(tmp);

                string tmpp = newsettings.autoloadPlName;
                if (newsettings.autoloadPl && newsettings.autoloadPlName != "writeme")
                {
                    StreamReader tmpr = new StreamReader(tmpp);
                    string newJs = tmpr.ReadToEnd();
                    PlayList newPl = new PlayList();
                    newPl = JsonConvert.DeserializeObject<PlayList>(newJs);
                    playList.Items.Clear();
                    v.files.Clear();
                    for (int i = 0; i < newPl.pl.Count; i++)
                    {
                        playList.Items.Add(v.GetFileName(newPl.pl[i]));
                        v.f.Add(newPl.pl[i]);
                    }
                    v.files = newPl.pl;
                    tmpr.Close();
                }
                else
                {
                    menuStrip1.Items.Remove(opendef);
                    menuStrip1.Items.Remove(savedef);

                }

                v.tagSongShow = newsettings.tagSongNameShow;
                //v.defpl = newsettings.autoloadPlName;
            }
            openFileDialog1.Filter = "MPEG-1 Audio Layer 3|*.mp3";
            playList.AllowDrop = true;
            playList.MouseMove += PlayList_MouseMove;
            playList.DragEnter += PlayList_DragEnter;
            playList.DragDrop += PlayList_DragDrop;
            
            v.defpl = newsettings.autoloadPlName;
        }

        private void PlayList_DragDrop(object sender, DragEventArgs e)
        {
            int newIndex = playList.IndexFromPoint(playList.PointToClient(new Point(e.X, e.Y)));
            
            if (newIndex == -1)
            {
                object itemToMove = playList.Items[indexToMove];
                playList.Items.RemoveAt(indexToMove);
                playList.Items.Add(itemToMove);
            }
            else if (indexToMove != newIndex)
            {
                object itemToMove = playList.Items[indexToMove];
                playList.Items.RemoveAt(indexToMove);
                playList.Items.Insert(newIndex, itemToMove);
            }
        }

        private void PlayList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PlayList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                indexToMove = playList.IndexFromPoint(e.X, e.Y);
                playList.DoDragDrop(indexToMove, DragDropEffects.Move);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] tmp = openFileDialog1.FileNames;

            for(int i = 0; i < tmp.Length; i++)
            {
                addSong(tmp[i]);
            }
                        
            playList.SelectedIndex = 0;
        }

        private void play_Click(object sender, EventArgs e)
        {
            basslib.SetVolume(basslib.stream, tbVol.Value);
            if ((playList.Items.Count != 0) && (playList.SelectedIndex != -1))
            {
                string current = v.files[playList.SelectedIndex];
                basslib.Play(current, basslib.g_vol);
                label1.Text = TimeSpan.FromSeconds(basslib.GetCurrPos(basslib.stream)).ToString();
                label2.Text = TimeSpan.FromSeconds(basslib.GetTime(basslib.stream)).ToString();
                tbPos.Maximum = basslib.GetTime(basslib.stream);
                tbPos.Value = basslib.GetCurrPos(basslib.stream);
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbPos.Maximum = basslib.GetTime(basslib.stream);
            label1.Text = TimeSpan.FromSeconds(basslib.GetCurrPos(basslib.stream)).ToString();
            tbPos.Value = basslib.GetCurrPos(basslib.stream);
            if (tbPos.Value == tbPos.Maximum)
            {
                if (playList.SelectedIndex != playList.Items.Count - 1)
                {
                    try
                    {
                        playList.SelectedIndex++;
                    } catch (Exception ex)
                    {

                    }
                    string current = v.files[playList.SelectedIndex];
                    basslib.Play(current, basslib.g_vol);
                    label1.Text = TimeSpan.FromSeconds(basslib.GetCurrPos(basslib.stream)).ToString();
                    label2.Text = TimeSpan.FromSeconds(basslib.GetTime(basslib.stream)).ToString();
                    tbPos.Maximum = basslib.GetTime(basslib.stream);
                    tbPos.Value = basslib.GetCurrPos(basslib.stream);
                    timer1.Enabled = true;
                }
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            basslib.pause(basslib.stream);
            
        }

        private void tbPos_Scroll(object sender, EventArgs e)
        {
            basslib.SetPosition(basslib.stream, tbPos.Value);
        }

        private void tbVol_Scroll(object sender, EventArgs e)
        {
            basslib.SetVolume(basslib.stream, tbVol.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(v.docsPath + "\\settings.json");
            string tmp = " "; tmp = sr.ReadToEnd();
            if (tmp.Contains("\\"))
            {
                tmp = Regex.Replace(tmp, @"\\", @"\\");
            }
            ssettings newsettings = new ssettings();
            newsettings = JsonConvert.DeserializeObject<ssettings>(tmp);

            PlayList pl = new PlayList();
            pl.pl = v.files;
            string plSer = JsonConvert.SerializeObject(pl);
            StreamWriter sw = new StreamWriter(newsettings.autoloadPlName);
            sw.Write(plSer);
            sw.Close();

        }

        private void loadJson_Click(object sender, EventArgs e)
        {

            settings ssettings = new settings();
            string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            StreamReader sr;

            
            sr = new StreamReader(v.docsPath + "\\settings.json");
            string tmp = " "; tmp = sr.ReadToEnd();
            if (tmp.Contains("\\"))
            {
                tmp = Regex.Replace(tmp, @"\\", @"\\");
            }
            ssettings newsettings = new ssettings();
            newsettings = JsonConvert.DeserializeObject<ssettings>(tmp);

            if (newsettings.autoloadPl && newsettings.autoloadPlName != "writeme")
            {

                StreamReader tmpr = new StreamReader(newsettings.autoloadPlName);
                string newJs = tmpr.ReadToEnd();
                PlayList newPl = new PlayList();
                newPl = JsonConvert.DeserializeObject<PlayList>(newJs);
                playList.Items.Clear();
                v.files.Clear();
                for (int i = 0; i < newPl.pl.Count; i++)
                {
                    playList.Items.Add(v.GetFileName(newPl.pl[i]));
                    v.f.Add(newPl.pl[i]);
                }
                v.files = newPl.pl;
                tmpr.Close();
            }
            

        }

        private void openself_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            
        }

        private void saveself_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader sr = new StreamReader(openFileDialog2.FileName);
            if (sr.Equals(""))
            {
                MessageBox.Show("I can't load a playlist.");
                return;
            }

            string newJs = sr.ReadToEnd();
            PlayList newPl = new PlayList();
            newPl = JsonConvert.DeserializeObject<PlayList>(newJs);
            playList.Items.Clear();
            v.files.Clear();
            for (int i = 0; i < newPl.pl.Count; i++)
            {

                if (!File.Exists(newPl.pl[i]))
                {
                    ////1-st variant
                    //continue;
                    MessageBox.Show("Файл " + newPl.pl[i] + " отсувствует, или указан не верный путь");
                    return;
                }

                v.files.Add(newPl.pl[i]);

                TagModel tm = new TagModel(newPl.pl[i]);         
                if (v.tagSongShow)
                {
                    playList.Items.Add(tm.artist + "-" + tm.title);
                }
                else
                    playList.Items.Add(v.GetFileName(newPl.pl[i]));

            }
            v.files = newPl.pl;
            sr.Close();

            try
            {
                playList.SelectedIndex = 0;
            }catch(Exception ex) { }
        }

        

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            

            PlayList pl = new PlayList();
            string tmp = "v.files = '";
            v.files.Clear();
            ////------------------
            //v.f.Clear();
            //if(saveFileDialog1.FileName == "-")
            //{
            //    MessageBox.Show("Ты мне втираешь какую-то дичь.");
            //}else
            //{
            //    MessageBox.Show(saveFileDialog1.FileName);
            //}
            //StreamReader tmpr = new StreamReader(saveFileDialog1.FileName);
            //string newJs = tmpr.ReadToEnd();
            //PlayList newPl = new PlayList();
            //newPl = JsonConvert.DeserializeObject<PlayList>(newJs);
            //playList.Items.Clear();
            //v.files.Clear();
            //for (int i = 0; i < newPl.pl.Count; i++)
            //{
            //    v.f.Add(newPl.pl[i]);
            //}
            ////v.files = newPl.pl;
            //tmpr.Close();
            ////-----------------

            for (int i = 0; i < playList.Items.Count; i++)
            {
                v.files.Add(v.f[i]);
                tmp += v.files[i] + "\n";
            }
            
            tmp += "'";
            //MessageBox.Show(tmp);

            pl.pl = v.files;
            
            string plSer = JsonConvert.SerializeObject(pl);
            if (File.Exists(saveFileDialog1.FileName))
            {
                File.Delete(saveFileDialog1.FileName);
            }
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.Write(plSer);
            sw.Close();
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Myrk Audio Player (MAP). Я его делал только лишь для себя.", "About MAP");
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (playList.SelectedIndex != playList.Items.Count - 1)
            {
                try
                {
                    playList.SelectedIndex++;
                }
                catch (Exception ex)
                {

                }
                string current = v.files[playList.SelectedIndex];
                basslib.Play(current, basslib.g_vol);
                label1.Text = TimeSpan.FromSeconds(basslib.GetCurrPos(basslib.stream)).ToString();
                label2.Text = TimeSpan.FromSeconds(basslib.GetTime(basslib.stream)).ToString();
                tbPos.Maximum = basslib.GetTime(basslib.stream);
                tbPos.Value = basslib.GetCurrPos(basslib.stream);
                timer1.Enabled = true;
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (playList.SelectedIndex != playList.Items.Count - 1)
            {
                try
                {
                    playList.SelectedIndex--;
                }
                catch (Exception ex)
                {

                }
                string current = v.files[playList.SelectedIndex];
                basslib.Play(current, basslib.g_vol);
                label1.Text = TimeSpan.FromSeconds(basslib.GetCurrPos(basslib.stream)).ToString();
                label2.Text = TimeSpan.FromSeconds(basslib.GetTime(basslib.stream)).ToString();
                tbPos.Maximum = basslib.GetTime(basslib.stream);
                tbPos.Value = basslib.GetCurrPos(basslib.stream);
                timer1.Enabled = true;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            int previ = 0;
            if(playList.SelectedIndex != -1)
            {
                //testOfList();
                try
                {
                    previ = playList.SelectedIndex;
                    v.files.RemoveAt(playList.SelectedIndex);
                    playList.Items.RemoveAt(playList.SelectedIndex);
                    playList.SelectedIndex = previ;
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Ошибка в программе. выход из границ массива \n\n" + ex.Message);
                }
                //v.files.RemoveAt()

            }
        }

        private void testOfList()
        {
            string tmp = " ";
            for(int i = 0; i < v.files.Count; i++)
            {
                if(playList.SelectedIndex == i)
                {
                    tmp += i + "(selected) - " + v.files[i] + "\n";
                }else
                    tmp += i + " - " + v.files[i] + "\n";
            }
            MessageBox.Show(tmp);
        }
        
    }

    public class PlayList
    {
        public List<string> pl = new List<string>();
        //public List<int> i = new List<int>();
    }

    public class ssettings
    {
        public string autoloadPlName = "writeme";
        public bool autoloadPl = false;
        public bool autoplay = false;

        public bool tagSongNameShow = true;
    }
}
