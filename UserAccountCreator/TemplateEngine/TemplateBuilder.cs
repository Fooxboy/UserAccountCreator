using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccountCreator.Models;
using UserAccountCreator.Services;

namespace UserAccountCreator.TemplateEngine
{
    public class TemplateBuilder
    {
        private readonly TranslitService _translitService;

        public TemplateBuilder(TranslitService translitService)
        {
            _translitService = translitService;
        }

        public string Apply(string fullName, string template, bool translit, TranslitMode translitMode = TranslitMode.Lower)
        {
            var data = GetSplitName(fullName);
            var result = template.Replace("%%Фамилия%%", data.LastName)
            .Replace("%%Имя%%", data.Name)
            .Replace("%%Отчество%%", data.MiddleName)
            .Replace("%%Ф%%", data.LastName.FirstOrDefault().ToString())
            .Replace("%%И%%", data.Name.FirstOrDefault().ToString())
            .Replace("%%О%%", data.MiddleName.FirstOrDefault().ToString());

            if(translit)
            {
                return _translitService.ConvertToTranslit(result, translitMode);
            }

            return result;
        }

        private (string LastName, string Name, string MiddleName) GetSplitName(string fullUserName)
        {
            var fullName = fullUserName.Trim();

            var splittedName = fullName.Split(" ");

            var lastName = string.Empty;

            if (splittedName.Length > 0)
            {
                lastName = splittedName[0];
            }

            var name = string.Empty;

            if (splittedName.Count() > 1)
            {
                name = splittedName[1];
            }

            var middleName = string.Empty;

            if (splittedName.Length == 3)
            {
                middleName = splittedName[2];
            }

            return (lastName, name, middleName);
        }
    }
}
