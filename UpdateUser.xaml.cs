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
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        User user;
        public UpdateUser(User _user)
        {
            InitializeComponent();
            SizeToContent = SizeToContent.Height;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            user = _user;

            txtID.Text = user.ID.ToString();
            txtAccountNumber.Text = user.Account.Id.ToString();


        }

        private void BtnUpdateUser_Click(object sender, RoutedEventArgs e)
        {

            // new name is required
            if (string.IsNullOrEmpty(txtNewName.Text))
            {
                MessageBox.Show("Please enter new User Name", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Password is required
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter new User Password", "Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            user.Name = txtNewName.Text;
            user.Password = txtPassword.Text;

            UserViewModel repo = new UserViewModel();
            repo.UpdateUser(user);

            Close();

        }
    }
}
