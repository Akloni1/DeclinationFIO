using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclensionOfFullName
{
    public abstract class DeclensionFIOBase
    {
        protected string _FIO { get; set; }
        protected const string _consonants = "бвгджзйклмнпрстфхцчшщ"; // согласные буквы русского алфавита 
        protected const string _rearConsonants = "хкгшщжч"; // согласные которые не попадают под правила
        //Метод возвращает имя 
        protected string ParseFirstName(string FIO)
        {
            return FIO.Split(' ').Skip(1).Take(1).FirstOrDefault();
        }

        //Метод возвращает фамилию 
        protected string ParseLastName(string FIO)
        {
            return FIO.Split(' ').Take(1).FirstOrDefault();

        }

        //Метод возвращает отчество  
        protected string ParseMiddleName(string FIO)
        {
            return FIO.Split(' ').Skip(2).Take(1).FirstOrDefault();
        }

        //Метод возвращает склоненную Фамилию если она двойная
        protected string DeclensionDoubleLastName(string lastName)
        {

            var doubleName = new List<string>();
            if (lastName.Any(i => i.ToString() == "-"))
            {
                doubleName = lastName.Split("-").ToList();
                return DeclensionLastName(doubleName[0]) + "-" + DeclensionLastName(char.ToUpper(doubleName[1][0]) + doubleName[1].Substring(1));
            }
            else
            {
                return DeclensionLastName(lastName);
            }
        }
        //Метод возвращает склоненнуое имя если оно двойное
        protected string DeclensionDoubleFirstName(string firstName)
        {
            var doubleName = new List<string>();
            if (firstName.Any(i => i.ToString() == "-"))
            {
                doubleName = firstName.Split("-").ToList();
                return DeclensionFirstName(doubleName[0]) + "-" + DeclensionFirstName(char.ToUpper(doubleName[1][0]) + doubleName[1].Substring(1));
            }
            else
            {
                return DeclensionFirstName(firstName);
            }
        }
      
        //Метод возвращает склоненные ФИО
        public string GetDeclensionLastNameFirstNameMiddleName(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            if (_FIO.Any(i => i.ToString() == "-"))
            {
                return DeclensionDoubleLastName(ParseLastName(_FIO)) + " " + DeclensionDoubleFirstName(ParseFirstName(_FIO)) + " " + DeclensionMiddleName(ParseMiddleName(_FIO));
            }
            return DeclensionLastName(ParseLastName(_FIO)) + " " + DeclensionFirstName(ParseFirstName(_FIO)) + " " + DeclensionMiddleName(ParseMiddleName(_FIO));
        }

        //Метод возвращает склоненное имя - отчество 
        public string GetDeclensionOfThePatronymicName(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            if (_FIO.Any(i => i.ToString() == "-"))
            {
                return DeclensionDoubleLastName(ParseLastName(_FIO)) + " " + DeclensionMiddleName(ParseMiddleName(_FIO));
            }
            return DeclensionLastName(ParseFirstName(_FIO)) + " " + DeclensionLastName(ParseMiddleName(_FIO));

        }

        //Метод возвращает склоненные фамилия инициалы
        public string GetDeclensionLastNameInitials(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            if (_FIO.Any(i => i.ToString() == "-"))
            {
                return DeclensionDoubleLastName(ParseLastName(_FIO)) + " " + ParseFirstName(_FIO).Take(1).FirstOrDefault() + ". " + ParseMiddleName(_FIO).Take(1).FirstOrDefault() + ".";
            }
            return DeclensionLastName(ParseLastName(_FIO)) + " " + ParseFirstName(_FIO).Take(1).FirstOrDefault() + ". " + ParseMiddleName(_FIO).Take(1).FirstOrDefault() + ".";
        }

        //Метод возвращает склоненные фамилия инициалы
        public string GetDeclensionInitialsLastName(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            if (_FIO.Any(i => i.ToString() == "-"))
            {
                return ParseFirstName(_FIO).Take(1).FirstOrDefault() + ". " + ParseMiddleName(_FIO).Take(1).FirstOrDefault() + ". "+ DeclensionDoubleLastName(ParseLastName(_FIO));
            }
            return ParseFirstName(_FIO).Take(1).FirstOrDefault() + ". " + ParseMiddleName(_FIO).Take(1).FirstOrDefault() + ". "+ DeclensionLastName(ParseLastName(_FIO));
        }

        //Метод определяет принадлежит ло отчество женщине 
        protected bool IsFemale(string middleName)
        {
            if (middleName.Substring(middleName.Length - 4) == "овна" ||
                middleName.Substring(middleName.Length - 4) == "евна" ||
                //  middleName.Substring(middleName.Length - 6) == "инична" ||
                middleName.Substring(middleName.Length - 4) == "ична")
            {
                return true;
            }
            return false;
        }

        //Метод определяет принадлежит ло отчество мужчине 
        protected bool IsMale(string middleName)
        {
            if (//middleName.Substring(middleName.Length - 4) == "ович" ||
                //middleName.Substring(middleName.Length - 4) == "евич" ||
                middleName.Substring(middleName.Length - 2) == "ич")
            {
                return true;
            }
            return false;
        }



        private string GetValidFIO(string FIO) // метод возврашает ФИО в правильном формате 
        {
            FIO = FIO.Trim().ToLower();
            FIO = System.Text.RegularExpressions.Regex.Replace(FIO, @"\s+", " ");
            var FIOArr = FIO.Split(' ');
            if (FIOArr.Length != 3)
            {
                //должно быть исключение
                throw new Exception("Ваши ФИО введены не верно");
            }
            var FIORes = "";
            foreach (string item in FIOArr)
            {
                FIORes += char.ToUpper(item[0]) + item.Substring(1) + " ";
            }
            return FIORes.Trim();
        }

        public abstract string DeclensionFirstName(string firstName);//Метод склоняет имя 
        public abstract string DeclensionLastName(string lastName); //Метод склоняет фамилию 
        public abstract string DeclensionMiddleName(string middleName); //Метод склоняет отчество 

    }
}
