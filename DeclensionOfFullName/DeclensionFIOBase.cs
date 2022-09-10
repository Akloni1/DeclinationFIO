using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclensionOfFullName
{
    public abstract class DeclensionFIOBase
    {
        protected static string _FIO { get; set; }
        protected const string _consonants = "бвгджзйклмнпрстфхцчшщ"; // согласные буквы русского алфавита 
        //Метод возвращает имя 
        protected static string ParseFirstName(string FIO)
        {
            return FIO.Split(' ').Skip(1).Take(1).FirstOrDefault();
        }

        //Метод возвращает фамилию 
        protected static string ParseLastName(string FIO)
        {
            return FIO.Split(' ').Take(1).FirstOrDefault();

        }

        //Метод возвращает отчество  
        protected static string ParseMiddleName(string FIO)
        {
            return FIO.Split(' ').Skip(2).Take(1).FirstOrDefault();
        }

        //Метод возвращает склоненные ФИО
        public string GetDeclensionLastNameFirstNameMiddleName(string FIO)
        {
            _FIO = FIO;
            return DeclensionLastName(ParseLastName(FIO)) + " " + DeclensionFirstName(ParseFirstName(FIO)) + " " + DeclensionMiddleName(ParseMiddleName(FIO));
        }

        public abstract string DeclensionFirstName(string firstName);
        public abstract string DeclensionLastName(string lastName);
        public abstract string DeclensionMiddleName(string middleName);
        public abstract string GetDeclensionLastNameInitials(string FIO);
        public abstract string GetDeclensionOfThePatronymicName(string FIO);

    }
}
