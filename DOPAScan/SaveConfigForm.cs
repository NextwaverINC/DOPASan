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
    public partial class SaveConfigForm : Form
    {
        public Boolean _IsSaveConfigComplete = false;

        public SaveConfigForm(String Rotate, String FlipX, String FlipY, String Brightness, String Contrast, String CropLeft, String CropTop, String CropWidth, String CropHeight, String ResizeWidth, String ResizeHeight)
        {
            InitializeComponent();

            txtConfigName.Text = "";
            txtRotate.Text = Rotate;

            if (FlipX == "1")
                txtFlipHorizontal.Text = "true";
            else
                txtFlipHorizontal.Text = "false";

            if (FlipY == "1")
                txtFlipVertical.Text = "true";
            else
                txtFlipVertical.Text = "false";

            txtBrightness.Text = Brightness;
            txtContrast.Text = Contrast;
            txtLeft.Text = CropLeft;
            txtTop.Text = CropTop;
            txtWidth.Text = CropWidth;
            txtHeight.Text = CropHeight;
            txtResizeWidth.Text = ResizeWidth;
            txtResizeHeight.Text = ResizeHeight;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (txtConfigName.Text.Trim() == "")
            {
                MessageBox.Show("Please input Config Name.", "Save Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (txtConfigName.Text.Trim().ToUpper() == "NONE")
            {
                MessageBox.Show("Please input Other Config Name, Config Name '" + txtConfigName.Text.Trim() + "' is Reserved.", "Save Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            String[] EditImageTemplate = System.IO.File.ReadAllLines("EditImageTemplate.config");
            Boolean IsDuplicateName = false;

            foreach (String EditImageTemplateItem in EditImageTemplate)
            {
                if (EditImageTemplateItem.Contains(txtConfigName.Text.Trim() + "|"))
                {
                    IsDuplicateName = true;
                    break;
                }
            }

            if (IsDuplicateName)
            {
                MessageBox.Show("Config Name Is Duplicate, Please input Other Config Name.", "Save Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            String _FlipX = "0";
            if (txtFlipHorizontal.Text == "true")
                _FlipX = "1";

            String _FlipY = "0";
            if (txtFlipVertical.Text == "true")
                _FlipY = "1";

            List<String> newConfig = new List<String>();
            newConfig.Add(txtConfigName.Text.Trim() + "|"
                         + txtRotate.Text + "|"
                         + _FlipX + "|"
                         + _FlipY + "|"
                         + txtBrightness.Text + "|"
                         + txtContrast.Text + "|"
                         + txtLeft.Text + "|"
                         + txtTop.Text + "|"
                         + txtWidth.Text + "|"
                         + txtHeight.Text + "|"
                         + txtResizeWidth.Text + "|"
                         + txtResizeHeight.Text + "|"
                         + "0");

            try
            {
                System.IO.File.AppendAllLines("EditImageTemplate.config", newConfig);

                MessageBox.Show("Save Config Cmplete.", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                _IsSaveConfigComplete = true;
                this.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Save Config Error: " + Ex.Message, "Save Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCancelConfig_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
