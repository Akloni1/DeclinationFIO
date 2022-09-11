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




        //Метод возвращает склоненные ФИО
        public string GetDeclensionLastNameFirstNameMiddleName(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            return DeclensionLastName(ParseLastName(_FIO)) + " " + DeclensionFirstName(ParseFirstName(_FIO)) + " " + DeclensionMiddleName(ParseMiddleName(_FIO));
        }

        //Метод возвращает склоненное имя - отчество 
        public string GetDeclensionOfThePatronymicName(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            return DeclensionLastName(ParseFirstName(_FIO)) + " " + DeclensionLastName(ParseMiddleName(_FIO));

        }

        //Метод возвращает склоненные фамилия инициалы
        public string GetDeclensionLastNameInitials(string FIO)
        {
            _FIO = GetValidFIO(FIO);
            return DeclensionLastName(ParseLastName(_FIO)) + " " + ParseFirstName(_FIO).Take(1).FirstOrDefault() + ". " + ParseMiddleName(_FIO).Take(1).FirstOrDefault() + ".";
        }

        //Метод определяет принадлежит ло отчество женщине 
        protected bool IsFemale(string middleName)
        {
            if (middleName.Substring(middleName.Length - 4) == "овна" ||
                middleName.Substring(middleName.Length - 4) == "евна" ||
                middleName.Substring(middleName.Length - 6) == "инична" ||
                middleName.Substring(middleName.Length - 4) == "ична")
            {
                return true;
            }
            return false;
        }

        //Метод определяет принадлежит ло отчество мужчине 
        protected bool IsMale(string middleName)
        {
            if (middleName.Substring(middleName.Length - 4) == "ович" ||
                middleName.Substring(middleName.Length - 4) == "евич" ||
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
