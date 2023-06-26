using System.Collections.Generic;
using UserAccountCreator.Models;

namespace UserAccountCreator.Services
{
    public class TranslitService
    {
        private readonly Dictionary<string, string> _lettersDictionary;

        public TranslitService()
        {
            _lettersDictionary = new Dictionary<string, string>();

            InitDictionary();
        }

        public string ConvertToTranslit(string sourceText, TranslitMode translitMode = TranslitMode.Lower)
        {
            var text = sourceText.ToUpper();

            foreach (var key in _lettersDictionary) 
            {
                text = text.Replace(key.Key, key.Value); 
            }

            if(translitMode == TranslitMode.Lower)
            {
                return text.ToLower();

            }else
            {
                return text.ToUpper();
            }
        }

        public void InitDictionary()
        {
            _lettersDictionary.Add("А", "A"); 
            _lettersDictionary.Add("Б", "B");
            _lettersDictionary.Add("В", "V");
            _lettersDictionary.Add("Г", "G");
            _lettersDictionary.Add("Д", "D");
            _lettersDictionary.Add("Е", "E"); 
            _lettersDictionary.Add("Ё", "YO");
            _lettersDictionary.Add("Ж", "J");
            _lettersDictionary.Add("З", "Z");
            _lettersDictionary.Add("И", "I");
            _lettersDictionary.Add("Й", "YI");
            _lettersDictionary.Add("К", "K");
            _lettersDictionary.Add("Л", "L");
            _lettersDictionary.Add("М", "M");
            _lettersDictionary.Add("Н", "N");
            _lettersDictionary.Add("О", "O");
            _lettersDictionary.Add("П", "P");
            _lettersDictionary.Add("Р", "R");
            _lettersDictionary.Add("С", "S"); 
            _lettersDictionary.Add("Т", "T");
            _lettersDictionary.Add("У", "U");
            _lettersDictionary.Add("Ф", "F");
            _lettersDictionary.Add("Х", "KH");
            _lettersDictionary.Add("Ц", "TS");
            _lettersDictionary.Add("Ч", "CH");
            _lettersDictionary.Add("Ш", "SH");
            _lettersDictionary.Add("Щ", "SCH");
            _lettersDictionary.Add("Ъ", "");
            _lettersDictionary.Add("Ы", "Y");
            _lettersDictionary.Add("Ь", "");
            _lettersDictionary.Add("Э", "E");
            _lettersDictionary.Add("Ю", "U");
            _lettersDictionary.Add("Я", "YA");

        }
    }
}
