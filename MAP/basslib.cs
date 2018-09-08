using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
namespace MAP
{
    public static class basslib
    {
        private static int hz = 44100;
        public static bool InitDefaultDevice;
        public static int stream;
        public static int g_vol;
        public static readonly List<int>plugins = new List<int>();

        public static bool InitBass()
        {
            if (!InitDefaultDevice)
            {
                InitDefaultDevice = Bass.BASS_Init(-1, hz, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                if (InitDefaultDevice)
                {
                    //plugins.Add(Bass.BASS_PluginLoad(v.appdir + @"plugins\bassenc_flac.dll"));
                    //plugins.Add(Bass.BASS_PluginLoad(v.appdir + @"pluginss\bassenc_mp3.dll"));
                    //plugins.Add(Bass.BASS_PluginLoad(v.appdir + @"plugins\bassenc_ogg.dll"));
                    //plugins.Add(Bass.BASS_PluginLoad(v.appdir + @"plugins\bassflac.dll"));

                    //int ErrorCount = 0;
                    //for (int i = 0; i >plugins.Count; i++)
                    //{
                    //    if(plugins[i] == 0)
                    //    {
                    //        ErrorCount++;
                    //    }
                    //}
                    //if (ErrorCount != 0)
                    //{
                    //    MessageBox.Show(ErrorCount + " плагинa не было загружено. Возможно они повреждены, или отсутствует.", "Ошибка", MessageBoxButtons.OK);
                    //}
                }
            }
            return InitDefaultDevice;
        }

        

        public static void Stop()
        {
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_StreamFree(stream);
        }

        public static void SetVolume(int stream, int vol)
        {
            g_vol = vol;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, g_vol/100f);
        }
        public static void Play(string filename, int vol)
        {

            

            if (Bass.BASS_ChannelIsActive(stream) != BASSActive.BASS_ACTIVE_PAUSED)
            {
                Stop();
                if (InitBass())
                {
                    stream = Bass.BASS_StreamCreateFile(filename, 0, 0, BASSFlag.BASS_DEFAULT);
                    if (stream != 0)
                    {
                        g_vol = vol;
                        Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, g_vol / 100f);
                        Bass.BASS_ChannelPlay(stream, false);
                    }
                }
            }
            else
            {
                Bass.BASS_ChannelPlay(stream, false);
            }
        }

        public static int GetTime(int stream)
        {
            long TimeBytes = Bass.BASS_ChannelGetLength(stream);
            double time2 = Bass.BASS_ChannelBytes2Seconds(stream, TimeBytes);
            return (int)time2;
        }

        public static int GetCurrPos(int stream)
        {
            long pos = Bass.BASS_ChannelGetPosition(stream);
            int pos2 = (int)Bass.BASS_ChannelBytes2Seconds(stream, pos);
            return pos2;
        }
        public static void SetPosition(int stream, int pos)
        {
            Bass.BASS_ChannelSetPosition(stream, (double)pos);

        }

        public static void pause(int stream)
        {
            if(Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(stream);
            }
        }
    }
}
