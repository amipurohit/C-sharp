using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz3
{
    public partial class frmCarwash : Form
    {
        public frmCarwash()
        {
            InitializeComponent();
        }

        private void rbtnCar_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnOwner_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnCar_Click(object sender, EventArgs e)
        {
            grpOwner.Enabled =false;
            grpCar.Enabled = true;
        }

        private void rbtnOwner_Click(object sender, EventArgs e)
        {
            grpCar.Enabled = false;
            grpOwner.Enabled = true;
        }

        private void frmCarwash_Load(object sender, EventArgs e)
        {
            
            cmbMake.Items.Add("HONDA");
            cmbMake.Items.Add("BMW");
            cmbMake.Items.Add("AUDI");

            cmbYear.Items.Add(2014);
            cmbYear.Items.Add(2015);
            cmbYear.Items.Add(2016);
            cmbYear.Items.Add(2017);
            cmbYear.Items.Add(2018);
            cmbYear.Items.Add(2019);

        }

        private void cmbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMake.SelectedItem == null) return;
            if (cmbMake.SelectedItem.ToString() == "HONDA")
            {
                cmbModel.Items.Clear();
                cmbModel.Items.Add("Accord");
                cmbModel.Items.Add("Civic");
                cmbModel.Items.Add("Sedan");

            } else if(cmbMake.SelectedItem.ToString() == "BMW")
            {
                cmbModel.Items.Clear();
                cmbModel.Items.Add("BMW M3");
                cmbModel.Items.Add("BMW Z4");
                cmbModel.Items.Add("BMW X5");

            }else if (cmbMake.SelectedItem.ToString() == "AUDI")
            {
                cmbModel.Items.Clear();
                cmbModel.Items.Add("Audi A7 Sportback");
                cmbModel.Items.Add("Audi A8");
                cmbModel.Items.Add("Audi TT");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtTelephone.Text = "";
            cmbModel.SelectedItem = null;
            cmbMake.SelectedItem = null;
            cmbYear.SelectedItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbMake.SelectedItem == null)
            //{
            //    MessageBox.Show("Must select car Make", "Required");
            //}
            //if (cmbModel.SelectedItem == null)
            //{
            //    MessageBox.Show("Must select car Model", "Required");
            //}
            //if (cmbYear.SelectedItem == null)
            //{
            //    MessageBox.Show("Must select car Year", "Required");
            //}

            //if (txtFirstname.Text == "")
            //{
            //    MessageBox.Show("Must Enter Owner first name", "Required");
            //}
            //if (txtLastName.Text == "")
            //{
            //    MessageBox.Show("Must Enter Owner First Name", "Required");
            //}
            //if (txtTelephone.Text == "")
            //{
            //    MessageBox.Show("Must Enter Owner Telephone", "Required");
            //}


            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Title = "Save File";
            savedlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savedlg.ShowDialog() == DialogResult.OK)
            {
                string temp = "  [Make: " + cmbMake.SelectedItem.ToString()
               + " Model: " + cmbModel.SelectedItem.ToString()
               + " Year: " + cmbYear.SelectedItem.ToString()
               + " ] "
               + " [ "
               + " Owner First name: "
               + txtFirstname.Text
               + " Last name: "
               + txtLastName.Text
               + " Telephone "
               + txtTelephone.Text
               + " ] ";

                FileStream fs = new FileStream(savedlg.FileName, FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(temp);
                }

                MessageBox.Show(temp, "Sucess");
            }


        }
    }
}
