using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeclensionOfFullName
{
    public static class DeclensionFIO
    {
        private static string _firstName { get; set; }
        private static string _lastName { get; set; }
        private static string _middleName { get; set; }
        private static string _FIO { get; set; }
        private const string _consonants = "бвгджзйклмнпрстфхцчшщ"; // согласные русского алфавита 


    //Метод возвращает имя 
    private static string ParseFirstName(string FIO)
        {
            return FIO.Split(' ').Skip(1).Take(1).FirstOrDefault();
        }

        //Метод возвращает фамилию 
        private static string ParseLastName(string FIO)
        {
            return FIO.Split(' ').Take(1).FirstOrDefault();
           
        }

        //Метод возвращает отчество  
        private static string ParseMiddleName(string FIO)
        {
            return FIO.Split(' ').Skip(2).Take(1).FirstOrDefault();
        }

        //Метод склоняет имя 
        public static string DeclensionFirstName(string firstName)
        {
            return "";
        }
        //Метод склоняет фамилию 
        public static string DeclensionLastName(string lastName)
        {
            if (lastName.Substring(lastName.Length - 1) == "о"||
                lastName.Substring(lastName.Length - 1) == "е"||
                lastName.Substring(lastName.Length - 1) == "э"||
                lastName.Substring(lastName.Length - 1) == "у"||
                lastName.Substring(lastName.Length - 1) == "ю")
            {
                return lastName;
            }
            else if (lastName.Substring(lastName.Length - 2) == "их"|| 
                     lastName.Substring(lastName.Length - 2) == "ых"||
                     lastName.Substring(lastName.Length - 2) == "иа")
            {
                return lastName;
            }
            else if (lastName.Substring(lastName.Length - 1) == "а") // если фамилия заканчивается на а, переводим в родительный падеж(удаляем а добавляем ы)
            {
               // return lastName.Substring(0, lastName.Length - 1)+"ы";
            }
            else if (IsMale(ParseMiddleName(_FIO)))
            {
                return "мужик";
            }
            else if (IsFemale(ParseMiddleName(_FIO)))// относится ли фио женщине 
            {
                if (_consonants.Any(i => i.ToString() == lastName.Substring(lastName.Length - 1))) //Является ли последняя буква фамилии согласной
                {
                    return lastName;
                }
                else
                {
                    //здесь должна быть логика с женскими именами которые склоняются
                   
                }
            }
            return "";
        }
        //Метод склоняет отчество 
        public static string DeclensionMiddleName(string middleName)
        {
            return "";
        }
        //Метод возвращает склоненное имя - отчество 
        public static string GetDeclensionOfThePatronymicName()
        {
            return "";
        }

        //Метод возвращает склоненные фамилия инициалы
        public static string GetDeclensionLastNameInitials()
        {
            return "";
        }
        //Метод возвращает склоненные ФИО
        public static string GetDeclensionLastNameFirstNameMiddleName(string FIO)
        {
            _FIO = FIO;
            return DeclensionLastName(ParseLastName(FIO));
        }

        //Метод определяет принадлежит ло отчество мужчине 
        public static bool IsMale(string middleName)
        {
            if (middleName.Substring(middleName.Length - 4) == "ович"||
                middleName.Substring(middleName.Length - 4) == "евич" ||
                middleName.Substring(middleName.Length - 2) == "ич")
            {
                return true;
            }
            return false;
        }
        //Метод определяет принадлежит ло отчество женщине 
        public static bool IsFemale(string middleName)
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
    }
}
