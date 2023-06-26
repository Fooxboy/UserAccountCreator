using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UserAccountCreator.Models;
using UserAccountCreator.Models.Departments;

namespace UserAccountCreator.Services
{
    public class SharesService
    {
        private readonly ConfigService _configService;

        private readonly DepartmentsFactory _departmentsFactory;

        public SharesService(ConfigService configService, DepartmentsFactory departmentsFactory)
        {
            _configService = configService;
            _departmentsFactory = departmentsFactory;
        }

        public void CreateUserFolder(ADUser user)
        {
            var config = _configService.GetConfig();
            var department = _departmentsFactory.GetDepartmentById(user.DepartmentId);

            var folderPath = Path.Combine(config.SharedDriveLocation, 
                department.SharedFolderName,
                user.LastName + " " + user.Name + " " + user.MiddleName);

            if(Directory.Exists(folderPath))
            {
                //todo: log

                return;
            }

            var directoryInfo = Directory.CreateDirectory(folderPath);

            SetAccessRules(directoryInfo, config, user);
        }

        private void SetAccessRules(DirectoryInfo directoryInfo, Config config, ADUser user)
        {
            var securitySettings = directoryInfo.GetAccessControl(System.Security.AccessControl.AccessControlSections.All);

            securitySettings.SetAccessRuleProtection(true, false);

            //group
            var groupAccountName = config.DCs[0].ToUpper() + "\\" + config.AdminsGroupName;
            securitySettings.AddAccessRule(new FileSystemAccessRule(groupAccountName, FileSystemRights.FullControl, AccessControlType.Allow));

            //user
            var userName = config.DCs[0].ToUpper() + "\\" + user.UserName;
            securitySettings.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.Modify, AccessControlType.Allow));

            directoryInfo.SetAccessControl(securitySettings);
        }
    }
}
