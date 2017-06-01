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

namespace DOPAScan
{
    public partial class WaitingProcessForm : Form
    {
        private String _ImageFolder = "";

        private Boolean _IsIncludeSubFolder = false;

        private DataTable _DisplayData = new DataTable();

        private DataTable _DisplayData2 = new DataTable();

        private String _LogonUserID = "";

        private Int32 _IsSuccess = 0;

        private Int32 _IsFailed = 0;

        private String _DisplayAction = "";

        private String[] ImageList;

        public WaitingProcessForm(String ImageFolder, Boolean IsIncludeSubFolder, String LogonUserID)
        {
            InitializeComponent();

            btnClose.Enabled = false;
            btnImportFailImage.Enabled = false;

            _DisplayAction = "Please wait ..";

            _DisplayData = new DataTable();
            _DisplayData.Columns.Add("Process", typeof(System.String));
            _DisplayData.Columns.Add("Result", typeof(System.String));
            _DisplayData.Columns.Add("Description", typeof(System.String));

            _DisplayData2 = new DataTable();
            _DisplayData2.Columns.Add("Process", typeof(System.String));
            _DisplayData2.Columns.Add("Result", typeof(System.String));
            _DisplayData2.Columns.Add("Description", typeof(System.String));

            tblProcessResult.AutoGenerateColumns = false;
            tblProcessResult.Columns[0].DataPropertyName = "Process";
            tblProcessResult.Columns[1].DataPropertyName = "Result";
            tblProcessResult.Columns[2].DataPropertyName = "Description";

            tblProcessResult.DataSource = _DisplayData;
            tblProcessResult.Refresh();

            _ImageFolder = ImageFolder;
            _IsIncludeSubFolder = IsIncludeSubFolder;
            _LogonUserID = LogonUserID;
        }

        private void WaitingProcessForm_Load(object sender, EventArgs e)
        {
            backgroundWorkerProcess.RunWorkerAsync();
        }

        private void backgroundWorkerProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;

            Decimal _ProgressTotal = 1;

            DataRow dRow = _DisplayData.NewRow();
            dRow["Process"] = "Prepare to Process";
            dRow["Result"] = "On Process";
            dRow["Description"] = "";
            _DisplayData.Rows.Add(dRow);

            dRow = _DisplayData2.NewRow();
            dRow["Process"] = "Prepare to Process";
            dRow["Result"] = "On Process";
            dRow["Description"] = "";
            _DisplayData2.Rows.Add(dRow);

            backgroundWorkerProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

            //---------------------------------------------------------------------------------------------------------------

            _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success";

            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Success";

            dRow = _DisplayData.NewRow();
            dRow["Process"] = "Calculate Total Image to Process";
            dRow["Result"] = "On Process";
            dRow["Description"] = "";
            _DisplayData.Rows.Add(dRow);

            dRow = _DisplayData2.NewRow();
            dRow["Process"] = "Calculate Total Image to Process";
            dRow["Result"] = "On Process";
            dRow["Description"] = "";
            _DisplayData2.Rows.Add(dRow);

            _ProgressTotal = 2;

            backgroundWorkerProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

            //---------------------------------------------------------------------------------------------------------------

            if (_IsIncludeSubFolder)
                ImageList = System.IO.Directory.GetFiles(_ImageFolder, "*.jpg", SearchOption.AllDirectories);
            else
                ImageList = System.IO.Directory.GetFiles(_ImageFolder, "*.jpg", SearchOption.TopDirectoryOnly);

            _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success";
            _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Description"] = ImageList.Length.ToString("#,0") + " Image to Process.";

            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Success";
            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = ImageList.Length.ToString("#,0") + " Image to Process.";

