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

namespace CExam2
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtTelephone.Text = "";

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (txtFirstName.TextLength <= 0)
            {
                MessageBox.Show("Please Enter First name" , "Waring");
                return;
            }

            if (txtLastName.TextLength <= 0)
            {
                MessageBox.Show("Please Enter Last name", "Waring");
                return;
            }
            if (txtTelephone.TextLength <= 0)
            {
                MessageBox.Show("Please Enter Telephone number", "Waring");
                return;
            }

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string telephone = txtTelephone.Text;

            // creating user class object
            User user = new User(firstName, lastName, telephone);


            try
            {
                string fpath = @"c:\temp\Users.txt";
               
                using (StreamWriter sw = new StreamWriter(fpath, true))
                {
                    sw.WriteLine("First name: " + firstName + "Last name: " + lastName + "Telephone: " + telephone);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message ,"Error");
            }
            MessageBox.Show("User has been added to the file", "Add User Sucess!");
            txtFirstName.Text ="";
            txtLastName.Text ="";
            txtTelephone.Text = "";


        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string fpath = @"c:\temp\Users.txt";

            try
            {
                if (File.Exists(fpath))
                {
                    
                    File.Delete(fpath);
                    MessageBox.Show("Users file has been deleted", "Delete File");

                }
            }catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error");
            }
        }

        private void btnUserCount_Click(object sender, EventArgs e)
        {
            int count = 0;

            try
            {
                string fpath = @"c:\temp\Users.txt";
               
                using (StreamReader sr = new StreamReader(fpath))
                {
                    String s;

                    while ((s = sr.ReadLine()) != null)
                    {
                       count++;
                    }
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error");
            }

            MessageBox.Show("Number of User added " + count, "User Count");
        }
    }
}
