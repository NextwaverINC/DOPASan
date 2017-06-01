using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOPAScan
{
    public partial class EditPerspective2 : Form
    {
        private List<Int32> _ZoomLevel = new List<Int32> { 10, 15, 20, 25, 30, 40, 50, 60, 80, 100, 120, 150, 200, 250, 300, 400, 500 };

        private ToolStripNumericUpDown txtTL_X;
        private ToolStripNumericUpDown txtTL_Y;

        private ToolStripNumericUpDown txtTR_X;
        private ToolStripNumericUpDown txtTR_Y;

        private ToolStripNumericUpDown txtBL_X;
        private ToolStripNumericUpDown txtBL_Y;

        private ToolStripNumericUpDown txtBR_X;
        private ToolStripNumericUpDown txtBR_Y;

        public Image _OriginalImage;

        private Boolean _IsEditCornerTL = false;
        private Boolean _IsEditCornerTR = false;
        private Boolean _IsEditCornerBL = false;
        private Boolean _IsEditCornerBR = false;

        private Point _PointCornerTL;
        private Point _PointCornerTR;
        private Point _PointCornerBL;
        private Point _PointCornerBR;

        private void InitialDropdownZoom()
        {
            cboZoomImage.Items.Clear();

            //////foreach (Int32 ZoomLevelItem in ImageBoxPreview.ZoomLevels)
            //////{
            //////    cboZoomImage.Items.Add(string.Format("{0}%", ZoomLevelItem));
            //////}

            cboZoomImage.SelectedItem = "100%";
        }

        public void SetStatusBarZoomText()
        {
            //////lblWebCameraZoom.Text = "Zoom: " + ImageBoxPreview.Zoom.ToString() + "%";
        }

        public EditPerspective2(Image OriginalImage)
        {
            InitializeComponent();

            //////ImageBoxPreview.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);

            lblProgramName.Text = "DOPA Scan Document - Adjust Perspective Image";

            txtTL_X = new ToolStripNumericUpDown();
            NumericUpDown txtTL_X_Control = (NumericUpDown)txtTL_X.NumericUpDownControl;
            txtTL_X_Control.Minimum = -9999;
            txtTL_X_Control.Maximum = 9999;
            txtTL_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTL_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtTL_X.Padding = cboZoomImage.Padding;
            txtTL_X.Margin = cboZoomImage.Margin;
            //txtTL_X.ValueChanged += txtTL_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(2, txtTL_X);

            txtTL_Y = new ToolStripNumericUpDown();
            NumericUpDown txtTL_Y_Control = (NumericUpDown)txtTL_Y.NumericUpDownControl;
            txtTL_Y_Control.Minimum = -9999;
            txtTL_Y_Control.Maximum = 9999;
            txtTL_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTL_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtTL_Y.Padding = cboZoomImage.Padding;
            txtTL_Y.Margin = cboZoomImage.Margin;
            //txtTL_Y.ValueChanged += txtTL_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(4, txtTL_Y);

            txtTR_X = new ToolStripNumericUpDown();
            NumericUpDown txtTR_X_Control = (NumericUpDown)txtTR_X.NumericUpDownControl;
            txtTR_X_Control.Minimum = -9999;
            txtTR_X_Control.Maximum = 9999;
            txtTR_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTR_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtTR_X.Padding = cboZoomImage.Padding;
            txtTR_X.Margin = cboZoomImage.Margin;
            //txtTR_X.ValueChanged += txtTR_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(7, txtTR_X);

            txtTR_Y = new ToolStripNumericUpDown();
            NumericUpDown txtTR_Y_Control = (NumericUpDown)txtTR_Y.NumericUpDownControl;
            txtTR_Y_Control.Minimum = -9999;
            txtTR_Y_Control.Maximum = 9999;
            txtTR_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTR_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtTR_Y.Padding = cboZoomImage.Padding;
            txtTR_Y.Margin = cboZoomImage.Margin;
            //txtTR_Y.ValueChanged += txtTR_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(9, txtTR_Y);

            txtBL_X = new ToolStripNumericUpDown();
            NumericUpDown txtBL_X_Control = (NumericUpDown)txtBL_X.NumericUpDownControl;
            txtBL_X_Control.Minimum = -9999;
            txtBL_X_Control.Maximum = 9999;
            txtBL_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBL_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtBL_X.Padding = cboZoomImage.Padding;
            txtBL_X.Margin = cboZoomImage.Margin;
            //txtBL_X.ValueChanged += txtBL_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(12, txtBL_X);

            txtBL_Y = new ToolStripNumericUpDown();
            NumericUpDown txtBL_Y_Control = (NumericUpDown)txtBL_Y.NumericUpDownControl;
            txtBL_Y_Control.Minimum = -9999;
            txtBL_Y_Control.Maximum = 9999;
            txtBL_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBL_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtBL_Y.Padding = cboZoomImage.Padding;
            txtBL_Y.Margin = cboZoomImage.Margin;
            //txtBL_Y.ValueChanged += txtBL_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(14, txtBL_Y);

            txtBR_X = new ToolStripNumericUpDown();
            NumericUpDown txtBR_X_Control = (NumericUpDown)txtBR_X.NumericUpDownControl;
            txtBR_X_Control.Minimum = -9999;
            txtBR_X_Control.Maximum = 9999;
            txtBR_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBR_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtBR_X.Padding = cboZoomImage.Padding;
            txtBR_X.Margin = cboZoomImage.Margin;
            //txtBR_X.ValueChanged += txtBR_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(17, txtBR_X);

            txtBR_Y = new ToolStripNumericUpDown();
            NumericUpDown txtBR_Y_Control = (NumericUpDown)txtBR_Y.NumericUpDownControl;
            txtBR_Y_Control.Minimum = -9999;
            txtBR_Y_Control.Maximum = 9999;
            txtBR_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBR_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtBR_Y.Padding = cboZoomImage.Padding;
            txtBR_Y.Margin = cboZoomImage.Margin;
            //txtBR_Y.ValueChanged += txtBR_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(19, txtBR_Y);

            _OriginalImage = OriginalImage;

            //////ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            InitialDropdownZoom();
            //////ImageBoxPreview.Zoom = 100;

            //////_PointCornerTL = ImageBoxPreview.PointToImage(new Point(50, 50));
            //////_PointCornerTR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, 50));
            //////_PointCornerBL = ImageBoxPreview.PointToImage(new Point(50, ImageBoxPreview.Image.Height - 50));
            //////_PointCornerBR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50));

            //////Graphics G = Graphics.FromImage(ImageBoxPreview.Image);

            //////using (var P = new Pen(Color.White, 8))
            //////{
            //////    G.DrawPolygon(P, new Point[4] { _PointCornerTL, _PointCornerTR, _PointCornerBR, _PointCornerBL });
            //////};

            //////ImageBoxPreview.Invalidate();
        }

        private void toolButtonChangeCornerTL_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = true;
            _IsEditCornerTR = false;
            _IsEditCornerBL = false;
            _IsEditCornerBR = false;
        }

        private void toolButtonChangeCornerTR_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = true;
            _IsEditCornerBL = false;
            _IsEditCornerBR = false;
        }

        private void toolButtonChangeCornerBL_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = false;
            _IsEditCornerBL = true;
            _IsEditCornerBR = false;
        }

        private void toolButtonChangeCornerBR_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = false;
            _IsEditCornerBL = false;
            _IsEditCornerBR = true;
        }

        private void DisplaySelectionRegion()
        {
            //////ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            //////Graphics G = Graphics.FromImage(ImageBoxPreview.Image);

            //////using (var P = new Pen(Color.White, 8))
            //////{
            //////    G.DrawPolygon(P, new Point[4] { _PointCornerTL, _PointCornerTR, _PointCornerBR, _PointCornerBL });
            //////};

            //////ImageBoxPreview.Invalidate();
        }

        private void ImageBoxPreview_MouseClick(object sender, MouseEventArgs e)
        {
            Boolean _IsEdit = false;

            if (_IsEditCornerTL)
            {
                //////_PointCornerTL = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerTL = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerTR)
            {
                //////_PointCornerTR = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerTR = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerBL)
            {
                //////_PointCornerBL = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerBL = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerBR)
            {
                //////_PointCornerBR = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerBR = false;
                _IsEdit = true;
            }

            if (_IsEdit)
            {
                DisplaySelectionRegion();
            }
        }

        public event EventHandler EditPerspectiveFormClosing;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.EditPerspectiveFormClosing(sender, e);

            //this.Close();
        }

        private void toolButtonReset_Click(object sender, EventArgs e)
        {
            //////ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            //////ImageBoxPreview.Zoom = 100;

            //////_PointCornerTL = ImageBoxPreview.PointToImage(new Point(50, 50));
            //////_PointCornerTR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, 50));
            //////_PointCornerBL = ImageBoxPreview.PointToImage(new Point(50, ImageBoxPreview.Image.Height - 50));
            //////_PointCornerBR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50));

            //////Graphics G = Graphics.FromImage(ImageBoxPreview.Image);

            //////using (var P = new Pen(Color.White, 8))
            //////{
            //////    G.DrawPolygon(P, new Point[4] { _PointCornerTL, _PointCornerTR, _PointCornerBR, _PointCornerBL });
            //////};

            //////ImageBoxPreview.Invalidate();
        }

        private void toolButtonActualSize_Click(object sender, EventArgs e)
        {
            //////ImageBoxPreview.ActualSize();
        }

        private void toolButtonZoomOut_Click(object sender, EventArgs e)
        {
            //////ImageBoxPreview.ZoomOut();
        }

        private void toolButtonZoomIn_Click(object sender, EventArgs e)
        {
            //////ImageBoxPreview.ZoomIn();
        }

        private void cboZoomImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////if (cboZoomImage.SelectedIndex != -1)
            //////    ImageBoxPreview.Zoom = Convert.ToInt32(cboZoomImage.SelectedItem.ToString().Replace("%", ""));
            //////SetStatusBarZoomText();
        }

        private void ImageBoxPreview_Zoomed(object sender, Cyotek.Windows.Forms.ImageBoxZoomEventArgs e)
        {
            //////cboZoomImage.SelectedItem = ImageBoxPreview.Zoom.ToString() + "%";
            //////SetStatusBarZoomText();
        }

        private void toolButtonSaveImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to adjust perspective image?", "Confirm Adjust Perspective Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Process Perspective Image Logic.");

                List<AForge.IntPoint> CornerList = new List<AForge.IntPoint>();
                CornerList.Add(new AForge.IntPoint(_PointCornerTL.X, _PointCornerTL.Y));
                CornerList.Add(new AForge.IntPoint(_PointCornerTR.X, _PointCornerTR.Y));
                CornerList.Add(new AForge.IntPoint(_PointCornerBR.X, _PointCornerBR.Y));
                CornerList.Add(new AForge.IntPoint(_PointCornerBL.X, _PointCornerBL.Y));

                //AForge.Imaging.Filters.QuadrilateralTransformation QuadTransform = new AForge.Imaging.Filters.QuadrilateralTransformation(CornerList);
                AForge.Imaging.Filters.QuadrilateralTransformation QuadTransform = new AForge.Imaging.Filters.QuadrilateralTransformation(CornerList, _OriginalImage.Width, _OriginalImage.Height);
                Image QuadTransformImage = QuadTransform.Apply((System.Drawing.Bitmap)_OriginalImage.Clone());
                
                _OriginalImage = (System.Drawing.Image)QuadTransformImage.Clone();

                //////ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

                MessageBox.Show("Adjust Perspective Successful", "Adjust Perspective", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                this.EditPerspectiveFormClosing(sender, e);
            }
        }

        //private void ApplyConfig()
        //{
        //    //Int32 Index = cboListConfig.SelectedIndex;

        //    //if (Index == -1)
        //    //{
        //    //    _IsCrop = false;
        //    //    ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
        //    //    ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);

        //    //    txtResizeWidth.Text = ImageBoxPreview.Image.Width.ToString();
        //    //    txtResizeHeight.Text = ImageBoxPreview.Image.Height.ToString();

        //    //    toolButtonLoadConfig.Enabled = false;
        //    //    toolButtonSaveConfig.Enabled = false;
        //    //    toolButtonDeleteConfig.Enabled = false;
        //    //    toolButtonDefaultConfig.Enabled = false;
        //    //}
        //    //else if (Index == 0)
        //    //{
        //    //    ImageRotate = 0;
        //    //    ImageFlipX = false;
        //    //    ImageFlipY = false;
        //    //    txtBrightness.Text = "0";
        //    //    txtContrast.Text = "0";
        //    //    _IsCrop = false;
        //    //    ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
        //    //    ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);

        //    //    txtResizeWidth.Text = ImageBoxPreview.Image.Width.ToString();
        //    //    txtResizeHeight.Text = ImageBoxPreview.Image.Height.ToString();

        //    //    toolButtonLoadConfig.Enabled = false;
        //    //    toolButtonSaveConfig.Enabled = false;
        //    //    toolButtonDeleteConfig.Enabled = false;
        //    //    toolButtonDefaultConfig.Enabled = true;
        //    //}
        //    //else
        //    //{
        //    //    try
        //    //    {
        //    //        ImageRotate = Convert.ToInt32(_ConfigEditImage_Rotate[Index]);
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        ImageRotate = 0;
        //    //    }

        //    //    try
        //    //    {
        //    //        if (_ConfigEditImage_FlipX[Index] == "1")
        //    //            ImageFlipX = true;
        //    //        else
        //    //            ImageFlipX = false;
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        ImageFlipX = false;
        //    //    }

        //    //    try
        //    //    {
        //    //        if (_ConfigEditImage_FlipY[Index] == "1")
        //    //            ImageFlipY = true;
        //    //        else
        //    //            ImageFlipY = false;
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        ImageFlipY = false;
        //    //    }

        //    //    try
        //    //    {
        //    //        txtBrightness.Text = Convert.ToInt32(_ConfigEditImage_Brightness[Index]).ToString();
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        txtBrightness.Text = "0";
        //    //    }

        //    //    try
        //    //    {
        //    //        txtContrast.Text = Convert.ToInt32(_ConfigEditImage_Contrast[Index]).ToString();
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        txtContrast.Text = "0";
        //    //    }

        //    //    try
        //    //    {
        //    //        txtResizeWidth.Text = Convert.ToInt32(_ConfigEditImage_ResizeWidth[Index]).ToString();
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        txtResizeWidth.Text = "0";
        //    //    }

        //    //    try
        //    //    {
        //    //        txtResizeHeight.Text = Convert.ToInt32(_ConfigEditImage_ResizeHeight[Index]).ToString();
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        txtResizeHeight.Text = "0";
        //    //    }

        //    //    SetStatusBarRotateText();
        //    //    SetStatusBarFlipText();
        //    //    SetStatusBarZoomText();

        //    //    DisplayImage();

        //    //    try
        //    //    {
        //    //        _IsCrop = true;
        //    //        ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.Rectangle;

        //    //        ImageBoxPreview.SelectionRegion = new RectangleF((float)Convert.ToDecimal(_ConfigEditImage_CropLeft[Index])
        //    //                                                        , (float)Convert.ToDecimal(_ConfigEditImage_CropTop[Index])
        //    //                                                        , (float)Convert.ToDecimal(_ConfigEditImage_CropWidth[Index])
        //    //                                                        , (float)Convert.ToDecimal(_ConfigEditImage_CropHeight[Index]));
        //    //    }
        //    //    catch (Exception)
        //    //    {
        //    //        _IsCrop = false;
        //    //        ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
        //    //        ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //    //    }

        //    //    toolButtonLoadConfig.Enabled = false;
        //    //    toolButtonSaveConfig.Enabled = false;
        //    //    toolButtonDeleteConfig.Enabled = true;
        //    //    toolButtonDefaultConfig.Enabled = true;
        //    //}
        //}

        //private void cboListConfig_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //ApplyConfig();
        //}

        //private void toolButtonLoadConfig_Click(object sender, EventArgs e)
        //{
        //    //ApplyConfig();
        //}

        //private void toolButtonDeleteConfig_Click(object sender, EventArgs e)
        //{
        //    //if (cboListConfig.SelectedIndex != -1 && cboListConfig.SelectedItem.ToString() != "None")
        //    //{
        //    //    if (MessageBox.Show("Are you sure to Delete Config '" + cboListConfig.SelectedItem.ToString() + "'?", "Confirm Delete Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //    //    {
        //    //        List<String> newConfig = new List<String>();

        //    //        for (Int32 Index = 0; Index < _ConfigEditImage_Name.Count; Index++)
        //    //        {
        //    //            if (_ConfigEditImage_Name[Index] != cboListConfig.SelectedItem.ToString() && _ConfigEditImage_Name[Index] != "None")
        //    //            {
        //    //                newConfig.Add(_ConfigEditImage_Name[Index] + "|"
        //    //                             + _ConfigEditImage_Rotate[Index] + "|"
        //    //                             + _ConfigEditImage_FlipX[Index] + "|"
        //    //                             + _ConfigEditImage_FlipY[Index] + "|"
        //    //                             + _ConfigEditImage_Brightness[Index] + "|"
        //    //                             + _ConfigEditImage_Contrast[Index] + "|"
        //    //                             + _ConfigEditImage_CropLeft[Index] + "|"
        //    //                             + _ConfigEditImage_CropTop[Index] + "|"
        //    //                             + _ConfigEditImage_CropWidth[Index] + "|"
        //    //                             + _ConfigEditImage_CropHeight[Index] + "|"
        //    //                             + _ConfigEditImage_ResizeWidth[Index] + "|"
        //    //                             + _ConfigEditImage_ResizeHeight[Index] + "|"
        //    //                             + _ConfigEditImage_Default[Index]);
        //    //            }
        //    //        }

        //    //        try
        //    //        {
        //    //            System.IO.File.WriteAllLines("EditImageTemplate.config", newConfig);

        //    //            MessageBox.Show("Delete Config Complete.", "Delete Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        //    //        }
        //    //        catch (Exception Ex)
        //    //        {
        //    //            MessageBox.Show("Delete Config Error: " + Ex.Message, "Delete Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //    //            return;
        //    //        }

        //    //        InitialDropdownListConfig();
        //    //    }
        //    //}
        //}

        //private void toolButtonDefaultConfig_Click(object sender, EventArgs e)
        //{
        //    //if (cboListConfig.SelectedIndex != -1)
        //    //{
        //    //    if (MessageBox.Show("Are you sure to Set Default Config '" + cboListConfig.SelectedItem.ToString() + "'?", "Confirm Set Default Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //    //    {
        //    //        List<String> newConfig = new List<String>();

        //    //        for (Int32 Index = 0; Index < _ConfigEditImage_Name.Count; Index++)
        //    //        {
        //    //            if (_ConfigEditImage_Name[Index] != "None")
        //    //            {
        //    //                String IsDefault = "0";
        //    //                if (_ConfigEditImage_Name[Index] == cboListConfig.SelectedItem.ToString())
        //    //                    IsDefault = "1";

        //    //                newConfig.Add(_ConfigEditImage_Name[Index] + "|"
        //    //                             + _ConfigEditImage_Rotate[Index] + "|"
        //    //                             + _ConfigEditImage_FlipX[Index] + "|"
        //    //                             + _ConfigEditImage_FlipY[Index] + "|"
        //    //                             + _ConfigEditImage_Brightness[Index] + "|"
        //    //                             + _ConfigEditImage_Contrast[Index] + "|"
        //    //                             + _ConfigEditImage_CropLeft[Index] + "|"
        //    //                             + _ConfigEditImage_CropTop[Index] + "|"
        //    //                             + _ConfigEditImage_CropWidth[Index] + "|"
        //    //                             + _ConfigEditImage_CropHeight[Index] + "|"
        //    //                             + _ConfigEditImage_ResizeWidth[Index] + "|"
        //    //                             + _ConfigEditImage_ResizeHeight[Index] + "|"
        //    //                             + IsDefault);
        //    //            }
        //    //        }

        //    //        try
        //    //        {
        //    //            System.IO.File.WriteAllLines("EditImageTemplate.config", newConfig);

        //    //            MessageBox.Show("Set Default Config Complete.", "Set Default Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        //    //        }
        //    //        catch (Exception Ex)
        //    //        {
        //    //            MessageBox.Show("Set Default Config Error: " + Ex.Message, "Set Default Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //    //            return;
        //    //        }

        //    //        InitialDropdownListConfig();
        //    //    }
        //    //}
        //}

        //private void toolButtonSaveConfig_Click(object sender, EventArgs e)
        //{
        //    //String _Rotate = ImageRotate.ToString();

        //    //String _FlipX = "0";
        //    //if (ImageFlipX)
        //    //    _FlipX = "1";

        //    //String _FlipY = "0";
        //    //if (ImageFlipY)
        //    //    _FlipY = "1";

        //    //String _Brightness = txtBrightness.Text;

        //    //String _Contrast = txtContrast.Text;

        //    //String _Left = ImageBoxPreview.SelectionRegion.X.ToString();

        //    //String _Top = ImageBoxPreview.SelectionRegion.Y.ToString();

        //    //String _Width = ImageBoxPreview.SelectionRegion.Width.ToString();

        //    //String _Height = ImageBoxPreview.SelectionRegion.Height.ToString();

        //    //String _ResizeWidth = txtResizeWidth.Text;

        //    //String _ResizeHeight = txtResizeHeight.Text;

        //    //SaveConfigForm _SaveConfigForm = new SaveConfigForm(_Rotate, _FlipX, _FlipY, _Brightness, _Contrast, _Left, _Top, _Width, _Height, _ResizeWidth, _ResizeHeight);
        //    //_SaveConfigForm.ShowDialog();

        //    //if (_SaveConfigForm._IsSaveConfigComplete)
        //    //{
        //    //    InitialDropdownListConfig();
        //    //}
        //}
    }
}
