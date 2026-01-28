using Champ2026Client.classes;
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

namespace Champ2026Client
{
    /// <summary>
    /// Логика взаимодействия для DisplayVmWindow.xaml
    /// </summary>
    public partial class DisplayVmWindow : Page
    {
        ApiService _api = new();
        public DisplayVmWindow()
        {
            InitializeComponent();           
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var display = await _api.GetDisplayVmAsync();
            for (int i = 0; i < display.Count; i++)
            {
                display[i].Id = i+1;
            }
            lvDisplay.ItemsSource = display;
        }
    }
}
