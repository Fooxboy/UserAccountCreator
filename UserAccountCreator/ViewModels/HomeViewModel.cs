using AsyncAwaitBestPractices.MVVM;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UserAccountCreator.Models;
using UserAccountCreator.ViewModels.Modals;
using UserAccountCreator.Views;

namespace UserAccountCreator.ViewModels
{
    public class HomeViewModel : BaseViewModel, INavigationPage
    {
        public ObservableCollection<ADUser> ADUsers { get; set; }

        public ADUser SelectedUser { get; set; }

        public ICommand AddNewUserCommand { get; set; }

        public ICommand RemoveUserCommand { get; set; }

        public ICommand NextCommand { get; set; }

        public HomeViewModel()
        {
            ADUsers = new ObservableCollection<ADUser>();

            AddNewUserCommand = new AsyncCommand(AddNewUserAsync);
            RemoveUserCommand = new AsyncCommand(RemoveUserAsync);
            NextCommand = new AsyncCommand(NextAsync);
        }

        public void OnEnter(object args)
        {

        }

        private async Task AddNewUserAsync()
        {
            var viewModel = new UserCreationModalViewModel(ContainerView.DepartmentsFactory);

            viewModel.CancelButtonEvent += ViewModel_CancelButtonEvent;
            viewModel.OkButtonEvent += ViewModel_OkButtonEvent;

            ContainerView.NavigationService.ShowModal(viewModel);
        }

        private void ViewModel_OkButtonEvent(ADUser user)
        {
            ADUsers.Add(user);

            ContainerView.NavigationService.CloseModal();
        }

        private void ViewModel_CancelButtonEvent()
        {
            ContainerView.NavigationService.CloseModal();
        }

        private async Task RemoveUserAsync()
        {
            if (SelectedUser is null) return;

            ADUsers.Remove(SelectedUser);
        }

        private async Task NextAsync()
        {

        }
    }
}
