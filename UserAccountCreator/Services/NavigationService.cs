using HandyControl.Controls;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UserAccountCreator.ViewModels;
using UserAccountCreator.ViewModels.Modals;
using UserAccountCreator.Views;
using UserAccountCreator.Views.Modals;

namespace UserAccountCreator.Services
{
    public class NavigationService
    {
        /// <summary>
        /// ViewModel, View
        /// </summary>
        public Dictionary<Type, Type> ViewBindings { get; }

        public List<INavigationPage> Pages { get; }

        public Frame NavigationFrame { get; set; }

        private Dialog _currentDialog;

        public NavigationService()
        {
            this.Pages = new List<INavigationPage>();

            this.ViewBindings = new Dictionary<Type, Type>
            {
                {typeof(HomeViewModel), typeof(HomeView) },
                {typeof(UserCreationModalViewModel), typeof(UserCreationModal) }
            };
        }


        public void NavigateTo(INavigationPage viewModel, object args = null)
        {
            var viewType = ViewBindings[viewModel.GetType()];

            var view = Activator.CreateInstance(viewType) as Page;

            view.DataContext = viewModel;

            Application.Current.Dispatcher.Invoke(() =>
            {
                NavigationFrame.Navigate(view);
            });

            viewModel.OnEnter(args);
        }

        public void ShowModal(IModal modalViewModel, object args = null)
        {
            var viewType = ViewBindings[modalViewModel.GetType()];

            var view = Activator.CreateInstance(viewType) as UserControl;

            view.DataContext = modalViewModel;

            _currentDialog = Dialog.Show(view);
            modalViewModel.OnOpen(args);
        }

        public void CloseModal()
        {
            _currentDialog.Close();
        }
    }
}
