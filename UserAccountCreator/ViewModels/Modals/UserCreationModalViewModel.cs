using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserAccountCreator.Models;
using UserAccountCreator.Models.Departments;
using UserAccountCreator.TemplateEngine;
using UserAccountCreator.Views;

namespace UserAccountCreator.ViewModels.Modals
{
    public class UserCreationModalViewModel : BaseViewModel, IModal
    {
        public event Action<ADUser> OkButtonEvent;

        public event Action CancelButtonEvent;

        public ICommand OkCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public DepartmentInfo Department { get; set; }
        
        public string UserName { get; set; }

        public string Email { get; set; }

        public ObservableCollection<DepartmentInfo> DepartmentsInfo { get; set; }

        private readonly DepartmentsFactory _departmentsFactory;

        public UserCreationModalViewModel(DepartmentsFactory departmentsFactory)
        {
            DepartmentsInfo = new ObservableCollection<DepartmentInfo>();
            OkCommand = new AsyncCommand(Ok);
            CancelCommand = new AsyncCommand(Cancel);
            _departmentsFactory = departmentsFactory;
        }

        public void OnOpen(object args)
        {
            var departments = _departmentsFactory.GetAll();

            foreach (var department in departments)
            {
                DepartmentsInfo.Add(new DepartmentInfo() { DepartmentId = department.Key, DisplayName = department.Value.DisplayName });
            }
        }

        public void FullNameChanged(string name)
        {
            //var config = ContainerView.ConfigService.GetConfig();
            //var templateUserName = config.UserNameTemplate;

            var templateUserName = "%%Фамилия%%%%И%%%%О%%";

            var templateBuilder = new TemplateBuilder(ContainerView.TranslitService);

            UserName = templateBuilder.Apply(name, templateUserName, true);

            Changed("UserName");

            //var templateEmail = config.UserNameTemplate;

            var templateEmail = "%%И%%.%%Фамилия%%@yandex.ru";

            Email = templateBuilder.Apply(name, templateEmail, true);

            Changed("Email");
        }

        private async Task Ok()
        {
            var splittedName = GetSplitName(FullName);

            var user = new ADUser()
            {
                DepartmentId = Department.DepartmentId,
                UserName = UserName,
                Email = Email,
                JobTitle = JobTitle,
                LastName = splittedName.LastName,
                MiddleName = splittedName.MiddleName,
                Name = splittedName.Name
            };

            OkButtonEvent?.Invoke(user);
        }

        private async Task Cancel()
        {
            CancelButtonEvent?.Invoke();
        }


        private (string LastName, string Name, string MiddleName) GetSplitName(string fullUserName)
        {
            var fullName = fullUserName.Trim();

            var splittedName = fullName.Split(" ");

            var lastName = string.Empty;
            if(splittedName.Length > 0)
            {
                lastName = splittedName[0];
            }

            var name = string.Empty;

            if(splittedName.Count() > 1)
            {
                name = splittedName[1];
            }

            var middleName = string.Empty;

            if(splittedName.Length == 3)
            {
                middleName = splittedName[2];
            }

            return (lastName, name, middleName);
        }
    }
}
