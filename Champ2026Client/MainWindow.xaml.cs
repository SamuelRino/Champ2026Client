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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _menuIsExpanded = false;
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage1(null, null);
        }

        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            fMainFrame.Navigate(new MainPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           

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
    }
}