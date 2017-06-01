namespace DOPAScan
{
    partial class PreviewImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewImage));
            this.ImageBoxPreview = new DOPAScan.ImageBoxEx();
            this.lblWebCameraZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusbarWebCamera = new System.Windows.Forms.StatusStrip();
            this.lblWebCameraRotate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraFlip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraImagePixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraSelectPixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbarWebCameraTool = new System.Windows.Forms.ToolStrip();
            this.toolButtonRotateCCW = new System.Windows.Forms.ToolStripButton();
            this.toolButtonRotateCW = new System.Windows.Forms.ToolStripButton();
            this.toolButtonRotateCCW90 = new System.Windows.Forms.ToolStripButton();
            this.toolButtonRotateCW90 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonFlipX = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonBrightnessActual = new System.Windows.Forms.ToolStripButton();
            this.toolButtonBrightnessDecrease = new System.Windows.Forms.ToolStripButton();
            this.toolButtonBrightnessIncrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonContrastActual = new System.Windows.Forms.ToolStripButton();
            this.toolButtonContrastDecrease = new System.Windows.Forms.ToolStripButton();
            this.toolButtonContrastIncrease = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonCrop = new System.Windows.Forms.ToolStripButton();
            this.toolButtonPerspective = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarUserInfo = new System.Windows.Forms.ToolStrip();
            this.lblProgramName = new System.Windows.Forms.ToolStripLabel();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolButtonSaveImage = new System.Windows.Forms.ToolStripButton();
            this.toolButtonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonActualSize = new System.Windows.Forms.ToolStripButton();
            this.toolButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.cboZoomImage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboListConfig = new System.Windows.Forms.ToolStripComboBox();
            this.toolButtonLoadConfig = new System.Windows.Forms.ToolStripButton();
            this.toolButtonSaveConfig = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDefaultConfig = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDeleteConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.statusbarWebCamera.SuspendLayout();
            this.toolbarWebCameraTool.SuspendLayout();
            this.toolbarUserInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageBoxPreview
            // 
            this.ImageBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBoxPreview.DragHandleSize = 32;
            this.ImageBoxPreview.Location = new System.Drawing.Point(0, 136);
            this.ImageBoxPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ImageBoxPreview.Name = "ImageBoxPreview";
            this.ImageBoxPreview.Size = new System.Drawing.Size(1000, 339);
            this.ImageBoxPreview.TabIndex = 14;
            this.ImageBoxPreview.SelectionRegionChanged += new System.EventHandler(this.ImageBoxPreview_SelectionRegionChanged);
            this.ImageBoxPreview.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.ImageBoxPreview_Zoomed);
            // 
            // lblWebCameraZoom
            // 
            this.lblWebCameraZoom.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWebCameraZoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCameraZoom.Margin = new System.Windows.Forms.Padding(0);
            this.lblWebCameraZoom.Name = "lblWebCameraZoom";
            this.lblWebCameraZoom.Size = new System.Drawing.Size(102, 25);
            this.lblWebCameraZoom.Text = "Zoom: 100%";
            this.lblWebCameraZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusbarWebCamera
            // 
            this.statusbarWebCamera.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusbarWebCamera.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusbarWebCamera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWebCameraRotate,
            this.lblWebCameraFlip,
            this.lblWebCameraZoom,
            this.lblWebCameraImagePixel,
            this.lblWebCameraSelectPixel});
            this.statusbarWebCamera.Location = new System.Drawing.Point(0, 475);
            this.statusbarWebCamera.Name = "statusbarWebCamera";
            this.statusbarWebCamera.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusbarWebCamera.Size = new System.Drawing.Size(1000, 25);
            this.statusbarWebCamera.SizingGrip = false;
            this.statusbarWebCamera.TabIndex = 15;
            // 
            // lblWebCameraRotate
            // 
            this.lblWebCameraRotate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWebCameraRotate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCameraRotate.Margin = new System.Windows.Forms.Padding(0);
            this.lblWebCameraRotate.Name = "lblWebCameraRotate";
            this.lblWebCameraRotate.Size = new System.Drawing.Size(104, 25);
            this.lblWebCameraRotate.Text = "Rotate: None";
            this.lblWebCameraRotate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWebCameraFlip
            // 
            this.lblWebCameraFlip.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWebCameraFlip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCameraFlip.Margin = new System.Windows.Forms.Padding(0);
            this.lblWebCameraFlip.Name = "lblWebCameraFlip";
            this.lblWebCameraFlip.Size = new System.Drawing.Size(84, 25);
            this.lblWebCameraFlip.Text = "Flip: None";
            this.lblWebCameraFlip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWebCameraImagePixel
            // 
            this.lblWebCameraImagePixel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWebCameraImagePixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCameraImagePixel.Margin = new System.Windows.Forms.Padding(0);
            this.lblWebCameraImagePixel.Name = "lblWebCameraImagePixel";
            this.lblWebCameraImagePixel.Size = new System.Drawing.Size(92, 25);
            this.lblWebCameraImagePixel.Text = "Image Size:";
            this.lblWebCameraImagePixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWebCameraSelectPixel
            // 
            this.lblWebCameraSelectPixel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblWebCameraSelectPixel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebCameraSelectPixel.Margin = new System.Windows.Forms.Padding(0);
            this.lblWebCameraSelectPixel.Name = "lblWebCameraSelectPixel";
            this.lblWebCameraSelectPixel.Size = new System.Drawing.Size(90, 25);
            this.lblWebCameraSelectPixel.Text = "Select Size:";
            this.lblWebCameraSelectPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolbarWebCameraTool
            // 
            this.toolbarWebCameraTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbarWebCameraTool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarWebCameraTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarWebCameraTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonRotateCCW,
            this.toolButtonRotateCW,
            this.toolButtonRotateCCW90,
            this.toolButtonRotateCW90,
            this.toolStripSeparator7,
            this.toolButtonFlipX,
            this.toolButtonFlipY,
            this.toolStripSeparator5,
            this.toolButtonBrightnessActual,
            this.toolButtonBrightnessDecrease,
            this.toolButtonBrightnessIncrease,
            this.toolStripSeparator3,
            this.toolButtonContrastActual,
            this.toolButtonContrastDecrease,
            this.toolButtonContrastIncrease,
            this.toolStripSeparator2,
            this.toolButtonCrop,
            this.toolButtonPerspective,
            this.toolStripSeparator9,
            this.toolStripLabel2,
            this.toolStripLabel5,
            this.toolStripSeparator6});
            this.toolbarWebCameraTool.Location = new System.Drawing.Point(0, 91);
            this.toolbarWebCameraTool.Name = "toolbarWebCameraTool";
            this.toolbarWebCameraTool.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolbarWebCameraTool.Size = new System.Drawing.Size(1000, 45);
            this.toolbarWebCameraTool.TabIndex = 16;
            // 
            // toolButtonRotateCCW
            // 
            this.toolButtonRotateCCW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRotateCCW.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolButtonRotateCCW.Image = global::DOPAScan.Properties.Resources.RotateCCW;
            this.toolButtonRotateCCW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonRotateCCW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonRotateCCW.Name = "toolButtonRotateCCW";
            this.toolButtonRotateCCW.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonRotateCCW.Size = new System.Drawing.Size(42, 42);
            this.toolButtonRotateCCW.Text = "Rotate Left";
            this.toolButtonRotateCCW.ToolTipText = "Rotate Counter Clockwise";
            this.toolButtonRotateCCW.Click += new System.EventHandler(this.toolButtonRotateCCW_Click);
            // 
            // toolButtonRotateCW
            // 
            this.toolButtonRotateCW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRotateCW.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolButtonRotateCW.Image = global::DOPAScan.Properties.Resources.RotateCW;
            this.toolButtonRotateCW.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonRotateCW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonRotateCW.Name = "toolButtonRotateCW";
            this.toolButtonRotateCW.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonRotateCW.Size = new System.Drawing.Size(42, 42);
            this.toolButtonRotateCW.Text = "Rotate Right";
            this.toolButtonRotateCW.ToolTipText = "Rotate Clockwise";
            this.toolButtonRotateCW.Click += new System.EventHandler(this.toolButtonRotateCW_Click);
            // 
            // toolButtonRotateCCW90
            // 
            this.toolButtonRotateCCW90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRotateCCW90.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolButtonRotateCCW90.Image = global::DOPAScan.Properties.Resources.Rotate90CCW;
            this.toolButtonRotateCCW90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonRotateCCW90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonRotateCCW90.Name = "toolButtonRotateCCW90";
            this.toolButtonRotateCCW90.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonRotateCCW90.Size = new System.Drawing.Size(42, 42);
            this.toolButtonRotateCCW90.Tag = "-90";
            this.toolButtonRotateCCW90.Text = "-90";
            this.toolButtonRotateCCW90.ToolTipText = "Rotate 90 Counter Clockwise";
            this.toolButtonRotateCCW90.Click += new System.EventHandler(this.toolButtonRotateCCW90_Click);
            // 
            // toolButtonRotateCW90
            // 
            this.toolButtonRotateCW90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRotateCW90.Image = global::DOPAScan.Properties.Resources.Rotate90CW;
            this.toolButtonRotateCW90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonRotateCW90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonRotateCW90.Name = "toolButtonRotateCW90";
            this.toolButtonRotateCW90.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonRotateCW90.Size = new System.Drawing.Size(42, 42);
            this.toolButtonRotateCW90.Text = "+90";
            this.toolButtonRotateCW90.ToolTipText = "Rotate 90 Clockwise";
            this.toolButtonRotateCW90.Click += new System.EventHandler(this.toolButtonRotateCW90_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
            // 
            // toolButtonFlipX
            // 
            this.toolButtonFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFlipX.Image = global::DOPAScan.Properties.Resources.FlipHorizontal;
            this.toolButtonFlipX.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFlipX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFlipX.Name = "toolButtonFlipX";
            this.toolButtonFlipX.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonFlipX.Size = new System.Drawing.Size(42, 42);
            this.toolButtonFlipX.Text = "Flip X";
            this.toolButtonFlipX.ToolTipText = "Flip Horizontal";
            this.toolButtonFlipX.Click += new System.EventHandler(this.toolButtonFlipX_Click);
            // 
            // toolButtonFlipY
            // 
            this.toolButtonFlipY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFlipY.Image = global::DOPAScan.Properties.Resources.FlipVertical;
            this.toolButtonFlipY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFlipY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFlipY.Name = "toolButtonFlipY";
            this.toolButtonFlipY.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonFlipY.Size = new System.Drawing.Size(42, 42);
            this.toolButtonFlipY.Text = "Flip Y";
            this.toolButtonFlipY.ToolTipText = "Flip Vertical";
            this.toolButtonFlipY.Click += new System.EventHandler(this.toolButtonFlipY_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
            // 
            // toolButtonBrightnessActual
            // 
            this.toolButtonBrightnessActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonBrightnessActual.Image = global::DOPAScan.Properties.Resources.BrightnessActual;
            this.toolButtonBrightnessActual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonBrightnessActual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonBrightnessActual.Name = "toolButtonBrightnessActual";
            this.toolButtonBrightnessActual.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonBrightnessActual.Size = new System.Drawing.Size(42, 42);
            this.toolButtonBrightnessActual.Text = "-Zoom";
            this.toolButtonBrightnessActual.ToolTipText = "Reset Brightness";
            this.toolButtonBrightnessActual.Click += new System.EventHandler(this.toolButtonBrightnessActual_Click);
            // 
            // toolButtonBrightnessDecrease
            // 
            this.toolButtonBrightnessDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonBrightnessDecrease.Image = global::DOPAScan.Properties.Resources.BrightnessDecrease;
            this.toolButtonBrightnessDecrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonBrightnessDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonBrightnessDecrease.Name = "toolButtonBrightnessDecrease";
            this.toolButtonBrightnessDecrease.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonBrightnessDecrease.Size = new System.Drawing.Size(42, 42);
            this.toolButtonBrightnessDecrease.Text = "-Zoom";
            this.toolButtonBrightnessDecrease.ToolTipText = "Brightness Decrease";
            this.toolButtonBrightnessDecrease.Click += new System.EventHandler(this.toolButtonBrightnessDecrease_Click);
            // 
            // toolButtonBrightnessIncrease
            // 
            this.toolButtonBrightnessIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonBrightnessIncrease.Image = global::DOPAScan.Properties.Resources.BrightnessIncrease;
            this.toolButtonBrightnessIncrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonBrightnessIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonBrightnessIncrease.Name = "toolButtonBrightnessIncrease";
            this.toolButtonBrightnessIncrease.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonBrightnessIncrease.Size = new System.Drawing.Size(42, 42);
            this.toolButtonBrightnessIncrease.Text = "+Zoom";
            this.toolButtonBrightnessIncrease.ToolTipText = "Brightness Increase";
            this.toolButtonBrightnessIncrease.Click += new System.EventHandler(this.toolButtonBrightnessIncrease_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // toolButtonContrastActual
            // 
            this.toolButtonContrastActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonContrastActual.Image = global::DOPAScan.Properties.Resources.ContrastActual;
            this.toolButtonContrastActual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonContrastActual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonContrastActual.Name = "toolButtonContrastActual";
            this.toolButtonContrastActual.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonContrastActual.Size = new System.Drawing.Size(42, 42);
            this.toolButtonContrastActual.Text = "-Zoom";
            this.toolButtonContrastActual.ToolTipText = "Reset Contrast";
            this.toolButtonContrastActual.Click += new System.EventHandler(this.toolButtonContrastActual_Click);
            // 
            // toolButtonContrastDecrease
            // 
            this.toolButtonContrastDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonContrastDecrease.Image = global::DOPAScan.Properties.Resources.ContrastDecrease;
            this.toolButtonContrastDecrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonContrastDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonContrastDecrease.Name = "toolButtonContrastDecrease";
            this.toolButtonContrastDecrease.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonContrastDecrease.Size = new System.Drawing.Size(42, 42);
            this.toolButtonContrastDecrease.Text = "-Zoom";
            this.toolButtonContrastDecrease.ToolTipText = "Contrast Decrease";
            this.toolButtonContrastDecrease.Click += new System.EventHandler(this.toolButtonContrastDecrease_Click);
            // 
            // toolButtonContrastIncrease
            // 
            this.toolButtonContrastIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonContrastIncrease.Image = global::DOPAScan.Properties.Resources.ContrastIncrease;
            this.toolButtonContrastIncrease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonContrastIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonContrastIncrease.Name = "toolButtonContrastIncrease";
            this.toolButtonContrastIncrease.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonContrastIncrease.Size = new System.Drawing.Size(42, 42);
            this.toolButtonContrastIncrease.Text = "+Zoom";
            this.toolButtonContrastIncrease.ToolTipText = "Contrast Increase";
            this.toolButtonContrastIncrease.Click += new System.EventHandler(this.toolButtonContrastIncrease_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // toolButtonCrop
            // 
            this.toolButtonCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonCrop.Image = global::DOPAScan.Properties.Resources.Crop;
            this.toolButtonCrop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCrop.Name = "toolButtonCrop";
            this.toolButtonCrop.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonCrop.Size = new System.Drawing.Size(42, 42);
            this.toolButtonCrop.Text = "Crop Image";
            this.toolButtonCrop.ToolTipText = "Crop Image";
            this.toolButtonCrop.Click += new System.EventHandler(this.toolButtonCrop_Click);
            // 
            // toolButtonPerspective
            // 
            this.toolButtonPerspective.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonPerspective.Image = global::DOPAScan.Properties.Resources.Perspective;
            this.toolButtonPerspective.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonPerspective.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonPerspective.Name = "toolButtonPerspective";
            this.toolButtonPerspective.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonPerspective.Size = new System.Drawing.Size(42, 42);
            this.toolButtonPerspective.Text = "Adjust PErspective Image";
            this.toolButtonPerspective.ToolTipText = "Adjust PErspective Image";
            this.toolButtonPerspective.Click += new System.EventHandler(this.toolButtonPerspective_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 42);
            this.toolStripLabel2.Text = "Resize : ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel5.Text = "X";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
            // 
            // toolbarUserInfo
            // 
            this.toolbarUserInfo.BackColor = System.Drawing.Color.SlateGray;
            this.toolbarUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbarUserInfo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarUserInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarUserInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgramName,
            this.btnClose});
            this.toolbarUserInfo.Location = new System.Drawing.Point(0, 0);
            this.toolbarUserInfo.Name = "toolbarUserInfo";
            this.toolbarUserInfo.Padding = new System.Windows.Forms.Padding(0, 8, 2, 8);
            this.toolbarUserInfo.Size = new System.Drawing.Size(1000, 46);
            this.toolbarUserInfo.TabIndex = 17;
            // 
            // lblProgramName
            // 
            this.lblProgramName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.ForeColor = System.Drawing.Color.Linen;
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(209, 27);
            this.lblProgramName.Text = "DOPA Scan Document";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DOPAScan.Properties.Resources.Exit;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnClose.Size = new System.Drawing.Size(36, 30);
            this.btnClose.Text = "Exit";
            this.btnClose.ToolTipText = "Save Page All";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonSaveImage,
            this.toolButtonReset,
            this.toolStripSeparator4,
            this.toolButtonActualSize,
            this.toolButtonZoomOut,
            this.toolButtonZoomIn,
            this.cboZoomImage,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cboListConfig,
            this.toolButtonLoadConfig,
            this.toolButtonSaveConfig,
            this.toolButtonDefaultConfig,
            this.toolButtonDeleteConfig,
            this.toolStripSeparator8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 46);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1000, 45);
            this.toolStrip1.TabIndex = 20;
            // 
            // toolButtonSaveImage
            // 
            this.toolButtonSaveImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolButtonSaveImage.Image = global::DOPAScan.Properties.Resources.SaveImage;
            this.toolButtonSaveImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonSaveImage.Name = "toolButtonSaveImage";
            this.toolButtonSaveImage.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonSaveImage.Size = new System.Drawing.Size(85, 42);
            this.toolButtonSaveImage.Text = "Save";
            this.toolButtonSaveImage.ToolTipText = "Save Image";
            this.toolButtonSaveImage.Click += new System.EventHandler(this.toolButtonSaveImage_Click);
            // 
            // toolButtonReset
            // 
            this.toolButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolButtonReset.Image = global::DOPAScan.Properties.Resources.Refresh;
            this.toolButtonReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonReset.Name = "toolButtonReset";
            this.toolButtonReset.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonReset.Size = new System.Drawing.Size(42, 42);
            this.toolButtonReset.Text = "Rotate Left";
            this.toolButtonReset.ToolTipText = "Reset Image";
            this.toolButtonReset.Click += new System.EventHandler(this.toolButtonReset_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // toolButtonActualSize
            // 
            this.toolButtonActualSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonActualSize.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonActualSize.Image")));
            this.toolButtonActualSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonActualSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonActualSize.Name = "toolButtonActualSize";
            this.toolButtonActualSize.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonActualSize.Size = new System.Drawing.Size(42, 42);
            this.toolButtonActualSize.Text = "Actual";
            this.toolButtonActualSize.ToolTipText = "Actual Size";
            this.toolButtonActualSize.Click += new System.EventHandler(this.toolButtonActualSize_Click);
            // 
            // toolButtonZoomOut
            // 
            this.toolButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonZoomOut.Image = global::DOPAScan.Properties.Resources.ZoomOut;
            this.toolButtonZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonZoomOut.Name = "toolButtonZoomOut";
            this.toolButtonZoomOut.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonZoomOut.Size = new System.Drawing.Size(42, 42);
            this.toolButtonZoomOut.Text = "-Zoom";
            this.toolButtonZoomOut.ToolTipText = "Zoom Out";
            this.toolButtonZoomOut.Click += new System.EventHandler(this.toolButtonZoomOut_Click);
            // 
            // toolButtonZoomIn
            // 
            this.toolButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonZoomIn.Image = global::DOPAScan.Properties.Resources.ZoomIn;
            this.toolButtonZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonZoomIn.Name = "toolButtonZoomIn";
            this.toolButtonZoomIn.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonZoomIn.Size = new System.Drawing.Size(42, 42);
            this.toolButtonZoomIn.Text = "+Zoom";
            this.toolButtonZoomIn.ToolTipText = "Zoom In";
            this.toolButtonZoomIn.Click += new System.EventHandler(this.toolButtonZoomIn_Click);
            // 
            // cboZoomImage
            // 
            this.cboZoomImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoomImage.DropDownWidth = 75;
            this.cboZoomImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZoomImage.Name = "cboZoomImage";
            this.cboZoomImage.Padding = new System.Windows.Forms.Padding(3);
            this.cboZoomImage.Size = new System.Drawing.Size(75, 45);
            this.cboZoomImage.SelectedIndexChanged += new System.EventHandler(this.cboZoomImage_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 42);
            this.toolStripLabel1.Text = "CONFIG : ";
            // 
            // cboListConfig
            // 
            this.cboListConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListConfig.DropDownWidth = 75;
            this.cboListConfig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListConfig.Name = "cboListConfig";
            this.cboListConfig.Padding = new System.Windows.Forms.Padding(3);
            this.cboListConfig.Size = new System.Drawing.Size(75, 45);
            this.cboListConfig.SelectedIndexChanged += new System.EventHandler(this.cboListConfig_SelectedIndexChanged);
            // 
            // toolButtonLoadConfig
            // 
            this.toolButtonLoadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonLoadConfig.Image = global::DOPAScan.Properties.Resources.LoadConfig;
            this.toolButtonLoadConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonLoadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonLoadConfig.Name = "toolButtonLoadConfig";
            this.toolButtonLoadConfig.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonLoadConfig.Size = new System.Drawing.Size(42, 42);
            this.toolButtonLoadConfig.Text = "Load Config";
            this.toolButtonLoadConfig.ToolTipText = "Load Config";
            this.toolButtonLoadConfig.Click += new System.EventHandler(this.toolButtonLoadConfig_Click);
            // 
            // toolButtonSaveConfig
            // 
            this.toolButtonSaveConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonSaveConfig.Image = global::DOPAScan.Properties.Resources.AddConfig;
            this.toolButtonSaveConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonSaveConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonSaveConfig.Name = "toolButtonSaveConfig";
            this.toolButtonSaveConfig.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonSaveConfig.Size = new System.Drawing.Size(42, 42);
            this.toolButtonSaveConfig.Text = "Add Current Config";
            this.toolButtonSaveConfig.ToolTipText = "Add Current Config";
            this.toolButtonSaveConfig.Click += new System.EventHandler(this.toolButtonSaveConfig_Click);
            // 
            // toolButtonDefaultConfig
            // 
            this.toolButtonDefaultConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDefaultConfig.Image = global::DOPAScan.Properties.Resources.Favourites;
            this.toolButtonDefaultConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonDefaultConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDefaultConfig.Name = "toolButtonDefaultConfig";
            this.toolButtonDefaultConfig.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonDefaultConfig.Size = new System.Drawing.Size(42, 42);
            this.toolButtonDefaultConfig.Text = "Se Default Config";
            this.toolButtonDefaultConfig.ToolTipText = "Se Default Config";
            this.toolButtonDefaultConfig.Click += new System.EventHandler(this.toolButtonDefaultConfig_Click);
            // 
            // toolButtonDeleteConfig
            // 
            this.toolButtonDeleteConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDeleteConfig.Image = global::DOPAScan.Properties.Resources.DeleteConfig;
            this.toolButtonDeleteConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonDeleteConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDeleteConfig.Name = "toolButtonDeleteConfig";
            this.toolButtonDeleteConfig.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonDeleteConfig.Size = new System.Drawing.Size(42, 42);
            this.toolButtonDeleteConfig.Text = "Delete Config";
            this.toolButtonDeleteConfig.ToolTipText = "Delete Config";
            this.toolButtonDeleteConfig.Click += new System.EventHandler(this.toolButtonDeleteConfig_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 45);
            // 
            // PreviewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.ImageBoxPreview);
            this.Controls.Add(this.toolbarWebCameraTool);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolbarUserInfo);
            this.Controls.Add(this.statusbarWebCamera);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreviewImage";
            this.Text = "PreviewImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusbarWebCamera.ResumeLayout(false);
            this.statusbarWebCamera.PerformLayout();
            this.toolbarWebCameraTool.ResumeLayout(false);
            this.toolbarWebCameraTool.PerformLayout();
            this.toolbarUserInfo.ResumeLayout(false);
            this.toolbarUserInfo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageBoxEx ImageBoxPreview;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraZoom;
        private System.Windows.Forms.StatusStrip statusbarWebCamera;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraRotate;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraFlip;
        private System.Windows.Forms.ToolStrip toolbarWebCameraTool;
        private System.Windows.Forms.ToolStripButton toolButtonRotateCCW;
        private System.Windows.Forms.ToolStripButton toolButtonRotateCW;
        private System.Windows.Forms.ToolStripButton toolButtonRotateCCW90;
        private System.Windows.Forms.ToolStripButton toolButtonRotateCW90;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolButtonFlipX;
        private System.Windows.Forms.ToolStripButton toolButtonFlipY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraImagePixel;
        private System.Windows.Forms.ToolStrip toolbarUserInfo;
        private System.Windows.Forms.ToolStripLabel lblProgramName;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton toolButtonBrightnessActual;
        private System.Windows.Forms.ToolStripButton toolButtonBrightnessDecrease;
        private System.Windows.Forms.ToolStripButton toolButtonBrightnessIncrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolButtonContrastActual;
        private System.Windows.Forms.ToolStripButton toolButtonContrastDecrease;
        private System.Windows.Forms.ToolStripButton toolButtonContrastIncrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolButtonCrop;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraSelectPixel;
        private System.Windows.Forms.ToolStripButton toolButtonPerspective;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolButtonSaveImage;
        private System.Windows.Forms.ToolStripButton toolButtonReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolButtonActualSize;
        private System.Windows.Forms.ToolStripButton toolButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolButtonZoomIn;
        private System.Windows.Forms.ToolStripComboBox cboZoomImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboListConfig;
        private System.Windows.Forms.ToolStripButton toolButtonLoadConfig;
        private System.Windows.Forms.ToolStripButton toolButtonDeleteConfig;
        private System.Windows.Forms.ToolStripButton toolButtonDefaultConfig;
        private System.Windows.Forms.ToolStripButton toolButtonSaveConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
    }
}