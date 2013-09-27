namespace PlaybackModUtil
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnImport = new System.Windows.Forms.Button();
            this.lstSounds = new System.Windows.Forms.ListBox();
            this.btnConv = new System.Windows.Forms.Button();
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statGreen = new System.Windows.Forms.PictureBox();
            this.statRed = new System.Windows.Forms.PictureBox();
            this.statYellow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statYellow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(337, 140);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(109, 32);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lstSounds
            // 
            this.lstSounds.FormattingEnabled = true;
            this.lstSounds.Location = new System.Drawing.Point(12, 140);
            this.lstSounds.Name = "lstSounds";
            this.lstSounds.Size = new System.Drawing.Size(319, 108);
            this.lstSounds.TabIndex = 3;
            this.lstSounds.SelectedIndexChanged += new System.EventHandler(this.lstSounds_SelectedIndexChanged);
            // 
            // btnConv
            // 
            this.btnConv.Location = new System.Drawing.Point(337, 216);
            this.btnConv.Name = "btnConv";
            this.btnConv.Size = new System.Drawing.Size(109, 32);
            this.btnConv.TabIndex = 4;
            this.btnConv.Text = "Save and Confirm";
            this.btnConv.UseVisualStyleBackColor = true;
            this.btnConv.Click += new System.EventHandler(this.button1_Click);
            // 
            // importDialog
            // 
            this.importDialog.Filter = "OGG files|*.ogg";
            this.importDialog.Multiselect = true;
            this.importDialog.Title = "Import";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(477, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // statGreen
            // 
            this.statGreen.Image = global::PlaybackModUtil.Properties.Resources.greenicon;
            this.statGreen.Location = new System.Drawing.Point(12, 109);
            this.statGreen.Name = "statGreen";
            this.statGreen.Size = new System.Drawing.Size(16, 16);
            this.statGreen.TabIndex = 6;
            this.statGreen.TabStop = false;
            // 
            // statRed
            // 
            this.statRed.Image = global::PlaybackModUtil.Properties.Resources.redicon;
            this.statRed.Location = new System.Drawing.Point(12, 109);
            this.statRed.Name = "statRed";
            this.statRed.Size = new System.Drawing.Size(16, 16);
            this.statRed.TabIndex = 7;
            this.statRed.TabStop = false;
            // 
            // statYellow
            // 
            this.statYellow.Image = global::PlaybackModUtil.Properties.Resources.yellowicon;
            this.statYellow.Location = new System.Drawing.Point(12, 109);
            this.statYellow.Name = "statYellow";
            this.statYellow.Size = new System.Drawing.Size(16, 16);
            this.statYellow.TabIndex = 8;
            this.statYellow.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 258);
            this.Controls.Add(this.statYellow);
            this.Controls.Add(this.statRed);
            this.Controls.Add(this.statGreen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstSounds);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnConv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "iPod Mod Sound Importer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statYellow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListBox lstSounds;
        private System.Windows.Forms.Button btnConv;
        private System.Windows.Forms.OpenFileDialog importDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox statGreen;
        private System.Windows.Forms.PictureBox statRed;
        private System.Windows.Forms.PictureBox statYellow;
    }
}

