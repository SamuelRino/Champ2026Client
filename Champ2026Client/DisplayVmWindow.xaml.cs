using Champ2026Client.classes;
using Champ2026Client.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        List<DisplayVmDTO> _AllMachines;
        List<DisplayVmDTO> _CurrentMachines;
        public DisplayVmWindow()
        {
            InitializeComponent();           
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var display = await _api.GetDisplayVmAsync();
            _AllMachines = display;
            _CurrentMachines = display;
            Refresh();
        }

        public void Refresh()
        {
            for (int i = 0; i < _CurrentMachines.Count; i++)
            {
                _CurrentMachines[i].Id = i + 1;
            }
            lvDisplay.ItemsSource = _CurrentMachines;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var btn = (ToggleButton)sender;
            var panel = (StackPanel)VisualTreeHelper.GetParent(btn);

            foreach (ToggleButton tb in panel.Children)
            {
                if (tb != btn) tb.IsChecked = false;
            }
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            _CurrentMachines = _AllMachines;

            int status = 0;
            for (int i = 0; i < 3; i++)
            {
                if (((ToggleButton)VisualTreeHelper.GetChild(spTotalStates,i)).IsChecked == true)
                {
                    status = i+1;
                }
            }

            bool controlMode = false;
            int conType = -1;
            for (int i = 0; i < 4; i++)
            {
                if (((ToggleButton)VisualTreeHelper.GetChild(spConnection, i)).IsChecked == true)
                {
                    if (i == 0) controlMode = true;
                    else conType = i-1; 
                }
            }

            bool billAcceptor = false;
            if (((ToggleButton)VisualTreeHelper.GetChild(spStatuses, 1)).IsChecked == true)
            {
                billAcceptor = true;
            }

            if (status != 0)
            {
                _CurrentMachines = _CurrentMachines.Where(m => m.StatusId == status).ToList();
            }

            if (controlMode)
            {
                _CurrentMachines = _CurrentMachines.Where(m => m.ControleMode == 1).ToList();
            }

            if (conType != -1)
            {
                _CurrentMachines = _CurrentMachines.Where(m => m.ComType == conType).ToList();
            }

            if (billAcceptor)
            {
                _CurrentMachines = _CurrentMachines.Where(m => m.BillValidatorOk == 0).ToList();
            }
            Refresh();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            StackPanel[] panels = new StackPanel[] { spTotalStates, spConnection, spStatuses };

            foreach (StackPanel sp in panels)
            {
                foreach (ToggleButton tb in sp.Children)
                {
                    tb.IsChecked = false;
                }
            }
            _CurrentMachines = _AllMachines;
            Refresh();
        }
    }
}
