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
    public partial class EditPerspective : Form
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

            foreach (Int32 ZoomLevelItem in ImageBoxPreview.ZoomLevels)
            {
                cboZoomImage.Items.Add(string.Format("{0}%", ZoomLevelItem));
            }

            cboZoomImage.SelectedItem = "100%";
        }

        public void SetStatusBarZoomText()
        {
            lblWebCameraZoom.Text = "Zoom: " + ImageBoxPreview.Zoom.ToString() + "%";
        }

        public EditPerspective(Image OriginalImage)
        {
            InitializeComponent();

            ImageBoxPreview.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);

            lblProgramName.Text = "DOPA Scan Document - Adjust Perspective Image";

            txtTL_X = new ToolStripNumericUpDown();
            NumericUpDown txtTL_X_Control = (NumericUpDown)txtTL_X.NumericUpDownControl;
            txtTL_X_Control.Minimum = -9999;
            txtTL_X_Control.Maximum = 9999;
            txtTL_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTL_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtTL_X.Padding = cboZoomImage.Padding;
            txtTL_X.Margin = cboZoomImage.Margin;
            txtTL_X.ValueChanged += txtTL_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(2, txtTL_X);

            txtTL_Y = new ToolStripNumericUpDown();
            NumericUpDown txtTL_Y_Control = (NumericUpDown)txtTL_Y.NumericUpDownControl;
            txtTL_Y_Control.Minimum = -9999;
            txtTL_Y_Control.Maximum = 9999;
            txtTL_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTL_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtTL_Y.Padding = cboZoomImage.Padding;
            txtTL_Y.Margin = cboZoomImage.Margin;
            txtTL_Y.ValueChanged += txtTL_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(4, txtTL_Y);

            txtTR_X = new ToolStripNumericUpDown();
            NumericUpDown txtTR_X_Control = (NumericUpDown)txtTR_X.NumericUpDownControl;
            txtTR_X_Control.Minimum = -9999;
            txtTR_X_Control.Maximum = 9999;
            txtTR_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTR_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtTR_X.Padding = cboZoomImage.Padding;
            txtTR_X.Margin = cboZoomImage.Margin;
            txtTR_X.ValueChanged += txtTR_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(7, txtTR_X);

            txtTR_Y = new ToolStripNumericUpDown();
            NumericUpDown txtTR_Y_Control = (NumericUpDown)txtTR_Y.NumericUpDownControl;
            txtTR_Y_Control.Minimum = -9999;
            txtTR_Y_Control.Maximum = 9999;
            txtTR_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtTR_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtTR_Y.Padding = cboZoomImage.Padding;
            txtTR_Y.Margin = cboZoomImage.Margin;
            txtTR_Y.ValueChanged += txtTR_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(9, txtTR_Y);

            txtBL_X = new ToolStripNumericUpDown();
            NumericUpDown txtBL_X_Control = (NumericUpDown)txtBL_X.NumericUpDownControl;
            txtBL_X_Control.Minimum = -9999;
            txtBL_X_Control.Maximum = 9999;
            txtBL_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBL_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtBL_X.Padding = cboZoomImage.Padding;
            txtBL_X.Margin = cboZoomImage.Margin;
            txtBL_X.ValueChanged += txtBL_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(12, txtBL_X);

            txtBL_Y = new ToolStripNumericUpDown();
            NumericUpDown txtBL_Y_Control = (NumericUpDown)txtBL_Y.NumericUpDownControl;
            txtBL_Y_Control.Minimum = -9999;
            txtBL_Y_Control.Maximum = 9999;
            txtBL_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBL_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtBL_Y.Padding = cboZoomImage.Padding;
            txtBL_Y.Margin = cboZoomImage.Margin;
            txtBL_Y.ValueChanged += txtBL_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(14, txtBL_Y);

            txtBR_X = new ToolStripNumericUpDown();
            NumericUpDown txtBR_X_Control = (NumericUpDown)txtBR_X.NumericUpDownControl;
            txtBR_X_Control.Minimum = -9999;
            txtBR_X_Control.Maximum = 9999;
            txtBR_X_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBR_X_Control.Size = cboZoomImage.ComboBox.Size;

            txtBR_X.Padding = cboZoomImage.Padding;
            txtBR_X.Margin = cboZoomImage.Margin;
            txtBR_X.ValueChanged += txtBR_X_ValueChanged;
            toolbarWebCameraTool.Items.Insert(17, txtBR_X);

            txtBR_Y = new ToolStripNumericUpDown();
            NumericUpDown txtBR_Y_Control = (NumericUpDown)txtBR_Y.NumericUpDownControl;
            txtBR_Y_Control.Minimum = -9999;
            txtBR_Y_Control.Maximum = 9999;
            txtBR_Y_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBR_Y_Control.Size = cboZoomImage.ComboBox.Size;

            txtBR_Y.Padding = cboZoomImage.Padding;
            txtBR_Y.Margin = cboZoomImage.Margin;
            txtBR_Y.ValueChanged += txtBR_Y_ValueChanged;
            toolbarWebCameraTool.Items.Insert(19, txtBR_Y);

            _OriginalImage = OriginalImage;

            ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            InitialDropdownListConfig();

            InitialDropdownZoom();
            ImageBoxPreview.Zoom = 100;

            //_PointCornerTL = ImageBoxPreview.PointToImage(new Point(50, 50));
            //_PointCornerTR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, 50));
            //_PointCornerBL = ImageBoxPreview.PointToImage(new Point(50, ImageBoxPreview.Image.Height - 50));
            //_PointCornerBR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50));

            //DisplaySelectionRegion();
        }

        private void toolButtonChangeCornerTL_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = true;
            _IsEditCornerTR = false;
            _IsEditCornerBL = false;
            _IsEditCornerBR = false;

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonChangeCornerTR_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = true;
            _IsEditCornerBL = false;
            _IsEditCornerBR = false;

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonChangeCornerBL_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = false;
            _IsEditCornerBL = true;
            _IsEditCornerBR = false;

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonChangeCornerBR_Click(object sender, EventArgs e)
        {
            _IsEditCornerTL = false;
            _IsEditCornerTR = false;
            _IsEditCornerBL = false;
            _IsEditCornerBR = true;

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtTL_X_ValueChanged(object sender, EventArgs e)
        {
            Int32 TL_X = 0;
            try
            {
                TL_X = Convert.ToInt32(txtTL_X.Text);
            }
            catch (Exception)
            {
                TL_X = 0;
            }

            _PointCornerTL.X = TL_X;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtTL_Y_ValueChanged(object sender, EventArgs e)
        {
            Int32 TL_Y = 0;
            try
            {
                TL_Y = Convert.ToInt32(txtTL_Y.Text);
            }
            catch (Exception)
            {
                TL_Y = 0;
            }

            _PointCornerTL.Y = TL_Y;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtTR_X_ValueChanged(object sender, EventArgs e)
        {
            Int32 TR_X = 0;
            try
            {
                TR_X = Convert.ToInt32(txtTR_X.Text);
            }
            catch (Exception)
            {
                TR_X = 0;
            }

            _PointCornerTR.X = TR_X;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtTR_Y_ValueChanged(object sender, EventArgs e)
        {
            Int32 TR_Y = 0;
            try
            {
                TR_Y = Convert.ToInt32(txtTR_Y.Text);
            }
            catch (Exception)
            {
                TR_Y = 0;
            }

            _PointCornerTR.Y = TR_Y;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtBL_X_ValueChanged(object sender, EventArgs e)
        {
            Int32 BL_X = 0;
            try
            {
                BL_X = Convert.ToInt32(txtBL_X.Text);
            }
            catch (Exception)
            {
                BL_X = 0;
            }

            _PointCornerBL.X = BL_X;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtBL_Y_ValueChanged(object sender, EventArgs e)
        {
            Int32 BL_Y = 0;
            try
            {
                BL_Y = Convert.ToInt32(txtBL_Y.Text);
            }
            catch (Exception)
            {
                BL_Y = 0;
            }

            _PointCornerBL.Y = BL_Y;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtBR_X_ValueChanged(object sender, EventArgs e)
        {
            Int32 BR_X = 0;
            try
            {
                BR_X = Convert.ToInt32(txtBR_X.Text);
            }
            catch (Exception)
            {
                BR_X = 0;
            }

            _PointCornerBR.X = BR_X;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtBR_Y_ValueChanged(object sender, EventArgs e)
        {
            Int32 BR_Y = 0;
            try
            {
                BR_Y = Convert.ToInt32(txtBR_Y.Text);
            }
            catch (Exception)
            {
                BR_Y = 0;
            }

            _PointCornerBR.Y = BR_Y;

            DisplaySelectionRegion();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void DisplaySelectionRegion()
        {
            ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            Graphics G = Graphics.FromImage(ImageBoxPreview.Image);

            using (var P = new Pen(Color.White, 8))
            {
                G.DrawPolygon(P, new Point[4] { _PointCornerTL, _PointCornerTR, _PointCornerBR, _PointCornerBL });
            };

            ImageBoxPreview.Invalidate();

            txtTL_X.Text = _PointCornerTL.X.ToString();
            txtTL_Y.Text = _PointCornerTL.Y.ToString();
            txtTR_X.Text = _PointCornerTR.X.ToString();
            txtTR_Y.Text = _PointCornerTR.Y.ToString();
            txtBL_X.Text = _PointCornerBL.X.ToString();
            txtBL_Y.Text = _PointCornerBL.Y.ToString();
            txtBR_X.Text = _PointCornerBR.X.ToString();
            txtBR_Y.Text = _PointCornerBR.Y.ToString();
        }

        private void ImageBoxPreview_MouseClick(object sender, MouseEventArgs e)
        {
            Boolean _IsEdit = false;

            if (_IsEditCornerTL)
            {
                _PointCornerTL = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerTL = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerTR)
            {
                _PointCornerTR = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerTR = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerBL)
            {
                _PointCornerBL = ImageBoxPreview.PointToImage(e.Location);
                _IsEditCornerBL = false;
                _IsEdit = true;
            }
            else if (_IsEditCornerBR)
            {
                _PointCornerBR = ImageBoxPreview.PointToImage(e.Location);
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
            ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

            ImageBoxPreview.Zoom = 100;

            _PointCornerTL = ImageBoxPreview.PointToImage(new Point(50, 50));
            _PointCornerTR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, 50));
            _PointCornerBL = ImageBoxPreview.PointToImage(new Point(50, ImageBoxPreview.Image.Height - 50));
            _PointCornerBR = ImageBoxPreview.PointToImage(new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50));

            DisplaySelectionRegion();
        }

        private void toolButtonActualSize_Click(object sender, EventArgs e)
        {
            ImageBoxPreview.ActualSize();
        }

        private void toolButtonZoomOut_Click(object sender, EventArgs e)
        {
            ImageBoxPreview.ZoomOut();
        }

        private void toolButtonZoomIn_Click(object sender, EventArgs e)
        {
            ImageBoxPreview.ZoomIn();
        }

        private void cboZoomImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZoomImage.SelectedIndex != -1)
                ImageBoxPreview.Zoom = Convert.ToInt32(cboZoomImage.SelectedItem.ToString().Replace("%", ""));
            SetStatusBarZoomText();
        }

        private void ImageBoxPreview_Zoomed(object sender, Cyotek.Windows.Forms.ImageBoxZoomEventArgs e)
        {
            cboZoomImage.SelectedItem = ImageBoxPreview.Zoom.ToString() + "%";
            SetStatusBarZoomText();
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

                ImageBoxPreview.Image = (System.Drawing.Image)_OriginalImage.Clone();

                MessageBox.Show("Adjust Perspective Successful", "Adjust Perspective", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                this.EditPerspectiveFormClosing(sender, e);
            }
        }

        private List<String> _ConfigPerspectiveImage_Name = new List<String>();
        private List<String> _ConfigPerspectiveImage_TL_X = new List<String>();
        private List<String> _ConfigPerspectiveImage_TL_Y = new List<String>();
        private List<String> _ConfigPerspectiveImage_TR_X = new List<String>();
        private List<String> _ConfigPerspectiveImage_TR_Y = new List<String>();
        private List<String> _ConfigPerspectiveImage_BL_X = new List<String>();
        private List<String> _ConfigPerspectiveImage_BL_Y = new List<String>();
        private List<String> _ConfigPerspectiveImage_BR_X = new List<String>();
        private List<String> _ConfigPerspectiveImage_BR_Y = new List<String>();
        private List<String> _ConfigPerspectiveImage_Default = new List<String>();
        private Int32 _ConfigPerspectiveImage_DefaultIndex = -1;

        private void InitialDropdownListConfig()
        {
            cboListConfig.Items.Clear();

            _ConfigPerspectiveImage_Name.Clear();
            _ConfigPerspectiveImage_TL_X.Clear();
            _ConfigPerspectiveImage_TL_Y.Clear();
            _ConfigPerspectiveImage_TR_X.Clear();
            _ConfigPerspectiveImage_TR_Y.Clear();
            _ConfigPerspectiveImage_BL_X.Clear();
            _ConfigPerspectiveImage_BL_Y.Clear();
            _ConfigPerspectiveImage_BR_X.Clear();
            _ConfigPerspectiveImage_BR_Y.Clear();
            _ConfigPerspectiveImage_Default.Clear();

            _ConfigPerspectiveImage_Name.Add("None");
            _ConfigPerspectiveImage_TL_X.Add("0");
            _ConfigPerspectiveImage_TL_Y.Add("0");
            _ConfigPerspectiveImage_TR_X.Add("0");
            _ConfigPerspectiveImage_TR_Y.Add("0");
            _ConfigPerspectiveImage_BL_X.Add("0");
            _ConfigPerspectiveImage_BL_Y.Add("0");
            _ConfigPerspectiveImage_BR_X.Add("0");
            _ConfigPerspectiveImage_BR_Y.Add("0");
            _ConfigPerspectiveImage_Default.Add("0");

            _ConfigPerspectiveImage_DefaultIndex = 0;

            String[] PerspectiveImageTemplate = System.IO.File.ReadAllLines("PerspectiveImageTemplate.config");

            Int32 TotalTemplate = 1;
            foreach (String PerspectiveImageTemplateItem in PerspectiveImageTemplate)
            {
                TotalTemplate++;

                String[] _SplitEditTemplateItem = PerspectiveImageTemplateItem.Split('|');

                if (_SplitEditTemplateItem.Length >= 10)
                {
                    _ConfigPerspectiveImage_Name.Add(_SplitEditTemplateItem[0]);
                    _ConfigPerspectiveImage_TL_X.Add(_SplitEditTemplateItem[1]);
                    _ConfigPerspectiveImage_TL_Y.Add(_SplitEditTemplateItem[2]);
                    _ConfigPerspectiveImage_TR_X.Add(_SplitEditTemplateItem[3]);
                    _ConfigPerspectiveImage_TR_Y.Add(_SplitEditTemplateItem[4]);
                    _ConfigPerspectiveImage_BL_X.Add(_SplitEditTemplateItem[5]);
                    _ConfigPerspectiveImage_BL_Y.Add(_SplitEditTemplateItem[6]);
                    _ConfigPerspectiveImage_BR_X.Add(_SplitEditTemplateItem[7]);
                    _ConfigPerspectiveImage_BR_Y.Add(_SplitEditTemplateItem[8]);
                    _ConfigPerspectiveImage_Default.Add(_SplitEditTemplateItem[9]);

                    if (_SplitEditTemplateItem[9] == "1")
                    {
                        _ConfigPerspectiveImage_DefaultIndex = TotalTemplate - 1;
                    }
                }
                else
                {
                    TotalTemplate = 1;

                    _ConfigPerspectiveImage_Name.Clear();
                    _ConfigPerspectiveImage_TL_X.Clear();
                    _ConfigPerspectiveImage_TL_Y.Clear();
                    _ConfigPerspectiveImage_TR_X.Clear();
                    _ConfigPerspectiveImage_TR_Y.Clear();
                    _ConfigPerspectiveImage_BL_X.Clear();
                    _ConfigPerspectiveImage_BL_Y.Clear();
                    _ConfigPerspectiveImage_BR_X.Clear();
                    _ConfigPerspectiveImage_BR_Y.Clear();
                    _ConfigPerspectiveImage_Default.Clear();

                    _ConfigPerspectiveImage_Name.Add("None");
                    _ConfigPerspectiveImage_TL_X.Add("0");
                    _ConfigPerspectiveImage_TL_Y.Add("0");
                    _ConfigPerspectiveImage_TR_X.Add("0");
                    _ConfigPerspectiveImage_TR_Y.Add("0");
                    _ConfigPerspectiveImage_BL_X.Add("0");
                    _ConfigPerspectiveImage_BL_Y.Add("0");
                    _ConfigPerspectiveImage_BR_X.Add("0");
                    _ConfigPerspectiveImage_BR_Y.Add("0");
                    _ConfigPerspectiveImage_Default.Add("0");

                    _ConfigPerspectiveImage_DefaultIndex = 0;

                    MessageBox.Show("Invalid Perspecive Image Config File", "Load Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                }
            }

            foreach (String ConfigEditImageNameItem in _ConfigPerspectiveImage_Name)
            {
                cboListConfig.Items.Add(ConfigEditImageNameItem);
            }

            cboListConfig.SelectedIndex = _ConfigPerspectiveImage_DefaultIndex;
        }

        private void ApplyConfig()
        {
            Int32 Index = cboListConfig.SelectedIndex;

            if (Index == -1)
            {
                _PointCornerTL = new Point(50, 50);
                _PointCornerTR = new Point(ImageBoxPreview.Image.Width - 50, 50);
                _PointCornerBL = new Point(50, ImageBoxPreview.Image.Height - 50);
                _PointCornerBR = new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50);

                DisplaySelectionRegion();

                toolButtonLoadConfig.Enabled = false;
                toolButtonSaveConfig.Enabled = false;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = false;
            }
            else if (Index == 0)
            {
                _PointCornerTL = new Point(50, 50);
                _PointCornerTR = new Point(ImageBoxPreview.Image.Width - 50, 50);
                _PointCornerBL = new Point(50, ImageBoxPreview.Image.Height - 50);
                _PointCornerBR = new Point(ImageBoxPreview.Image.Width - 50, ImageBoxPreview.Image.Height - 50);

                DisplaySelectionRegion();

                toolButtonLoadConfig.Enabled = false;
                toolButtonSaveConfig.Enabled = false;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = true;
            }
            else
            {
                Int32 TL_X = 0;
                Int32 TL_Y = 0;
                Int32 TR_X = 0;
                Int32 TR_Y = 0;
                Int32 BL_X = 0;
                Int32 BL_Y = 0;
                Int32 BR_X = 0;
                Int32 BR_Y = 0;

                try
                {
                    TL_X = Convert.ToInt32(_ConfigPerspectiveImage_TL_X[Index]);
                }
                catch (Exception)
                {
                    TL_X = 0;
                }

                try
                {
                    TL_Y = Convert.ToInt32(_ConfigPerspectiveImage_TL_Y[Index]);
                }
                catch (Exception)
                {
                    TL_Y = 0;
                }

                try
                {
                    TR_X = Convert.ToInt32(_ConfigPerspectiveImage_TR_X[Index]);
                }
                catch (Exception)
                {
                    TR_X = 0;
                }

                try
                {
                    TR_Y = Convert.ToInt32(_ConfigPerspectiveImage_TR_Y[Index]);
                }
                catch (Exception)
                {
                    TR_Y = 0;
                }

                try
                {
                    BL_X = Convert.ToInt32(_ConfigPerspectiveImage_BL_X[Index]);
                }
                catch (Exception)
                {
                    BL_X = 0;
                }

                try
                {
                    BL_Y = Convert.ToInt32(_ConfigPerspectiveImage_BL_Y[Index]);
                }
                catch (Exception)
                {
                    BL_Y = 0;
                }

                try
                {
                    BR_X = Convert.ToInt32(_ConfigPerspectiveImage_BR_X[Index]);
                }
                catch (Exception)
                {
                    BR_X = 0;
                }

                try
                {
                    BR_Y = Convert.ToInt32(_ConfigPerspectiveImage_BR_Y[Index]);
                }
                catch (Exception)
                {
                    BR_Y = 0;
                }

                _PointCornerTL = new Point(TL_X, TL_Y);
                _PointCornerTR = new Point(TR_X, TR_Y);
                _PointCornerBL = new Point(BL_X, BL_Y);
                _PointCornerBR = new Point(BR_X, BR_Y);

                DisplaySelectionRegion();

                toolButtonLoadConfig.Enabled = false;
                toolButtonSaveConfig.Enabled = false;
                toolButtonDeleteConfig.Enabled = true;
                toolButtonDefaultConfig.Enabled = true;
            }
        }

        private void cboListConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyConfig();
        }

        private void toolButtonLoadConfig_Click(object sender, EventArgs e)
        {
            ApplyConfig();
        }

        private void toolButtonDeleteConfig_Click(object sender, EventArgs e)
        {
            if (cboListConfig.SelectedIndex != -1 && cboListConfig.SelectedItem.ToString() != "None")
            {
                if (MessageBox.Show("Are you sure to Delete Config '" + cboListConfig.SelectedItem.ToString() + "'?", "Confirm Delete Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<String> newConfig = new List<String>();

                    for (Int32 Index = 0; Index < _ConfigPerspectiveImage_Name.Count; Index++)
                    {
                        if (_ConfigPerspectiveImage_Name[Index] != cboListConfig.SelectedItem.ToString() && _ConfigPerspectiveImage_Name[Index] != "None")
                        {
                            newConfig.Add(_ConfigPerspectiveImage_Name[Index] + "|"
                                         + _ConfigPerspectiveImage_TL_X[Index] + "|"
                                         + _ConfigPerspectiveImage_TL_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_TR_X[Index] + "|"
                                         + _ConfigPerspectiveImage_TR_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_BL_X[Index] + "|"
                                         + _ConfigPerspectiveImage_BL_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_BR_X[Index] + "|"
                                         + _ConfigPerspectiveImage_BR_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_Default[Index]);
                        }
                    }

                    try
                    {
                        System.IO.File.WriteAllLines("PerspectiveImageTemplate.config", newConfig);

                        MessageBox.Show("Delete Config Complete.", "Delete Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Delete Config Error: " + Ex.Message, "Delete Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    InitialDropdownListConfig();
                }
            }
        }

        private void toolButtonDefaultConfig_Click(object sender, EventArgs e)
        {
            if (cboListConfig.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure to Set Default Config '" + cboListConfig.SelectedItem.ToString() + "'?", "Confirm Set Default Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<String> newConfig = new List<String>();

                    for (Int32 Index = 0; Index < _ConfigPerspectiveImage_Name.Count; Index++)
                    {
                        if (_ConfigPerspectiveImage_Name[Index] != "None")
                        {
                            String IsDefault = "0";
                            if (_ConfigPerspectiveImage_Name[Index] == cboListConfig.SelectedItem.ToString())
                                IsDefault = "1";

                            newConfig.Add(_ConfigPerspectiveImage_Name[Index] + "|"
                                         + _ConfigPerspectiveImage_TL_X[Index] + "|"
                                         + _ConfigPerspectiveImage_TL_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_TR_X[Index] + "|"
                                         + _ConfigPerspectiveImage_TR_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_BL_X[Index] + "|"
                                         + _ConfigPerspectiveImage_BL_Y[Index] + "|"
                                         + _ConfigPerspectiveImage_BR_X[Index] + "|"
                                         + _ConfigPerspectiveImage_BR_Y[Index] + "|"
                                         + IsDefault);
                        }
                    }

                    try
                    {
                        System.IO.File.WriteAllLines("PerspectiveImageTemplate.config", newConfig);

                        MessageBox.Show("Set Default Config Complete.", "Set Default Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Set Default Config Error: " + Ex.Message, "Set Default Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    InitialDropdownListConfig();
                }
            }
        }

        private void toolButtonSaveConfig_Click(object sender, EventArgs e)
        {
            String _TL_X = _PointCornerTL.X.ToString();
            String _TL_Y = _PointCornerTL.Y.ToString();
            String _TR_X = _PointCornerTR.X.ToString();
            String _TR_Y = _PointCornerTR.Y.ToString();
            String _BL_X = _PointCornerBL.X.ToString();
            String _BL_Y = _PointCornerBL.Y.ToString();
            String _BR_X = _PointCornerBR.X.ToString();
            String _BR_Y = _PointCornerBR.Y.ToString();

            SaveConfigPerspectiveForm _SaveConfigPerspectiveForm = new SaveConfigPerspectiveForm(_TL_X, _TL_Y, _TR_X, _TR_Y, _BL_X, _BL_Y, _BR_X, _BR_Y);
            _SaveConfigPerspectiveForm.ShowDialog();

            if (_SaveConfigPerspectiveForm._IsSaveConfigComplete)
            {
                InitialDropdownListConfig();
            }
        }
    }
}
