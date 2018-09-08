namespace MAP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playList = new System.Windows.Forms.ListBox();
            this.play = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbPos = new System.Windows.Forms.TrackBar();
            this.tbVol = new System.Windows.Forms.TrackBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plAdd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plM = new System.Windows.Forms.ToolStripMenuItem();
            this.opendef = new System.Windows.Forms.ToolStripMenuItem();
            this.savedef = new System.Windows.Forms.ToolStripMenuItem();
            this.openself = new System.Windows.Forms.ToolStripMenuItem();
            this.saveself = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playList
            // 
            this.playList.FormattingEnabled = true;
            this.playList.Location = new System.Drawing.Point(8, 143);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(304, 225);
            this.playList.TabIndex = 0;
            this.playList.DoubleClick += new System.EventHandler(this.play_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(134, 27);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(23, 23);
            this.play.TabIndex = 1;
            this.play.Text = ">";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(163, 27);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(23, 23);
            this.pause.TabIndex = 2;
            this.pause.Text = "| |";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "playlist.json";
            this.saveFileDialog1.Filter = "Плейлисты|*.json";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tbPos
            // 
            this.tbPos.Location = new System.Drawing.Point(7, 92);
            this.tbPos.Name = "tbPos";
            this.tbPos.Size = new System.Drawing.Size(204, 45);
            this.tbPos.TabIndex = 4;
            this.tbPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPos.Scroll += new System.EventHandler(this.tbPos_Scroll);
            // 
            // tbVol
            // 
            this.tbVol.Location = new System.Drawing.Point(217, 92);
            this.tbVol.Maximum = 100;
            this.tbVol.Name = "tbVol";
            this.tbVol.Size = new System.Drawing.Size(94, 45);
            this.tbVol.TabIndex = 5;
            this.tbVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbVol.Value = 100;
            this.tbVol.Scroll += new System.EventHandler(this.tbVol_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plAdd
            // 
            this.plAdd.Location = new System.Drawing.Point(8, 116);
            this.plAdd.Name = "plAdd";
            this.plAdd.Size = new System.Drawing.Size(21, 21);
            this.plAdd.TabIndex = 10;
            this.plAdd.Text = "+";
            this.plAdd.UseVisualStyleBackColor = true;
            this.plAdd.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plM,
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(320, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plM
            // 
            this.plM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opendef,
            this.savedef,
            this.openself,
            this.saveself});
            this.plM.Name = "plM";
            this.plM.Size = new System.Drawing.Size(73, 20);
            this.plM.Text = "Плейлист";
            // 
            // opendef
            // 
            this.opendef.Name = "opendef";
            this.opendef.Size = new System.Drawing.Size(218, 22);
            this.opendef.Text = "Открыть по умолчанию";
            this.opendef.Click += new System.EventHandler(this.loadJson_Click);
            // 
            // savedef
            // 
            this.savedef.Name = "savedef";
            this.savedef.Size = new System.Drawing.Size(218, 22);
            this.savedef.Text = "Сохранить по умолчанию";
            this.savedef.Click += new System.EventHandler(this.button1_Click);
            // 
            // openself
            // 
            this.openself.Name = "openself";
            this.openself.Size = new System.Drawing.Size(218, 22);
            this.openself.Text = "Открыть свой...";
            this.openself.Click += new System.EventHandler(this.openself_Click);
            // 
            // saveself
            // 
            this.saveself.Name = "saveself";
            this.saveself.Size = new System.Drawing.Size(218, 22);
            this.saveself.Text = "Сохранить свой...";
            this.saveself.Click += new System.EventHandler(this.saveself_Click);
            // 
            // help
            // 
            this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(65, 20);
            this.help.Text = "Справка";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(149, 22);
            this.about.Text = "О программе";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "playlist.json";
            this.openFileDialog2.Filter = "Плейлисты|*.json";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(192, 27);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(29, 23);
            this.next.TabIndex = 12;
            this.next.Text = ">>";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(99, 27);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(29, 23);
            this.previous.TabIndex = 13;
            this.previous.Text = "<<";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(35, 116);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(21, 21);
            this.remove.TabIndex = 14;
            this.remove.Text = "-";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 380);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.next);
            this.Controls.Add(this.plAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVol);
            this.Controls.Add(this.tbPos);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.play);
            this.Controls.Add(this.playList);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Myrk Audio Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVol)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox playList;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar tbPos;
        private System.Windows.Forms.TrackBar tbVol;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button plAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plM;
        private System.Windows.Forms.ToolStripMenuItem opendef;
        private System.Windows.Forms.ToolStripMenuItem savedef;
        private System.Windows.Forms.ToolStripMenuItem openself;
        private System.Windows.Forms.ToolStripMenuItem saveself;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button remove;
    }
}

