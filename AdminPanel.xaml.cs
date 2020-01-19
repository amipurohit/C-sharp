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
using System.Windows.Shapes;
using Test3_Bank.Model;

namespace Test3_Bank
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        UserViewModel repo = new UserViewModel();
        MainWindow mainWindow;

        public AdminPanel(MainWindow _mainWindow)
        {
            InitializeComponent();
            SizeToContent = SizeToContent.Width;
            SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            mainWindow = _mainWindow;
            dgUserLog.ItemsSource = repo.GetAllUsersData();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            dgUserLog.ItemsSource = repo.GetAllUsersData();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgUserLog.SelectedItem == null)
            {
                MessageBox.Show("Please selected a record first to update");
                return;
            }
            else
            {
                User user = dgUserLog.SelectedItem as User;
                UpdateUser updateUser = new UpdateUser(user);
                updateUser.ShowDialog();
                dgUserLog.ItemsSource = repo.GetAllUsersData();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgUserLog.SelectedItem == null)
            {
                MessageBox.Show("Please selected a record first to update");
                return;
            }

            if (dgUserLog.SelectedItem != null && MessageBox.Show("Are you sure you want to delete?\n" +
               "This will delete the User Account records as well", "Confirm Delete"
               , MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                try
                {
                    var currentUser = dgUserLog.SelectedItem as User;
                    repo.DeleteUserRecord(currentUser.ID);
                    dgUserLog.ItemsSource = repo.GetAllUsersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void DataWindow_Closing(Object sender, EventArgs e)
        {
            mainWindow.btnLogin.Content = "Login";
            mainWindow.Show();
        }

    }
}
