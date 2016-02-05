namespace Pixer
{
    partial class Transform
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
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_H = new System.Windows.Forms.TrackBar();
            this.trackBar_W = new System.Windows.Forms.TrackBar();
            this.trackBar_X = new System.Windows.Forms.TrackBar();
            this.trackBar_Y = new System.Windows.Forms.TrackBar();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.value_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rotate_trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_W)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotate_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(196, 236);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 17);
            this.radioButton3.TabIndex = 82;
            this.radioButton3.Text = "Биллинейная";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(116, 236);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 81;
            this.radioButton2.Text = "Линейная";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 236);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 17);
            this.radioButton1.TabIndex = 80;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "К ближайшему";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 79;
            this.label4.Text = "H:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "W:";
            // 
            // trackBar_H
            // 
            this.trackBar_H.Location = new System.Drawing.Point(28, 134);
            this.trackBar_H.Maximum = 1000;
            this.trackBar_H.Minimum = 10;
            this.trackBar_H.Name = "trackBar_H";
            this.trackBar_H.Size = new System.Drawing.Size(350, 45);
            this.trackBar_H.TabIndex = 77;
            this.trackBar_H.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_H.Value = 450;
            this.trackBar_H.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // trackBar_W
            // 
            this.trackBar_W.Location = new System.Drawing.Point(28, 99);
            this.trackBar_W.Maximum = 1000;
            this.trackBar_W.Minimum = 10;
            this.trackBar_W.Name = "trackBar_W";
            this.trackBar_W.Size = new System.Drawing.Size(350, 45);
            this.trackBar_W.TabIndex = 76;
            this.trackBar_W.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_W.Value = 600;
            this.trackBar_W.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // trackBar_X
            // 
            this.trackBar_X.Location = new System.Drawing.Point(28, 16);
            this.trackBar_X.Maximum = 1000;
            this.trackBar_X.Minimum = -1000;
            this.trackBar_X.Name = "trackBar_X";
            this.trackBar_X.Size = new System.Drawing.Size(350, 45);
            this.trackBar_X.TabIndex = 75;
            this.trackBar_X.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_X.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // trackBar_Y
            // 
            this.trackBar_Y.Location = new System.Drawing.Point(28, 59);
            this.trackBar_Y.Maximum = 500;
            this.trackBar_Y.Minimum = -500;
            this.trackBar_Y.Name = "trackBar_Y";
            this.trackBar_Y.Size = new System.Drawing.Size(350, 45);
            this.trackBar_Y.TabIndex = 74;
            this.trackBar_Y.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Y.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(303, 258);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 69;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(222, 258);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 68;
            this.button_OK.Text = "Применить";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "X:";
            // 
            // value_textBox
            // 
            this.value_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value_textBox.Location = new System.Drawing.Point(49, 180);
            this.value_textBox.Name = "value_textBox";
            this.value_textBox.ReadOnly = true;
            this.value_textBox.Size = new System.Drawing.Size(42, 20);
            this.value_textBox.TabIndex = 71;
            this.value_textBox.Text = "0";
            this.value_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Угол:";
            // 
            // rotate_trackBar
            // 
            this.rotate_trackBar.BackColor = System.Drawing.SystemColors.Control;
            this.rotate_trackBar.Location = new System.Drawing.Point(97, 176);
            this.rotate_trackBar.Maximum = 360;
            this.rotate_trackBar.Name = "rotate_trackBar";
            this.rotate_trackBar.Size = new System.Drawing.Size(281, 45);
            this.rotate_trackBar.TabIndex = 67;
            this.rotate_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rotate_trackBar.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // Transform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 290);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar_H);
            this.Controls.Add(this.trackBar_W);
            this.Controls.Add(this.trackBar_X);
            this.Controls.Add(this.trackBar_Y);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.value_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotate_trackBar);
            this.Name = "Transform";
            this.Text = "Transform";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_W)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotate_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar_H;
        private System.Windows.Forms.TrackBar trackBar_W;
        private System.Windows.Forms.TrackBar trackBar_X;
        private System.Windows.Forms.TrackBar trackBar_Y;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox value_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar rotate_trackBar;
    }
}