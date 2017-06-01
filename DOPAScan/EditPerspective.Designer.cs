namespace DOPAScan
{
    partial class EditPerspective
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPerspective));
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
            this.toolbarWebCameraTool = new System.Windows.Forms.ToolStrip();
            this.toolButtonChangeCornerTL = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolButtonChangeCornerTR = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolButtonChangeCornerBL = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolButtonChangeCornerBR = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.statusbarWebCamera = new System.Windows.Forms.StatusStrip();
            this.lblWebCameraRotate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraFlip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraImagePixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebCameraSelectPixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ImageBoxPreview = new DOPAScan.ImageBoxEx();
            this.toolbarUserInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolbarWebCameraTool.SuspendLayout();
            this.statusbarWebCamera.SuspendLayout();
            this.SuspendLayout();
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
            this.toolbarUserInfo.TabIndex = 18;
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
            this.toolStrip1.TabIndex = 21;
            // 
            // toolButtonSaveImage
            // 
            this.toolButtonSaveImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolButtonSaveImage.Image = global::DOPAScan.Properties.Resources.Perspective;
            this.toolButtonSaveImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonSaveImage.Name = "toolButtonSaveImage";
            this.toolButtonSaveImage.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonSaveImage.Size = new System.Drawing.Size(178, 42);
            this.toolButtonSaveImage.Text = "Adjust Perspective";
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
            // toolbarWebCameraTool
            // 
            this.toolbarWebCameraTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbarWebCameraTool.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarWebCameraTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarWebCameraTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonChangeCornerTL,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolButtonChangeCornerTR,
            this.toolStripLabel6,
            this.toolStripLabel7,
            this.toolButtonChangeCornerBL,
            this.toolStripLabel8,
            this.toolStripLabel9,
            this.toolButtonChangeCornerBR,
            this.toolStripLabel10,
            this.toolStripLabel11});
            this.toolbarWebCameraTool.Location = new System.Drawing.Point(0, 91);
            this.toolbarWebCameraTool.Name = "toolbarWebCameraTool";
            this.toolbarWebCameraTool.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolbarWebCameraTool.Size = new System.Drawing.Size(1000, 45);
            this.toolbarWebCameraTool.TabIndex = 22;
            // 
            // toolButtonChangeCornerTL
            // 
            this.toolButtonChangeCornerTL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonChangeCornerTL.Image = global::DOPAScan.Properties.Resources.TL;
            this.toolButtonChangeCornerTL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonChangeCornerTL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonChangeCornerTL.Name = "toolButtonChangeCornerTL";
            this.toolButtonChangeCornerTL.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonChangeCornerTL.Size = new System.Drawing.Size(42, 42);
            this.toolButtonChangeCornerTL.Text = "Corner Top Left Coordinate";
            this.toolButtonChangeCornerTL.ToolTipText = "Corner Top Left Coordinate";
            this.toolButtonChangeCornerTL.Click += new System.EventHandler(this.toolButtonChangeCornerTL_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel3.Text = "X";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel4.Text = "Y";
            // 
            // toolButtonChangeCornerTR
            // 
            this.toolButtonChangeCornerTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonChangeCornerTR.Image = global::DOPAScan.Properties.Resources.TR;
            this.toolButtonChangeCornerTR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonChangeCornerTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonChangeCornerTR.Name = "toolButtonChangeCornerTR";
            this.toolButtonChangeCornerTR.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonChangeCornerTR.Size = new System.Drawing.Size(42, 42);
            this.toolButtonChangeCornerTR.Text = "Corner Top Right Coordinate";
            this.toolButtonChangeCornerTR.ToolTipText = "Corner Top Right Coordinate";
            this.toolButtonChangeCornerTR.Click += new System.EventHandler(this.toolButtonChangeCornerTR_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel6.Text = "X";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel7.Text = "Y";
            // 
            // toolButtonChangeCornerBL
            // 
            this.toolButtonChangeCornerBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonChangeCornerBL.Image = global::DOPAScan.Properties.Resources.BL;
            this.toolButtonChangeCornerBL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonChangeCornerBL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonChangeCornerBL.Name = "toolButtonChangeCornerBL";
            this.toolButtonChangeCornerBL.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonChangeCornerBL.Size = new System.Drawing.Size(42, 42);
            this.toolButtonChangeCornerBL.Text = "Corner Bottom Left Coordinate";
            this.toolButtonChangeCornerBL.ToolTipText = "Corner Bottom Left Coordinate";
            this.toolButtonChangeCornerBL.Click += new System.EventHandler(this.toolButtonChangeCornerBL_Click);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel8.Text = "X";
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel9.Text = "Y";
            // 
            // toolButtonChangeCornerBR
            // 
            this.toolButtonChangeCornerBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonChangeCornerBR.Image = global::DOPAScan.Properties.Resources.BR;
            this.toolButtonChangeCornerBR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonChangeCornerBR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonChangeCornerBR.Name = "toolButtonChangeCornerBR";
            this.toolButtonChangeCornerBR.Padding = new System.Windows.Forms.Padding(3);
            this.toolButtonChangeCornerBR.Size = new System.Drawing.Size(42, 42);
            this.toolButtonChangeCornerBR.Text = "Corner Bottom Right Coordinate";
            this.toolButtonChangeCornerBR.ToolTipText = "Corner Bottom Right Coordinate";
            this.toolButtonChangeCornerBR.Click += new System.EventHandler(this.toolButtonChangeCornerBR_Click);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel10.Text = "X";
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(20, 42);
            this.toolStripLabel11.Text = "Y";
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
            this.statusbarWebCamera.TabIndex = 23;
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
            // ImageBoxPreview
            // 
            this.ImageBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBoxPreview.DragHandleSize = 32;
            this.ImageBoxPreview.Location = new System.Drawing.Point(0, 136);
            this.ImageBoxPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ImageBoxPreview.Name = "ImageBoxPreview";
            this.ImageBoxPreview.Size = new System.Drawing.Size(1000, 339);
            this.ImageBoxPreview.TabIndex = 24;
            this.ImageBoxPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageBoxPreview_MouseClick);
            // 
            // EditPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.ImageBoxPreview);
            this.Controls.Add(this.statusbarWebCamera);
            this.Controls.Add(this.toolbarWebCameraTool);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolbarUserInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditPerspective";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditPerspective";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolbarUserInfo.ResumeLayout(false);
            this.toolbarUserInfo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolbarWebCameraTool.ResumeLayout(false);
            this.toolbarWebCameraTool.PerformLayout();
            this.statusbarWebCamera.ResumeLayout(false);
            this.statusbarWebCamera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarUserInfo;
        private System.Windows.Forms.ToolStripLabel lblProgramName;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripButton toolButtonSaveConfig;
        private System.Windows.Forms.ToolStripButton toolButtonDefaultConfig;
        private System.Windows.Forms.ToolStripButton toolButtonDeleteConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStrip toolbarWebCameraTool;
        private System.Windows.Forms.StatusStrip statusbarWebCamera;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraRotate;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraFlip;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraZoom;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraImagePixel;
        private System.Windows.Forms.ToolStripStatusLabel lblWebCameraSelectPixel;
        private ImageBoxEx ImageBoxPreview;
        private System.Windows.Forms.ToolStripButton toolButtonChangeCornerTL;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolButtonChangeCornerTR;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripButton toolButtonChangeCornerBL;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripButton toolButtonChangeCornerBR;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripButton toolButtonSaveImage;
    }
}