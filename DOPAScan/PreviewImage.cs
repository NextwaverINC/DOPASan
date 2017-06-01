using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge;
using AForge.Math;
using AForge.Controls;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Formats;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DOPAScan
{
    public partial class PreviewImage : Form
    {
        private List<Int32> _ZoomLevel = new List<Int32> { 10, 15, 20, 25, 30, 40, 50, 60, 80, 100, 120, 150, 200, 250, 300, 400, 500 };

        private EditPerspective _EditPerspective;

        public enum PreviewMode
        {
            View, Edit
        }

        private Boolean _IsCrop;

        private ToolStripNumericUpDown txtBrightness;

        private ToolStripNumericUpDown txtContrast;

        private ToolStripNumericUpDown txtResizeWidth;

        private ToolStripNumericUpDown txtResizeHeight;

        public System.Drawing.Image _OriginalImage;
        public System.Drawing.Image _FinalImage;

        private Int32 ImageRotate = 0;

        private Boolean ImageFlipX = false;

        private Boolean ImageFlipY = false;

        private List<String> _ConfigEditImage_Name = new List<String>();
        private List<String> _ConfigEditImage_Rotate = new List<String>();
        private List<String> _ConfigEditImage_FlipX = new List<String>();
        private List<String> _ConfigEditImage_FlipY = new List<String>();
        private List<String> _ConfigEditImage_Brightness = new List<String>();
        private List<String> _ConfigEditImage_Contrast = new List<String>();
        private List<String> _ConfigEditImage_CropLeft = new List<String>();
        private List<String> _ConfigEditImage_CropTop = new List<String>();
        private List<String> _ConfigEditImage_CropWidth = new List<String>();
        private List<String> _ConfigEditImage_CropHeight = new List<String>();
        private List<String> _ConfigEditImage_ResizeWidth = new List<String>();
        private List<String> _ConfigEditImage_ResizeHeight = new List<String>();
        private List<String> _ConfigEditImage_Default = new List<String>();
        private Int32 _ConfigEditImage_DefaultIndex = -1;

        private void InitialDropdownListConfig()
        {
            cboListConfig.Items.Clear();

            _ConfigEditImage_Name.Clear();
            _ConfigEditImage_Rotate.Clear();
            _ConfigEditImage_FlipX.Clear();
            _ConfigEditImage_FlipY.Clear();
            _ConfigEditImage_Brightness.Clear();
            _ConfigEditImage_Contrast.Clear();
            _ConfigEditImage_CropLeft.Clear();
            _ConfigEditImage_CropTop.Clear();
            _ConfigEditImage_CropWidth.Clear();
            _ConfigEditImage_CropHeight.Clear();
            _ConfigEditImage_ResizeWidth.Clear();
            _ConfigEditImage_ResizeHeight.Clear();
            _ConfigEditImage_Default.Clear();

            _ConfigEditImage_Name.Add("None");
            _ConfigEditImage_Rotate.Add("0");
            _ConfigEditImage_FlipX.Add("0");
            _ConfigEditImage_FlipY.Add("0");
            _ConfigEditImage_Brightness.Add("0");
            _ConfigEditImage_Contrast.Add("0");
            _ConfigEditImage_CropLeft.Add("0");
            _ConfigEditImage_CropTop.Add("0");
            _ConfigEditImage_CropWidth.Add("0");
            _ConfigEditImage_CropHeight.Add("0");
            _ConfigEditImage_ResizeWidth.Add("0");
            _ConfigEditImage_ResizeHeight.Add("0");
            _ConfigEditImage_Default.Add("0");

            _ConfigEditImage_DefaultIndex = 0;

            String[] EditImageTemplate = System.IO.File.ReadAllLines("EditImageTemplate.config");

            Int32 TotalTemplate = 1;
            foreach (String EditImageTemplateItem in EditImageTemplate)
            {
                TotalTemplate++;

                String[] _SplitEditTemplateItem = EditImageTemplateItem.Split('|');

                if (_SplitEditTemplateItem.Length >= 13)
                {
                    _ConfigEditImage_Name.Add(_SplitEditTemplateItem[0]);
                    _ConfigEditImage_Rotate.Add(_SplitEditTemplateItem[1]);
                    _ConfigEditImage_FlipX.Add(_SplitEditTemplateItem[2]);
                    _ConfigEditImage_FlipY.Add(_SplitEditTemplateItem[3]);
                    _ConfigEditImage_Brightness.Add(_SplitEditTemplateItem[4]);
                    _ConfigEditImage_Contrast.Add(_SplitEditTemplateItem[5]);
                    _ConfigEditImage_CropLeft.Add(_SplitEditTemplateItem[6]);
                    _ConfigEditImage_CropTop.Add(_SplitEditTemplateItem[7]);
                    _ConfigEditImage_CropWidth.Add(_SplitEditTemplateItem[8]);
                    _ConfigEditImage_CropHeight.Add(_SplitEditTemplateItem[9]);
                    _ConfigEditImage_ResizeWidth.Add(_SplitEditTemplateItem[10]);
                    _ConfigEditImage_ResizeHeight.Add(_SplitEditTemplateItem[11]);
                    _ConfigEditImage_Default.Add(_SplitEditTemplateItem[12]);

                    if (_SplitEditTemplateItem[12] == "1")
                    {
                        _ConfigEditImage_DefaultIndex = TotalTemplate - 1;
                    }
                }
                else
                {
                    TotalTemplate = 1;

                    _ConfigEditImage_Name.Clear();
                    _ConfigEditImage_Rotate.Clear();
                    _ConfigEditImage_FlipX.Clear();
                    _ConfigEditImage_FlipY.Clear();
                    _ConfigEditImage_Brightness.Clear();
                    _ConfigEditImage_Contrast.Clear();
                    _ConfigEditImage_CropLeft.Clear();
                    _ConfigEditImage_CropTop.Clear();
                    _ConfigEditImage_CropWidth.Clear();
                    _ConfigEditImage_CropHeight.Clear();
                    _ConfigEditImage_ResizeWidth.Clear();
                    _ConfigEditImage_ResizeHeight.Clear();
                    _ConfigEditImage_Default.Clear();

                    _ConfigEditImage_Name.Add("None");
                    _ConfigEditImage_Rotate.Add("0");
                    _ConfigEditImage_FlipX.Add("0");
                    _ConfigEditImage_FlipY.Add("0");
                    _ConfigEditImage_Brightness.Add("0");
                    _ConfigEditImage_Contrast.Add("0");
                    _ConfigEditImage_CropLeft.Add("0");
                    _ConfigEditImage_CropTop.Add("0");
                    _ConfigEditImage_CropWidth.Add("0");
                    _ConfigEditImage_CropHeight.Add("0");
                    _ConfigEditImage_ResizeWidth.Add("0");
                    _ConfigEditImage_ResizeHeight.Add("0");
                    _ConfigEditImage_Default.Add("0");

                    _ConfigEditImage_DefaultIndex = 0;

                    MessageBox.Show("Invalid Edit Image Config File", "Load Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                }
            }

            foreach (String ConfigEditImageNameItem in _ConfigEditImage_Name)
            {
                cboListConfig.Items.Add(ConfigEditImageNameItem);
            }

            cboListConfig.SelectedIndex = _ConfigEditImage_DefaultIndex;
        }

        private void ApplyConfig()
        {
            Int32 Index = cboListConfig.SelectedIndex;

            if (Index == -1)
            {
                _IsCrop = false;
                ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
                ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);

                txtResizeWidth.Text = ImageBoxPreview.Image.Width.ToString();
                txtResizeHeight.Text = ImageBoxPreview.Image.Height.ToString();

                toolButtonLoadConfig.Enabled = false;
                toolButtonSaveConfig.Enabled = false;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = false;
            }
            else if (Index == 0)
            {
                ImageRotate = 0;
                ImageFlipX = false;
                ImageFlipY = false;
                txtBrightness.Text = "0";
                txtContrast.Text = "0";
                _IsCrop = false;
                ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
                ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);

                txtResizeWidth.Text = ImageBoxPreview.Image.Width.ToString();
                txtResizeHeight.Text = ImageBoxPreview.Image.Height.ToString();

                toolButtonLoadConfig.Enabled = false;
                toolButtonSaveConfig.Enabled = false;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = true;
            }
            else
            {
                try
                {
                    ImageRotate = Convert.ToInt32(_ConfigEditImage_Rotate[Index]);
                }
                catch (Exception)
                {
                    ImageRotate = 0;
                }

                try
                {
                    if (_ConfigEditImage_FlipX[Index] == "1")
                        ImageFlipX = true;
                    else
                        ImageFlipX = false;
                }
                catch (Exception)
                {
                    ImageFlipX = false;
                }

                try
                {
                    if (_ConfigEditImage_FlipY[Index] == "1")
                        ImageFlipY = true;
                    else
                        ImageFlipY = false;
                }
                catch (Exception)
                {
                    ImageFlipY = false;
                }

                try
                {
                    txtBrightness.Text = Convert.ToInt32(_ConfigEditImage_Brightness[Index]).ToString();
                }
                catch (Exception)
                {
                    txtBrightness.Text = "0";
                }

                try
                {
                    txtContrast.Text = Convert.ToInt32(_ConfigEditImage_Contrast[Index]).ToString();
                }
                catch (Exception)
                {
                    txtContrast.Text = "0";
                }

                try
                {
                    txtResizeWidth.Text = Convert.ToInt32(_ConfigEditImage_ResizeWidth[Index]).ToString();
                }
                catch (Exception)
                {
                    txtResizeWidth.Text = "0";
                }

                try
                {
                    txtResizeHeight.Text = Convert.ToInt32(_ConfigEditImage_ResizeHeight[Index]).ToString();
                }
                catch (Exception)
                {
                    txtResizeHeight.Text = "0";
                }

                SetStatusBarRotateText();
                SetStatusBarFlipText();
                SetStatusBarZoomText();

                DisplayImage();

                try
                {
                    _IsCrop = true;
                    ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.Rectangle;

                    ImageBoxPreview.SelectionRegion = new RectangleF((float)Convert.ToDecimal(_ConfigEditImage_CropLeft[Index])
                                                                    , (float)Convert.ToDecimal(_ConfigEditImage_CropTop[Index])
                                                                    , (float)Convert.ToDecimal(_ConfigEditImage_CropWidth[Index])
                                                                    , (float)Convert.ToDecimal(_ConfigEditImage_CropHeight[Index]));
                }
                catch (Exception)
                {
                    _IsCrop = false;
                    ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;
                    ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);
                }

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

                    for (Int32 Index = 0; Index < _ConfigEditImage_Name.Count; Index++)
                    {
                        if (_ConfigEditImage_Name[Index] != cboListConfig.SelectedItem.ToString() && _ConfigEditImage_Name[Index] != "None")
                        {
                            newConfig.Add(_ConfigEditImage_Name[Index] + "|"
                                         + _ConfigEditImage_Rotate[Index] + "|"
                                         + _ConfigEditImage_FlipX[Index] + "|"
                                         + _ConfigEditImage_FlipY[Index] + "|"
                                         + _ConfigEditImage_Brightness[Index] + "|"
                                         + _ConfigEditImage_Contrast[Index] + "|"
                                         + _ConfigEditImage_CropLeft[Index] + "|"
                                         + _ConfigEditImage_CropTop[Index] + "|"
                                         + _ConfigEditImage_CropWidth[Index] + "|"
                                         + _ConfigEditImage_CropHeight[Index] + "|"
                                         + _ConfigEditImage_ResizeWidth[Index] + "|"
                                         + _ConfigEditImage_ResizeHeight[Index] + "|"
                                         + _ConfigEditImage_Default[Index]);
                        }
                    }

                    try
                    {
                        System.IO.File.WriteAllLines("EditImageTemplate.config", newConfig);

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

                    for (Int32 Index = 0; Index < _ConfigEditImage_Name.Count; Index++)
                    {
                        if (_ConfigEditImage_Name[Index] != "None")
                        {
                            String IsDefault = "0";
                            if (_ConfigEditImage_Name[Index] == cboListConfig.SelectedItem.ToString())
                                IsDefault = "1";

                            newConfig.Add(_ConfigEditImage_Name[Index] + "|"
                                         + _ConfigEditImage_Rotate[Index] + "|"
                                         + _ConfigEditImage_FlipX[Index] + "|"
                                         + _ConfigEditImage_FlipY[Index] + "|"
                                         + _ConfigEditImage_Brightness[Index] + "|"
                                         + _ConfigEditImage_Contrast[Index] + "|"
                                         + _ConfigEditImage_CropLeft[Index] + "|"
                                         + _ConfigEditImage_CropTop[Index] + "|"
                                         + _ConfigEditImage_CropWidth[Index] + "|"
                                         + _ConfigEditImage_CropHeight[Index] + "|"
                                         + _ConfigEditImage_ResizeWidth[Index] + "|"
                                         + _ConfigEditImage_ResizeHeight[Index] + "|"
                                         + IsDefault);
                        }
                    }

                    try
                    {
                        System.IO.File.WriteAllLines("EditImageTemplate.config", newConfig);

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
            String _Rotate = ImageRotate.ToString();

            String _FlipX = "0";
            if (ImageFlipX)
                _FlipX = "1";

            String _FlipY = "0";
            if (ImageFlipY)
                _FlipY = "1";

            String _Brightness = txtBrightness.Text;

            String _Contrast = txtContrast.Text;

            String _Left = ImageBoxPreview.SelectionRegion.X.ToString();

            String _Top = ImageBoxPreview.SelectionRegion.Y.ToString();

            String _Width = ImageBoxPreview.SelectionRegion.Width.ToString();

            String _Height = ImageBoxPreview.SelectionRegion.Height.ToString();

            String _ResizeWidth = txtResizeWidth.Text;

            String _ResizeHeight = txtResizeHeight.Text;

            SaveConfigForm _SaveConfigForm = new SaveConfigForm(_Rotate, _FlipX, _FlipY, _Brightness, _Contrast, _Left, _Top, _Width, _Height, _ResizeWidth, _ResizeHeight);
            _SaveConfigForm.ShowDialog();

            if (_SaveConfigForm._IsSaveConfigComplete)
            {
                InitialDropdownListConfig();
            }
        }

        private void InitialDropdownZoom()
        {
            cboZoomImage.Items.Clear();

            foreach (Int32 ZoomLevelItem in ImageBoxPreview.ZoomLevels)
            {
                cboZoomImage.Items.Add(string.Format("{0}%", ZoomLevelItem));
            }

            cboZoomImage.SelectedItem = "100%";
        }

        public PreviewImage(PreviewMode PreviewMode, System.Drawing.Image PreviewImage)
        {
            InitializeComponent();

            ImageBoxPreview.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);

            cboListConfig.ComboBox.MinimumSize = new Size(150, cboListConfig.ComboBox.Height);

            _IsCrop = false;

            txtBrightness = new ToolStripNumericUpDown();
            NumericUpDown txtBrightness_Control = (NumericUpDown)txtBrightness.NumericUpDownControl;
            txtBrightness_Control.Minimum = -255;
            txtBrightness_Control.Maximum = 255;
            txtBrightness_Control.Value = 0;
            txtBrightness_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBrightness_Control.Size = cboZoomImage.ComboBox.Size;

            txtBrightness.Padding = cboZoomImage.Padding;
            txtBrightness.Margin = cboZoomImage.Margin;
            txtBrightness.ValueChanged += txtBrightness_ValueChanged;
            toolbarWebCameraTool.Items.Insert(11, txtBrightness);


            txtContrast = new ToolStripNumericUpDown();
            NumericUpDown txtContrast_Control = (NumericUpDown)txtContrast.NumericUpDownControl;
            txtContrast_Control.Minimum = -127;
            txtContrast_Control.Maximum = 127;
            txtContrast_Control.Value = 0;
            txtContrast_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtContrast_Control.Size = cboZoomImage.ComboBox.Size;

            txtContrast.Padding = cboZoomImage.Padding;
            txtContrast.Margin = cboZoomImage.Margin;
            txtContrast.ValueChanged += txtContrast_ValueChanged;
            toolbarWebCameraTool.Items.Insert(16, txtContrast);

            txtResizeWidth = new ToolStripNumericUpDown();
            NumericUpDown txtResizeWidth_Control = (NumericUpDown)txtResizeWidth.NumericUpDownControl;
            txtResizeWidth_Control.Minimum = 0;
            txtResizeWidth_Control.Maximum = 9999;
            txtResizeWidth_Control.Value = 0;
            txtResizeWidth_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtResizeWidth_Control.Size = cboZoomImage.ComboBox.Size;

            txtResizeWidth.Padding = cboZoomImage.Padding;
            txtResizeWidth.Margin = cboZoomImage.Margin;
            txtResizeWidth.ValueChanged += txtResizeWidth_ValueChanged;
            toolbarWebCameraTool.Items.Insert(22, txtResizeWidth);

            txtResizeHeight = new ToolStripNumericUpDown();
            NumericUpDown txtResizeHeight_Control = (NumericUpDown)txtResizeHeight.NumericUpDownControl;
            txtResizeHeight_Control.Minimum = 0;
            txtResizeHeight_Control.Maximum = 9999;
            txtResizeWidth_Control.Value = 0;
            txtResizeHeight_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtResizeHeight_Control.Size = cboZoomImage.ComboBox.Size;

            txtResizeHeight.Padding = cboZoomImage.Padding;
            txtResizeHeight.Margin = cboZoomImage.Margin;
            txtResizeHeight.ValueChanged += txtResizeHeight_ValueChanged;
            toolbarWebCameraTool.Items.Insert(24, txtResizeHeight);



            ImageBoxPreview.SelectionColor = Color.FromArgb(0, 255, 255, 255);
            ImageBoxPreview.MinimumSelectionSize = new Size(200, 200);


            if (PreviewMode == PreviewMode.View)
            {
                lblProgramName.Text = "DOPA Scan Document - Preview Image";

                toolButtonCrop.Visible = false;
                toolButtonSaveImage.Visible = false;
            }
            else
            {
                lblProgramName.Text = "DOPA Scan Document - Edit Image";

                toolButtonCrop.Visible = true;
                toolButtonSaveImage.Visible = true;
            }


            _OriginalImage = PreviewImage;
            _FinalImage = (System.Drawing.Image)_OriginalImage.Clone();

            ImageBoxPreview.Image = (System.Drawing.Image)_FinalImage.Clone();

            InitialDropdownListConfig();

            InitialDropdownZoom();
            ImageBoxPreview.Zoom = 100;

            DisplayImage();
        }

        private void DisplayImage()
        {
            _FinalImage = (System.Drawing.Image)_OriginalImage.Clone();

            if (ImageRotate == 0)
            {
                if (ImageFlipX)
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                }
                else
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                }
            }
            else if (ImageRotate == 90)
            {
                if (ImageFlipX)
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    }
                }
                else
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate90FlipY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                }
            }
            else if (ImageRotate == 180)
            {
                if (ImageFlipX)
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    }
                }
                else
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }
                }
            }
            else if (ImageRotate == 270)
            {
                if (ImageFlipX)
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                    }
                }
                else
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate270FlipY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                }
            }
            else
            {
                if (ImageFlipX)
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    }
                    else
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                }
                else
                {
                    if (ImageFlipY)
                    {
                        _FinalImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                }

                System.Drawing.Image newRotateImage = (System.Drawing.Image)_FinalImage.Clone();
                try
                {
                    RotateBilinear RotateImage = new RotateBilinear(360 - ImageRotate);
                    RotateImage.FillColor = Color.Transparent;
                    newRotateImage = RotateImage.Apply((Bitmap)_FinalImage);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Rotate Image Error: " + Ex.Message, "Rotate Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                _FinalImage.Dispose();
                _FinalImage = (System.Drawing.Image)newRotateImage.Clone();
            }

            System.Drawing.Image newImage = (System.Drawing.Image)_FinalImage;

            Int32 BrightnessValue = 0;
            try
            {
                if (txtBrightness.Text != null && txtBrightness.Text != "")
                    BrightnessValue = Convert.ToInt32(txtBrightness.Text);
                else
                    BrightnessValue = 0;
            }
            catch (Exception)
            {
                BrightnessValue = 0;
            }

            BrightnessCorrection BrightnessImage = new BrightnessCorrection();
            BrightnessImage.AdjustValue = BrightnessValue;
            newImage = BrightnessImage.Apply((Bitmap)newImage);

            Int32 ContrastValue = 0;
            try
            {
                if (txtContrast.Text != null && txtContrast.Text != "")
                    ContrastValue = Convert.ToInt32(txtContrast.Text);
                else
                    ContrastValue = 0;
            }
            catch (Exception)
            {
                ContrastValue = 0;
            }

            ContrastCorrection ContrastImage = new ContrastCorrection();
            ContrastImage.Factor = ContrastValue;
            newImage = ContrastImage.Apply((Bitmap)newImage);

            _FinalImage = (System.Drawing.Image)newImage.Clone();

            ImageBoxPreview.Image = (System.Drawing.Image)_FinalImage.Clone();

            try
            {
                Double ImageWidthResolution = ImageBoxPreview.Image.HorizontalResolution;
                Double ImageHeightResolution = ImageBoxPreview.Image.VerticalResolution;
                Double ImageWidthPx = ImageBoxPreview.Image.Width;
                Double ImageHeightPx = ImageBoxPreview.Image.Height;
                Double ImageWidth = ImageWidthPx * 2.54 / ImageWidthResolution;
                Double ImageHeight = ImageHeightPx * 2.54 / ImageHeightResolution;

                lblWebCameraImagePixel.Text = "Image Size: " + ImageWidthPx.ToString("#,0") + " x " + ImageHeightPx.ToString("#,0") + " px";
                lblWebCameraImagePixel.Text += ", " + ImageWidth.ToString("#,0.0") + " x " + ImageHeight.ToString("#,0.0") + " cm";
            }
            catch (Exception)
            {
                lblWebCameraImagePixel.Text = "Image Size: 0 x 0 px";
                lblWebCameraImagePixel.Text += ", 0 x 0 cm";
            }
        }

        public void SetStatusBarRotateText()
        {
            if (ImageRotate == 0)
                lblWebCameraRotate.Text = "Rotate: None";
            else
                lblWebCameraRotate.Text = "Rotate: " + ImageRotate.ToString();
        }

        public void SetStatusBarFlipText()
        {
            if (ImageFlipX)
                if (ImageFlipY)
                    lblWebCameraFlip.Text = "Filp: Both";
                else
                    lblWebCameraFlip.Text = "Filp: Horizontal";
            else
                if (ImageFlipY)
                lblWebCameraFlip.Text = "Filp: Vertical";
            else
                lblWebCameraFlip.Text = "Filp: None";
        }

        public void SetStatusBarZoomText()
        {
            lblWebCameraZoom.Text = "Zoom: " + ImageBoxPreview.Zoom.ToString() + "%";
        }

        private void toolButtonRotateCCW_Click(object sender, EventArgs e)
        {
            if (ImageRotate == 0)
                ImageRotate = 359;
            else
                ImageRotate -= 1;
            SetStatusBarRotateText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonRotateCW_Click(object sender, EventArgs e)
        {
            if (ImageRotate == 359)
                ImageRotate = 0;
            else
                ImageRotate += 1;
            SetStatusBarRotateText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonRotateCCW90_Click(object sender, EventArgs e)
        {
            if (ImageRotate % 90 == 0)
            {
                if (ImageRotate == 0)
                    ImageRotate = 270;
                else
                    ImageRotate -= 90;
            }
            else
            {
                if (ImageRotate > 0 && ImageRotate < 90)
                    ImageRotate = 0;
                else if (ImageRotate > 90 && ImageRotate < 180)
                    ImageRotate = 90;
                else if (ImageRotate > 180 && ImageRotate < 270)
                    ImageRotate = 180;
                else if (ImageRotate > 270 && ImageRotate < 360)
                    ImageRotate = 270;
            }
            SetStatusBarRotateText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonRotateCW90_Click(object sender, EventArgs e)
        {
            if (ImageRotate % 90 == 0)
            {
                if (ImageRotate == 270)
                    ImageRotate = 0;
                else
                    ImageRotate += 90;
            }
            else
            {
                if (ImageRotate > 0 && ImageRotate < 90)
                    ImageRotate = 90;
                else if (ImageRotate > 90 && ImageRotate < 180)
                    ImageRotate = 180;
                else if (ImageRotate > 180 && ImageRotate < 270)
                    ImageRotate = 270;
                else if (ImageRotate > 270 && ImageRotate < 360)
                    ImageRotate = 0;
            }
            SetStatusBarRotateText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonFlipX_Click(object sender, EventArgs e)
        {
            if (ImageFlipX)
                ImageFlipX = false;
            else
                ImageFlipX = true;
            SetStatusBarFlipText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonFlipY_Click(object sender, EventArgs e)
        {
            if (ImageFlipY)
                ImageFlipY = false;
            else
                ImageFlipY = true;
            SetStatusBarFlipText();

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
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

        private void toolButtonBrightnessActual_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtBrightness.NumericUpDownControl).Value != 0)
            {
                toolButtonLoadConfig.Enabled = true;
                toolButtonSaveConfig.Enabled = true;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = false;
            }

            ((NumericUpDown)txtBrightness.NumericUpDownControl).Value = 0;

            DisplayImage();
        }

        private void toolButtonBrightnessDecrease_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtBrightness.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness.NumericUpDownControl).Minimum)
            {
                ((NumericUpDown)txtBrightness.NumericUpDownControl).Value -= 1;
            }

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonBrightnessIncrease_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtBrightness.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness.NumericUpDownControl).Maximum)
            {
                ((NumericUpDown)txtBrightness.NumericUpDownControl).Value += 1;
            }

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtBrightness_ValueChanged(object sender, EventArgs e)
        {
            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtResizeWidth_ValueChanged(object sender, EventArgs e)
        {
            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtResizeHeight_ValueChanged(object sender, EventArgs e)
        {
            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonContrastActual_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtContrast.NumericUpDownControl).Value != 0)
            {
                toolButtonLoadConfig.Enabled = true;
                toolButtonSaveConfig.Enabled = true;
                toolButtonDeleteConfig.Enabled = false;
                toolButtonDefaultConfig.Enabled = false;
            }

            ((NumericUpDown)txtContrast.NumericUpDownControl).Value = 0;

            DisplayImage();
        }

        private void toolButtonContrastDecrease_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtContrast.NumericUpDownControl).Value != ((NumericUpDown)txtContrast.NumericUpDownControl).Minimum)
            {
                ((NumericUpDown)txtContrast.NumericUpDownControl).Value -= 1;
            }

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void toolButtonContrastIncrease_Click(object sender, EventArgs e)
        {
            if (((NumericUpDown)txtContrast.NumericUpDownControl).Value != ((NumericUpDown)txtContrast.NumericUpDownControl).Maximum)
            {
                ((NumericUpDown)txtContrast.NumericUpDownControl).Value += 1;
            }

            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        private void txtContrast_ValueChanged(object sender, EventArgs e)
        {
            DisplayImage();

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }

        public event EventHandler PreviewImageFormClosing;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.PreviewImageFormClosing(sender, e);

            //this.Close();
        }

        private void toolButtonReset_Click(object sender, EventArgs e)
        {
            ImageRotate = 0;
            ImageFlipX = false;
            ImageFlipY = false;
            ImageBoxPreview.ActualSize();
            ((NumericUpDown)txtBrightness.NumericUpDownControl).Value = 0;
            ((NumericUpDown)txtContrast.NumericUpDownControl).Value = 0;

            SetStatusBarRotateText();
            SetStatusBarFlipText();
            SetStatusBarZoomText();

            DisplayImage();
        }

        private void toolButtonSaveImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to save image?", "Confirm Save Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                _OriginalImage = (System.Drawing.Image)ImageBoxPreview.Image.Clone();
                
                if (_IsCrop)
                {
                    if (!(ImageBoxPreview.SelectionRegion.Top == 0
                            && ImageBoxPreview.SelectionRegion.Left == 0
                            && ImageBoxPreview.SelectionRegion.Width == 0
                            && ImageBoxPreview.SelectionRegion.Height == 0)
                        && (ImageBoxPreview.SelectionRegion.Top != 0
                            || ImageBoxPreview.SelectionRegion.Left != 0
                            || ImageBoxPreview.SelectionRegion.Width != ImageBoxPreview.Image.Width
                            || ImageBoxPreview.SelectionRegion.Height != ImageBoxPreview.Image.Height))
                    {
                        if (MessageBox.Show("Do you want to crop image?", "Confirm crop Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            System.Drawing.Image ScanImage = (System.Drawing.Image)ImageBoxPreview.Image.Clone();
                            _OriginalImage = ((Bitmap)ScanImage).Clone(ImageBoxPreview.SelectionRegion, ScanImage.PixelFormat);
                        }
                    }

                    _IsCrop = false;

                    ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;

                    ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);
                }

                Int32 ResizeWidth = 0;
                try
                {
                    if (txtResizeWidth.Text != null && txtResizeWidth.Text != "")
                        ResizeWidth = Convert.ToInt32(txtResizeWidth.Text);
                    else
                        ResizeWidth = ImageBoxPreview.Image.Width;
                }
                catch (Exception)
                {
                    ResizeWidth = ImageBoxPreview.Image.Width;
                }

                Int32 ResizeHeight = 0;
                try
                {
                    if (txtResizeHeight.Text != null && txtResizeHeight.Text != "")
                        ResizeHeight = Convert.ToInt32(txtResizeHeight.Text);
                    else
                        ResizeHeight = ImageBoxPreview.Image.Height;
                }
                catch (Exception)
                {
                    ResizeHeight = ImageBoxPreview.Image.Height;
                }

                ResizeBicubic ResizeImage = new ResizeBicubic(ResizeWidth, ResizeHeight);
                _OriginalImage = (System.Drawing.Image)ResizeImage.Apply((Bitmap)_OriginalImage).Clone();

                _FinalImage = (System.Drawing.Image)_OriginalImage.Clone();

                ImageBoxPreview.Image = (System.Drawing.Image)_FinalImage.Clone();

                MessageBox.Show("Save Image Successful", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                ImageRotate = 0;
                ImageFlipX = false;
                ImageFlipY = false;
                ImageBoxPreview.ActualSize();
                ((NumericUpDown)txtBrightness.NumericUpDownControl).Value = 0;
                ((NumericUpDown)txtContrast.NumericUpDownControl).Value = 0;

                SetStatusBarRotateText();
                SetStatusBarFlipText();
                SetStatusBarZoomText();

                DisplayImage();
            }
        }

        private void toolButtonCrop_Click(object sender, EventArgs e)
        {
            if (_IsCrop)
            {
                if (ImageBoxPreview.SelectionRegion.Top != 0
                    || ImageBoxPreview.SelectionRegion.Left != 0
                    || ImageBoxPreview.SelectionRegion.Width != ImageBoxPreview.Image.Width
                    || ImageBoxPreview.SelectionRegion.Height != ImageBoxPreview.Image.Height)
                {
                    if (MessageBox.Show("Do you want to crop image?", "Confirm crop Image", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        System.Drawing.Image ScanImage = (System.Drawing.Image)ImageBoxPreview.Image.Clone();
                        _FinalImage = ((Bitmap)ScanImage).Clone(ImageBoxPreview.SelectionRegion, ScanImage.PixelFormat);
                    }
                }

                ImageBoxPreview.Image = (System.Drawing.Image)_FinalImage.Clone();

                _IsCrop = false;

                ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.None;

                ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, 0, 0);
            }
            else
            {
                _IsCrop = true;

                ImageBoxPreview.SelectionMode = Cyotek.Windows.Forms.ImageBoxSelectionMode.Rectangle;

                ImageBoxPreview.SelectionRegion = new RectangleF(0, 0, ImageBoxPreview.Image.Width, ImageBoxPreview.Image.Height);
            }
        }

        private void toolButtonPerspective_Click(object sender, EventArgs e)
        {
            _EditPerspective = new EditPerspective(_OriginalImage);
            _EditPerspective.EditPerspectiveFormClosing += _EditPerspective_EditPerspectiveFormClosing;
            _EditPerspective.ShowDialog();
        }

        private void _EditPerspective_EditPerspectiveFormClosing(object sender, EventArgs e)
        {
            _OriginalImage = _EditPerspective._OriginalImage;

            DisplayImage();

            _EditPerspective.Dispose();
            _EditPerspective = null;
            GC.Collect();
        }

        private void ImageBoxPreview_SelectionRegionChanged(object sender, EventArgs e)
        {
            try
            {
                Double ImageWidthResolution = ImageBoxPreview.Image.HorizontalResolution;
                Double ImageHeightResolution = ImageBoxPreview.Image.VerticalResolution;
                Double ImageWidthPx = ImageBoxPreview.SelectionRegion.Width;
                Double ImageHeightPx = ImageBoxPreview.SelectionRegion.Height;
                Double ImageWidth = ImageWidthPx * 2.54 / ImageWidthResolution;
                Double ImageHeight = ImageHeightPx * 2.54 / ImageHeightResolution;

                lblWebCameraSelectPixel.Text = "Select Size: " + ImageWidthPx.ToString("#,0") + " x " + ImageHeightPx.ToString("#,0") + " px";
                lblWebCameraSelectPixel.Text += ", " + ImageWidth.ToString("#,0.0") + " x " + ImageHeight.ToString("#,0.0") + " cm";
            }
            catch (Exception)
            {
                lblWebCameraSelectPixel.Text = "Select Size: 0 x 0 px";
                lblWebCameraSelectPixel.Text += ", 0 x 0 cm";
            }

            toolButtonLoadConfig.Enabled = true;
            toolButtonSaveConfig.Enabled = true;
            toolButtonDeleteConfig.Enabled = false;
            toolButtonDefaultConfig.Enabled = false;
        }
    }
}
