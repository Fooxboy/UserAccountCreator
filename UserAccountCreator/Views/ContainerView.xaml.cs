using System.Windows;
using UserAccountCreator.Models.Departments;
using UserAccountCreator.Services;
using UserAccountCreator.ViewModels;

namespace UserAccountCreator.Views
{
    /// <summary>
    /// Логика взаимодействия для ContainerView.xaml
    /// </summary>
    public partial class ContainerView : HandyControl.Controls.Window
    {
        public static NavigationService  NavigationService { get; private set; }

        public static ConfigService ConfigService { get; private set; }

        public static ActiveDirectoryService ActiveDirectoryService { get; private set; }

        public static SharesService SharesService { get; private set; }

        public static DepartmentsFactory DepartmentsFactory { get; private set; }

        public static TranslitService TranslitService { get; private set; }

        public static LoggerService LoggerService { get; private set; } 

        public ContainerView()
        {
            InitializeComponent();
            this.Loaded += ContainerView_Loaded;

            NavigationService = new NavigationService();
            NavigationService.NavigationFrame = MainAppFrame;

            ConfigService = new ConfigService();
            DepartmentsFactory = new DepartmentsFactory();
            ActiveDirectoryService = new ActiveDirectoryService(ConfigService, DepartmentsFactory);
            SharesService = new SharesService(ConfigService, DepartmentsFactory);
            TranslitService = new TranslitService();
            LoggerService = new LoggerService();
        }

        private void ContainerView_Loaded(object sender, RoutedEventArgs e)
        {
            ContainerView.NavigationService.NavigateTo(new HomeViewModel());

            var logView = new LogsView();
            logView.DataContext = new LogsViewModel();
            this.LogsAppFrame.Navigate(logView);
        }
    }
}
