using ScheduleReport.Client.Extensions;
using ScheduleReport.Client.ViewModels;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ScheduleReport.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();

            // Инициировать модель формы
            DataContext = ViewModel = new MainViewModel();


            // Получить список объектов
            lstReports.ItemsSource = ViewModel.Reports = RestApiExtension.GetReports().Select(a => (ReportViewModel)a).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var form = new EditWindow(this);
            form.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (lstReports.SelectedIndex == -1) return;

            var reportModel = lstReports.Items[lstReports.SelectedIndex] as ReportViewModel;

            RestApiExtension.DeleteReport(reportModel.ID);

            ViewModel.Reports.Remove(reportModel);



            // Обновить отображение
            ((ICollectionView)CollectionViewSource.GetDefaultView(lstReports.ItemsSource)).Refresh();

            //lstReports.Items.RemoveAt(lstReports.SelectedIndex);
        }
    }
}
