// See https://aka.ms/new-console-template for more information
using DeclensionOfFullName;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

//Console.WriteLine(DeclensionFIO.GetDeclensionLastNameFirstNameMiddleName("Лапоть Дарья Михайлович"));

var h = new DeclensionFIOIntoGenitiveCase();
var g = new DeclensionFIOIntoDativeCase();
List<string> test = new List<string>();
test.Add("Данилов Кирилл Романович");
test.Add("Самсонов Михаил Владимирович");
test.Add("Васильева Эмилия Кирилловна");
test.Add("Щеглов Александр Романович");
test.Add("Субботин Михаил Михайлович");
test.Add("Баранова Милана Дмитриевна");
test.Add("Антонова Надежда Денисовна");
test.Add("Гусев Максим Александрович");
test.Add("Яковлева Наталья Елисеевна");
test.Add("Голованова Таисия Мироновна");
test.Add("Ильин Андрей Тимурович");
test.Add("Юдин Григорий Владимирович");
test.Add("Меркулова София Михайловна");
test.Add("Меркулова София Михайловна");
test.Add("Данилов Кирилл Романович");
test.Add("Васильева Дарина Александровна");
test.Add("Логинова Валерия Леоновна");
test.Add("Петров Адам Степанович");
test.Add("Зайцев Давид Кириллович");
test.Add("Прохоров Артём Давидович");
test.Add("Данилов Филипп Всеволодович");
test.Add("Матвеева Вера Робертовна");
test.Add("Фомин Артём Егорович");
test.Add("Алексеева Анисия Максимовна");
test.Add("Демидова Алиса Егоровна");
test.Add("Лапин Тимур Савельевич");
test.Add("Потапов Михаил Романович");
test.Add("Андреева Есения Маратовна");
test.Add("Никитин Дамир Никитич");
test.Add("Никитин Дамир Никитич");
test.Add("Смирнов Михаил Дмитриевич");
test.Add("Карпова Милана Никитична");
test.Add("Симонов Артём Иванович");
test.Add("Федотова Арина Михайловна");
test.Add("Алексеева София Тимофеевна");
test.Add("Лебедев Тимур Евгеньевич");
test.Add("Тихонова Анна Демьяновна");
test.Add("Чесноков Марк Маркович");
test.Add("Александров Даниил Маркович");
test.Add("Никольский Даниил Никитич");
test.Add("Никитина Алисия Данииловна");
test.Add("Козловский Сергей Константинович");
test.Add("Пирогов Артём Максимович");
test.Add("Захарова Алина Андреевна");
test.Add("Мельникова Алиса Артемьевна");
test.Add("Котова Ирина Яковлевна");
test.Add("Петрова Анна Владиславовна");
test.Add("Волкова Екатерина Григорьевна");
test.Add("Поляков Семён Петрович");
test.Add("Смирнов Виктор Саввич");
test.Add("Зайцева Мария Владиславовна");
test.Add("Леонова Милана Николаевна");
test.Add("Васильева Ульяна Павловна");
test.Add("Лаврова София Тихоновна");
test.Add("Макарова София Тимофеевна");
test.Add("Титов Кирилл Александрович");
test.Add("Фролова Полина Ильинична");
test.Add("Мельникова Полина Дмитриевна");
test.Add("Черняев Захар Андреевич");
test.Add("Лебедев Мирон Тимофеевич");
test.Add("Иванов Константин Ибрагимович");
test.Add("Алешин Максим Кириллович");
test.Add("Павлов Владислав Максимович");
test.Add("Казаков Матвей Дмитриевич");
test.Add("Баранова Елизавета Богдановна");
test.Add("Корнев Тимофей Макарович");
test.Add("Беспалова Арина Глебовна");
test.Add("Попов Святослав Дмитриевич");
test.Add("Ковалев Эмир Тимофеевич");
test.Add("Алексеев Артём Александрович");
test.Add("Иванов Вячеслав Александрович");
test.Add("Рябинин Алексей Даниилович");
test.Add("Березина София Алексеевна");
test.Add("Захарова Варвара Тимофеевна");
test.Add("Иванов Михаил Георгиевич");
test.Add("Козырева Амина Владиславовна");
test.Add("Озерова Полина Артемьевна");
test.Add("Киселев Али Михайлович");
test.Add("Соколов Максим Михайлович");
test.Add("Соколов Максим Михайлович");
test.Add("Федоров Мирон Давидович");
test.Add("Федотова Алиса Владимировна");
test.Add("Агеева Таисия Арсеновна");
test.Add("Лобанова Александра Германовна");
test.Add("Морозова Полина Вадимовна");
test.Add("Павлов Даниил Кириллович");
test.Add("Терентьева Мирослава Кирилловна");
test.Add("Чернов Кирилл Кириллович");
test.Add("Тихонов Артём Александрович");
test.Add("Леонов Кирилл Владимирович");
test.Add("Данилов Сергей Егорович");
test.Add("Павлова Дарья Семёновна");
test.Add("Титова София Юрьевна");
test.Add("Волков Николай Александрович");
test.Add("Клюева Ульяна Владиславовна");
test.Add("Титова Варвара Петровна");
test.Add("Волков Марк Иванович");
test.Add("Кудряшова Варвара Марковна");
test.Add("Черняев Дмитрий Владимирович");
test.Add("Иванов Андрей Ильич");
test.Add("Степанов Владислав Владиславович");
test.Add("Агеева Таисия Арсеновна");

try
{

    foreach (string j in test)
    {
        Console.WriteLine(j + " ----- " + g.GetDeclensionLastNameFirstNameMiddleName(j));
    }
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    Console.WriteLine(g.GetDeclensionLastNameFirstNameMiddleName("         Зарюжа-Зарюжа      Лука-Лука  андреевич "));

    Console.WriteLine(g.GetDeclensionOfThePatronymicName("         карПухИн      Рене  андреевич "));
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    Console.WriteLine(g.GetDeclensionLastNameInitials("         карПухин-Карпухин      МихАил  андреевич "));
    Console.WriteLine(g.GetDeclensionInitialsLastName("         карПухин-Карпухин      МихАил  андреевич "));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}