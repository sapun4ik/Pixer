namespace Pixer
{
    partial class BrightnessAndContrast
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_Contrast = new System.Windows.Forms.TextBox();
            this.textBox_Brightness = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_Contrast = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_Brightness = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(169, 146);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 31;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(88, 146);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 30;
            this.button_OK.Text = "Применить";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_Contrast
            // 
            this.textBox_Contrast.Location = new System.Drawing.Point(260, 69);
            this.textBox_Contrast.Name = "textBox_Contrast";
            this.textBox_Contrast.ReadOnly = true;
            this.textBox_Contrast.Size = new System.Drawing.Size(46, 20);
            this.textBox_Contrast.TabIndex = 29;
            this.textBox_Contrast.Text = "0";
            this.textBox_Contrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Brightness
            // 
            this.textBox_Brightness.Location = new System.Drawing.Point(260, 11);
            this.textBox_Brightness.Name = "textBox_Brightness";
            this.textBox_Brightness.ReadOnly = true;
            this.textBox_Brightness.Size = new System.Drawing.Size(46, 20);
            this.textBox_Brightness.TabIndex = 28;
            this.textBox_Brightness.Text = "0";
            this.textBox_Brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Контрастность";
            // 
            // trackBar_Contrast
            // 
            this.trackBar_Contrast.Location = new System.Drawing.Point(4, 95);
            this.trackBar_Contrast.Maximum = 100;
            this.trackBar_Contrast.Minimum = -100;
            this.trackBar_Contrast.Name = "trackBar_Contrast";
            this.trackBar_Contrast.Size = new System.Drawing.Size(324, 45);
            this.trackBar_Contrast.TabIndex = 26;
            this.trackBar_Contrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Contrast.Scroll += new System.EventHandler(this.trackBar_Brightness_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Яркость";
            // 
            // trackBar_Brightness
            // 
            this.trackBar_Brightness.Location = new System.Drawing.Point(4, 40);
            this.trackBar_Brightness.Maximum = 255;
            this.trackBar_Brightness.Minimum = -255;
            this.trackBar_Brightness.Name = "trackBar_Brightness";
            this.trackBar_Brightness.Size = new System.Drawing.Size(324, 45);
            this.trackBar_Brightness.TabIndex = 24;
            this.trackBar_Brightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Brightness.Scroll += new System.EventHandler(this.trackBar_Brightness_Scroll);
            // 
            // BrightnessAndContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 180);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Contrast);
            this.Controls.Add(this.textBox_Brightness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar_Contrast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_Brightness);
            this.Name = "BrightnessAndContrast";
            this.Text = "Яркость/Контрастность";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Brightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_Contrast;
        private System.Windows.Forms.TextBox textBox_Brightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_Contrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_Brightness;
    }
}