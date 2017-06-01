namespace DOPAScan
{
    partial class WaitingProcessForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progressTotal = new System.Windows.Forms.ProgressBar();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblActionName = new System.Windows.Forms.Label();
            this.tblProcessResult = new System.Windows.Forms.DataGridView();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorkerProcess = new System.ComponentModel.BackgroundWorker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImportFailImage = new System.Windows.Forms.Button();
            this.backgroundWorkerReProcess = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.tblProcessResult)).BeginInit();
            this.SuspendLayout();
            // 
            // progressTotal
            // 
            this.progressTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressTotal.Location = new System.Drawing.Point(30, 80);
            this.progressTotal.MarqueeAnimationSpeed = 10;
            this.progressTotal.Name = "progressTotal";
            this.progressTotal.Size = new System.Drawing.Size(440, 10);
            this.progressTotal.Step = 1;
            this.progressTotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressTotal.TabIndex = 0;
            // 
            // lblProcessName
            // 
            this.lblProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblProcessName.Location = new System.Drawing.Point(30, 10);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(440, 40);
            this.lblProcessName.TabIndex = 1;
            this.lblProcessName.Text = "Import Image Bulk";
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblActionName
            // 
            this.lblActionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblActionName.Location = new System.Drawing.Point(30, 50);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(440, 30);
            this.lblActionName.TabIndex = 2;
            this.lblActionName.Text = "Please wait ..";
            this.lblActionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblProcessResult
            // 
            this.tblProcessResult.AllowUserToAddRows = false;
            this.tblProcessResult.AllowUserToDeleteRows = false;
            this.tblProcessResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblProcessResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblProcessResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tblProcessResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tblProcessResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProcessResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Process,
            this.Result,
            this.Description});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProcessResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.tblProcessResult.Location = new System.Drawing.Point(30, 100);
            this.tblProcessResult.Name = "tblProcessResult";
            this.tblProcessResult.ReadOnly = true;
            this.tblProcessResult.RowHeadersWidth = 20;
            this.tblProcessResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblProcessResult.Size = new System.Drawing.Size(440, 191);
            this.tblProcessResult.TabIndex = 3;
            this.tblProcessResult.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.tblProcessResult_DataBindingComplete);
            // 
            // Process
            // 
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // backgroundWorkerProcess
            // 
            this.backgroundWorkerProcess.WorkerReportsProgress = true;
            this.backgroundWorkerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcess_DoWork);
            this.backgroundWorkerProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProcess_ProgressChanged);
            this.backgroundWorkerProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcess_RunWorkerCompleted);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(395, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImportFailImage
            // 
            this.btnImportFailImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportFailImage.Location = new System.Drawing.Point(219, 297);
            this.btnImportFailImage.Name = "btnImportFailImage";
            this.btnImportFailImage.Size = new System.Drawing.Size(170, 30);
            this.btnImportFailImage.TabIndex = 5;
            this.btnImportFailImage.Text = "Import Failed Image";
            this.btnImportFailImage.UseVisualStyleBackColor = true;
            this.btnImportFailImage.Click += new System.EventHandler(this.btnImportFailImage_Click);
            // 
            // backgroundWorkerReProcess
            // 
            this.backgroundWorkerReProcess.WorkerReportsProgress = true;
            this.backgroundWorkerReProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReProcess_DoWork);
            this.backgroundWorkerReProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerReProcess_ProgressChanged);
            this.backgroundWorkerReProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReProcess_RunWorkerCompleted);
            // 
            // WaitingProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnImportFailImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tblProcessResult);
            this.Controls.Add(this.progressTotal);
            this.Controls.Add(this.lblActionName);
            this.Controls.Add(this.lblProcessName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WaitingProcessForm";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WaitingProcessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblProcessResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressTotal;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Label lblActionName;
        private System.Windows.Forms.DataGridView tblProcessResult;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImportFailImage;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReProcess;
    }
}