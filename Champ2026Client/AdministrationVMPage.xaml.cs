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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Champ2026Client
{
    public static class DataMachine
    {
        public static VendingMachine? machine;
    }
    /// <summary>
    /// Логика взаимодействия для AdministrationVMPage.xaml
    /// </summary>
    public partial class AdministrationVMPage : Page
    {
        DispatcherTimer _timer;
        int totalRecords;
        int recordsPerPage;
        int currentPage;
        int totalPages;
        public AdministrationVMPage()
        {
            InitializeComponent();
            currentPage = 0;
            recordsPerPage = 10;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(10);
            Timer_tick();
            _timer.Tick += (sender, e) => Timer_tick();
            _timer.Start();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var machine = btn.DataContext as VendingMachine;

            DataMachine.machine = machine; 

            AddEditMachine w = new AddEditMachine();
            w.Show();
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что желаете удалить автомат?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Button btn = (Button)sender;
                    var machine = btn.DataContext as VendingMachine;

                    using (User102Context c = new())
                    {
                        var m = c.VendingMachines.FirstOrDefault(m => m.Id == machine.Id);
                        m.IsDeleted = true;
                        c.SaveChanges();
                    }

                    Refresh();
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка");
                }
            }
        }

        private void btnLock_click(object sender, RoutedEventArgs e)
        {

        }

        private void Timer_tick()
        {
            Refresh();
        }

        private void Refresh()
        {
            if (IsInitialized)
            {
                using (User102Context c = new())
                {
                    var machines = c.VendingMachines.Include(m => m.Model).Include(m => m.Company).Where(m => m.IsDeleted != true).Skip(recordsPerPage * currentPage).Take(recordsPerPage).ToList();
                    lvMachines.ItemsSource = machines;
                    totalRecords = c.VendingMachines.Count();
                    totalPages = totalRecords / recordsPerPage;
                    if (totalPages * recordsPerPage < totalRecords) totalPages++;
                    tbRecordsCount.Text = $"Всего найдено {totalRecords} шт.";
                    if (currentPage != totalPages-1) tbShowing.Text = $"Записи с {recordsPerPage * currentPage + 1} до {recordsPerPage * currentPage + recordsPerPage} из {totalRecords}";
                    else tbShowing.Text = $"Записи с {recordsPerPage * currentPage + 1} до {totalRecords} из {totalRecords}";
                }
                AddPageButtons();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbShowRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsInitialized)
            {
                currentPage = 0;
                switch (cbShowRecords.SelectedIndex)
                {
                    case 0:
                        recordsPerPage = totalRecords;
                        break;
                    case 1:
                        recordsPerPage = 5;
                        break;
                    case 2:
                        recordsPerPage = 4;
                        break;
                }
                Refresh();
            }         
        }

        private void AddPageButtons()
        {
            spPageButtons.Children.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                Button btn = new Button() { Width = 40, Content=i.ToString() };
                btn.Click += btnNumberPage_Click;

                spPageButtons.Children.Add(btn);
            }
        }

        private void btnNumberPage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int number = Convert.ToInt32(btn.Content);

            currentPage = number-1;

            Refresh();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
            }
            Refresh();
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < totalPages-1)
            {
                currentPage++;
            }
            Refresh();
        }

        private void btnAddMachine_Click(object sender, RoutedEventArgs e)
        {
            DataMachine.machine = null;
            AddEditMachine w = new AddEditMachine();
            w.Show();
        }
    }
}
