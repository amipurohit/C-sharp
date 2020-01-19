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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        MainWindow mainWindow; 

        public LoginWindow(MainWindow _mainWindow)
        {
            InitializeComponent();
           
            txtPassword.MaxLength = 20;
            
            SizeToContent = SizeToContent.Width;
            SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            mainWindow = _mainWindow;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Id is required
            if (string.IsNullOrEmpty(txtId.Text)) {
                MessageBox.Show("Please enter User Id", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Password is required
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please enter User Password", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //validate user exist
            UserViewModel repo = new UserViewModel();
            int userId;
            if (! int.TryParse(txtId.Text, out userId))
            {
                MessageBox.Show("Please enter valid user Id, Id must be numeric value", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //check user exist by id and password 
            if (repo.CheckUserExistByIdAndPassword(userId, txtPassword.Password))
            {
                // get user object from dbcontext
                User user = repo.GetUserByIdAndPassword(userId, txtPassword.Password);

                // display welcome message
                MessageBox.Show("Welcome " + user.Name, "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                if (user.Name == "admin")
                {
                    AdminPanel adminWindow = new AdminPanel(mainWindow);
                    adminWindow.Show();
                    this.Close();
                }
                else
                {
                    mainWindow.DisplayUserInfo(user);
                    mainWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid user Id and  Password", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