            if (ImageList.Length > 0)
            {
                _IsSuccess = 0;
                _IsFailed = 0;

                progressTotal.Maximum = ImageList.Length + 5;

                dRow = _DisplayData.NewRow();
                dRow["Process"] = "Create Task to Import Image";
                dRow["Result"] = "On Process";
                dRow["Description"] = "";
                _DisplayData.Rows.Add(dRow);

                dRow = _DisplayData2.NewRow();
                dRow["Process"] = "Create Task to Import Image";
                dRow["Result"] = "On Process";
                dRow["Description"] = "";
                _DisplayData2.Rows.Add(dRow);

                _ProgressTotal = 5;

                backgroundWorkerProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

                //---------------------------------------------------------------------------------------------------------------

                for (Int32 Index = 0; Index < ImageList.Length; Index++)
                {
                    if ((Index + 1) % 1 == 0)
                    {
                        _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Description"] = (Index + 1).ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";

                        _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Description"] = (Index + 1).ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";
                    }

                    dRow = _DisplayData2.NewRow();
                    dRow["Process"] = "    " + (Index + 1).ToString("#,0") + " - Import " + ImageList[Index];
                    dRow["Result"] = "On Process";
                    dRow["Description"] = "";
                    _DisplayData2.Rows.Add(dRow);

                    _ProgressTotal++;

                    backgroundWorkerProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

                    //---------------------------------------------------------------------------------------------------------------

                    Byte[] ImageData = null;

                    String ImageItem = ImageList[Index];

                    if (System.IO.File.Exists(ImageItem))
                    {
                        try
                        {
                            ImageData = System.IO.File.ReadAllBytes(ImageItem);
                        }
                        catch (Exception Ex)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = Ex.Message;

                            continue;
                        }

                        if (ImageData == null || ImageData.Length <= 0)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = "No Image Data.";

                            continue;
                        }
                    }
                    else
                    {
                        _IsFailed++;
                        _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                        _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = "File not exists.";

                        continue;
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
                        _IsFailed++;
                        _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                        _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = "Invalid File Format 'B<Book No>_P<Page No>_V<Version No>.jpg'.";

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
                            _IsFailed++;
                            _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Failed";
                            _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Description"] = Ex.Message;

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

                            DOPAGun.SaveImagePage(Convert.ToInt32(sBook), Convert.ToInt32(sPage), Convert.ToInt32(sVersion), _ImageFullPath, _LogonUserID, ImageData);
                        }
                        catch (Exception Ex)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                            _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Description"] = Ex.Message;

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

                        _IsSuccess++;
                        _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Success";

