using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBDemo
{
    /// <summary>
    /// Interaction logic for Conferences.xaml
    /// </summary>
    public partial class Conferences : Window
    {
        //string to tell us where is the database
        private string dbConnection = ConfigurationManager.ConnectionStrings["DBDemo.Properties.Settings.ConfrencesDBConnectionString"].ConnectionString;
        private Conference conference = new Conference();

        public Conferences()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PopulateConferences();
        }

        private void PopulateConferences()
        {
            try
            {
                string command = @"SELECT * from Conferences";
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Cenferences");

                    cmbLoadVisitorForm.ItemsSource = ds.Tables["Cenferences"].Rows;
                    cmbLoadVisitorForm.SelectedValuePath = ".[Id]";
                    cmbLoadVisitorForm.DisplayMemberPath = ".[Name]";

                    cmbLoadVisitorForm.Items.Refresh();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        // check all required values with validation
        private bool ValidateAllValues()
        {
            txtConferenceName.Text.Trim();
            txtContactNumber.Text.Trim();
            dpConferenceDate.SelectedDate.ToString().Trim();

            if (String.IsNullOrEmpty(txtConferenceName.Text)){
                MessageBox.Show("Please enter Conference name", "Requires", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtContactNumber.Text)) {
                MessageBox.Show("Please enter Contact number", "Requires", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (String.IsNullOrEmpty(dpConferenceDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please select Conference Date", "Requires", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //Validate phone formate
            var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
            if (!(r.IsMatch(txtContactNumber.Text.Trim()))){
                MessageBox.Show("Please enter valid phone number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // init conference object values 
            conference.Name = txtConferenceName.Text;
            conference.ContactNum = txtContactNumber.Text;
            conference.ConfDate = dpConferenceDate.SelectedDate.Value;

            return true;
        }



        private void BtnAddConference_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateAllValues()) return;
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    string command = @"INSERT INTO Conferences (Name, ContactNum, ConfDate) VALUES (" +
                        @"'" + conference.Name + @"' ," +
                        @"'" + conference.ContactNum + @"' ," +
                        @"'" + conference.ConfDate + @"' )" ;
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            ////Repopulate my conferences list
            PopulateConferences();
            MessageBox.Show((String.Format("Conference {0} has been added", conference.Name)), "Add succesful",MessageBoxButton.OK);
            
            txtConferenceName.Text =
            txtContactNumber.Text = "";
            dpConferenceDate.Text = "";


        }

        //private void CmbLoadVisitorForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //Load All Visitors form (MainWindow)
        //    //number 1 in the argument list has to be changed later.
        //    string ConferenceName = (cmbLoadVisitorForm.SelectedItem as DataRow)["Name"].ToString();
        //    MainWindow allVisitorsForm = new MainWindow(int.Parse(cmbLoadVisitorForm.SelectedValue.ToString()), ConferenceName);
        //    //Showdialog
        //    allVisitorsForm.ShowDialog();
        //}

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            //Load All Visitors form (MainWindow)
            //number 1 in the argument list has to be changed later.
            if (cmbLoadVisitorForm.SelectedValue == null)
            {
                MessageBox.Show("Please select one conference to load ", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int  ConferenceId = int.Parse(cmbLoadVisitorForm.SelectedValue.ToString());
            GetConferenceObjectById(ConferenceId);
            MainWindow allVisitorsForm = new MainWindow(conference);
            //Showdialog
            allVisitorsForm.ShowDialog();

        }

        private bool GetConferenceObjectById(int _id)
        {
            string command = @"SELECT * FROM Conferences WHERE Id= '" + _id +"'";
            DataSet ds = new DataSet();// moved to class level
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Conferences");

                    if (ds.Tables["Conferences"].Rows.Count == 0)
                    {
                        MessageBox.Show("No data available.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return false;
                    }

                    // updating conference Object
                    var  records          = ds.Tables["Conferences"].Rows;
                    conference.Id         = int.Parse( records[0]["Id"].ToString());
                    conference.Name       = records[0]["Name"].ToString();
                    conference.ContactNum = records[0]["ContactNum"].ToString();
                    conference.ConfDate   = DateTime.Parse(  records[0]["ConfDate"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing DB.\nContact admin.\n" + ex.Message, "DB Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }



        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (cmbLoadVisitorForm.SelectedValue == null)
            {
                MessageBox.Show("Please select one conference to Delete ", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (MessageBox.Show("Record will be deleted permenantly.\nDo you want proceed?", "Delete Record Alert"
                  , MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {

                //Delete Connecting Records from Visitor tables
                if (DeleteRow("Visitors", "ConferenceID", cmbLoadVisitorForm.SelectedValue.ToString())) {

                    //Delete record from Conference Table
                   if ( DeleteRow("Conferences", "Id", cmbLoadVisitorForm.SelectedValue.ToString()))
                    {
                        string ConferenceName = (cmbLoadVisitorForm.SelectedItem as DataRow)["Name"].ToString();
                        MessageBox.Show((String.Format("Conference{0} has been Deleted!", ConferenceName)), "Delete Succesful", MessageBoxButton.OK);
                        PopulateConferences();
                    }
                    
                } 
            }
        }


        private  bool DeleteRow(string table, string columnName, string IDNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE " + columnName + " = '" + IDNumber + "'", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                return false;
            }
            return true;
        }
    }
}
