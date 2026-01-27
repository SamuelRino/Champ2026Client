using Champ2026Client.Models;
using System.Buffers.Text;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Champ2026Client
{
    public static class DataUser
    {
        public static User? user;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _menuIsExpanded = false;
        private MainPage mainPage = new();
        private AdministrationVMPage administrationVMPage = new();
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage1(null, null);
        }

        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            fMainFrame.Navigate(mainPage);
        }

        private void NavigateToPage2(object sender, RoutedEventArgs e)
        {
            fMainFrame.Navigate(administrationVMPage);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new();
            image.BeginInit();
            image.StreamSource = new MemoryStream(Convert.FromBase64String(DataUser.user.Image));
            image.EndInit();
            imageUserPhoto.Source = image;

            var parts = DataUser.user.FullName.Split(' ');

            tbUserFullName.Text = $"{parts[0]} {parts[1][0]}. {parts[2][0]}.";
            tbUserRole.Text = DataUser.user.Role;
        }

        private void btnExpand_Click(object sender, RoutedEventArgs e)
        {
            if (_menuIsExpanded)
            {
                cdColumn1.Width = new GridLength(0);
                cdColumn2.Width = new GridLength(0);
                _menuIsExpanded = false;
            }
            else
            {
                cdColumn1.Width = new GridLength(1, GridUnitType.Auto);
                cdColumn2.Width = new GridLength(25);
                _menuIsExpanded = true;
            }
        }

        private void btnVmOpen_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage2(null,null);
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage1(null, null);
        }
    }
}