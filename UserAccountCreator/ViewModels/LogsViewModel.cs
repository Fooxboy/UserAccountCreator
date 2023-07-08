using System.Collections.ObjectModel;
using System.Windows;
using UserAccountCreator.Models;
using UserAccountCreator.Views;

namespace UserAccountCreator.ViewModels
{
    public class LogsViewModel : BaseViewModel
    {
        public ObservableCollection<Log> LogList { get; set; }

        public LogsViewModel()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ContainerView.LoggerService.AddedLog += LoggerService_AddedLog;
                LogList = new ObservableCollection<Log>();
            });
        }

        private void LoggerService_AddedLog(Log obj)
        {
            LogList.Add(obj);
        }
    }
}
