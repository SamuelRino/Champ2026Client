using Champ2026Client.Models;
using LiveCharts;
using LiveCharts.Wpf;
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
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        DispatcherTimer timer;
        User102Context _context;
        public MainPage()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += (sender,e) => Timer_tick();
            timer.Interval = TimeSpan.FromSeconds(10);
            Timer_tick();
            timer.Start();
        }

        private async void Timer_tick()
        {
            double effective = 0;

            InitColumnChart();

            using (_context = new User102Context())
            {
                double count = await _context.VendingMachines.CountAsync();
                double countAvailable = await _context.VendingMachines.Include(c => c.Status).Where(m => m.Status.Id == 1).CountAsync();

                effective = countAvailable / count;              
            }

            if (pcNetState.Series.Count == 0) InitPie();
            else UpdatePie();

            //if (ccSalesDynamic.Series.Count == 0) InitColumnChart();

            effective = Math.Round(effective, 2) * 100;

            agNetEffective.Value = effective;

            tbEffective.Text = $"Работающих автоматов - {effective}%";
        }

        private void InitPie()
        {
            using (_context = new User102Context())
            {
                var series = new SeriesCollection()
                {
                    new PieSeries
                    {
                    Title = "Работает",
                    Values = new ChartValues<int> { _context.VendingMachines.Include(c => c.Status).Where(m => m.Status.Id == 1).Count() },
                    Fill = Brushes.Green
                    },
                    new PieSeries
                    {
                    Title = "Обслуживается",
                    Values = new ChartValues<int> { _context.VendingMachines.Include(c => c.Status).Where(m => m.Status.Id == 2).Count() },
                    Fill = Brushes.DodgerBlue
                    },
                    new PieSeries
                    {
                    Title = "Не работает",
                    Values = new ChartValues<int> { _context.VendingMachines.Include(c => c.Status).Where(m => m.Status.Id == 3).Count() },
                    Fill = Brushes.Red
                    }
                };

                pcNetState.Series = series;
            }              
        }

        private void UpdatePie()
        {
            var ps1 = pcNetState.Series[0] as PieSeries;
            var ps2 = pcNetState.Series[1] as PieSeries;
            var ps3 = pcNetState.Series[2] as PieSeries;

            int[] count = new int[3];

            using (_context = new User102Context())
            {
                for (int i = 0; i < 3; i++)
                {
                    count[i] = _context.VendingMachines.Include(c => c.Status).Where(m => m.Status.Id == i+1).Count();
                }
            }

            ps1.Values[0] = count[0];
            ps2.Values[0] = count[1];
            ps3.Values[0] = count[2];
        }

        private void InitColumnChart()
        {
            var dates = new List<DateTime>();
            var labelsX = new List<string>();

            for (int i = -9; i <= 0; i++)
            {
                var today = new DateTime(2024, 8, 27);
                var date = today.AddDays(i);
                var dayOfWeek = date.ToString("ddd");

                dates.Add(date);
                labelsX.Add($"{date.ToString("d")}\n{dayOfWeek}");
            }

            //for (int i = -9; i <= 0; i++)
            //{
            //    var today = DateTime.Today;
            //    var date = today.AddDays(i);
            //    var dayOfWeek = date.ToString("ddd");

            //    dates.Add(date);
            //    labelsX.Add($"{dayOfWeek}\n{date.ToString("d")}");
            //}

            ccSalesDynamic.AxisX.Clear();

            ccSalesDynamic.AxisX.Add(new Axis { Labels = labelsX, Separator = new LiveCharts.Wpf.Separator { Step = 1, IsEnabled = true }, FontSize=10, MinValue=0, MaxValue=10});

            var fromSum = new Axis();

            var fromCount = new Axis {Separator = new LiveCharts.Wpf.Separator{Step = 1 } };

            ccSalesDynamic.AxisY.Clear();           

            using (_context = new User102Context())
            {
                var sales = _context.SalesToCharts.Where(s => s.Date <= DateOnly.FromDateTime(dates.Last()) 
                        && s.Date >= DateOnly.FromDateTime(dates.First())).OrderBy(s => s.Date).ToList();

                if (rbSum.IsChecked == true)
                {
                    ccSalesDynamic.AxisY.Add(fromSum);
                    var values = new ChartValues<decimal>();
                    foreach (var date in dates)
                    {
                        var sale = sales.FirstOrDefault(s => s.Date == DateOnly.FromDateTime(date));
                        values.Add(sale?.TotalPrice ?? 0m);
                    }
                    var series = new SeriesCollection { new ColumnSeries { Title = "Продажи", Values = values } };

                    ccSalesDynamic.Series = series;
                }
                if (rbCount.IsChecked == true)
                {
                    ccSalesDynamic.AxisY.Add(fromCount);
                    var values = new ChartValues<int>();

                    foreach (var date in dates)
                    {
                        var sale = sales.FirstOrDefault(s => s.Date == DateOnly.FromDateTime(date));
                        values.Add(sale?.SalesCount ?? 0);
                    }
                    var series = new SeriesCollection { new ColumnSeries { Title = "Продажи", Values = values } };

                    ccSalesDynamic.Series = series;
                }                                              
            }
        }

        private void rb_checked(object sender, RoutedEventArgs e)
        {
            if (ccSalesDynamic != null) InitColumnChart();
        }
    }
}
