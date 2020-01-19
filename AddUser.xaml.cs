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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        UserViewModel repo = new UserViewModel();

        public AddUser()
        {
            InitializeComponent();
            SizeToContent = SizeToContent.Width;
            SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            // Id is required
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter User Id", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Password is required
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please enter User Password", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User user = new User
            {
                Name = txtName.Text,
                Password = txtPassword.Password,
                Account = new Account
                {
                    Balance = 0,
                }
            };

            repo.AddNewUser(user);
          
            Close();
        }


        public void AddTempUser()
        {
            List<User> users = new List<User>
            {
                new User()
                {
                    Name = "admin",
                    Password = "1234",
                    Account = new Account
                    {
                        Balance = 0,
                    }
                }
            };

            repo.AddNewUser(users[0]);

            users.Add(new User()
            {
                Name = "Test",
                Password = "1111",
                Account = new Account
                {
                    Balance = 1110,
                }
            });

            repo.AddNewUser(users[1]);

        }

    }
}
