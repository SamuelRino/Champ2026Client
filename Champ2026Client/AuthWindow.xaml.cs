using Champ2026Client.classes;
using Champ2026Client.Models;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbLogin.Text) && !string.IsNullOrWhiteSpace(tbPassword.Password))
            {
                string Login = tbLogin.Text;
                string Password = tbPassword.Password;

                using (User102Context c = new ())
                {
                    var user = c.UserLogins.FirstOrDefault(u => u.Login == Login);
                    if (user is not null)
                    {
                        bool verify = PasswordHasher.VerifyPassword(user.Password, Password);
                        if (verify)
                        {
                            DataUser.user = c.Users.FirstOrDefault(u => u.Id == user.UserId);
                            MainWindow w = new();
                            w.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с таким логином не существует", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
