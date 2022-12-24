using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam r1 = new ResearchTeam("name1", "Org1", 12345, TimeFrame.Long);
            r1.AddMembers(new Person());
            r1.AddPapers(new Paper(), new Paper(), new Paper());
            ResearchTeam r2 = new ResearchTeam("name2", "Org2", 3567, TimeFrame.TwoYears);
            r2.AddMembers(new Person(), new Person());
            r2.AddPapers(new Paper());
            ResearchTeam r3 = new ResearchTeam("name3", "Org3", 23552, TimeFrame.Year);
            r3.AddMembers(new Person(), new Person(), new Person());
            r3.AddPapers(new Paper(), new Paper(), new Paper());
            ResearchTeamCollection rr = new ResearchTeamCollection();
            rr.AddDefaults();
            rr.AddResearchTeams(r1, r2, r3);
            Console.WriteLine("             ОБЪЕКТ ResearchTeamCollection");
            Console.WriteLine();
            Console.WriteLine(rr.ToString());
            Console.WriteLine("             СОРТИРОВКА ПО НОМЕРУ РЕГИСТРАЦИИ");
            rr.SortRegNum();
            Console.WriteLine(rr.ToShortString());
            Console.WriteLine();
            Console.WriteLine("             СОРТИРОВКА ПО НАЗВАНИЮ ТЕМЫ ИССЛЕДОВАНИЙ");
            rr.SortTopic();
            Console.WriteLine(rr.ToShortString());
            Console.WriteLine();
            Console.WriteLine("             СОРТИРОВКА ПО ЧИСЛУ ПУБЛИКАЦИЙ");
            rr.SortNumPapers();
            Console.WriteLine(rr.ToShortString());
            Console.WriteLine();
            Console.WriteLine("Минимальный регистрационный номер:  " + rr.MinRegNum);
            Console.WriteLine("Проекты с продолжительностью TwoYears:");
            foreach (ResearchTeam r in rr.TwoYears)
                Console.WriteLine("   *  " + r.ToShortString());
            Console.WriteLine();
            Console.WriteLine("          Группа с 1 публикацией:");
            foreach (ResearchTeam r in rr.NGroup(1))
                Console.WriteLine(r.ToShortString());
            Console.WriteLine();
            Console.WriteLine("          Группа с 3 публикациями:");
            foreach (ResearchTeam r in rr.NGroup(3))
                Console.WriteLine(r.ToShortString());

            TestCollections test = new TestCollections(1000000);
            test.SearchTime(1000000);
        }
    }
}


//теория
/*Конкретные значения типовых параметров ТКеу и TValue зависят от варианта. Во всех вариантах тип ключа ТКеу и тип значения TValue связаны отношением базовый-производный. Во всех вариантах в классе TValue определено свойство, которое возвращает ссылку на объект типа ТКеу с данными, совпадающими с данными подобъекта базового класса (это свойство должно возвращать ссылку на объект типа ТКеу, а не ссылку на ВЫЗЫВаЮЩИЙ объект TValue).
В конструкторе класса TestCollections создаются коллекции с заданным числом элементов. Надо сравнить время поиска элемента в коллекцияхсписках List<Tkey> и время поиска элемента по ключу и элемента по значению в коллекциях-словарях 
Для автоматической генерации элементов коллекций в классе TestCollections надо определить статический метод, который принимает один целочисленный параметр типа int и возвращает ссылку на объект типа TVaIue.
Каждый объект TValue содержит подобъект базового класса ТКеу. Соответствие между значениями целочисленного параметра метода и подобъектами ТКеу класса TValue должно быть взаимно-однозначным — равным значениям параметра должны отвечать равные объекты ТКеу и наоборот. Равенство объектов типа ткеу трактуется так же, как это было сделано в лабораторной работе 2 при определении операций равенства объектов.
Все четыре коллекции содержат одинаковое число элементов. Каждому элементу из коллекции List<Tkey> должен отвечать элемент в коллекции DictionarY<Tkey, TValue> с равным значением ключа. Список List<string> состоит из строк, которые получены в результате вызова метода ToString() для объектов ТКеу из списка List<Tkey>. Каждому элементу списка List<string> отвечает элемент в коллекции-словаре Dictionary<string, TValue> с равным значением ключа типа string.
Число элементов в коллекциях вводится пользователем в процессе работы приложения. Если при вводе была допущена ошибка, приложение должно обработать исключение, сообщить об ошибке ввода и повторить прием ввода до тех пор, пока не будет правильно введено целочисленное значение.
Для четырех разных элементов первого, центрального, последнего и элемента, не входящего в коллекцию — надо измерить время поиска
•	элемента в коллекциях List<Tkey> и List<string> с помощью метода Contains;
•	элемента по ключу в коллекциях Dictionary< ТКеу, TValue> и Dictionary
<string, TVaIue > с помощью метода Containskey;
•	значения элемента в коллекции Dictionary< ТКеу, TValue > с помощью метода ContainsValue.
Так как статический метод для автоматической генерации элементов должен обеспечивать взаимно-однозначное соответствие между значением целочисленного параметра метода и объектами ТКеу, этот метод можно использовать как при создании коллекций с большим числом элементов, так и для генерации элемента для поиска.
*/