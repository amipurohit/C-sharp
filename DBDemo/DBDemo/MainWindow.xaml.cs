using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;

namespace DBDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string to tell us where is the database
        private string dbConnection = ConfigurationManager.ConnectionStrings["DBDemo.Properties.Settings.ConfrencesDBConnectionString"].ConnectionString;
        private int conferenceID;
        private DataSet ds = new DataSet();
        Conference conference;

        public MainWindow(Conference _conference)
        {
            conference   = _conference;
            conferenceID = conference.Id;
            InitWindow(conference.Id, conference.Name);
        } 


        public MainWindow(int _conferenceID, string title)
        {
            InitWindow(_conferenceID, title);
        }



        public void InitWindow(int _conferenceID, string title)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            conferenceID = _conferenceID;
            PopulateCountries();
            LoadAllData();
            this.Title = title + " Conference - Visitor Information";
            txtbconferenceTitle.Text = title + " Confernece";
        }


        private void LoadAllData()
        {
            string command = @"SELECT * FROM Visitors WHERE ConferenceID=" + conferenceID;
            //DataSet ds = new DataSet(); moved to class level
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Visitors");

                    gridDbData.ItemsSource = ds.Tables["Visitors"].DefaultView;//dt.DefaultView;
                    gridDbData.Items.Refresh();

                    if (ds.Tables["Visitors"].Rows.Count == 0)
                        MessageBox.Show("No data available.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing DB.\nContact admin.\n" + ex.Message, "DB Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLoadAllData_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"SELECT * from Visitors");
            FilterVisitorTable("");
        }

        private void BtnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"SELECT * from Visitors WHERE FullName LIKE'%"+txtName.Text+@"%'");
            FilterVisitorTable(@"FullName LIKE'%" + txtName.Text + @"%'");
            txtName.Text = "";
        }

        private void FilterVisitorTable(string filter)
        {
            try
            {
                //ds.Tables["Visitors"].DefaultView.RowFilter = "";
                ds.Tables["Visitors"].DefaultView.RowFilter = filter;
                gridDbData.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void CmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //QueryVisitorTable(@"SELECT * from Visitors WHERE Country ='"+ cmbCountries.SelectedValue.ToString() + @"'");
            FilterVisitorTable(@"Country = '" + cmbCountries.SelectedValue.ToString() + @"'");
        }

        private void PopulateCountries()
        {
            try
            {
                string command = @"SELECT Name from Countries";
                //DataSet ds = new DataSet(); //Moved to class level
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Countries");

                    cmbCountries.ItemsSource = ds.Tables["Countries"].Rows;
                    cmbCountries.SelectedValuePath = ".[Name]";
                    cmbCountries.DisplayMemberPath = ".[Name]";

                    cmbCountries.Items.Refresh();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ChkSpeaker_Click(object sender, RoutedEventArgs e)
        {
            //QueryVisitorTable(@"SELECT * from Visitors WHERE Speaker ='" +chkSpeaker.IsChecked.Value + @"'");
            FilterVisitorTable(@"Speaker ='" + chkSpeaker.IsChecked.Value + @"'");
        }

        private void BtnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
                FilterVisitorTable(
                    "CheckinDate >= #" + dpStartDate.SelectedDate.Value + "# AND " +
                    "CheckinDate <= #" + dpEndDate.SelectedDate.Value + "#");
            /*QueryVisitorTable(@"SELECT * from Visitors WHERE CheckinDate BETWEEN '" +
                dpStartDate.SelectedDate.Value + @"' AND '" +
                dpEndDate.SelectedDate.Value + @"'");*/
            else
                MessageBox.Show("Error: please enter a date first", "Date Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //REMOVED
        private void QueryVisitorTable(string command)
        {
            //Command: SQL
            //string command;
            //Dataset: class allows me to save data extracted from DB
            DataSet ds = new DataSet();
            //DataTable to save the dataset
            //DataTable dt;
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {

                    SqlCommand cmd = new SqlCommand(command, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "Visitors");

                    gridDbData.ItemsSource = ds.Tables["Visitors"].DefaultView;//dt.DefaultView;
                    gridDbData.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing DB.\nContact admin.\n" + ex.Message, "DB Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddVisitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorsWindow newVisitorWindow = new VisitorsWindow(ds.Tables["Countries"].Rows);
            if (newVisitorWindow.ShowDialog().Value)
            {
                //Add to the database
                Visitor v = newVisitorWindow.VisitorInfo;
                string command =
                            "INSERT INTO Visitors " +
                            "(FullName, Major, Country, Status, Speaker, CheckinDate, ConferenceID) VALUES (" +
                            @"'" + v.FullName + @"', " +
                            @"'" + v.Major + @"', " +
                            @"'" + v.Country + @"', " +
                            @"'" + v.VisitorStatus.ToString() + @"', " +
                            @"'" + v.IsSpeaker + @"', " +
                            @"'" + v.CheckInDate + @"', " +
                            conferenceID + ")";
                ExecuteNonQuery(command);
                
            }
        }

        private void BtnEditVisitorInfo_Click(object sender, RoutedEventArgs e)
        {
            if (gridDbData.SelectedIndex >= 0 && gridDbData.SelectedIndex != gridDbData.Items.Count)
            {
                DataRowView r = gridDbData.SelectedItem as DataRowView;
                Visitor existing = GetVisitorObject(r); /*new Visitor()
                {
                    FullName = r["FullName"].ToString(),
                    Major = r["Major"].ToString(),
                    Country = r["Country"].ToString(),
                    VisitorStatus = r["Status"].ToString() == Status.Teacher.ToString() ? Status.Teacher :
                                      r["Status"].ToString() == Status.Student.ToString() ? Status.Student : Status.Proffessional,
                    IsSpeaker = bool.Parse(r["Speaker"].ToString()),
                    CheckInDate = DateTime.Parse(r["CheckinDate"].ToString())
                };*/
                //MessageBox.Show(gridDbData.SelectedItem.ToString());
                VisitorsWindow modifyVisitor = new VisitorsWindow(ds.Tables["Countries"].Rows, existing);

                if (modifyVisitor.ShowDialog().Value)
                {
                    Visitor v = modifyVisitor.VisitorInfo;
                    string command =
                                "UPDATE Visitors SET " +
                                @"FullName ='" + v.FullName + @"', " +
                                @"Major ='" + v.Major + @"', " +
                                @"Country ='" + v.Country + @"', " +
                                @"Status ='" + v.VisitorStatus.ToString() + @"', " +
                                @"Speaker ='" + v.IsSpeaker + @"', " +
                                @"CheckinDate ='" + v.CheckInDate + @"' WHERE Id=" + r["Id"];
                    ExecuteNonQuery(command);                    
                }

            }
            else
                MessageBox.Show("Please select a record first", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridDbData.SelectedIndex >= 0 && gridDbData.SelectedIndex != gridDbData.Items.Count)
            {
                if(MessageBox.Show("Record will be deleted permenantly.\nDo you want proceed?","Delete Record Alert"
                    ,MessageBoxButton.YesNo,MessageBoxImage.Stop) == MessageBoxResult.Yes)
                {
                    DataRowView r = gridDbData.SelectedItem as DataRowView;
                    string command = "Delete From Visitors WHERE Id=" + r["Id"];
                    ExecuteNonQuery(command);
                }
            }
            else
                MessageBox.Show("Please select a record first","No Selection", MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void ExecuteNonQuery(string command)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(dbConnection))
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Updating my grid.
                    ds.Tables["Visitors"].Clear();
                    LoadAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveToCSV_Click(object sender, RoutedEventArgs e)
        {
            //Make sure there is data to save.
            if (gridDbData.Items.Count == 1)
                MessageBox.Show("Visitor's List is empty.\nAdd visitors to the list first.", "Alert",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            else
            {
                // First Choose where to save to
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CVS File|*.csv";

                //Make sure the sure chose a file name and location
                if (saveFileDialog.ShowDialog() == true)
                {
                    StringBuilder report = new StringBuilder();
                    //Adding title to the report
                    report.AppendLine(this.Title.ToString());
                    //Adding table header
                    report.AppendLine("Full Name,Major,Country,Status,Is Speaker,Checkin Date");
                    //Extract data from the grid >> utilize the Visitor's class
                    for (int i = 0; i < gridDbData.Items.Count-1; i++)
                    {
                        report.AppendLine(GetVisitorObject(gridDbData.Items[i] as DataRowView).AllData);
                    }

                    //Save to a file
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, report.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving report to CSV\n"+ex.Message, "Error Saving",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //Message of Confirmation
                    MessageBox.Show("Report saved succesfully.\nLocation: "+saveFileDialog.FileName, "Report Saved",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        private Visitor GetVisitorObject(DataRowView r)
        {
            return new Visitor()
            {
                FullName = r["FullName"].ToString(),
                Major = r["Major"].ToString(),
                Country = r["Country"].ToString(),
                VisitorStatus = r["Status"].ToString() == Status.Teacher.ToString() ? Status.Teacher :
                                      r["Status"].ToString() == Status.Student.ToString() ? Status.Student : Status.Proffessional,
                IsSpeaker = bool.Parse(r["Speaker"].ToString()),
                CheckInDate = DateTime.Parse(r["CheckinDate"].ToString())
            };
        }

        private void ConferenceInfo_Click(object sender, RoutedEventArgs e)
        {

            ConferenceInfo conInfoDlg = new ConferenceInfo(conference);
            conInfoDlg.ShowDialog();

            //MessageBox.Show(conference.ToString(), "Conference Information", MessageBoxButton.OK, MessageBoxImage.Information );
        }
    }
}