                        /*-- For Test Swap Failed --*/
                        //if (_DisplayData2.Rows.Count % 2 == 1)
                        //{
                        //    _IsFailed++;
                        //    _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Failed";
                        //}
                        //else
                        //{
                        //    _IsSuccess++;
                        //    _DisplayData2.Rows[_DisplayData2.Rows.Count - 1]["Result"] = "Success";
                        //}

                    }
                }

                _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Description"] = ImageList.Length.ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";

                _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Description"] = ImageList.Length.ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";

                if (_IsFailed > 0)
                {
                    _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success with Failed";

                    _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success with Failed";
                }
                else
                {
                    _DisplayData.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success";

                    _DisplayData2.Rows[_DisplayData.Rows.Count - 1]["Result"] = "Success";
                }
            }
        }

        private void backgroundWorkerProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProcessName.Text = "Import Image Bulk.";
            lblProcessName.Refresh();

            lblActionName.Text = _DisplayAction;
            lblActionName.Refresh();

            progressTotal.Value = e.ProgressPercentage;

            tblProcessResult.DataSource = _DisplayData;
            tblProcessResult.Refresh();
        }

        private void backgroundWorkerProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressTotal.Value = progressTotal.Maximum;
            progressTotal.Refresh();

            tblProcessResult.DataSource = _DisplayData2;
            tblProcessResult.Refresh();

            if (_IsFailed > 0)
            {
                lblActionName.Text = "Process Success with Failed.";
                lblActionName.Refresh();

                btnImportFailImage.Enabled = true;

                MessageBox.Show("Process Success with Failed.", "Import Image Bulk", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                lblActionName.Text = "Process Success.";
                lblActionName.Refresh();

                MessageBox.Show("Process Success.", "Import Image Bulk", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            btnClose.Enabled = true;
        }

        private void btnImportFailImage_Click(object sender, EventArgs e)
        {
            btnImportFailImage.Enabled = true;

            backgroundWorkerReProcess.RunWorkerAsync();
        }

        private void backgroundWorkerReProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;

            Decimal _ProgressTotal = 1;

            _DisplayData2.Rows[0]["Result"] = "On Process";

            backgroundWorkerReProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

            //---------------------------------------------------------------------------------------------------------------

            _DisplayData2.Rows[0]["Result"] = "Success";

            _DisplayData2.Rows[1]["Result"] = "On Process";

            _ProgressTotal = 2;

            backgroundWorkerReProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

            //---------------------------------------------------------------------------------------------------------------
            
            List<Int32> ImageFailList = new List<Int32>();

            for (Int32 Index = 3; Index < _DisplayData2.Rows.Count; Index++)
            {
                if (_DisplayData2.Rows[Index]["Result"].ToString().ToUpper() == "FAILED")
                {
                    ImageFailList.Add(Index - 3);
                }
            }

            _DisplayData2.Rows[1]["Result"] = "Success";

            if (ImageFailList.Count > 0)
            {
                progressTotal.Maximum = ImageFailList.Count + 5;

                _DisplayData2.Rows[2]["Result"] = "On Process";

                _ProgressTotal = 5;

                backgroundWorkerReProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

                //---------------------------------------------------------------------------------------------------------------

                _IsFailed = 0;

                for (Int32 Index = 0; Index < ImageFailList.Count; Index++)
                {
                    if ((Index + 1) % 1 == 0)
                    {
                        _DisplayData2.Rows[2]["Description"] = (ImageList.Length - ImageFailList.Count + Index + 1).ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";
                    }

                    _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "On Process";

                    _ProgressTotal++;

                    backgroundWorkerReProcess.ReportProgress(Convert.ToInt32(_ProgressTotal));

                    //---------------------------------------------------------------------------------------------------------------

                    Byte[] ImageData = null;

                    String ImageItem = ImageList[ImageFailList[Index]];

                    if (System.IO.File.Exists(ImageItem))
                    {
                        try
                        {
                            ImageData = System.IO.File.ReadAllBytes(ImageItem);
                        }
                        catch (Exception Ex)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = Ex.Message;

                            continue;
                        }

                        if (ImageData == null || ImageData.Length <= 0)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = "No Image Data.";

                            continue;
                        }
                    }
                    else
                    {
                        _IsFailed++;
                        _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                        _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = "File not exists.";

                        continue;
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
                        _IsFailed++;
                        _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                        _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = "Invalid File Format 'B<Book No>_P<Page No>_V<Version No>.jpg'.";

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
                            _IsFailed++;
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = Ex.Message;

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

                            DOPAGun.SaveImagePage(Convert.ToInt32(sBook), Convert.ToInt32(sPage), Convert.ToInt32(sVersion), _ImageFullPath, _LogonUserID, ImageData);
                        }
                        catch (Exception Ex)
                        {
                            _IsFailed++;
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Failed";
                            _DisplayData2.Rows[ImageFailList[Index] + 3]["Description"] = Ex.Message;

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

                        _IsSuccess++;
                        _DisplayData2.Rows[ImageFailList[Index] + 3]["Result"] = "Success";
                    }
                }

                _DisplayData2.Rows[2]["Description"] = ImageList.Length.ToString("#,0") + " Image to Process. Result : " + _IsSuccess.ToString() + " Success, " + _IsFailed.ToString() + " Failed";

                if (_IsFailed > 0)
                {
                    _DisplayData2.Rows[2]["Result"] = "Success with Failed";
                }
                else
                {
                    _DisplayData2.Rows[2]["Result"] = "Success";
                }
            }
        }

        private void backgroundWorkerReProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProcessName.Text = "Import Image Bulk.";
            lblProcessName.Refresh();

            lblActionName.Text = _DisplayAction;
            lblActionName.Refresh();

            progressTotal.Value = e.ProgressPercentage;

            tblProcessResult.DataSource = _DisplayData2;
            tblProcessResult.Refresh();
        }

        private void backgroundWorkerReProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressTotal.Value = progressTotal.Maximum;
            progressTotal.Refresh();

            tblProcessResult.DataSource = _DisplayData2;
            tblProcessResult.Refresh();

            if (_IsFailed > 0)
            {
                lblActionName.Text = "Process Success with Failed.";
                lblActionName.Refresh();

                btnImportFailImage.Enabled = true;

                MessageBox.Show("Process Success with Failed.", "Import Image Bulk", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                lblActionName.Text = "Process Success.";
                lblActionName.Refresh();

                btnImportFailImage.Enabled = false;

                MessageBox.Show("Process Success.", "Import Image Bulk", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            btnClose.Enabled = true;
        }

        private void tblProcessResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (Int32 RowIndex = 0; RowIndex < tblProcessResult.Rows.Count; RowIndex++)
            {
                for (Int32 ColIndex = 0; ColIndex < tblProcessResult.Columns.Count; ColIndex++)
                {
                    String ChangeText = tblProcessResult.Rows[RowIndex].Cells[ColIndex].Value.ToString().ToUpper();

                    switch (ChangeText)
                    {
                        case "WAITING..":
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Blue;
                            break;
                        case "ON PROCESS":
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.SaddleBrown;
                            break;
                        case "SUCCESS":
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Green;
                            break;
                        case "SUCCESS WITH FAILED":
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Green;
                            break;
                        case "FAILED":
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Red;
                            break;
                        default:
                            tblProcessResult.Rows[RowIndex].Cells[ColIndex].Style.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
