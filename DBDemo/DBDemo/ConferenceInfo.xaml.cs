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

namespace DBDemo
{
    /// <summary>
    /// Interaction logic for ConferenceInfo.xaml
    /// </summary>
    public partial class ConferenceInfo : Window
    {
        public ConferenceInfo(Conference _conference)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Height;
            this.SizeToContent = SizeToContent.Width;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            txtName.Text          = _conference.Name;
            txtContactNumber.Text = _conference.ContactNum;
            dpConferneceDate.SelectedDate = _conference.ConfDate; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
