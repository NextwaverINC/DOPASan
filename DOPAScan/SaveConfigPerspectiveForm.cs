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
    public partial class SaveConfigPerspectiveForm : Form
    {
        public Boolean _IsSaveConfigComplete = false;

        public SaveConfigPerspectiveForm(String TL_X, String TL_Y, String TR_X, String TR_Y, String BL_X, String BL_Y, String BR_X, String BR_Y)
        {
            InitializeComponent();

            txtConfigName.Text = "";
            txtTL_X.Text = TL_X;
            txtTL_Y.Text = TL_Y;
            txtTR_X.Text = TR_X;
            txtTR_Y.Text = TR_Y;
            txtBL_X.Text = BL_X;
            txtBL_Y.Text = BL_Y;
            txtBR_X.Text = BR_X;
            txtBR_Y.Text = BR_Y;
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

            String[] PerspectiveImageTemplate = System.IO.File.ReadAllLines("PerspectiveImageTemplate.config");
            Boolean IsDuplicateName = false;

            foreach (String PerspectiveImageTemplateItem in PerspectiveImageTemplate)
            {
                if (PerspectiveImageTemplateItem.Contains(txtConfigName.Text.Trim() + "|"))
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

            List<String> newConfig = new List<String>();
            newConfig.Add(txtConfigName.Text.Trim() + "|"
                         + txtTL_X.Text + "|"
                         + txtTL_Y.Text + "|"
                         + txtTR_X.Text + "|"
                         + txtTR_Y.Text + "|"
                         + txtBL_X.Text + "|"
                         + txtBL_Y.Text + "|"
                         + txtBR_X.Text + "|"
                         + txtBR_Y.Text + "|"
                         + "0");

            try
            {
                System.IO.File.AppendAllLines("PerspectiveImageTemplate.config", newConfig);

                MessageBox.Show("Save Config Cmplete.", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                _IsSaveConfigComplete = true;
                this.Close();
            }
            catch (Exception Ex)
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
