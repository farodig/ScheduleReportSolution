using ScheduleReport.Client.Attributes;
using ScheduleReport.Client.Enums;
using ScheduleReport.Client.Extensions;
using ScheduleReport.Client.ViewModels;
using ScheduleReport.DB;
using ScheduleReport.DB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace ScheduleReport.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private MainWindow mainWindow;

        /// <summary>
        /// Модель формы
        /// </summary>
        private ReportViewModel ViewModel { get; }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public EditWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            InitializeComponent();

            // Инициировать модель формы
            DataContext = ViewModel = new ReportViewModel();

            // TODO: вынести в Application или Lazy

            // Получить список типов отчётов
            cmbReportType.ItemsSource = ComboboxExtension.EnumToComboBox<ReportTypeEnum>();

            // Получить список периодичности отчётов
            cmbPeriodicityReport.ItemsSource = ComboboxExtension.EnumToComboBox<PeriodicityReportEnum>();

            // Получить список объектов
            cmbObjects.ItemsSource = RestApiExtension.GetObjects().OrderBy(a => a.Code).Select(a => new SelectableObjectViewModel<MonitoringObjectViewModel>
            {
                Name = a.Number,
                Value = new MonitoringObjectViewModel(a)
            });
        }

        /// <summary>
        /// Обработка комбобокса с чекбоксами
        /// </summary>
        private void OnCbObjectCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            // Очистить список выбранных объектов
            ViewModel.MonitorObjects.Clear();

            // Заполнить список выбранных объектов
            foreach (SelectableObjectViewModel<MonitoringObjectViewModel> cbObject in cmbObjects.Items)
            {
                if (cbObject.IsSelected)
                {
                    ViewModel.MonitorObjects.Add(cbObject.Value);
                }
                    
            }
            
            // Вывести выбранные объекты
            tbObjects.Text = ViewModel.MonitorObjects.Any() ? string.Join(", ", ViewModel.MonitorObjects.Select(a => a.Number).ToArray()) : "Выберите объекты...";
        }

        /// <summary>
        /// Заглушить комбобокс
        /// </summary>
        private void OnCbObjectsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Добавить отчёт (на сервере)
            RestApiExtension.AddReport((Report)ViewModel);

            // Добавить отчёт в модели клиента
            mainWindow.ViewModel.Reports.Add(ViewModel);

            // Обновить отображение
            ((ICollectionView)CollectionViewSource.GetDefaultView(mainWindow.lstReports.ItemsSource)).Refresh();

            Close();
        }
    }
}
