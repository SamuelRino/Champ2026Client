using Champ2026Client.Models;
using Microsoft.Data.SqlClient;
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
        private VendingMachine machine;
        private User102Context c = new();
        public AddEditMachine()
        {
            InitializeComponent();

            cbModel.ItemsSource = c.Models.ToList();
            cbModel.DisplayMemberPath = "Model1";
            cbWorkMode.ItemsSource = c.WorkModes.ToList();
            cbWorkMode.DisplayMemberPath = "WorkMode1";
            cbTimezone.ItemsSource = c.Timezones.ToList();
            cbTimezone.DisplayMemberPath = "Timezone1";
            cbCriticalTresholdTemplate.ItemsSource = c.CriticalThresholdTemplates.ToList();
            cbCriticalTresholdTemplate.DisplayMemberPath = "Template";
            cbNotificationTemplate.ItemsSource = c.NotificationTemplates.ToList();
            cbNotificationTemplate.DisplayMemberPath = "Template";
            cbCompany.ItemsSource = c.Companies.ToList();
            cbCompany.DisplayMemberPath = "Company1";
            cbUser.ItemsSource = c.Users.Where(u => u.IsEngineer == false && u.IsManager == false && u.IsOperator == false).ToList();
            cbUser.DisplayMemberPath = "FullName";
            cbManager.ItemsSource = c.Users.Where(u => u.IsManager == true).ToList();
            cbManager.DisplayMemberPath = "FullName";
            cbEngineer.ItemsSource = c.Users.Where(u => u.IsEngineer == true).ToList();
            cbEngineer.DisplayMemberPath = "FullName";
            cbOperator.ItemsSource = c.Users.Where(u => u.IsOperator == true).ToList();
            cbOperator.DisplayMemberPath = "FullName";
            cbServicePriority.ItemsSource = c.ServicePriorities.ToList();
            cbServicePriority.DisplayMemberPath = "ServicePriority1";

            if (DataMachine.machine != null)
            {
                var machines = c.VendingMachines
                        .Include(m => m.WorkMode)
                        .Include(m => m.Model)
                        .Include(m => m.TimezoneNavigation)
                        .Include(m => m.CriticalTresholdTemplate)
                        .Include(m => m.NotificationTemplate)
                        .Include(m => m.Company)
                        .Include(m => m.User)
                        .Include(m => m.Manager)
                        .Include(m => m.Engineer)
                        .Include(m => m.Technician)
                        .Include(m => m.ServicePriority);
                machine = machines.FirstOrDefault(m => m.Id == DataMachine.machine.Id);
                tbTitle.Text = "Изменение торгового автомата";
                btnSave.Content = "Сохранить";
            }
            else
            {
                machine = new() {Id = Guid.NewGuid().ToString() };
                tbTitle.Text = "Создание торгового автомата";
                btnSave.Content = "Создать";
            }
            DataContext = machine;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {                     
            try
            {
                if (DataMachine.machine != null)
                {
                    c.SaveChanges();
                }
                else
                {
                    c.VendingMachines.Add(machine);
                    c.SaveChanges();
                }
                MessageBox.Show("Аппарат успешно сохранён!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine("Возникла ошибка при сохранении.");

                int number = ((SqlException)ex.InnerException).Number;

                if (number == 515)
                {
                    message.AppendLine("Не заполнены обязательные поля.");
                }

                if (number == 2601)
                {
                    message.AppendLine("Серийный номер не уникален.");
                }

                MessageBox.Show(message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
