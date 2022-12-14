using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeclensionOfFullName
{
    public class DeclensionFIOIntoGenitiveCase : DeclensionFIOBase
    {
       
      
        //Метод склоняет имя 
        public override string DeclensionFirstName(string firstName)
        {
            if (firstName.Substring(firstName.Length - 1) == "а")
            {
                if (_rearConsonants.Any(i=>i.ToString()== firstName.SkipLast(1).TakeLast(1).FirstOrDefault().ToString())) //если последняя буква равна букве, которая не попадает под правила, то меняем ее на и
                {
                    return firstName.Substring(0, firstName.Length - 1) + "и";
                }
                return firstName.Substring(0, firstName.Length - 1) + "ы";
            }
            else if (firstName.Substring(firstName.Length - 1) == "я")
            {
                return firstName.Substring(0, firstName.Length - 1) + "и";
            }
            else if (IsMale(ParseMiddleName(_FIO)))// относится ли фио мужчине 
            {
                if (firstName == "Лев")
                {
                    return "Льва";
                }
                else if (firstName == "Петр")
                {
                    return "Петра";
                }
                else if (firstName == "Пётр")
                {
                    return "Петра";
                }
                else if (firstName.Substring(firstName.Length - 1) == "й")
                {
                    return firstName.Substring(0, firstName.Length - 1) + "я";
                }
                else if (_consonants.Any(i => i.ToString() == firstName.Substring(firstName.Length - 1))) //Если последняя буква согласная то
                {
                    return firstName + "а";
                }
                if (firstName.Substring(firstName.Length - 1) == "ь")
                {
                    return firstName.Substring(0, firstName.Length - 1) + "я";
                }
            }
            else if (IsFemale(ParseMiddleName(_FIO)))// относится ли фио женщине
            {
                if (firstName.Substring(firstName.Length - 1) == "ь")
                {
                    return firstName.Substring(0, firstName.Length - 1) + "и";
                }
            }
            
            return firstName;
        }
        //Метод склоняет фамилию 
        public override string DeclensionLastName(string lastName)
        {
            if (lastName.Substring(lastName.Length - 1) == "о" ||
                lastName.Substring(lastName.Length - 1) == "е" ||
                lastName.Substring(lastName.Length - 1) == "ё" ||
                lastName.Substring(lastName.Length - 1) == "э" ||
                lastName.Substring(lastName.Length - 1) == "у" ||
                lastName.Substring(lastName.Length - 1) == "и" ||
                lastName.Substring(lastName.Length - 1) == "ы" ||
                lastName.Substring(lastName.Length - 1) == "ю")
            {
                return lastName;
            }
            else if (lastName.Substring(lastName.Length - 2) == "их" ||
                     lastName.Substring(lastName.Length - 2) == "ых" ||
                     lastName.Substring(lastName.Length - 2) == "иа")
            {
                return lastName;
            }
            else if (lastName.Substring(lastName.Length - 1) == "я")//если фамилия заканчивается на я,  переводим в родительный падеж(обрезаем последнюю "я" и добавляем "и" в конец)
            {
                return lastName.Substring(0, lastName.Length - 1) + "и";
            }
            else if (IsMale(ParseMiddleName(_FIO)))// относится ли фио мужчине 
            {
                if (lastName.Substring(lastName.Length - 1) == "к") //если фамилия заканчивается на к, переводим в родительный падеж(добавляем "а" в конец)
                {
                    return lastName + "а";
                }
                else if (lastName.Substring(lastName.Length - 2) == "ов" ||//если фамилия заканчивается на ов или ев,  переводим в родительный падеж(добавляем "а" в конец)
                   lastName.Substring(lastName.Length - 2) == "ев")
                {
                    return lastName + "а";
                }
                else if (lastName.Substring(lastName.Length - 2) == "ин" ||//если фамилия заканчивается на ин или ын,  переводим в родительный падеж(добавляем "а" в конец)
                  lastName.Substring(lastName.Length - 2) == "ын")
                {
                    return lastName + "а";
                }
               /* else if (lastName.Substring(lastName.Length - 4) == "ский" ||//если фамилия заканчивается на цкий или ский,  переводим в родительный падеж(удаляем "ий" и добавляем "ого" в конец)////// не нужно
                 lastName.Substring(lastName.Length - 4) == "цкий")
                {
                    return lastName.Substring(0, lastName.Length - 2) + "ого";
                }*/
                else if (lastName.Substring(lastName.Length - 2) == "ой" ||//если фамилия заканчивается на ой или ий или ый,  переводим в родительный падеж(удаляем 2 символа в конце и добавляем "ого" в конец)
                         lastName.Substring(lastName.Length - 2) == "ий" ||
                         lastName.Substring(lastName.Length - 2) == "ый")
                {
                    return lastName.Substring(0, lastName.Length - 2) + "ого";
                }
                else if (lastName.Substring(lastName.Length - 2) == "ец")//если фамилия заканчивается на ец,  переводим в родительный падеж(обрезаем последнюю "ец" и добавляем "ца" в конец)
                {
                    return lastName.Substring(0, lastName.Length - 2) + "ца";
                }
                else if (_consonants.Any(i => i.ToString() == lastName.Substring(lastName.Length - 1))) //Является ли последняя буква фамилии согласной
                {
                    return lastName + "а";
                }
                else if (lastName.Substring(lastName.Length - 1) == "а")//если фамилия заканчивается на а,  переводим в родительный падеж(обрезаем последнюю "а" и добавляем "ы" в конец)
                {
                    if (_rearConsonants.Any(i => i.ToString() == lastName.SkipLast(1).TakeLast(1).FirstOrDefault().ToString())) //если последняя буква равна букве, которая не попадает под правила, то меняем ее на и
                    {
                        return lastName.Substring(0, lastName.Length - 1) + "и";
                    }
                    return lastName.Substring(0, lastName.Length - 1) + "ы";
                }
                else if (lastName.Substring(lastName.Length - 1) == "ь")//если фамилия заканчивается на ь,  переводим в родительный падеж(обрезаем последнюю "ь" и добавляем "я" в конец)
                {
                    return lastName.Substring(0, lastName.Length - 1) + "я";
                }

                return lastName;
            }



            else if (IsFemale(ParseMiddleName(_FIO)))// относится ли фио женщине 
            {
                if (_consonants.Any(i => i.ToString() == lastName.Substring(lastName.Length - 1))) //Является ли последняя буква фамилии согласной
                {
                    return lastName;
                }
                else if (lastName.Substring(lastName.Length - 3) == "ова" ||//если фамилия заканчивается на ова или ева,  переводим в родительный падеж(обрезаем последнюю "а" и добавляем "ой" в конец)
                   lastName.Substring(lastName.Length - 3) == "ева")
                {
                    return lastName.Substring(0, lastName.Length - 1) + "ой";
                }
                else if (lastName.Substring(lastName.Length - 3) == "ина" ||//если фамилия заканчивается на ина или ына,  переводим в родительный падеж(обрезаем последнюю "а" и добавляем "ой" в конец)
                  lastName.Substring(lastName.Length - 3) == "ына")
                {
                    return lastName.Substring(0, lastName.Length - 1) + "ой";
                }
               /* else if (lastName.Substring(lastName.Length - 4) == "ская" ||//если фамилия заканчивается на ская или цкая,  переводим в родительный падеж(обрезаем последнюю "ая" и добавляем "ой" в конец)////лишнее
                lastName.Substring(lastName.Length - 4) == "цкая")
                {
                    return lastName.Substring(0, lastName.Length - 2) + "ой";
                }*/
                else if (lastName.Substring(lastName.Length - 2) == "ая")//если фамилия заканчивается на ая,  переводим в родительный падеж(обрезаем последнюю "ая" и добавляем "ой" в конец)
                {
                    return lastName.Substring(0, lastName.Length - 2) + "ой";
                }
                else if (lastName.Substring(lastName.Length - 1) == "а")//если фамилия заканчивается на а,  переводим в родительный падеж(обрезаем последнюю "а" и добавляем "ы" в конец)
                {
                    if (_rearConsonants.Any(i => i.ToString() == lastName.SkipLast(1).TakeLast(1).FirstOrDefault().ToString())) //если последняя буква равна букве, которая не попадает под правила, то меняем ее на и
                    {
                        return lastName.Substring(0, lastName.Length - 1) + "и";
                    }

                    return lastName.Substring(0, lastName.Length - 1) + "ы";
                }
                else if (lastName.Substring(lastName.Length - 1) == "ь")//если фамилия заканчивается на ь, она не склоняется у женщин
                {
                    return lastName;
                }
            }
            return lastName;
        }
        //Метод склоняет отчество 
        public override string DeclensionMiddleName(string middleName)
        {
            if (IsMale(ParseMiddleName(_FIO)))// относится ли фио мужчине 
            {
                return middleName + "а";
            }
            else if (IsFemale(ParseMiddleName(_FIO)))// относится ли фио женщине
            {
                return middleName.Substring(0, middleName.Length - 1) + "ы";
            }
            return middleName;
        }
    }
}
