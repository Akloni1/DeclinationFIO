using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclensionOfFullName
{
    public abstract class DeclensionFIOBase
    {
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

        public abstract string GetDeclensionLastNameFirstNameMiddleName(string FIO);

    }
}
