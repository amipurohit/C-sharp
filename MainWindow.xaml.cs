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
using Test3_Bank.Model;

namespace Test3_Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user;
        UserViewModel repo = new UserViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            HideAllControls();
        }


        public void  DisplayUserInfo(User _user)
        {

            // copy user 
            user = _user;

            VisibleAllControls();

            //Disable User Id 
            txtID.IsEnabled = false;
            txtID.Text = user.ID.ToString();

            //Disable User name
            txtName.IsEnabled = false;
            txtName.Text = user.Name;

            //Disable account balance
            txtBalance.IsEnabled = false;
            txtBalance.Text = user.Account.Balance.ToString("c");

            txtAmount.IsEnabled = true;

            btnDeposite.IsEnabled = true;
            btnWithdraw.IsEnabled = true;

            
        }



        public void  VisibleAllControls()
        {
            txtID.Visibility       = Visibility.Visible;
            txtbID.Visibility      = Visibility.Visible;
            txtName.Visibility     = Visibility.Visible;
            txtbName.Visibility    = Visibility.Visible;
            txtbAmount.Visibility  = Visibility.Visible;
            txtAmount.Visibility   = Visibility.Visible;
            txtBalance.Visibility  = Visibility.Visible;
            txtbBalance.Visibility = Visibility.Visible;
            btnDeposite.Visibility = Visibility.Visible;
            btnWithdraw.Visibility = Visibility.Visible;

            // hide welcome text
            txtbwelcome.Visibility = Visibility.Hidden;
        }


        public void HideAllControls()
        {
            txtID.Visibility = Visibility.Hidden;
            txtbID.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Hidden;
            txtbName.Visibility = Visibility.Hidden;
            txtbAmount.Visibility = Visibility.Hidden;
            txtAmount.Visibility = Visibility.Hidden;
            txtBalance.Visibility = Visibility.Hidden;
            txtbBalance.Visibility = Visibility.Hidden;
            btnDeposite.Visibility = Visibility.Hidden;
            btnWithdraw.Visibility = Visibility.Hidden;

            //  welcome text
            txtbwelcome.Visibility = Visibility.Visible;
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Logout")
            {
                HideAllControls();
                user = null;
                btnLogin.Content = "Login";
            } else if (btnLogin.Content.ToString() == "Login") {
                this.Hide();
                btnLogin.Content = "Logout";
                LoginWindow loginWindow = new LoginWindow(this);
                loginWindow.ShowDialog();
            }
        }

     

        private void BtnDeposite_Click(object sender, RoutedEventArgs e)
        {

            if (Double.TryParse(txtAmount.Text, out double amount))
            {
                if (amount < 0)
                {
                    MessageBox.Show("Amount can not be less then 0 ", "Invalid Value", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                //save to data 
                repo.UpdateUserBalance(user, UserViewModel.TRANSACTION_TYPE_DEPOSIT, amount);
                MessageBox.Show("Transaction SuccessFul!", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                // reset balance data
                txtBalance.Text = user.Account.Balance.ToString("c");
                txtAmount.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter valide amount", "Invalid Value", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void BtnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            //validate amount enter by user
            if (Double.TryParse(txtAmount.Text, out double amount))
            {

                if (amount < 0)
                {
                    MessageBox.Show("Amount can not be less then 0 ", "Invalid Value", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (user.Account.Balance < amount)
                {
                    MessageBox.Show("You cannot withdraw more than " + txtBalance.Text, "Invalid Value", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
           
                //save  to database
                repo.UpdateUserBalance(user, UserViewModel.TRANSACTION_TYPE_WITHDRAW, amount);
                MessageBox.Show("Transaction SuccessFul!", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                // reset balance data
                txtBalance.Text = user.Account.Balance.ToString("c");
                txtAmount.Text = "";

            }
            else
            {
                MessageBox.Show("Please enter valide amount", "Invalid Value", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        

       
    }
}
