using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
    public partial class DOPAScanDoc : Form
    {
        private List<Int32> _ZoomLevel = new List<Int32> { 10, 15, 20, 25, 30, 40, 50, 60, 80, 100, 120, 150, 200, 250, 300, 400, 500 };

        private PreviewImage _PreviewImage;

        //private ToolStripNumericUpDown txtBrightness_L;
        //private ToolStripNumericUpDown txtBrightness_R;

        //private ToolStripNumericUpDown txtContrast_L;
        //private ToolStripNumericUpDown txtContrast_R;

        private String _LogonUserID = "";
        private String _LogonUserDispName = "";

        private VideoCaptureDevice WebCameraSource_L;
        private VideoCaptureDevice WebCameraSource_R;

        //private Int32 ImageRotate_L = 0;
        //private Int32 ImageRotate_R = 0;

        //private Boolean ImageFlipX_L = false;
        //private Boolean ImageFlipX_R = false;

        //private Boolean ImageFlipY_L = false;
        //private Boolean ImageFlipY_R = false;

        public DataTable dtBookNo;
        public DataTable dtPageNo_L;
        public DataTable dtPageNo_R;
        public DataTable dtVersionNo_L;
        public DataTable dtVersionNo_R;

        //private void InitialDropdownZoom()
        //{
        //    cboZoomImage_L.Items.Clear();
        //    cboZoomImage_R.Items.Clear();

        //    foreach (Int32 ZoomLevelItem in WebCameraImage_L.ZoomLevels)
        //    {
        //        cboZoomImage_L.Items.Add(string.Format("{0}%", ZoomLevelItem));
        //    }

        //    foreach (Int32 ZoomLevelItem in WebCameraImage_R.ZoomLevels)
        //    {
        //        cboZoomImage_R.Items.Add(string.Format("{0}%", ZoomLevelItem));
        //    }

        //    cboZoomImage_L.SelectedItem = "100%";
        //    cboZoomImage_R.SelectedItem = "100%";
        //}

        private byte[] ImageToByteArray(System.Drawing.Image imageData)
        {
            using (var Mem = new MemoryStream())
            {
                imageData.Save(Mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Mem.ToArray();
            }
        }

        private void InitialDropdownBookNo()
        {
            DOPAGun_WS.GRB_WebService DOPAGun = null;
            DataTable dtGunBook = null;

            try
            {
                cboBookNo.ComboBox.DataSource = null;
                cboBookNo.Items.Clear();

                DOPAGun = new DOPAGun_WS.GRB_WebService();

                dtBookNo = new DataTable();
                dtBookNo.Columns.Add("BookNo", typeof(String));
                dtBookNo.Columns.Add("BookNoDisp", typeof(String));
                dtBookNo.Columns.Add("BookVersion", typeof(String));
                dtBookNo.Columns.Add("BookYear", typeof(String));
                dtBookNo.Columns.Add("GunRegIDStart", typeof(String));
                dtBookNo.Columns.Add("GunRegIDEnd", typeof(String));
                dtBookNo.Columns.Add("PageTotal", typeof(String));

                DataRow dRow = dtBookNo.NewRow();
                dRow["BookNo"] = "-";
                dRow["BookNoDisp"] = "-- Book No --";
                dRow["BookVersion"] = "-";
                dRow["BookYear"] = "-";
                dRow["GunRegIDStart"] = "-";
                dRow["GunRegIDEnd"] = "-";
                dRow["PageTotal"] = "-";
                dtBookNo.Rows.Add(dRow);

                dtGunBook = DOPAGun.GetBook(0);

                if (dtGunBook != null && dtGunBook.Rows.Count > 0)
                {
                    foreach (DataRow GunBookItem in dtGunBook.Rows)
                    {
                        dRow = dtBookNo.NewRow();
                        dRow["BookNo"] = GunBookItem["BookNo"];
                        dRow["BookNoDisp"] = GunBookItem["BookNo"] + " (" + GunBookItem["BookYear"] + ")";
                        dRow["BookYear"] = GunBookItem["BookYear"];
                        dRow["GunRegIDStart"] = GunBookItem["GunRegIDStart"];
                        dRow["GunRegIDEnd"] = GunBookItem["GunRegIDEnd"];
                        dRow["PageTotal"] = GunBookItem["PageTotal"];

                        dtBookNo.Rows.Add(dRow);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dtGunBook != null)
                {
                    dtGunBook.Dispose();
                    dtGunBook = null;
                }

                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }

            cboBookNo.ComboBox.DataSource = dtBookNo;
            cboBookNo.ComboBox.DisplayMember = "BookNoDisp";
            cboBookNo.ComboBox.ValueMember = "BookNo";
            cboBookNo.ComboBox.Refresh();

            cboBookNo.SelectedIndex = 0;
        }

        private void InitialDropdownPageNo_L(String BookNo)
        {
            DOPAGun_WS.GRB_WebService DOPAGun = null;
            DataTable dtGunPage = null;

            try
            {
                cboPageNo_L.DataSource = null;
                cboPageNo_L.Items.Clear();

                DOPAGun = new DOPAGun_WS.GRB_WebService();

                dtPageNo_L = new DataTable();
                dtPageNo_L.Columns.Add("BookNo", typeof(String));
                dtPageNo_L.Columns.Add("PageNo", typeof(String));
                dtPageNo_L.Columns.Add("PageNoDisp", typeof(String));
                dtPageNo_L.Columns.Add("PageVersion", typeof(String));
                dtPageNo_L.Columns.Add("ImgUrl", typeof(String));

                DataRow dRow = dtPageNo_L.NewRow();
                dRow["BookNo"] = "-";
                dRow["PageNo"] = "-";
                dRow["PageNoDisp"] = "- Select -";
                dRow["PageVersion"] = "-";
                dRow["ImgUrl"] = "-";
                dtPageNo_L.Rows.Add(dRow);

                if (BookNo != "-")
                {
                    dtGunPage = DOPAGun.GetPage(Convert.ToInt32(BookNo), 0);

                    if (dtGunPage != null && dtGunPage.Rows.Count > 0)
                    {
                        foreach (DataRow GunPageItem in dtGunPage.Rows)
                        {
                            dRow = dtPageNo_L.NewRow();
                            dRow["BookNo"] = GunPageItem["BookNo"];
                            dRow["PageNo"] = GunPageItem["PageNo"];
                            dRow["PageNoDisp"] = GunPageItem["PageNo"];
                            dRow["PageVersion"] = GunPageItem["PageVersion"];
                            dRow["ImgUrl"] = GunPageItem["ImgUrl"];

                            dtPageNo_L.Rows.Add(dRow);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dtGunPage != null)
                {
                    dtGunPage.Dispose();
                    dtGunPage = null;
                }

                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }

            cboPageNo_L.DataSource = dtPageNo_L;
            cboPageNo_L.DisplayMember = "PageNoDisp";
            cboPageNo_L.ValueMember = "PageNo";
            cboPageNo_L.Refresh();
        }

        private void InitialDropdownPageNo_R(String BookNo)
        {
            DOPAGun_WS.GRB_WebService DOPAGun = null;
            DataTable dtGunPage = null;

            try
            {
                cboPageNo_R.DataSource = null;
                cboPageNo_R.Items.Clear();

                DOPAGun = new DOPAGun_WS.GRB_WebService();

                dtPageNo_R = new DataTable();
                dtPageNo_R.Columns.Add("BookNo", typeof(String));
                dtPageNo_R.Columns.Add("PageNo", typeof(String));
                dtPageNo_R.Columns.Add("PageNoDisp", typeof(String));
                dtPageNo_R.Columns.Add("PageVersion", typeof(String));
                dtPageNo_R.Columns.Add("ImgUrl", typeof(String));

                DataRow dRow = dtPageNo_R.NewRow();
                dRow["BookNo"] = "-";
                dRow["PageNo"] = "-";
                dRow["PageNoDisp"] = "- Select -";
                dRow["PageVersion"] = "-";
                dRow["ImgUrl"] = "-";
                dtPageNo_R.Rows.Add(dRow);

                if (BookNo != "-")
                {
                    dtGunPage = DOPAGun.GetPage(Convert.ToInt32(BookNo), 0);

                    if (dtGunPage != null && dtGunPage.Rows.Count > 0)
                    {
                        foreach (DataRow GunPageItem in dtGunPage.Rows)
                        {
                            dRow = dtPageNo_R.NewRow();
                            dRow["BookNo"] = GunPageItem["BookNo"];
                            dRow["PageNo"] = GunPageItem["PageNo"];
                            dRow["PageNoDisp"] = GunPageItem["PageNo"];
                            dRow["PageVersion"] = GunPageItem["PageVersion"];
                            dRow["ImgUrl"] = GunPageItem["ImgUrl"];

                            dtPageNo_R.Rows.Add(dRow);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dtGunPage != null)
                {
                    dtGunPage.Dispose();
                    dtGunPage = null;
                }

                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }

            cboPageNo_R.DataSource = dtPageNo_R;
            cboPageNo_R.DisplayMember = "PageNoDisp";
            cboPageNo_R.ValueMember = "PageNo";
            cboPageNo_R.Refresh();
        }

        private void InitialDropdownVersionNo_L(String BookNo, String PageNo)
        {
            DOPAGun_WS.GRB_WebService DOPAGun = null;
            DataTable dtGunPageVersion = null;

            try
            {
                cboVersionNo_L.DataSource = null;
                cboVersionNo_L.Items.Clear();

                DOPAGun = new DOPAGun_WS.GRB_WebService();

                dtVersionNo_L = new DataTable();
                dtVersionNo_L.Columns.Add("BookNo", typeof(String));
                dtVersionNo_L.Columns.Add("PageNo", typeof(String));
                dtVersionNo_L.Columns.Add("PageVersion", typeof(String));
                dtVersionNo_L.Columns.Add("PageVersionDisp", typeof(String));
                dtVersionNo_L.Columns.Add("ImgUrl", typeof(String));

                DataRow dRow = dtVersionNo_L.NewRow();

                if (PageNo != "-")
                {
                    dtGunPageVersion = DOPAGun.GetPageVersion(Convert.ToInt32(BookNo), Convert.ToInt32(PageNo), 0);

                    if (dtGunPageVersion != null && dtGunPageVersion.Rows.Count > 0)
                    {
                        Int32 RowIndex = 0;
                        foreach (DataRow GunPageVersionItem in dtGunPageVersion.Rows)
                        {
                            dRow = dtVersionNo_L.NewRow();
                            dRow["BookNo"] = GunPageVersionItem["BookNo"];
                            dRow["PageNo"] = GunPageVersionItem["PageNo"];
                            dRow["PageVersion"] = GunPageVersionItem["PageVersion"];

                            if (RowIndex == 0)
                            {
                                DataRow dRowNew = dtVersionNo_L.NewRow();
                                dRowNew["BookNo"] = "-";
                                dRowNew["PageNo"] = "-";
                                dRowNew["PageVersion"] = (Convert.ToInt32(GunPageVersionItem["PageVersion"]) + 1).ToString();
                                dRowNew["PageVersionDisp"] = (Convert.ToInt32(GunPageVersionItem["PageVersion"]) + 1).ToString() + " (New)";
                                dRowNew["ImgUrl"] = "-";
                                dtVersionNo_L.Rows.Add(dRowNew);

                                dRow["PageVersionDisp"] = GunPageVersionItem["PageVersion"] + " (Current)";
                            }
                            else
                                dRow["PageVersionDisp"] = GunPageVersionItem["PageVersion"] + " (History)";

                            dRow["ImgUrl"] = GunPageVersionItem["ImgUrl"];

                            dtVersionNo_L.Rows.Add(dRow);

                            RowIndex++;

                            break;
                        }
                    }
                }
                else
                {
                    dRow["BookNo"] = "-";
                    dRow["PageNo"] = "-";
                    dRow["PageVersion"] = "-";
                    dRow["PageVersionDisp"] = "- Select -";
                    dRow["ImgUrl"] = "-";
                    dtVersionNo_L.Rows.Add(dRow);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dtGunPageVersion != null)
                {
                    dtGunPageVersion.Dispose();
                    dtGunPageVersion = null;
                }

                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }

            cboVersionNo_L.DataSource = dtVersionNo_L;
            cboVersionNo_L.DisplayMember = "PageVersionDisp";
            cboVersionNo_L.ValueMember = "PageVersion";
            cboVersionNo_L.Refresh();

            if (cboVersionNo_L.Items.Count > 1)
                if (cboDefaultPageVersion.SelectedItem.ToString() == "Current")
                    cboVersionNo_L.SelectedIndex = 1;
                else
                    cboVersionNo_L.SelectedIndex = 0;
            else
                cboVersionNo_L.SelectedIndex = 0;
        }

        private void InitialDropdownVersionNo_R(String BookNo, String PageNo)
        {
            DOPAGun_WS.GRB_WebService DOPAGun = null;
            DataTable dtGunPageVersion = null;

            try
            {
                cboVersionNo_R.DataSource = null;
                cboVersionNo_R.Items.Clear();

                DOPAGun = new DOPAGun_WS.GRB_WebService();

                dtVersionNo_R = new DataTable();
                dtVersionNo_R.Columns.Add("BookNo", typeof(String));
                dtVersionNo_R.Columns.Add("PageNo", typeof(String));
                dtVersionNo_R.Columns.Add("PageVersion", typeof(String));
                dtVersionNo_R.Columns.Add("PageVersionDisp", typeof(String));
                dtVersionNo_R.Columns.Add("ImgUrl", typeof(String));

                DataRow dRow = dtVersionNo_R.NewRow();

                if (PageNo != "-")
                {
                    dtGunPageVersion = DOPAGun.GetPageVersion(Convert.ToInt32(BookNo), Convert.ToInt32(PageNo), 0);

                    if (dtGunPageVersion != null && dtGunPageVersion.Rows.Count > 0)
                    {
                        Int32 RowIndex = 0;
                        foreach (DataRow GunPageVersionItem in dtGunPageVersion.Rows)
                        {
                            dRow = dtVersionNo_R.NewRow();
                            dRow["BookNo"] = GunPageVersionItem["BookNo"];
                            dRow["PageNo"] = GunPageVersionItem["PageNo"];
                            dRow["PageVersion"] = GunPageVersionItem["PageVersion"];

                            if (RowIndex == 0)
                            {
                                DataRow dRowNew = dtVersionNo_R.NewRow();
                                dRowNew["BookNo"] = "-";
                                dRowNew["PageNo"] = "-";
                                dRowNew["PageVersion"] = (Convert.ToInt32(GunPageVersionItem["PageVersion"]) + 1).ToString();
                                dRowNew["PageVersionDisp"] = (Convert.ToInt32(GunPageVersionItem["PageVersion"]) + 1).ToString() + " (New)";
                                dRowNew["ImgUrl"] = "-";
                                dtVersionNo_R.Rows.Add(dRowNew);

                                dRow["PageVersionDisp"] = GunPageVersionItem["PageVersion"] + " (Current)";
                            }
                            else
                                dRow["PageVersionDisp"] = GunPageVersionItem["PageVersion"] + " (History)";

                            dRow["ImgUrl"] = GunPageVersionItem["ImgUrl"];

                            dtVersionNo_R.Rows.Add(dRow);

                            RowIndex++;

                            break;
                        }
                    }
                }
                else
                {
                    dRow["BookNo"] = "-";
                    dRow["PageNo"] = "-";
                    dRow["PageVersion"] = "-";
                    dRow["PageVersionDisp"] = "- Select -";
                    dRow["ImgUrl"] = "-";
                    dtVersionNo_R.Rows.Add(dRow);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dtGunPageVersion != null)
                {
                    dtGunPageVersion.Dispose();
                    dtGunPageVersion = null;
                }

                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }

            cboVersionNo_R.DataSource = dtVersionNo_R;
            cboVersionNo_R.DisplayMember = "PageVersionDisp";
            cboVersionNo_R.ValueMember = "PageVersion";
            cboVersionNo_R.Refresh();

            if (cboVersionNo_R.Items.Count > 1)
                if (cboDefaultPageVersion.SelectedItem.ToString() == "Current")
                    cboVersionNo_R.SelectedIndex = 1;
                else
                    cboVersionNo_R.SelectedIndex = 0;
            else
                cboVersionNo_R.SelectedIndex = 0;
        }

        //public void SetStatusBarRotateText_L()
        //{
        //    if (ImageRotate_L == 0)
        //        lblWebCameraRotate_L.Text = "Rotate: None";
        //    else
        //        lblWebCameraRotate_L.Text = "Rotate: " + ImageRotate_L.ToString();
        //}

        //public void SetStatusBarRotateText_R()
        //{
        //    if (ImageRotate_R == 0)
        //        lblWebCameraRotate_R.Text = "Rotate: None";
        //    else
        //        lblWebCameraRotate_R.Text = "Rotate: " + ImageRotate_R.ToString();
        //}

        //public void SetStatusBarFlipText_L()
        //{
        //    if (ImageFlipX_L)
        //        if (ImageFlipY_L)
        //            lblWebCameraFlip_L.Text = "Filp: Both";
        //        else
        //            lblWebCameraFlip_L.Text = "Filp: Horizontal";
        //    else
        //        if (ImageFlipY_L)
        //        lblWebCameraFlip_L.Text = "Filp: Vertical";
        //    else
        //        lblWebCameraFlip_L.Text = "Filp: None";
        //}

        //public void SetStatusBarFlipText_R()
        //{
        //    if (ImageFlipX_R)
        //        if (ImageFlipY_R)
        //            lblWebCameraFlip_R.Text = "Filp: Both";
        //        else
        //            lblWebCameraFlip_R.Text = "Filp: Horizontal";
        //    else
        //        if (ImageFlipY_R)
        //        lblWebCameraFlip_R.Text = "Filp: Vertical";
        //    else
        //        lblWebCameraFlip_R.Text = "Filp: None";
        //}

        //public void SetStatusBarZoomText_L()
        //{
        //    lblWebCameraZoom_L.Text = "Zoom: " + WebCameraImage_L.Zoom.ToString() + "%";
        //}

        //public void SetStatusBarZoomText_R()
        //{
        //    lblWebCameraZoom_R.Text = "Zoom: " + WebCameraImage_R.Zoom.ToString() + "%";
        //}

        public DOPAScanDoc()
        {
            InitializeComponent();

            //toolbarAdjust_L.Location = new System.Drawing.Point(0, 0);
            //toolbarRotate_L.Location = new System.Drawing.Point(0, 0);
            //toolbarZoom_L.Location = new System.Drawing.Point(0, 0);

            //toolbarAdjust_R.Location = new System.Drawing.Point(0, 0);
            //toolbarRotate_R.Location = new System.Drawing.Point(0, 0);
            //toolbarZoom_R.Location = new System.Drawing.Point(0, 0);

            cboAutoIncrementPageNo.SelectedItem = "Yes";
            cboDefaultPageVersion.SelectedItem = "Current";

            //WebCameraImage_L.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);
            //WebCameraImage_R.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);

            PageImage_L.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);
            PageImage_R.ZoomLevels = new Cyotek.Windows.Forms.ZoomLevelCollection(_ZoomLevel);

            //lblNewPageNo_L.Visible = false;
            //txtNewPageNo_L.Visible = false;

            //lblNewPageNo_R.Visible = false;
            //txtNewPageNo_R.Visible = false;

            //cboWebCameraSource_L.ComboBox.MinimumSize = new Size(300, 26);
            //cboWebCameraSource_R.ComboBox.MinimumSize = new Size(300, 26);

            //txtBrightness_L = new ToolStripNumericUpDown();
            //NumericUpDown txtBrightness_L_Control = (NumericUpDown)txtBrightness_L.NumericUpDownControl;
            //txtBrightness_L_Control.Minimum = -255;
            //txtBrightness_L_Control.Maximum = 255;
            //txtBrightness_L_Control.Value = 0;
            //txtBrightness_L_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtBrightness_L_Control.Size = cboZoomImage_L.ComboBox.Size;

            //txtBrightness_L.Padding = cboZoomImage_L.Padding;
            //txtBrightness_L.Margin = cboZoomImage_L.Margin;
            //toolbarAdjust_L.Items.Insert(3, txtBrightness_L);


            //txtBrightness_R = new ToolStripNumericUpDown();
            //NumericUpDown txtBrightness_R_Control = (NumericUpDown)txtBrightness_R.NumericUpDownControl;
            //txtBrightness_R_Control.Minimum = -255;
            //txtBrightness_R_Control.Maximum = 255;
            //txtBrightness_R_Control.Value = 0;
            //txtBrightness_R_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtBrightness_R_Control.Size = cboZoomImage_R.ComboBox.Size;

            //txtBrightness_R.Padding = cboZoomImage_L.Padding;
            //txtBrightness_R.Margin = cboZoomImage_L.Margin;
            //toolbarAdjust_R.Items.Insert(3, txtBrightness_R);


            //txtContrast_L = new ToolStripNumericUpDown();
            //NumericUpDown txtContrast_L_Control = (NumericUpDown)txtContrast_L.NumericUpDownControl;
            //txtContrast_L_Control.Minimum = -127;
            //txtContrast_L_Control.Maximum = 127;
            //txtContrast_L_Control.Value = 0;
            //txtContrast_L_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtContrast_L_Control.Size = cboZoomImage_L.ComboBox.Size;

            //txtContrast_L.Padding = cboZoomImage_L.Padding;
            //txtContrast_L.Margin = cboZoomImage_L.Margin;
            //toolbarAdjust_L.Items.Insert(8, txtContrast_L);


            //txtContrast_R = new ToolStripNumericUpDown();
            //NumericUpDown txtContrast_R_Control = (NumericUpDown)txtContrast_R.NumericUpDownControl;
            //txtContrast_R_Control.Minimum = -127;
            //txtContrast_R_Control.Maximum = 127;
            //txtContrast_R_Control.Value = 0;
            //txtContrast_R_Control.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txtContrast_R_Control.Size = cboZoomImage_R.ComboBox.Size;

            //txtContrast_R.Padding = cboZoomImage_R.Padding;
            //txtContrast_R.Margin = cboZoomImage_R.Margin;
            //toolbarAdjust_R.Items.Insert(8, txtContrast_R);

            txtPassword.TextBox.PasswordChar = '•';

            lblUsernameDisp.Visible = false;
            lblUsernameDisp.Text = "";

            lblUsername.Visible = true;
            txtUsername.Visible = true;
            txtUsername.Text = "";
            txtUsername.TextBox.MinimumSize = new Size(100, 26);

            lblPassword.Visible = true;
            txtPassword.Visible = true;
            txtPassword.Text = "";
            txtPassword.TextBox.MinimumSize = new Size(100, 26);

            toolButtonLogin.Text = "Login";

            DOPAScanDoc.CheckForIllegalCrossThreadCalls = false;

            InitialDropdownBookNo();

            //Int32 DeviceNo = 1;

            //cboWebCameraSource_L.Items.Clear();
            //cboWebCameraSource_R.Items.Clear();
            //cboWebCameraSource_L.Items.Add("-- Select Video Device --");
            //cboWebCameraSource_R.Items.Add("-- Select Video Device --");
            //foreach (FilterInfo WebCameraDeviceItem in WebCameraUtil.WebCameraDeviceList)
            //{
            //    cboWebCameraSource_L.Items.Add(DeviceNo.ToString() + ". " + WebCameraDeviceItem.Name);
            //    cboWebCameraSource_R.Items.Add(DeviceNo.ToString() + ". " + WebCameraDeviceItem.Name);

            //    DeviceNo++;
            //}

            //InitialDropdownZoom();
            //WebCameraImage_L.Zoom = 100;
            //WebCameraImage_R.Zoom = 100;

            //SetStatusBarRotateText_L();
            //SetStatusBarRotateText_R();

            //SetStatusBarFlipText_L();
            //SetStatusBarFlipText_R();

            //SetStatusBarZoomText_L();
            //SetStatusBarZoomText_R();

            //WebCameraImage_L.SelectionColor = Color.FromArgb(0, 255, 255, 255);
            //WebCameraImage_L.MinimumSelectionSize = new Size(200, 200);

            //WebCameraImage_R.SelectionColor = Color.FromArgb(0, 255, 255, 255);
            //WebCameraImage_R.MinimumSelectionSize = new Size(200, 200);

            //if (cboWebCameraSource_L.Items.Count - 1 == 0)
            //{
            //    cboWebCameraSource_L.SelectedIndex = 0;
            //    cboWebCameraSource_R.SelectedIndex = 0;
            //}
            //else if (cboWebCameraSource_L.Items.Count - 1 == 1)
            //{
            //    cboWebCameraSource_L.SelectedIndex = 1;
            //    cboWebCameraSource_R.SelectedIndex = 0;
            //}
            //else
            //{
            //    cboWebCameraSource_L.SelectedIndex = 1;
            //    cboWebCameraSource_R.SelectedIndex = 2;
            //}
        }

        private async void WaitLittleBit()
        {
            await Task.Delay(100);
        }

        //private void WebCameraSource_L_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    Bitmap WebCameraImage = (Bitmap)eventArgs.Frame.Clone();
        //    //Bitmap WebCameraImage = WebCameraUtil.GetNewFrameImage(ref eventArgs);

        //    if (ImageRotate_L == 0)
        //    {
        //        if (ImageFlipX_L)
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_L == 90)
        //    {
        //        if (ImageFlipX_L)
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_L == 180)
        //    {
        //        if (ImageFlipX_L)
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_L == 270)
        //    {
        //        if (ImageFlipX_L)
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (ImageFlipX_L)
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_L)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //            }
        //        }

        //        RotateBilinear RotateImage = new RotateBilinear(360 - ImageRotate_L);
        //        RotateImage.FillColor = Color.Transparent;
        //        Bitmap newRotateImage = RotateImage.Apply(WebCameraImage);

        //        WebCameraImage.Dispose();
        //        WebCameraImage = newRotateImage;
        //    }

        //    Bitmap newImage = WebCameraImage;

        //    Int32 BrightnessValue = 0;
        //    try
        //    {
        //        if (txtBrightness_L.Text != null && txtBrightness_L.Text != "")
        //            BrightnessValue = Convert.ToInt32(txtBrightness_L.Text);
        //        else
        //            BrightnessValue = 0;
        //    }
        //    catch (Exception)
        //    {
        //        BrightnessValue = 0;
        //    }

        //    BrightnessCorrection BrightnessImage = new BrightnessCorrection();
        //    BrightnessImage.AdjustValue = BrightnessValue;
        //    newImage = BrightnessImage.Apply(newImage);

        //    Int32 ContrastValue = 0;
        //    try
        //    {
        //        if (txtContrast_L.Text != null && txtContrast_L.Text != "")
        //            ContrastValue = Convert.ToInt32(txtContrast_L.Text);
        //        else
        //            ContrastValue = 0;
        //    }
        //    catch (Exception)
        //    {
        //        ContrastValue = 0;
        //    }

        //    ContrastCorrection ContrastImage = new ContrastCorrection();
        //    ContrastImage.Factor = ContrastValue;
        //    newImage = ContrastImage.Apply(newImage);

        //    WebCameraImage = newImage;

        //    if (WebCameraImage_L.Image == null)
        //    {
        //        WebCameraImage_L.Image = WebCameraImage;

        //        WebCameraImage_L.SelectionRegion = new RectangleF(0, 0, WebCameraImage_L.Image.Width, WebCameraImage_L.Image.Height);
        //    }
        //    else
        //    {
        //        WebCameraImage_L.Image = WebCameraImage;

        //        if (WebCameraImage_L.SelectionRegion.Width > WebCameraImage_L.Image.Width
        //            || WebCameraImage_L.SelectionRegion.Height > WebCameraImage_L.Image.Height
        //            || WebCameraImage_L.SelectionRegion.Left < 0
        //            || WebCameraImage_L.SelectionRegion.Top < 0
        //            || WebCameraImage_L.SelectionRegion.Right > WebCameraImage_L.Image.Width
        //            || WebCameraImage_L.SelectionRegion.Bottom > WebCameraImage_L.Image.Height)
        //        {
        //            WebCameraImage_L.SelectionRegion = new RectangleF(0, 0, WebCameraImage_L.Image.Width, WebCameraImage_L.Image.Height);
        //        }
        //    }
        //}

        //private void WebCameraSource_R_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    Bitmap WebCameraImage = (Bitmap)eventArgs.Frame.Clone();
        //    //Bitmap WebCameraImage = WebCameraUtil.GetNewFrameImage(ref eventArgs);

        //    if (ImageRotate_R == 0)
        //    {
        //        if (ImageFlipX_R)
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_R == 90)
        //    {
        //        if (ImageFlipX_R)
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_R == 180)
        //    {
        //        if (ImageFlipX_R)
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
        //            }
        //        }
        //    }
        //    else if (ImageRotate_R == 270)
        //    {
        //        if (ImageFlipX_R)
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (ImageFlipX_R)
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        //            }
        //            else
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //            }
        //        }
        //        else
        //        {
        //            if (ImageFlipY_R)
        //            {
        //                WebCameraImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //            }
        //        }

        //        RotateBilinear RotateImage = new RotateBilinear(360 - ImageRotate_R);
        //        RotateImage.FillColor = Color.Transparent;
        //        Bitmap newRotateImage = RotateImage.Apply(WebCameraImage);

        //        WebCameraImage.Dispose();
        //        WebCameraImage = newRotateImage;
        //    }

        //    Bitmap newImage = WebCameraImage;

        //    Int32 BrightnessValue = 0;
        //    try
        //    {
        //        if (txtBrightness_R.Text != null && txtBrightness_R.Text != "")
        //            BrightnessValue = Convert.ToInt32(txtBrightness_R.Text);
        //        else
        //            BrightnessValue = 0;
        //    }
        //    catch (Exception)
        //    {
        //        BrightnessValue = 0;
        //    }

        //    BrightnessCorrection BrightnessImage = new BrightnessCorrection();
        //    BrightnessImage.AdjustValue = BrightnessValue;
        //    newImage = BrightnessImage.Apply(newImage);

        //    Int32 ContrastValue = 0;
        //    try
        //    {
        //        if (txtContrast_R.Text != null && txtContrast_R.Text != "")
        //            ContrastValue = Convert.ToInt32(txtContrast_R.Text);
        //        else
        //            ContrastValue = 0;
        //    }
        //    catch (Exception)
        //    {
        //        ContrastValue = 0;
        //    }

        //    ContrastCorrection ContrastImage = new ContrastCorrection();
        //    ContrastImage.Factor = ContrastValue;
        //    newImage = ContrastImage.Apply(newImage);

        //    WebCameraImage = newImage;

        //    if (WebCameraImage_R.Image == null)
        //    {
        //        WebCameraImage_R.Image = WebCameraImage;

        //        WebCameraImage_R.SelectionRegion = new RectangleF(0, 0, WebCameraImage_R.Image.Width, WebCameraImage_R.Image.Height);
        //    }
        //    else
        //    {
        //        WebCameraImage_R.Image = WebCameraImage;

        //        if (WebCameraImage_R.SelectionRegion.Width > WebCameraImage_R.Image.Width
        //            || WebCameraImage_R.SelectionRegion.Height > WebCameraImage_R.Image.Height
        //            || WebCameraImage_R.SelectionRegion.Left < 0
        //            || WebCameraImage_R.SelectionRegion.Top < 0
        //            || WebCameraImage_R.SelectionRegion.Right > WebCameraImage_R.Image.Width
        //            || WebCameraImage_R.SelectionRegion.Bottom > WebCameraImage_R.Image.Height)
        //        {
        //            WebCameraImage_R.SelectionRegion = new RectangleF(0, 0, WebCameraImage_R.Image.Width, WebCameraImage_R.Image.Height);
        //        }
        //    }
        //}

        //private async void cboWebCameraSource_L_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (cboWebCameraSource_L.SelectedIndex == 0)
        //    {
        //        WebCameraImage_L.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_L);
        //        try
        //        {
        //            WebCameraSource_L.NewFrame -= new NewFrameEventHandler(WebCameraSource_L_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_L.Image = null;
        //    }
        //    else if (cboWebCameraSource_L.SelectedIndex == cboWebCameraSource_R.SelectedIndex)
        //    {
        //        MessageBox.Show("Can not select same device in left and right channel.", "Warning Select Video Device", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        //        cboWebCameraSource_L.SelectedIndex = 0;

        //        WebCameraImage_L.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_L);
        //        try
        //        {
        //            WebCameraSource_L.NewFrame -= new NewFrameEventHandler(WebCameraSource_L_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_L.Image = null;
        //    }
        //    else
        //    {
        //        WebCameraImage_L.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_L);
        //        try
        //        {
        //            WebCameraSource_L.NewFrame -= new NewFrameEventHandler(WebCameraSource_L_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_L.Image = null;

        //        WebCameraSource_L = new VideoCaptureDevice(WebCameraUtil.WebCameraDeviceList[cboWebCameraSource_L.SelectedIndex - 1].MonikerString);
        //        //WebCameraSource_L = WebCameraUtil.GetWebCameraSource(cboWebCameraSource_L.SelectedIndex - 1);
        //        WebCameraSource_L.NewFrame += new NewFrameEventHandler(WebCameraSource_L_NewFrame);

        //        await Task.Delay(100);

        //        WebCameraUtil.ConnectWebCamera(ref WebCameraSource_L);
        //        WebCameraImage_L.Focus();
        //    }
        //}

        //private async void cboWebCameraSource_R_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboWebCameraSource_R.SelectedIndex == 0)
        //    {
        //        WebCameraImage_R.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_R);
        //        try
        //        {
        //            WebCameraSource_R.NewFrame -= new NewFrameEventHandler(WebCameraSource_R_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_R.Image = null;
        //    }
        //    else if (cboWebCameraSource_R.SelectedIndex == cboWebCameraSource_L.SelectedIndex)
        //    {
        //        MessageBox.Show("Can not select same device in left and right channel.", "Warning Select Video Device", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        //        cboWebCameraSource_R.SelectedIndex = 0;

        //        WebCameraImage_R.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_R);
        //        try
        //        {
        //            WebCameraSource_R.NewFrame -= new NewFrameEventHandler(WebCameraSource_R_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_R.Image = null;
        //    }
        //    else
        //    {
        //        WebCameraImage_R.SelectionRegion = new RectangleF(0, 0, 0, 0);
        //        WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_R);
        //        try
        //        {
        //            WebCameraSource_R.NewFrame -= new NewFrameEventHandler(WebCameraSource_R_NewFrame);
        //        }
        //        catch (Exception) { }
        //        WebCameraImage_R.Image = null;

        //        WebCameraSource_R = new VideoCaptureDevice(WebCameraUtil.WebCameraDeviceList[cboWebCameraSource_R.SelectedIndex - 1].MonikerString);
        //        //WebCameraSource2 = WebCameraUtil.GetWebCameraSource(cboWebCameraSource_R.SelectedIndex - 1);
        //        WebCameraSource_R.NewFrame += new NewFrameEventHandler(WebCameraSource_R_NewFrame);

        //        await Task.Delay(500);

        //        WebCameraUtil.ConnectWebCamera(ref WebCameraSource_R);
        //        WebCameraImage_R.Focus();
        //    }
        //}

        //private void toolButtonRotateCCW_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_L == 0)
        //        ImageRotate_L = 359;
        //    else
        //        ImageRotate_L -= 1;
        //    SetStatusBarRotateText_L();
        //}

        //private void toolButtonRotateCCW_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_R == 0)
        //        ImageRotate_R = 359;
        //    else
        //        ImageRotate_R -= 1;
        //    SetStatusBarRotateText_R();
        //}

        //private void toolButtonRotateCW_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_L == 359)
        //        ImageRotate_L = 0;
        //    else
        //        ImageRotate_L += 1;
        //    SetStatusBarRotateText_L();
        //}

        //private void toolButtonRotateCW_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_R == 359)
        //        ImageRotate_R = 0;
        //    else
        //        ImageRotate_R += 1;
        //    SetStatusBarRotateText_R();
        //}

        //private void toolButtonRotateCCW90_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_L % 90 == 0)
        //    {
        //        if (ImageRotate_L == 0)
        //            ImageRotate_L = 270;
        //        else
        //            ImageRotate_L -= 90;
        //    }
        //    else
        //    {
        //        if (ImageRotate_L > 0 && ImageRotate_L < 90)
        //            ImageRotate_L = 0;
        //        else if (ImageRotate_L > 90 && ImageRotate_L < 180)
        //            ImageRotate_L = 90;
        //        else if (ImageRotate_L > 180 && ImageRotate_L < 270)
        //            ImageRotate_L = 180;
        //        else if (ImageRotate_L > 270 && ImageRotate_L < 360)
        //            ImageRotate_L = 270;
        //    }
        //    SetStatusBarRotateText_L();
        //}

        //private void toolButtonRotateCCW90_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_R % 90 == 0)
        //    {
        //        if (ImageRotate_R == 0)
        //            ImageRotate_R = 270;
        //        else
        //            ImageRotate_R -= 90;
        //    }
        //    else
        //    {
        //        if (ImageRotate_R > 0 && ImageRotate_R < 90)
        //            ImageRotate_R = 0;
        //        else if (ImageRotate_R > 90 && ImageRotate_R < 180)
        //            ImageRotate_R = 90;
        //        else if (ImageRotate_R > 180 && ImageRotate_R < 270)
        //            ImageRotate_R = 180;
        //        else if (ImageRotate_R > 270 && ImageRotate_R < 360)
        //            ImageRotate_R = 270;
        //    }
        //    SetStatusBarRotateText_R();
        //}

        //private void toolButtonRotateCW90_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_L % 90 == 0)
        //    {
        //        if (ImageRotate_L == 270)
        //            ImageRotate_L = 0;
        //        else
        //            ImageRotate_L += 90;
        //    }
        //    else
        //    {
        //        if (ImageRotate_L > 0 && ImageRotate_L < 90)
        //            ImageRotate_L = 90;
        //        else if (ImageRotate_L > 90 && ImageRotate_L < 180)
        //            ImageRotate_L = 180;
        //        else if (ImageRotate_L > 180 && ImageRotate_L < 270)
        //            ImageRotate_L = 270;
        //        else if (ImageRotate_L > 270 && ImageRotate_L < 360)
        //            ImageRotate_L = 0;
        //    }
        //    SetStatusBarRotateText_L();
        //}

        //private void toolButtonRotateCW90_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageRotate_R % 90 == 0)
        //    {
        //        if (ImageRotate_R == 270)
        //            ImageRotate_R = 0;
        //        else
        //            ImageRotate_R += 90;
        //    }
        //    else
        //    {
        //        if (ImageRotate_R > 0 && ImageRotate_R < 90)
        //            ImageRotate_R = 90;
        //        else if (ImageRotate_R > 90 && ImageRotate_R < 180)
        //            ImageRotate_R = 180;
        //        else if (ImageRotate_R > 180 && ImageRotate_R < 270)
        //            ImageRotate_R = 270;
        //        else if (ImageRotate_R > 270 && ImageRotate_R < 360)
        //            ImageRotate_R = 0;
        //    }
        //    SetStatusBarRotateText_R();
        //}

        //private void toolButtonFlipX_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageFlipX_L)
        //        ImageFlipX_L = false;
        //    else
        //        ImageFlipX_L = true;
        //    SetStatusBarFlipText_L();
        //}

        //private void toolButtonFlipX_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageFlipX_R)
        //        ImageFlipX_R = false;
        //    else
        //        ImageFlipX_R = true;
        //    SetStatusBarFlipText_R();
        //}

        //private void toolButtonFlipY_L_Click(object sender, EventArgs e)
        //{
        //    if (ImageFlipY_L)
        //        ImageFlipY_L = false;
        //    else
        //        ImageFlipY_L = true;
        //    SetStatusBarFlipText_L();
        //}

        //private void toolButtonFlipY_R_Click(object sender, EventArgs e)
        //{
        //    if (ImageFlipY_R)
        //        ImageFlipY_R = false;
        //    else
        //        ImageFlipY_R = true;
        //    SetStatusBarFlipText_R();
        //}

        //private void toolButtonActualSize_L_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_L.ActualSize();
        //}

        //private void toolButtonActualSize_R_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_R.ActualSize();
        //}

        //private void toolButtonZoomOut_L_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_L.ZoomOut();
        //}

        //private void toolButtonZoomOut_R_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_R.ZoomOut();
        //}

        //private void toolButtonZoomIn_L_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_L.ZoomIn();
        //}

        //private void toolButtonZoomIn_R_Click(object sender, EventArgs e)
        //{
        //    WebCameraImage_R.ZoomIn();
        //}

        //private void cboZoomImage_L_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboZoomImage_L.SelectedIndex != -1)
        //        WebCameraImage_L.Zoom = Convert.ToInt32(cboZoomImage_L.SelectedItem.ToString().Replace("%", ""));
        //    SetStatusBarZoomText_L();
        //}

        //private void cboZoomImage_R_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboZoomImage_R.SelectedIndex != -1)
        //        WebCameraImage_R.Zoom = Convert.ToInt32(cboZoomImage_R.SelectedItem.ToString().Replace("%", ""));
        //    SetStatusBarZoomText_R();
        //}

        //private void WebCameraImage_L_Zoomed(object sender, Cyotek.Windows.Forms.ImageBoxZoomEventArgs e)
        //{
        //    cboZoomImage_L.SelectedItem = WebCameraImage_L.Zoom.ToString() + "%";
        //    SetStatusBarZoomText_L();
        //}

        //private void WebCameraImage_R_Zoomed(object sender, Cyotek.Windows.Forms.ImageBoxZoomEventArgs e)
        //{
        //    cboZoomImage_R.SelectedItem = WebCameraImage_R.Zoom.ToString() + "%";
        //    SetStatusBarZoomText_R();
        //}

        //private void toolButtonBrightnessActual_L_Click(object sender, EventArgs e)
        //{
        //    ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value = 0;
        //}

        //private void toolButtonBrightnessActual_R_Click(object sender, EventArgs e)
        //{
        //    ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value = 0;
        //}

        //private void toolButtonBrightnessDecrease_L_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Minimum)
        //    {
        //        ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value -= 1;
        //    }
        //}

        //private void toolButtonBrightnessDecrease_R_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Minimum)
        //    {
        //        ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value -= 1;
        //    }
        //}

        //private void toolButtonBrightnessIncrease_L_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Maximum)
        //    {
        //        ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value += 1;
        //    }
        //}

        //private void toolButtonBrightnessIncrease_R_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value != ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Maximum)
        //    {
        //        ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value += 1;
        //    }
        //}

        //private void toolButtonContrastActual_L_Click(object sender, EventArgs e)
        //{
        //    ((NumericUpDown)txtContrast_L.NumericUpDownControl).Value = 0;
        //}

        //private void toolButtonContrastActual_R_Click(object sender, EventArgs e)
        //{
        //    ((NumericUpDown)txtContrast_R.NumericUpDownControl).Value = 0;
        //}

        //private void toolButtonContrastDecrease_L_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtContrast_L.NumericUpDownControl).Value != ((NumericUpDown)txtContrast_L.NumericUpDownControl).Minimum)
        //    {
        //        ((NumericUpDown)txtContrast_L.NumericUpDownControl).Value -= 1;
        //    }
        //}

        //private void toolButtonContrastDecrease_R_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtContrast_R.NumericUpDownControl).Value != ((NumericUpDown)txtContrast_R.NumericUpDownControl).Minimum)
        //    {
        //        ((NumericUpDown)txtContrast_R.NumericUpDownControl).Value -= 1;
        //    }
        //}

        //private void toolButtonContrastIncrease_L_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtContrast_L.NumericUpDownControl).Value != ((NumericUpDown)txtContrast_L.NumericUpDownControl).Maximum)
        //    {
        //        ((NumericUpDown)txtContrast_L.NumericUpDownControl).Value += 1;
        //    }
        //}

        //private void toolButtonContrastIncrease_R_Click(object sender, EventArgs e)
        //{
        //    if (((NumericUpDown)txtContrast_R.NumericUpDownControl).Value != ((NumericUpDown)txtContrast_R.NumericUpDownControl).Maximum)
        //    {
        //        ((NumericUpDown)txtContrast_R.NumericUpDownControl).Value += 1;
        //    }
        //}

        private void toolButtondBrowseImage_L_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseImage = new OpenFileDialog();
            BrowseImage.Multiselect = false;
            BrowseImage.CheckFileExists = true;
            BrowseImage.CheckPathExists = true;
            BrowseImage.Title = "Select Image (Left)";
            BrowseImage.Filter = "Bitmap File (*.bmp)|*.bmp|JPEG File (*.jpg, *.jpeg)|*.jpg; *.jpeg|PNG File (*.png)|*.png|TIFF File (*.tif, *.tiff)|*.tif; *.tiff";
            BrowseImage.FilterIndex = 2;
            BrowseImage.ShowDialog();

            if (BrowseImage.FileName != "")
            {
                System.Drawing.Image LoadImage = System.Drawing.Image.FromStream(BrowseImage.OpenFile());
                PageImage_L.Image = (System.Drawing.Image)LoadImage.Clone();
                PageImage_L.ZoomToFit();
            }
        }

        private void toolButtondBrowseImage_R_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseImage = new OpenFileDialog();
            BrowseImage.Multiselect = false;
            BrowseImage.CheckFileExists = true;
            BrowseImage.CheckPathExists = true;
            BrowseImage.Title = "Select Image (Left)";
            BrowseImage.Filter = "Bitmap File (*.bmp)|*.bmp|JPEG File (*.jpg, *.jpeg)|*.jpg; *.jpeg|PNG File (*.png)|*.png|TIFF File (*.tif, *.tiff)|*.tif; *.tiff";
            BrowseImage.FilterIndex = 2;
            BrowseImage.ShowDialog();

            if (BrowseImage.FileName != "")
            {
                System.Drawing.Image LoadImage = System.Drawing.Image.FromStream(BrowseImage.OpenFile());
                PageImage_R.Image = (System.Drawing.Image)LoadImage.Clone();
                PageImage_R.ZoomToFit();
            }
        }

        //private void toolButtondScanImage_L_Click(object sender, EventArgs e)
        //{
        //    if (WebCameraImage_L.Image == null)
        //    {
        //        MessageBox.Show("Please Select Camera to scan.", "Scan Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    System.Drawing.Image ScanImage = (System.Drawing.Image)WebCameraImage_L.Image.Clone();
        //    PageImage_L.Image = ((Bitmap)ScanImage).Clone(WebCameraImage_L.SelectionRegion, ScanImage.PixelFormat);
        //    PageImage_L.ZoomToFit();
        //}

        //private void toolButtondScanImage_R_Click(object sender, EventArgs e)
        //{
        //    if (WebCameraImage_R.Image == null)
        //    {
        //        MessageBox.Show("Please Select Camera to scan.", "Scan Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //        return;
        //    }
        //    System.Drawing.Image ScanImage = (System.Drawing.Image)WebCameraImage_R.Image.Clone();
        //    PageImage_R.Image = ((Bitmap)ScanImage).Clone(WebCameraImage_R.SelectionRegion, ScanImage.PixelFormat);
        //    PageImage_R.ZoomToFit();
        //}

        //private void WebCameraImage_L_SelectionRegionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Double ImageWidthResolution = WebCameraImage_L.Image.HorizontalResolution;
        //        Double ImageHeightResolution = WebCameraImage_L.Image.VerticalResolution;
        //        Double ImageWidthPx = WebCameraImage_L.SelectionRegion.Width;
        //        Double ImageHeightPx = WebCameraImage_L.SelectionRegion.Height;
        //        Double ImageWidth = ImageWidthPx * 2.54 / ImageWidthResolution;
        //        Double ImageHeight = ImageHeightPx * 2.54 / ImageHeightResolution;

        //        lblWebCameraSelectPixel_L.Text = "Select Size: " + ImageWidthPx.ToString("#,0") + " x " + ImageHeightPx.ToString("#,0") + " px";
        //        lblWebCameraSelectPixel_L.Text += ", " + ImageWidth.ToString("#,0.0") + " x " + ImageHeight.ToString("#,0.0") + " cm";
        //    }
        //    catch (Exception)
        //    {
        //        lblWebCameraSelectPixel_L.Text = "Select Size: 0 x 0 px";
        //        lblWebCameraSelectPixel_L.Text += ", 0 x 0 cm";
        //    }
        //}

        //private void WebCameraImage_R_SelectionRegionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Double ImageWidthResolution = WebCameraImage_R.Image.HorizontalResolution;
        //        Double ImageHeightResolution = WebCameraImage_R.Image.VerticalResolution;
        //        Double ImageWidthPx = WebCameraImage_R.SelectionRegion.Width;
        //        Double ImageHeightPx = WebCameraImage_R.SelectionRegion.Height;
        //        Double ImageWidth = ImageWidthPx * 2.54 / ImageWidthResolution;
        //        Double ImageHeight = ImageHeightPx * 2.54 / ImageHeightResolution;

        //        lblWebCameraSelectPixel_R.Text = "Select Size: " + ImageWidthPx.ToString("#,0") + " x " + ImageHeightPx.ToString("#,0") + " px";
        //        lblWebCameraSelectPixel_R.Text += ", " + ImageWidth.ToString("#,0.0") + " x " + ImageHeight.ToString("#,0.0") + " cm";
        //    }
        //    catch (Exception)
        //    {
        //        lblWebCameraSelectPixel_R.Text = "Select Size: 0 x 0 px";
        //        lblWebCameraSelectPixel_R.Text += ", 0 x 0 cm";
        //    }
        //}

        private void TestScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_L);
            WebCameraUtil.DisConnectWebCamera(ref WebCameraSource_R);
        }

        private void toolButtondDeleteImage_L_Click(object sender, EventArgs e)
        {
            PageImage_L.Image = null;
            PageImage_L.ActualSize();
        }

        private void toolButtondDeleteImage_R_Click(object sender, EventArgs e)
        {
            PageImage_R.Image = null;
            PageImage_R.ActualSize();
        }

        private void toolButtonSavePageImage_L_Click(object sender, EventArgs e)
        {
            DataRowView _BookRow;
            DataRowView _PageRow;
            DataRowView _VersionRow;

            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Save Page", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (cboBookNo.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Book", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBookNo.Focus();
                return;
            }
            else
            {
                _BookRow = (DataRowView)cboBookNo.SelectedItem;
            }

            if (PageImage_L.Image == null)
            {
                MessageBox.Show("Please Scan Image (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboPageNo_L.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_L.Focus();
                return;
            }
            else
            {
                _PageRow = (DataRowView)cboPageNo_L.SelectedItem;
                //if (_PageRow["PageNo"].ToString() == "New")
                //{
                //    if (txtNewPageNo_L.Text.Trim() == "")
                //    {
                //        MessageBox.Show("Please Input New Page No (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    else
                //    {
                //        Boolean IsDuplicatePageNo = false;
                //        foreach (DataRow dPageRowItem in ((DataTable)cboPageNo_L.DataSource).Rows)
                //        {
                //            if (dPageRowItem["PageNo"].ToString() == txtNewPageNo_L.Text.Trim())
                //                IsDuplicatePageNo = true;
                //        }
                //        if (IsDuplicatePageNo)
                //        {
                //            MessageBox.Show("Duplicate New Page No (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //}
            }

            if (cboVersionNo_L.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Version (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVersionNo_L.Focus();
                return;
            }
            else
            {
                _VersionRow = (DataRowView)cboVersionNo_L.SelectedItem;
            }

            Int32 _iBookYear = Convert.ToInt32(_BookRow["BookYear"].ToString());
            Int32 _iBookNo = Convert.ToInt32(_BookRow["BookNo"].ToString());
            Int32 _iPageNo = Convert.ToInt32(_PageRow["PageNo"].ToString());
            Int32 _iVersionNo = Convert.ToInt32(_VersionRow["PageVersion"].ToString());

            String _BookYear = _iBookYear.ToString();
            String _BookNo = _iBookNo.ToString().PadLeft(4, '0');
            String _PageNo = _iPageNo.ToString().PadLeft(4, '0');
            String _VersionNo = _iVersionNo.ToString().PadLeft(2, '0');

            String _ImageFolder = "Active/Y" + _BookYear + "/B" + _BookNo;
            String _ImageName = "B" + _BookNo + "_P" + _PageNo + "_V" + _VersionNo + ".jpg";

            String _ImageFullPath = _ImageFolder + "/" + _ImageName;

            DOPAGun_WS.GRB_WebService DOPAGun = null;

            Boolean _IsDisplayNotNextPageImageLeft = false;

            try
            {
                DOPAGun = new DOPAGun_WS.GRB_WebService();

                DOPAGun.SaveImagePage(_iBookNo, _iPageNo, _iVersionNo, _ImageFullPath, _LogonUserDispName, ImageToByteArray((System.Drawing.Image)PageImage_L.Image.Clone()));

                if (cboAutoIncrementPageNo.SelectedItem.ToString() == "Yes")
                {
                    Int32 NextIndex = -1;
                    Int32 NextPageNo = _iPageNo + 2;

                    for (Int32 Index = 0; Index < cboPageNo_L.Items.Count; Index++)
                    {
                        DataRowView drv = (DataRowView)cboPageNo_L.Items[Index];

                        if (NextPageNo.ToString() == drv["PageNo"].ToString())
                        {
                            NextIndex = Index;
                            break;
                        }
                    }

                    if (NextIndex != -1)
                    {
                        cboPageNo_L.SelectedIndex = NextIndex;

                        _PageRow = (DataRowView)cboPageNo_L.SelectedItem;
                    }
                    else
                    {
                        _IsDisplayNotNextPageImageLeft = true;
                    }
                }

                InitialDropdownVersionNo_L(_BookRow["BookNo"].ToString(), _PageRow["PageNo"].ToString());

                MessageBox.Show("Save Page Image Success.", "Save Page Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (_IsDisplayNotNextPageImageLeft)
                {
                    MessageBox.Show("No Next Page Initial for Left Area", "Auto Next Page (Left)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Save Page Image Failed: " + Ex.Message, "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }
        }

        private void toolButtonSavePageImage_R_Click(object sender, EventArgs e)
        {
            DataRowView _BookRow;
            DataRowView _PageRow;
            DataRowView _VersionRow;

            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Save Page", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (cboBookNo.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Book", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBookNo.Focus();
                return;
            }
            else
            {
                _BookRow = (DataRowView)cboBookNo.SelectedItem;
            }

            if (PageImage_R.Image == null)
            {
                MessageBox.Show("Please Scan Image (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboPageNo_R.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_R.Focus();
                return;
            }
            else
            {
                _PageRow = (DataRowView)cboPageNo_R.SelectedItem;
                //if (_PageRow["PageNo"].ToString() == "New")
                //{
                //    if (txtNewPageNo_R.Text.Trim() == "")
                //    {
                //        MessageBox.Show("Please Input New Page No (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    else
                //    {
                //        Boolean IsDuplicatePageNo = false;
                //        foreach (DataRow dPageRowItem in ((DataTable)cboPageNo_R.DataSource).Rows)
                //        {
                //            if (dPageRowItem["PageNo"].ToString() == txtNewPageNo_R.Text.Trim())
                //                IsDuplicatePageNo = true;
                //        }
                //        if (IsDuplicatePageNo)
                //        {
                //            MessageBox.Show("Duplicate New Page No (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //}
            }

            if (cboVersionNo_R.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Version (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVersionNo_R.Focus();
                return;
            }
            else
            {
                _VersionRow = (DataRowView)cboVersionNo_R.SelectedItem;
            }

            Int32 _iBookYear = Convert.ToInt32(_BookRow["BookYear"].ToString());
            Int32 _iBookNo = Convert.ToInt32(_BookRow["BookNo"].ToString());
            Int32 _iPageNo = Convert.ToInt32(_PageRow["PageNo"].ToString());
            Int32 _iVersionNo = Convert.ToInt32(_VersionRow["PageVersion"].ToString());

            String _BookYear = _iBookYear.ToString();
            String _BookNo = _iBookNo.ToString().PadLeft(4, '0');
            String _PageNo = _iPageNo.ToString().PadLeft(4, '0');
            String _VersionNo = _iVersionNo.ToString().PadLeft(2, '0');

            String _ImageFolder = "Active/Y" + _BookYear + "/B" + _BookNo;
            String _ImageName = "B" + _BookNo + "_P" + _PageNo + "_V" + _VersionNo + ".jpg";

            String _ImageFullPath = _ImageFolder + "/" + _ImageName;

            DOPAGun_WS.GRB_WebService DOPAGun = null;

            Boolean _IsDisplayNotNextPageImageRight = false;

            try
            {
                DOPAGun = new DOPAGun_WS.GRB_WebService();

                DOPAGun.SaveImagePage(_iBookNo, _iPageNo, _iVersionNo, _ImageFullPath, _LogonUserDispName, ImageToByteArray((System.Drawing.Image)PageImage_R.Image.Clone()));

                if (cboAutoIncrementPageNo.SelectedItem.ToString() == "Yes")
                {
                    Int32 NextIndex = -1;
                    Int32 NextPageNo = _iPageNo + 2;

                    for (Int32 Index = 0; Index < cboPageNo_R.Items.Count; Index++)
                    {
                        DataRowView drv = (DataRowView)cboPageNo_R.Items[Index];

                        if (NextPageNo.ToString() == drv["PageNo"].ToString())
                        {
                            NextIndex = Index;
                            break;
                        }
                    }

                    if (NextIndex != -1)
                    {
                        cboPageNo_R.SelectedIndex = NextIndex;

                        _PageRow = (DataRowView)cboPageNo_R.SelectedItem;
                    }
                    else
                    {
                        _IsDisplayNotNextPageImageRight = true;
                    }
                }

                InitialDropdownVersionNo_R(_BookRow["BookNo"].ToString(), _PageRow["PageNo"].ToString());

                MessageBox.Show("Save Page Image Success.", "Save Page Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (_IsDisplayNotNextPageImageRight)
                {
                    MessageBox.Show("No Next Page Initial for Right Area", "Auto Next Page (Right)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Save Page Image Failed: " + Ex.Message, "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }
        }

        private void toolButtonSavePageImageAll_Click(object sender, EventArgs e)
        {
            DataRowView _BookRow;
            DataRowView _PageRow_L;
            DataRowView _PageRow_R;
            DataRowView _VersionRow_L;
            DataRowView _VersionRow_R;

            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Save Page", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (cboBookNo.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Book", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBookNo.Focus();
                return;
            }
            else
            {
                _BookRow = (DataRowView)cboBookNo.SelectedItem;
            }

            if (PageImage_L.Image == null)
            {
                MessageBox.Show("Please Scan Image (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PageImage_R.Image == null)
            {
                MessageBox.Show("Please Scan Image (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboPageNo_L.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_L.Focus();
                return;
            }
            else
            {
                _PageRow_L = (DataRowView)cboPageNo_L.SelectedItem;
                //if (_PageRow_L["PageNo"].ToString() == "New")
                //{
                //    if (txtNewPageNo_L.Text.Trim() == "")
                //    {
                //        MessageBox.Show("Please Input New Page No (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    else
                //    {
                //        Boolean IsDuplicatePageNo = false;
                //        foreach (DataRow dPageRowItem in ((DataTable)cboPageNo_L.DataSource).Rows)
                //        {
                //            if (dPageRowItem["PageNo"].ToString() == txtNewPageNo_L.Text.Trim())
                //                IsDuplicatePageNo = true;
                //        }
                //        if (IsDuplicatePageNo)
                //        {
                //            MessageBox.Show("Duplicate New Page No (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //}
            }

            if (cboPageNo_R.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_R.Focus();
                return;
            }
            else
            {
                _PageRow_R = (DataRowView)cboPageNo_R.SelectedItem;
                //if (_PageRow_R["PageNo"].ToString() == "New")
                //{
                //    if (txtNewPageNo_R.Text.Trim() == "")
                //    {
                //        MessageBox.Show("Please Input New Page No (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    else
                //    {
                //        Boolean IsDuplicatePageNo = false;
                //        foreach (DataRow dPageRowItem in ((DataTable)cboPageNo_R.DataSource).Rows)
                //        {
                //            if (dPageRowItem["PageNo"].ToString() == txtNewPageNo_R.Text.Trim())
                //                IsDuplicatePageNo = true;
                //        }
                //        if (IsDuplicatePageNo)
                //        {
                //            MessageBox.Show("Duplicate New Page No (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //}
            }

            if (cboVersionNo_L.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Version (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVersionNo_L.Focus();
                return;
            }
            else
            {
                _VersionRow_L = (DataRowView)cboVersionNo_L.SelectedItem;
            }

            if (cboVersionNo_R.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Version (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVersionNo_R.Focus();
                return;
            }
            else
            {
                _VersionRow_R = (DataRowView)cboVersionNo_R.SelectedItem;
            }

            Int32 _iBookYear = Convert.ToInt32(_BookRow["BookYear"].ToString());
            Int32 _iBookNo = Convert.ToInt32(_BookRow["BookNo"].ToString());

            Int32 _iPageNo_L = Convert.ToInt32(_PageRow_L["PageNo"].ToString());
            Int32 _iPageNo_R = Convert.ToInt32(_PageRow_R["PageNo"].ToString());

            Int32 _iVersionNo_L = Convert.ToInt32(_VersionRow_L["PageVersion"].ToString());
            Int32 _iVersionNo_R = Convert.ToInt32(_VersionRow_R["PageVersion"].ToString());

            String _BookYear = _iBookYear.ToString();
            String _BookNo = _iBookNo.ToString().PadLeft(4, '0');

            String _PageNo_L = _iPageNo_L.ToString().PadLeft(4, '0');
            String _PageNo_R = _iPageNo_R.ToString().PadLeft(4, '0');

            String _VersionNo_L = _iVersionNo_L.ToString().PadLeft(2, '0');
            String _VersionNo_R = _iVersionNo_R.ToString().PadLeft(2, '0');

            String _ImageFolder_L = "Active/Y" + _BookYear + "/B" + _BookNo;
            String _ImageName_L = "B" + _BookNo + "_P" + _PageNo_L + "_V" + _VersionNo_L + ".jpg";

            String _ImageFolder_R = "Active/Y" + _BookYear + "/B" + _BookNo;
            String _ImageName_R = "B" + _BookNo + "_P" + _PageNo_R + "_V" + _VersionNo_R + ".jpg";

            String _ImageFullPath_L = _ImageFolder_L + "/" + _ImageName_L;
            String _ImageFullPath_R = _ImageFolder_R + "/" + _ImageName_R;

            if (_iPageNo_L == _iPageNo_R && _iVersionNo_L == _iVersionNo_R)
            {
                MessageBox.Show("Can't Save in Same Page and Same Version", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DOPAGun_WS.GRB_WebService DOPAGun = null;

            Boolean _IsDisplayNotNextPageImageLeft = false;
            Boolean _IsDisplayNotNextPageImageRight = false;

            try
            {
                DOPAGun = new DOPAGun_WS.GRB_WebService();

                DOPAGun.SaveImagePage(_iBookNo, _iPageNo_L, _iVersionNo_L, _ImageFullPath_L, _LogonUserDispName, ImageToByteArray((System.Drawing.Image)PageImage_L.Image.Clone()));

                DOPAGun.SaveImagePage(_iBookNo, _iPageNo_R, _iVersionNo_R, _ImageFullPath_R, _LogonUserDispName, ImageToByteArray((System.Drawing.Image)PageImage_L.Image.Clone()));

                if (cboAutoIncrementPageNo.SelectedItem.ToString() == "Yes")
                {
                    Int32 NextIndex = -1;
                    Int32 NextPageNo = _iPageNo_L + 2;

                    for (Int32 Index = 0; Index < cboPageNo_L.Items.Count; Index++)
                    {
                        DataRowView drv = (DataRowView)cboPageNo_L.Items[Index];

                        if (NextPageNo.ToString() == drv["PageNo"].ToString())
                        {
                            NextIndex = Index;
                            break;
                        }
                    }

                    if (NextIndex != -1)
                    {
                        cboPageNo_L.SelectedIndex = NextIndex;

                        _PageRow_L = (DataRowView)cboPageNo_L.SelectedItem;
                    }
                    else
                    {
                        _IsDisplayNotNextPageImageLeft = true;
                    }
                }

                InitialDropdownVersionNo_L(_BookRow["BookNo"].ToString(), _PageRow_L["PageNo"].ToString());

                if (cboAutoIncrementPageNo.SelectedItem.ToString() == "Yes")
                {
                    Int32 NextIndex = -1;
                    Int32 NextPageNo = _iPageNo_R + 2;

                    for (Int32 Index = 0; Index < cboPageNo_R.Items.Count; Index++)
                    {
                        DataRowView drv = (DataRowView)cboPageNo_R.Items[Index];

                        if (NextPageNo.ToString() == drv["PageNo"].ToString())
                        {
                            NextIndex = Index;
                            break;
                        }
                    }

                    if (NextIndex != -1)
                    {
                        cboPageNo_R.SelectedIndex = NextIndex;

                        _PageRow_R = (DataRowView)cboPageNo_R.SelectedItem;
                    }
                    else
                    {
                        _IsDisplayNotNextPageImageRight = true;
                    }
                }

                InitialDropdownVersionNo_L(_BookRow["BookNo"].ToString(), _PageRow_L["PageNo"].ToString());

                MessageBox.Show("Save Page Image All Success.", "Save Page All Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (_IsDisplayNotNextPageImageLeft && _IsDisplayNotNextPageImageRight)
                {
                    MessageBox.Show("No Next Page Initial for Left/Right Area", "Auto Next Page (Left and Right)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (_IsDisplayNotNextPageImageLeft)
                    {
                        MessageBox.Show("No Next Page Initial for Left Area", "Auto Next Page (Left)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    if (_IsDisplayNotNextPageImageRight)
                    {
                        MessageBox.Show("No Next Page Initial for Right Area", "Auto Next Page (Right)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Save Page Image All Failed: " + Ex.Message, "Save Page All Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }
        }

        private void cboBookNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBookNo.SelectedIndex != -1)
            {
                DataRowView dtBookNoRow = (DataRowView)cboBookNo.SelectedItem;

                txtBookYear.Text = dtBookNoRow["BookYear"].ToString();
                txtGunRegID.Text = dtBookNoRow["GunRegIDStart"].ToString() + " - " + dtBookNoRow["GunRegIDEnd"].ToString();
                txtTotalPage.Text = dtBookNoRow["PageTotal"].ToString();

                InitialDropdownPageNo_L(dtBookNoRow["BookNo"].ToString());
                InitialDropdownPageNo_R(dtBookNoRow["BookNo"].ToString());
            }
        }

        private void cboPageNo_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageNo_L.SelectedIndex != -1)
            {
                DataRowView dtPageRow = (DataRowView)cboPageNo_L.SelectedItem;

                //if (dtPageRow["PageNoDisp"].ToString() == "New")
                //{
                //    txtNewPageNo_L.Text = "";
                //    txtNewPageNo_L.ReadOnly = false;
                //}
                //else
                //{
                //    txtNewPageNo_L.Text = "-";
                //    txtNewPageNo_L.ReadOnly = true;
                //}

                InitialDropdownVersionNo_L(dtPageRow["BookNo"].ToString(), dtPageRow["PageNo"].ToString());
            }
        }

        private void cboPageNo_R_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageNo_R.SelectedIndex != -1)
            {
                DataRowView dtPageRow = (DataRowView)cboPageNo_R.SelectedItem;

                //if (dtPageRow["PageNoDisp"].ToString() == "New")
                //{
                //    txtNewPageNo_R.Text = "";
                //    txtNewPageNo_R.ReadOnly = false;
                //}
                //else
                //{
                //    txtNewPageNo_R.Text = "-";
                //    txtNewPageNo_R.ReadOnly = true;
                //}

                InitialDropdownVersionNo_R(dtPageRow["BookNo"].ToString(), dtPageRow["PageNo"].ToString());
            }
        }

        private void cboVersionNo_L_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVersionNo_L.SelectedIndex != -1)
            {
                DataRowView dtVersionRow = (DataRowView)cboVersionNo_L.SelectedItem;
            }
        }

        private void cboVersionNo_R_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVersionNo_R.SelectedIndex != -1)
            {
                DataRowView dtVersionRow = (DataRowView)cboVersionNo_R.SelectedItem;
            }
        }

        private void _PreviewImage_L_PreviewImageFormClosing(object sender, EventArgs e)
        {
            PageImage_L.Image = _PreviewImage._OriginalImage;

            _PreviewImage.Dispose();
            _PreviewImage = null;
            GC.Collect();
        }

        private void _PreviewImage_R_PreviewImageFormClosing(object sender, EventArgs e)
        {
            PageImage_R.Image = _PreviewImage._OriginalImage;

            _PreviewImage.Dispose();
            _PreviewImage = null;
            GC.Collect();
        }

        private void ButtondPreviewImage_L_Click(object sender, EventArgs e)
        {
            if (PageImage_L.Image == null)
            {
                MessageBox.Show("No Image to Preview.", "Preview Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.View, (System.Drawing.Image)PageImage_L.Image.Clone());
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_L_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
        }

        private void ButtondPreviewImage_R_Click(object sender, EventArgs e)
        {
            if (PageImage_R.Image == null)
            {
                MessageBox.Show("No Image to Preview.", "Preview Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            PreviewImage _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.View, (System.Drawing.Image)PageImage_R.Image.Clone());
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_R_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
        }

        private void PageImage_L_DoubleClick(object sender, EventArgs e)
        {
            if (PageImage_L.Image == null)
            {
                MessageBox.Show("No Image to Edit.", "Edit Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.Edit, PageImage_L.Image);
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_L_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
            //if (PageImage_L.Image == null)
            //{
            //    MessageBox.Show("No Image to Preview.", "Preview Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            //PreviewImage _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.View, (System.Drawing.Image)PageImage_L.Image.Clone());
            //_PreviewImage.PreviewImageFormClosing += _PreviewImage_L_PreviewImageFormClosing;
            //_PreviewImage.ShowDialog();
        }

        private void PageImage_R_DoubleClick(object sender, EventArgs e)
        {
            if (PageImage_R.Image == null)
            {
                MessageBox.Show("No Image to Edit.", "Edit Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.Edit, PageImage_R.Image);
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_R_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
            //if (PageImage_R.Image == null)
            //{
            //    MessageBox.Show("No Image to Preview.", "Preview Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            //PreviewImage _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.View, (System.Drawing.Image)PageImage_R.Image.Clone());
            //_PreviewImage.PreviewImageFormClosing += _PreviewImage_R_PreviewImageFormClosing;
            //_PreviewImage.ShowDialog();
        }

        private void toolButtondEditImage_L_Click(object sender, EventArgs e)
        {
            if (PageImage_L.Image == null)
            {
                MessageBox.Show("No Image to Edit.", "Edit Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.Edit, PageImage_L.Image);
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_L_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
        }

        private void toolButtondEditImage_R_Click(object sender, EventArgs e)
        {
            if (PageImage_R.Image == null)
            {
                MessageBox.Show("No Image to Edit.", "Edit Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            _PreviewImage = new PreviewImage(PreviewImage.PreviewMode.Edit, PageImage_R.Image);
            _PreviewImage.PreviewImageFormClosing += _PreviewImage_R_PreviewImageFormClosing;
            _PreviewImage.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolButtonLogin_Click(object sender, EventArgs e)
        {
            if (toolButtonLogin.Text.Trim() == "Login")
            {
                if (txtUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input Username", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please Input Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }

                Boolean IsCorrectLogin = false;

                String _Username = txtUsername.Text.Trim();
                String _Password = txtPassword.Text.Trim();

                DOPAGun_WS.GRB_WebService DOPAGun = null;
                DataTable dtAuthen = null;

                try
                {
                    DOPAGun = new DOPAGun_WS.GRB_WebService();

                    dtAuthen = DOPAGun.UserAuth(_Username, _Password);

                    if (dtAuthen != null && dtAuthen.Rows.Count > 0)
                    {
                        _LogonUserID = dtAuthen.Rows[0]["ID"].ToString();
                        _LogonUserDispName = dtAuthen.Rows[0]["USERNAME"].ToString();

                        IsCorrectLogin = true;
                    }
                }
                catch (Exception) { }
                finally
                {
                    if (dtAuthen != null)
                    {
                        dtAuthen.Dispose();
                        dtAuthen = null;
                    }

                    if (DOPAGun != null)
                    {
                        DOPAGun.Dispose();
                        DOPAGun = null;
                    }

                    GC.Collect();
                }

                if (IsCorrectLogin == false)
                {
                    MessageBox.Show("Incorrect Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Welcome " + _LogonUserDispName, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblUsernameDisp.Visible = true;
                    lblUsernameDisp.Text = _LogonUserDispName;

                    lblUsername.Visible = false;
                    txtUsername.Visible = false;
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;

                    toolButtonLogin.Text = "Logout";
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _LogonUserID = "";
                    _LogonUserDispName = "";

                    lblUsernameDisp.Visible = false;
                    lblUsernameDisp.Text = "";

                    lblUsername.Visible = true;
                    txtUsername.Visible = true;
                    txtUsername.Text = "";
                    lblPassword.Visible = true;
                    txtPassword.Visible = true;
                    txtPassword.Text = "";

                    toolButtonLogin.Text = "Login";
                }
            }
        }

        private void toolButtonLoadCurrent_L_Click(object sender, EventArgs e)
        {
            PageImage_L.Image = null;

            DataRowView _BookRow;
            DataRowView _PageRow_L;

            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Load Current Image Page", "Load Current Image Pag Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (cboBookNo.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Book", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBookNo.Focus();
                return;
            }
            else
            {
                _BookRow = (DataRowView)cboBookNo.SelectedItem;
            }

            if (cboPageNo_L.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Left)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_L.Focus();
                return;
            }
            else
            {
                _PageRow_L = (DataRowView)cboPageNo_L.SelectedItem;
            }

            Int32 _iBookNo = Convert.ToInt32(_BookRow["BookNo"].ToString());

            Int32 _iPageNo_L = Convert.ToInt32(_PageRow_L["PageNo"].ToString());

            DOPAGun_WS.GRB_WebService DOPAGun = null;

            try
            {
                DOPAGun = new DOPAGun_WS.GRB_WebService();

                Byte[] _CurrentImage = DOPAGun.GetCurrentImagePage(_iBookNo, _iPageNo_L);

                MemoryStream _ImageStream = new MemoryStream(_CurrentImage);

                PageImage_L.Image = System.Drawing.Image.FromStream(_ImageStream);

                MessageBox.Show("Load Current Image Page Success.", "Load Current Image Page", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Load Current Image Page Failed: " + Ex.Message, "Load Current Image Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }
        }

        private void toolButtonLoadCurrent_R_Click(object sender, EventArgs e)
        {
            PageImage_R.Image = null;

            DataRowView _BookRow;
            DataRowView _PageRow_R;

            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Load Current Image Page", "Load Current Image Pag Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (cboBookNo.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Book", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBookNo.Focus();
                return;
            }
            else
            {
                _BookRow = (DataRowView)cboBookNo.SelectedItem;
            }

            if (cboPageNo_R.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Page (Right)", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPageNo_R.Focus();
                return;
            }
            else
            {
                _PageRow_R = (DataRowView)cboPageNo_R.SelectedItem;
            }

            Int32 _iBookNo = Convert.ToInt32(_BookRow["BookNo"].ToString());

            Int32 _iPageNo_R = Convert.ToInt32(_PageRow_R["PageNo"].ToString());

            DOPAGun_WS.GRB_WebService DOPAGun = null;

            try
            {
                DOPAGun = new DOPAGun_WS.GRB_WebService();

                Byte[] _CurrentImage = DOPAGun.GetCurrentImagePage(_iBookNo, _iPageNo_R);

                MemoryStream _ImageStream = new MemoryStream(_CurrentImage);

                PageImage_R.Image = System.Drawing.Image.FromStream(_ImageStream);

                MessageBox.Show("Load Current Image Page Success.", "Load Current Image Page", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Load Current Image Page Failed: " + Ex.Message, "Load Current Image Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (DOPAGun != null)
                {
                    DOPAGun.Dispose();
                    DOPAGun = null;
                }

                GC.Collect();
            }
        }

        private void ImportFolder(Boolean IsIncludeSubFolder)
        {
            if (_LogonUserID == "")
            {
                MessageBox.Show("Please Login before Save Page", "Save Page Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            FolderBrowserDialog BrowseFolder = new FolderBrowserDialog();
            BrowseFolder.Description = "Select Folder of Image\nFor Import All Image (*.jpg, Format Name: 'B<Book No>_P<Page No>_V<Version No>.jpg') in Select Folder.";
            BrowseFolder.ShowNewFolderButton = false;
            BrowseFolder.ShowDialog();

            if (BrowseFolder.SelectedPath != "")
            {
                WaitingProcessForm WaitForm = new WaitingProcessForm(BrowseFolder.SelectedPath, IsIncludeSubFolder, _LogonUserID);
                WaitForm.ShowDialog();

                /*String ErrorMessage = "";

                String[] ImageList = System.IO.Directory.GetFiles(BrowseFolder.SelectedPath, "*.jpg", SearchOption.AllDirectories);

                foreach (String ImageItem in ImageList)
                {
                    Byte[] ImageData = null;

                    if (System.IO.File.Exists(ImageItem))
                    {
                        try
                        {
                            ImageData = System.IO.File.ReadAllBytes(ImageItem);
                        }
                        catch (Exception Ex)
                        {
                            ErrorMessage += "Image [" + ImageItem + "] error : " + Ex.Message + "\n";

                            continue;
                        }

                        if (ImageData == null || ImageData.Length <= 0)
                        {
                            ErrorMessage += "Image [" + ImageItem + "] error : No Image Data.\n";

                            continue;
                        }
                    }
                    else
                    {
                        ErrorMessage += "Image [" + ImageItem + "] error : File not exists.\n";
                    }

                    String[] ImageItemSplit = ImageItem.ToUpper().Trim().Split('\\');

                    String ImageName = ImageItemSplit[ImageItemSplit.Length - 1].Substring(0, ImageItemSplit[ImageItemSplit.Length - 1].Trim().Length - 4);

                    String[] ImageNameSplit = ImageName.Split('_');

                    String sBookYear = "";
                    String sBook = "";
                    String sPage = "";
                    String sVersion = "";

                    Int32 iBook = 0;
                    Int32 iPage = 0;
                    Int32 iVersion = 0;

                    foreach (String Item in ImageNameSplit)
                    {
                        if (Item.ToUpper().Contains("B") && Item.ToUpper() == "B" + Item.ToUpper().Replace("B", ""))
                        {
                            sBook = Item.ToUpper().Replace("B", "");

                            try
                            {
                                iBook = Convert.ToInt32(sBook);
                            }
                            catch (Exception)
                            {
                                iBook = 0;
                            }

                            continue;
                        }

                        if (Item.ToUpper().Contains("P") && Item.ToUpper() == "P" + Item.ToUpper().Replace("P", ""))
                        {
                            sPage = Item.ToUpper().Replace("P", "");

                            try
                            {
                                iPage = Convert.ToInt32(sPage);
                            }
                            catch (Exception)
                            {
                                iPage = 0;
                            }

                            continue;
                        }

                        if (Item.ToUpper().Contains("V") && Item.ToUpper() == "V" + Item.ToUpper().Replace("V", ""))
                        {
                            sVersion = Item.ToUpper().Replace("V", "");

                            try
                            {
                                iVersion = Convert.ToInt32(sVersion);
                            }
                            catch (Exception)
                            {
                                iVersion = 0;
                            }

                            continue;
                        }
                    }

                    if (iBook == 0 || iPage == 0 || iVersion == 0)
                    {
                        ErrorMessage += "Image [" + ImageItem + "] error : Invalid File Format.\n";

                        continue;
                    }
                    else
                    {
                        sBook = iBook.ToString().PadLeft(4, '0');
                        sPage = iPage.ToString().PadLeft(4, '0');
                        sVersion = iVersion.ToString().PadLeft(2, '0');

                        DOPAGun_WS.GRB_WebService DOPAGun = null;
                        DataTable dtGunBook = null;

                        try
                        {
                            DOPAGun = new DOPAGun_WS.GRB_WebService();

                            dtGunBook = DOPAGun.GetBook(iBook);

                            if (dtGunBook != null && dtGunBook.Rows.Count > 0)
                            {
                                sBookYear = dtGunBook.Rows[0]["BookYear"].ToString();
                            }
                        }
                        catch (Exception Ex)
                        {
                            ErrorMessage += "Image [" + ImageItem + "] error : " + Ex.Message + "\n";

                            continue;
                        }
                        finally
                        {
                            if (dtGunBook != null)
                            {
                                dtGunBook.Dispose();
                                dtGunBook = null;
                            }

                            if (DOPAGun != null)
                            {
                                DOPAGun.Dispose();
                                DOPAGun = null;
                            }

                            GC.Collect();
                        }

                        String _ImageFolder = "Active/Y" + sBookYear + "/B" + sBook;
                        String _ImageName = "B" + sBook + "_P" + sPage + "_V" + sVersion + ".jpg";

                        String _ImageFullPath = _ImageFolder + "/" + _ImageName;

                        try
                        {
                            DOPAGun = new DOPAGun_WS.GRB_WebService();

                            DOPAGun.SaveImagePage(Convert.ToInt32(sBook), Convert.ToInt32(sPage), Convert.ToInt32(sVersion), _ImageFullPath, _LogonUserDispName, ImageData);
                        }
                        catch (Exception Ex)
                        {
                            ErrorMessage += "Image [" + ImageItem + "] error : " + Ex.Message + "\n";

                            continue;
                        }
                        finally
                        {
                            if (DOPAGun != null)
                            {
                                DOPAGun.Dispose();
                                DOPAGun = null;
                            }

                            GC.Collect();
                        }
                    }
                }

                if (ErrorMessage == "")
                {
                    MessageBox.Show("Import Bulk Image Success.", "Import Bulk Image", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Import Bulk Image Failed.\n\n" + ErrorMessage, "Import Bulk Image", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                */
            }
        }

        private void toolButtonImportFolder_Click(object sender, EventArgs e)
        {
            ImportFolder(false);
        }

        private void toolButtonImportFolderWithSub_Click(object sender, EventArgs e)
        {
            ImportFolder(true);
        }

        //private void WebCameraImage_L_MouseUp(object sender, MouseEventArgs e)
        //{
        //    float _Left = 0;
        //    float _Top = 0;
        //    float _Width = 0;
        //    float _Height = 0;

        //    if (WebCameraImage_L.Image != null)
        //    {
        //        if (WebCameraImage_L.SelectionRegion.Width < WebCameraImage_L.MinimumSelectionSize.Width)
        //        {
        //            if (WebCameraImage_L.SelectionRegion.Left + WebCameraImage_L.MinimumSelectionSize.Width > WebCameraImage_L.Image.Width)
        //                _Left = WebCameraImage_L.Image.Width - WebCameraImage_L.MinimumSelectionSize.Width;
        //            else
        //                _Left = WebCameraImage_L.SelectionRegion.Left;

        //            _Width = WebCameraImage_L.MinimumSelectionSize.Width;
        //        }
        //        else
        //        {
        //            _Left = WebCameraImage_L.SelectionRegion.Left;
        //            _Width = WebCameraImage_L.SelectionRegion.Width;
        //        }

        //        if (WebCameraImage_L.SelectionRegion.Height < WebCameraImage_L.MinimumSelectionSize.Height)
        //        {
        //            if (WebCameraImage_L.SelectionRegion.Top + WebCameraImage_L.MinimumSelectionSize.Height > WebCameraImage_L.Image.Height)
        //                _Top = WebCameraImage_L.Image.Height - WebCameraImage_L.MinimumSelectionSize.Height;
        //            else
        //                _Top = WebCameraImage_L.SelectionRegion.Top;

        //            _Height = WebCameraImage_L.MinimumSelectionSize.Height;
        //        }
        //        else
        //        {
        //            _Top = WebCameraImage_L.SelectionRegion.Top;
        //            _Height = WebCameraImage_L.SelectionRegion.Height;
        //        }

        //        WebCameraImage_L.SelectionRegion = new RectangleF(_Left, _Top, _Width, _Height);
        //    }
        //}

        //private void WebCameraImage_R_MouseUp(object sender, MouseEventArgs e)
        //{
        //    float _Reft = 0;
        //    float _Top = 0;
        //    float _Width = 0;
        //    float _Height = 0;

        //    if (WebCameraImage_R.Image != null)
        //    {
        //        if (WebCameraImage_R.SelectionRegion.Width < WebCameraImage_R.MinimumSelectionSize.Width)
        //        {
        //            if (WebCameraImage_R.SelectionRegion.Left + WebCameraImage_R.MinimumSelectionSize.Width > WebCameraImage_R.Image.Width)
        //                _Reft = WebCameraImage_R.Image.Width - WebCameraImage_R.MinimumSelectionSize.Width;
        //            else
        //                _Reft = WebCameraImage_R.SelectionRegion.Left;

        //            _Width = WebCameraImage_R.MinimumSelectionSize.Width;
        //        }
        //        else
        //        {
        //            _Reft = WebCameraImage_R.SelectionRegion.Left;
        //            _Width = WebCameraImage_R.SelectionRegion.Width;
        //        }

        //        if (WebCameraImage_R.SelectionRegion.Height < WebCameraImage_R.MinimumSelectionSize.Height)
        //        {
        //            if (WebCameraImage_R.SelectionRegion.Top + WebCameraImage_R.MinimumSelectionSize.Height > WebCameraImage_R.Image.Height)
        //                _Top = WebCameraImage_R.Image.Height - WebCameraImage_R.MinimumSelectionSize.Height;
        //            else
        //                _Top = WebCameraImage_R.SelectionRegion.Top;

        //            _Height = WebCameraImage_R.MinimumSelectionSize.Height;
        //        }
        //        else
        //        {
        //            _Top = WebCameraImage_R.SelectionRegion.Top;
        //            _Height = WebCameraImage_R.SelectionRegion.Height;
        //        }

        //        WebCameraImage_R.SelectionRegion = new RectangleF(_Reft, _Top, _Width, _Height);
        //    }
        //}

        //private void toolButtonReset_L_Click(object sender, EventArgs e)
        //{
        //    ImageRotate_L = 0;
        //    ImageFlipX_L = false;
        //    ImageFlipY_L = false;
        //    WebCameraImage_L.ActualSize();
        //    ((NumericUpDown)txtBrightness_L.NumericUpDownControl).Value = 0;
        //    ((NumericUpDown)txtContrast_L.NumericUpDownControl).Value = 0;

        //    SetStatusBarRotateText_L();
        //    SetStatusBarFlipText_L();
        //    SetStatusBarZoomText_L();
        //}

        //private void toolButtonReset_R_Click(object sender, EventArgs e)
        //{
        //    ImageRotate_R = 0;
        //    ImageFlipX_R = false;
        //    ImageFlipY_R = false;
        //    WebCameraImage_R.ActualSize();
        //    ((NumericUpDown)txtBrightness_R.NumericUpDownControl).Value = 0;
        //    ((NumericUpDown)txtContrast_R.NumericUpDownControl).Value = 0;

        //    SetStatusBarRotateText_R();
        //    SetStatusBarFlipText_R();
        //    SetStatusBarZoomText_R();
        //}
    }
}
