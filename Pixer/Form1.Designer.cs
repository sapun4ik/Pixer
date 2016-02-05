namespace Pixer
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
            this.viewportPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blue = new System.Windows.Forms.Panel();
            this.green = new System.Windows.Forms.Panel();
            this.red = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.HistCombo = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveJPG = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessAndContrast = new System.Windows.Forms.ToolStripMenuItem();
            this.HSV = new System.Windows.Forms.ToolStripMenuItem();
            this.invert = new System.Windows.Forms.ToolStripMenuItem();
            this.binary = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.colorOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.pointBlackAndWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.SCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.curves = new System.Windows.Forms.ToolStripMenuItem();
            this.palette = new System.Windows.Forms.ToolStripMenuItem();
            this.трансформацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeTransform = new System.Windows.Forms.ToolStripMenuItem();
            this.transform = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convolution = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussian = new System.Windows.Forms.ToolStripMenuItem();
            this.normalBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.medianer = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasian = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasianOfGaussian = new System.Windows.Forms.ToolStripMenuItem();
            this.channelImageList = new System.Windows.Forms.ImageList(this.components);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rgb = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.difference = new System.Windows.Forms.ToolStripMenuItem();
            this.viewportPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // viewportPanel
            // 
            this.viewportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewportPanel.AutoScroll = true;
            this.viewportPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.viewportPanel.Controls.Add(this.button3);
            this.viewportPanel.Controls.Add(this.groupBox2);
            this.viewportPanel.Controls.Add(this.button2);
            this.viewportPanel.Controls.Add(this.groupBox1);
            this.viewportPanel.Controls.Add(this.pictureBox1);
            this.viewportPanel.Location = new System.Drawing.Point(0, 24);
            this.viewportPanel.Name = "viewportPanel";
            this.viewportPanel.Size = new System.Drawing.Size(1036, 680);
            this.viewportPanel.TabIndex = 67;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(1000, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blue);
            this.groupBox2.Controls.Add(this.green);
            this.groupBox2.Controls.Add(this.red);
            this.groupBox2.Controls.Add(this.rgb);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(756, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 152);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Каналы";
            // 
            // blue
            // 
            this.blue.BackColor = System.Drawing.Color.Blue;
            this.blue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blue.Location = new System.Drawing.Point(176, 88);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(60, 50);
            this.blue.TabIndex = 4;
            this.blue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blue_MouseDown);
            // 
            // green
            // 
            this.green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.green.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.green.Cursor = System.Windows.Forms.Cursors.Hand;
            this.green.Location = new System.Drawing.Point(104, 88);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(60, 50);
            this.green.TabIndex = 4;
            this.green.MouseDown += new System.Windows.Forms.MouseEventHandler(this.green_MouseDown);
            // 
            // red
            // 
            this.red.BackColor = System.Drawing.Color.Red;
            this.red.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.red.Cursor = System.Windows.Forms.Cursors.Hand;
            this.red.Location = new System.Drawing.Point(36, 88);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(60, 50);
            this.red.TabIndex = 4;
            this.red.MouseDown += new System.Windows.Forms.MouseEventHandler(this.red_MouseDown);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(8, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(1004, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.HistCombo);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(760, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Гистограмма";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(8, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HistCombo
            // 
            this.HistCombo.DisplayMember = "1";
            this.HistCombo.Enabled = false;
            this.HistCombo.FormattingEnabled = true;
            this.HistCombo.Items.AddRange(new object[] {
            "Красный",
            "Синий",
            "Зеленый",
            "Яркость"});
            this.HistCombo.Location = new System.Drawing.Point(60, 21);
            this.HistCombo.Name = "HistCombo";
            this.HistCombo.Size = new System.Drawing.Size(121, 21);
            this.HistCombo.TabIndex = 1;
            this.HistCombo.SelectedIndexChanged += new System.EventHandler(this.HistCombo_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изображениеToolStripMenuItem,
            this.фильтрыToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 24);
            this.menuStrip1.TabIndex = 68;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.SaveAs,
            this.SaveJPG});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(162, 22);
            this.Open.Text = "Открыть";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(162, 22);
            this.SaveAs.Text = "Сохранить как...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // SaveJPG
            // 
            this.SaveJPG.Name = "SaveJPG";
            this.SaveJPG.Size = new System.Drawing.Size(162, 22);
            this.SaveJPG.Text = "Сохранить JPG";
            this.SaveJPG.Click += new System.EventHandler(this.SaveJPG_Click);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessAndContrast,
            this.HSV,
            this.invert,
            this.binary,
            this.grayscale,
            this.colorOverlay,
            this.pointBlackAndWhite,
            this.SCorrection,
            this.gammaCorrection,
            this.curves,
            this.palette,
            this.трансформацияToolStripMenuItem});
            this.изображениеToolStripMenuItem.Enabled = false;
            this.изображениеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            // 
            // brightnessAndContrast
            // 
            this.brightnessAndContrast.Name = "brightnessAndContrast";
            this.brightnessAndContrast.Size = new System.Drawing.Size(208, 22);
            this.brightnessAndContrast.Text = "Яркость/Контрастность";
            this.brightnessAndContrast.Click += new System.EventHandler(this.brightnessAndContrast_Click);
            // 
            // HSV
            // 
            this.HSV.Name = "HSV";
            this.HSV.Size = new System.Drawing.Size(208, 22);
            this.HSV.Text = "HSV-коррекция";
            this.HSV.Click += new System.EventHandler(this.HSV_Click);
            // 
            // invert
            // 
            this.invert.Name = "invert";
            this.invert.Size = new System.Drawing.Size(208, 22);
            this.invert.Text = "Инверсия";
            this.invert.Click += new System.EventHandler(this.invert_Click);
            // 
            // binary
            // 
            this.binary.Name = "binary";
            this.binary.Size = new System.Drawing.Size(208, 22);
            this.binary.Text = "Бинаризация";
            this.binary.Click += new System.EventHandler(this.binary_Click);
            // 
            // grayscale
            // 
            this.grayscale.Name = "grayscale";
            this.grayscale.Size = new System.Drawing.Size(208, 22);
            this.grayscale.Text = "Удаление цвета";
            this.grayscale.Click += new System.EventHandler(this.grayscale_Click);
            // 
            // colorOverlay
            // 
            this.colorOverlay.Name = "colorOverlay";
            this.colorOverlay.Size = new System.Drawing.Size(208, 22);
            this.colorOverlay.Text = "Наложение цвета";
            this.colorOverlay.Click += new System.EventHandler(this.colorOverlay_Click);
            // 
            // pointBlackAndWhite
            // 
            this.pointBlackAndWhite.Name = "pointBlackAndWhite";
            this.pointBlackAndWhite.Size = new System.Drawing.Size(208, 22);
            this.pointBlackAndWhite.Text = "Точка черного и белого";
            this.pointBlackAndWhite.Click += new System.EventHandler(this.pointBlackAndWhite_Click);
            // 
            // SCorrection
            // 
            this.SCorrection.Name = "SCorrection";
            this.SCorrection.Size = new System.Drawing.Size(208, 22);
            this.SCorrection.Text = "S-коррекция";
            this.SCorrection.Click += new System.EventHandler(this.SCorrection_Click);
            // 
            // gammaCorrection
            // 
            this.gammaCorrection.Name = "gammaCorrection";
            this.gammaCorrection.Size = new System.Drawing.Size(208, 22);
            this.gammaCorrection.Text = "Гамма-коррекция";
            this.gammaCorrection.Click += new System.EventHandler(this.gammaCorrection_Click);
            // 
            // curves
            // 
            this.curves.Name = "curves";
            this.curves.Size = new System.Drawing.Size(208, 22);
            this.curves.Text = "Кривые";
            this.curves.Click += new System.EventHandler(this.curves_Click);
            // 
            // palette
            // 
            this.palette.Name = "palette";
            this.palette.Size = new System.Drawing.Size(208, 22);
            this.palette.Text = "Палитра";
            this.palette.Click += new System.EventHandler(this.palette_Click);
            // 
            // трансформацияToolStripMenuItem
            // 
            this.трансформацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeTransform,
            this.transform});
            this.трансформацияToolStripMenuItem.Name = "трансформацияToolStripMenuItem";
            this.трансформацияToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.трансформацияToolStripMenuItem.Text = "Трансформация";
            // 
            // freeTransform
            // 
            this.freeTransform.Name = "freeTransform";
            this.freeTransform.Size = new System.Drawing.Size(152, 22);
            this.freeTransform.Text = "Свободная";
            this.freeTransform.Click += new System.EventHandler(this.freeTransform_Click);
            // 
            // transform
            // 
            this.transform.Name = "transform";
            this.transform.Size = new System.Drawing.Size(152, 22);
            this.transform.Text = "Без потери";
            this.transform.Click += new System.EventHandler(this.transform_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convolution,
            this.gaussian,
            this.normalBlur,
            this.medianer,
            this.laplasian,
            this.laplasianOfGaussian,
            this.difference});
            this.фильтрыToolStripMenuItem.Enabled = false;
            this.фильтрыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // convolution
            // 
            this.convolution.Name = "convolution";
            this.convolution.Size = new System.Drawing.Size(293, 22);
            this.convolution.Text = "Матрица свертки";
            this.convolution.Click += new System.EventHandler(this.convolution_Click);
            // 
            // gaussian
            // 
            this.gaussian.Name = "gaussian";
            this.gaussian.Size = new System.Drawing.Size(293, 22);
            this.gaussian.Text = "Фильтр Гаусса";
            this.gaussian.Click += new System.EventHandler(this.gaussian_Click);
            // 
            // normalBlur
            // 
            this.normalBlur.Name = "normalBlur";
            this.normalBlur.Size = new System.Drawing.Size(293, 22);
            this.normalBlur.Text = "Усредненное размытие";
            this.normalBlur.Click += new System.EventHandler(this.normalBlur_Click);
            // 
            // medianer
            // 
            this.medianer.Name = "medianer";
            this.medianer.Size = new System.Drawing.Size(293, 22);
            this.medianer.Text = "Медианер";
            this.medianer.Click += new System.EventHandler(this.medianer_Click);
            // 
            // laplasian
            // 
            this.laplasian.Name = "laplasian";
            this.laplasian.Size = new System.Drawing.Size(293, 22);
            this.laplasian.Text = "Усиление границ по Лапласу";
            this.laplasian.Click += new System.EventHandler(this.laplasian_Click);
            // 
            // laplasianOfGaussian
            // 
            this.laplasianOfGaussian.Name = "laplasianOfGaussian";
            this.laplasianOfGaussian.Size = new System.Drawing.Size(293, 22);
            this.laplasianOfGaussian.Text = "Усиление границ по Лапласу с Гауссом";
            this.laplasianOfGaussian.Click += new System.EventHandler(this.laplasianOfGaussian_Click);
            // 
            // channelImageList
            // 
            this.channelImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("channelImageList.ImageStream")));
            this.channelImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.channelImageList.Images.SetKeyName(0, "RGB");
            this.channelImageList.Images.SetKeyName(1, "R");
            this.channelImageList.Images.SetKeyName(2, "G");
            this.channelImageList.Images.SetKeyName(3, "B");
            // 
            // numericUpDown
            // 
            this.numericUpDown.Enabled = false;
            this.numericUpDown.Location = new System.Drawing.Point(980, 4);
            this.numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown.TabIndex = 72;
            this.numericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(924, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Масштаб";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.undoToolStripMenuItem.Text = "<Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.redoToolStripMenuItem.Text = "Redo>";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // rgb
            // 
            this.rgb.BackgroundImage = global::Pixer.Properties.Resources.Icon_RGB_01;
            this.rgb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rgb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rgb.Location = new System.Drawing.Point(104, 36);
            this.rgb.Name = "rgb";
            this.rgb.Size = new System.Drawing.Size(60, 46);
            this.rgb.TabIndex = 3;
            this.rgb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rgb_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(8, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pictureBox1.Location = new System.Drawing.Point(76, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(712, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // difference
            // 
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(293, 22);
            this.difference.Text = "Разница";
            this.difference.Click += new System.EventHandler(this.difference_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 702);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.viewportPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pixer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.viewportPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel viewportPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem SaveJPG;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox HistCombo;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ToolStripMenuItem brightnessAndContrast;
        private System.Windows.Forms.ToolStripMenuItem HSV;
        private System.Windows.Forms.ToolStripMenuItem invert;
        private System.Windows.Forms.ToolStripMenuItem binary;
        private System.Windows.Forms.ToolStripMenuItem grayscale;
        private System.Windows.Forms.ToolStripMenuItem colorOverlay;
        private System.Windows.Forms.ToolStripMenuItem pointBlackAndWhite;
        private System.Windows.Forms.ToolStripMenuItem SCorrection;
        private System.Windows.Forms.ToolStripMenuItem gammaCorrection;
        private System.Windows.Forms.ToolStripMenuItem curves;
        private System.Windows.Forms.ToolStripMenuItem palette;
        private System.Windows.Forms.ToolStripMenuItem convolution;
        private System.Windows.Forms.ToolStripMenuItem gaussian;
        private System.Windows.Forms.ToolStripMenuItem normalBlur;
        private System.Windows.Forms.ToolStripMenuItem medianer;
        private System.Windows.Forms.ToolStripMenuItem laplasian;
        private System.Windows.Forms.ToolStripMenuItem laplasianOfGaussian;
        private System.Windows.Forms.ImageList channelImageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem трансформацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeTransform;
        private System.Windows.Forms.ToolStripMenuItem transform;
        private System.Windows.Forms.Panel rgb;
        private System.Windows.Forms.Panel blue;
        private System.Windows.Forms.Panel green;
        private System.Windows.Forms.Panel red;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difference;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}

