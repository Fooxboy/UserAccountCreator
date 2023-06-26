using System;
using UserAccountCreator.Models;
using System.DirectoryServices.AccountManagement;
using UserAccountCreator.Models.Departments;

namespace UserAccountCreator.Services
{
    public class ActiveDirectoryService
    {
        private readonly ConfigService _configService;
        private readonly DepartmentsFactory _departmentsFactory;

        public ActiveDirectoryService(ConfigService configService, DepartmentsFactory departmentsFactory)
        {
            _configService = configService;
            _departmentsFactory = departmentsFactory;
        }

        public void CreateUser(ADUser user, string adminPassword)
        {
            try
            {
                var config = _configService.GetConfig();
                var departmentInfo = _departmentsFactory.GetDepartmentById(user.DepartmentId);

                var principalContext = new PrincipalContext(ContextType.Domain,
                     string.Join(".", config.DCs),
                     $"OU={departmentInfo.OUName}{string.Join(",DC=", config.DCs)}",
                     config.Login,
                     adminPassword);

                var userAD = new UserPrincipal(principalContext);
                userAD.SamAccountName = user.UserName;
                userAD.Name = user.Name;
                userAD.Surname = user.LastName;
                userAD.DisplayName = user.Name + " " + user.LastName;
                userAD.EmailAddress = user.Email;
                userAD.Enabled = true;
                userAD.SetPassword(config.DefaultUserPasswordAD);
                userAD.ExpirePasswordNow();
                userAD.Save();

            }catch(Exception ex)
            {
                //todo log
            }
        }
    }
}
