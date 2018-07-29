namespace MikanPlayer3
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxMp3Data = new System.Windows.Forms.TextBox();
            this.labelMp3Data = new System.Windows.Forms.Label();
            this.buttonFileSelect = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonReverse = new System.Windows.Forms.Button();
            this.buttonPlayListDeleteAll = new System.Windows.Forms.Button();
            this.openFileDialogMulti = new System.Windows.Forms.OpenFileDialog();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.groupBoxPlayList = new System.Windows.Forms.GroupBox();
            this.buttonPlayListUp = new System.Windows.Forms.Button();
            this.buttonPlayListDown = new System.Windows.Forms.Button();
            this.buttonPlayListDeleteOnce = new System.Windows.Forms.Button();
            this.groupBoxPlayFunction = new System.Windows.Forms.GroupBox();
            this.listBoxPlayList = new System.Windows.Forms.ListBox();
            this.panelImg = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBoxPlayList.SuspendLayout();
            this.groupBoxPlayFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMp3Data
            // 
            this.textBoxMp3Data.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMp3Data.Location = new System.Drawing.Point(1, 357);
            this.textBoxMp3Data.Multiline = true;
            this.textBoxMp3Data.Name = "textBoxMp3Data";
            this.textBoxMp3Data.ReadOnly = true;
            this.textBoxMp3Data.Size = new System.Drawing.Size(414, 202);
            this.textBoxMp3Data.TabIndex = 1;
            // 
            // labelMp3Data
            // 
            this.labelMp3Data.AutoSize = true;
            this.labelMp3Data.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMp3Data.Location = new System.Drawing.Point(-2, 338);
            this.labelMp3Data.Name = "labelMp3Data";
            this.labelMp3Data.Size = new System.Drawing.Size(239, 16);
            this.labelMp3Data.TabIndex = 2;
            this.labelMp3Data.Text = "*** 再生中MP3ファイルのデータ ***";
            // 
            // buttonFileSelect
            // 
            this.buttonFileSelect.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonFileSelect.Location = new System.Drawing.Point(12, 16);
            this.buttonFileSelect.Name = "buttonFileSelect";
            this.buttonFileSelect.Size = new System.Drawing.Size(339, 38);
            this.buttonFileSelect.TabIndex = 2;
            this.buttonFileSelect.Text = "プレイリストに追加";
            this.buttonFileSelect.UseVisualStyleBackColor = true;
            this.buttonFileSelect.Click += new System.EventHandler(this.buttonFileFunction_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPlay.Location = new System.Drawing.Point(84, 21);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(95, 36);
            this.buttonPlay.TabIndex = 8;
            this.buttonPlay.Text = "再生";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlayFunction_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop.Location = new System.Drawing.Point(184, 21);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(95, 36);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonPlayFunction_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonForward.Location = new System.Drawing.Point(285, 21);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(66, 36);
            this.buttonForward.TabIndex = 10;
            this.buttonForward.Text = "次へ";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonPlayFunction_Click);
            // 
            // buttonReverse
            // 
            this.buttonReverse.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonReverse.Location = new System.Drawing.Point(12, 21);
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(66, 36);
            this.buttonReverse.TabIndex = 7;
            this.buttonReverse.Text = "前へ";
            this.buttonReverse.UseVisualStyleBackColor = true;
            this.buttonReverse.Click += new System.EventHandler(this.buttonPlayFunction_Click);
            // 
            // buttonPlayListDeleteAll
            // 
            this.buttonPlayListDeleteAll.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPlayListDeleteAll.Location = new System.Drawing.Point(265, 60);
            this.buttonPlayListDeleteAll.Name = "buttonPlayListDeleteAll";
            this.buttonPlayListDeleteAll.Size = new System.Drawing.Size(86, 36);
            this.buttonPlayListDeleteAll.TabIndex = 6;
            this.buttonPlayListDeleteAll.Text = "全削除";
            this.buttonPlayListDeleteAll.UseVisualStyleBackColor = true;
            this.buttonPlayListDeleteAll.Click += new System.EventHandler(this.buttonFileFunction_Click);
            // 
            // openFileDialogMulti
            // 
            this.openFileDialogMulti.FileName = "openFileDialog1";
            this.openFileDialogMulti.Title = "MP3ファイルを開きます(複数選択可)";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 1;
            this.trackBarVolume.Location = new System.Drawing.Point(6, 65);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(343, 45);
            this.trackBarVolume.TabIndex = 11;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // groupBoxPlayList
            // 
            this.groupBoxPlayList.Controls.Add(this.buttonPlayListUp);
            this.groupBoxPlayList.Controls.Add(this.buttonPlayListDown);
            this.groupBoxPlayList.Controls.Add(this.buttonPlayListDeleteOnce);
            this.groupBoxPlayList.Controls.Add(this.buttonFileSelect);
            this.groupBoxPlayList.Controls.Add(this.buttonPlayListDeleteAll);
            this.groupBoxPlayList.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxPlayList.Location = new System.Drawing.Point(427, 341);
            this.groupBoxPlayList.Name = "groupBoxPlayList";
            this.groupBoxPlayList.Size = new System.Drawing.Size(355, 102);
            this.groupBoxPlayList.TabIndex = 10;
            this.groupBoxPlayList.TabStop = false;
            this.groupBoxPlayList.Text = "プレイリスト";
            // 
            // buttonPlayListUp
            // 
            this.buttonPlayListUp.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPlayListUp.Location = new System.Drawing.Point(12, 60);
            this.buttonPlayListUp.Name = "buttonPlayListUp";
            this.buttonPlayListUp.Size = new System.Drawing.Size(74, 36);
            this.buttonPlayListUp.TabIndex = 3;
            this.buttonPlayListUp.Text = "▲";
            this.buttonPlayListUp.UseVisualStyleBackColor = true;
            this.buttonPlayListUp.Click += new System.EventHandler(this.buttonFileFunction_Click);
            // 
            // buttonPlayListDown
            // 
            this.buttonPlayListDown.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPlayListDown.Location = new System.Drawing.Point(92, 60);
            this.buttonPlayListDown.Name = "buttonPlayListDown";
            this.buttonPlayListDown.Size = new System.Drawing.Size(76, 36);
            this.buttonPlayListDown.TabIndex = 4;
            this.buttonPlayListDown.Text = "▼";
            this.buttonPlayListDown.UseVisualStyleBackColor = true;
            this.buttonPlayListDown.Click += new System.EventHandler(this.buttonFileFunction_Click);
            // 
            // buttonPlayListDeleteOnce
            // 
            this.buttonPlayListDeleteOnce.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPlayListDeleteOnce.Location = new System.Drawing.Point(173, 60);
            this.buttonPlayListDeleteOnce.Name = "buttonPlayListDeleteOnce";
            this.buttonPlayListDeleteOnce.Size = new System.Drawing.Size(86, 36);
            this.buttonPlayListDeleteOnce.TabIndex = 5;
            this.buttonPlayListDeleteOnce.Text = "1件削除";
            this.buttonPlayListDeleteOnce.UseVisualStyleBackColor = true;
            this.buttonPlayListDeleteOnce.Click += new System.EventHandler(this.buttonFileFunction_Click);
            // 
            // groupBoxPlayFunction
            // 
            this.groupBoxPlayFunction.Controls.Add(this.trackBarVolume);
            this.groupBoxPlayFunction.Controls.Add(this.buttonForward);
            this.groupBoxPlayFunction.Controls.Add(this.buttonStop);
            this.groupBoxPlayFunction.Controls.Add(this.buttonPlay);
            this.groupBoxPlayFunction.Controls.Add(this.buttonReverse);
            this.groupBoxPlayFunction.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBoxPlayFunction.Location = new System.Drawing.Point(427, 449);
            this.groupBoxPlayFunction.Name = "groupBoxPlayFunction";
            this.groupBoxPlayFunction.Size = new System.Drawing.Size(355, 110);
            this.groupBoxPlayFunction.TabIndex = 11;
            this.groupBoxPlayFunction.TabStop = false;
            this.groupBoxPlayFunction.Text = "MP3再生";
            // 
            // listBoxPlayList
            // 
            this.listBoxPlayList.Enabled = false;
            this.listBoxPlayList.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBoxPlayList.FormattingEnabled = true;
            this.listBoxPlayList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.listBoxPlayList.ItemHeight = 16;
            this.listBoxPlayList.Location = new System.Drawing.Point(1, 2);
            this.listBoxPlayList.Name = "listBoxPlayList";
            this.listBoxPlayList.Size = new System.Drawing.Size(783, 324);
            this.listBoxPlayList.TabIndex = 0;
            this.listBoxPlayList.SelectedIndexChanged += new System.EventHandler(this.listBoxPlayList_SelectedIndexChanged);
            // 
            // panelImg
            // 
            this.panelImg.BackColor = System.Drawing.Color.Transparent;
            this.panelImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelImg.BackgroundImage")));
            this.panelImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelImg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelImg.Location = new System.Drawing.Point(290, 79);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(259, 237);
            this.panelImg.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelImg);
            this.Controls.Add(this.listBoxPlayList);
            this.Controls.Add(this.groupBoxPlayFunction);
            this.Controls.Add(this.groupBoxPlayList);
            this.Controls.Add(this.labelMp3Data);
            this.Controls.Add(this.textBoxMp3Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "未完プレイヤー3 - MikanPlayer3";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBoxPlayList.ResumeLayout(false);
            this.groupBoxPlayFunction.ResumeLayout(false);
            this.groupBoxPlayFunction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelMp3Data;
        private System.Windows.Forms.Button buttonFileSelect;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonReverse;
        private System.Windows.Forms.Button buttonPlayListDeleteAll;
        public System.Windows.Forms.OpenFileDialog openFileDialogMulti;
        public System.Windows.Forms.TextBox textBoxMp3Data;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.GroupBox groupBoxPlayList;
        private System.Windows.Forms.GroupBox groupBoxPlayFunction;
        private System.Windows.Forms.Button buttonPlayListUp;
        private System.Windows.Forms.Button buttonPlayListDown;
        private System.Windows.Forms.Button buttonPlayListDeleteOnce;
        private System.Windows.Forms.Panel panelImg;
        public System.Windows.Forms.ListBox listBoxPlayList;
    }
}

