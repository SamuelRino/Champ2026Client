using Champ2026Client.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Champ2026Client
{
    /// <summary>
    /// Логика взаимодействия для AddEditMachine.xaml
    /// </summary>
    public partial class AddEditMachine : Window
    {
        public AddEditMachine()
        {
            InitializeComponent();

            using (User102Context c = new())
            {
                cbModel.ItemsSource = c.Models.Select(m => m.Model1).ToList();
                cbWorkMode.ItemsSource = c.WorkModes.Select(m => m.WorkMode1).ToList();
                cbTimezone.ItemsSource = c.Timezones.Select(z => z.Timezone1).ToList();
            }

            if (DataMachine.machine != null)
            {
                using (User102Context c = new())
                {                   
                    var machines = c.VendingMachines.Include(m => m.WorkMode).Include(m => m.Model);
                    var machine = machines.FirstOrDefault(m => m.Id == DataMachine.machine.Id);
                    cbModel.DataContext = machine;
                    cbWorkMode.DataContext = machine;
                    cbTimezone.DataContext = machine;
                }                
            }
        }
    }
}
