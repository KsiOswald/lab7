using System.ComponentModel;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int numberOfLab = 0;
        Console.Write("Введите номер лабораторной работы (1-10): ");
        while ((!int.TryParse(Console.ReadLine(), out numberOfLab))
            || ((numberOfLab <= 0) || (numberOfLab > 10)))
        {
            Console.WriteLine("Введён неверный номер, повторите попытку ещё раз");
        }
        switch (numberOfLab)
        {
            case 1:
                {
                    Console.WriteLine("Определить разность суммы элементов " +
                        "первой и второй половины файла.");
                    const string path = "7.1.txt";
                    Files.CreateRandomIntFile(path);
                    int length = Files.LengthOfFile(path);
                    int difference = Files.DiffOfHalves(path, length);
                    Console.WriteLine("Разница между половинами равна: " + difference);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Вычислить сумму элементов.");
                    const string path = "7.2.txt";
                    Files.CreateFileLotIntNumbers(path);
                    Console.WriteLine("Сумма всех элементов в файле: "
                        + Files.SumOfFile(path));
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Переписать в другой текстовый файл" +
                        " самую короткую и самую длинную строки. ");
                    const string path = "7.3.txt";
                    string newStr = Files.FindMinStr(path)
                        + "\n\n" + Files.FindMaxStr(path);
                    Files.WriteStrToFile(newStr);
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Получить в новом файле те компоненты" +
                        " исходного файла, которые являются четными.");
                    const string path = "7.4.dat";
                    Files.FillBinaryFile(path);
                    Files.FillNewBinaryFile(path);
                    break;
                }
            case 5:
                {
                    Console.WriteLine(" Найти багаж, средняя масса одной" +
                        " единицы багажа, в котором отличается не более чем" +
                        " на m кг от общей средней массы одной единицы багажа.");
                    const string path = "7.5.xml";

                    Passenger[] passengers = new Passenger[3];

                    BaggageItem[] items1 = new BaggageItem[2];
                    items1[0] = new BaggageItem("Чемодан", 18.0);
                    items1[1] = new BaggageItem("Сумка", 4.0);
                    passengers[0] = new Passenger("Иванов", items1);

                    BaggageItem[] items2 = new BaggageItem[1];
                    items2[0] = new BaggageItem("Коробка", 12.0);
                    passengers[1] = new Passenger("Петров", items2);

                    BaggageItem[] items3 = new BaggageItem[2];
                    items3[0] = new BaggageItem("Рюкзак", 6.0);
                    items3[1] = new BaggageItem("Пакет", 2.0);
                    passengers[2] = new Passenger("Сидоров", items3);
                    for (int i = 0; i < passengers.Length; i++)
                    {
                        Console.WriteLine(passengers[i]);
                    }

                    Files.FillBaggageFile(path, passengers);
                    Console.WriteLine("Введите m - отклонение от средней массы");
                    double m = 0;
                    while (!double.TryParse(Console.ReadLine(), out m))
                    {
                        Console.WriteLine("Введена некорректная величина");
                    }
                    Files.FindBaggage(path, m);
                    break;
                }
            case 6:
                {
                    Console.WriteLine("Удаление всех элементов E из списка.");
                    List<string> words = [];
                    Collections.FillStringListFromConsole(words);
                    Console.WriteLine("Введите строку, которую нужно" +
                        " удалить из списка:");
                    string? target = Console.ReadLine();
                    if (!string.IsNullOrEmpty(target))
                    {
                        Collections.RemoveAllElements(words, target);
                    }
                    Console.WriteLine("\nСписок после удаления:");
                    if (words.Count == 0)
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    else
                    {
                        for (int i = 0; i < words.Count; i++)
                        {
                            Console.WriteLine(words[i] + " ");
                        }
                    }
                    break;
                }
            case 7:
                {
                    Console.WriteLine("Напечатать в обратном порядке" +
                        " элементы непустого списка L. ");
                    LinkedList<string> strings = new LinkedList<string>();
                    Collections.FillLinkedListFromConsole(strings);
                    Console.WriteLine("\nРезультат в обратном порядке:");
                    if (strings.First != null)
                    {
                        Collections.PrintInReverse(strings.First);
                    }
                    else
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    break;
                }
            case 8:
                {
                    Console.WriteLine("Есть перечень компьютерных фирм," +
                        " где может производиться закупка. ");
                    HashSet<string> allFirms = new HashSet<string>();
                    Console.Write("Введите количество фирм: ");
                    int count = 0;
                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Не целое число, повторите попытку: ");
                    }
                    string name = "Asus";
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Введите название фирмы: ");
                        name = Console.ReadLine();
                        allFirms.Add(name);
                    }
                    Console.WriteLine("Все фирмы: " + string.Join(", ", allFirms));

                    List<HashSet<string>> schools = new List<HashSet<string>>();

                    int n = 0;
                    Console.Write("Введите количество школ: ");
                    while (!int.TryParse(Console.ReadLine(), out count))
                    {
                        Console.WriteLine("Не целое число, повторите попытку: ");
                    }
                    for (int i = 0; i < count; i++)
                    {
                        HashSet<string> school = new HashSet<string>();
                        Console.Write($"Введите количество фирм для {i + 1} школы: ");
                        while (!int.TryParse(Console.ReadLine(), out n))
                        {
                            Console.WriteLine("Не целое число, повторите попытку: ");
                        }
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write("Введите название фирмы: ");
                            name = Console.ReadLine();
                            school.Add(name);
                        }
                        schools.Add(school);
                    }

                    HashSet<string> commonFirms = new HashSet<string>();
                    commonFirms = Collections.CommonFirms(schools);

                    HashSet<string> atLeastOneFirm = new HashSet<string>();
                    atLeastOneFirm = Collections.LeastOneFirm(schools);

                    HashSet<string> nobodyBoughtFirms = new HashSet<string>();
                    nobodyBoughtFirms = Collections.NobodyBoughtFirms(schools, allFirms);

                    Collections.PrintSet("Купили в каждом заведении: ", commonFirms);
                    Collections.PrintSet("Купили хотя бы в одном: ", atLeastOneFirm);
                    Collections.PrintSet("Никто не покупал: ", nobodyBoughtFirms);

                    break;
                }
            case 9:
                {
                    Console.WriteLine("Напечатать в алфавитном порядке все" +
                        " звонкие согласные буквы, которые входят " +
                        "хотя бы в одно слово. ");
                    const string path = "7.9.txt";
                    Collections.PrintVoicedConsonants(path);
                    break;
                }
            case 10:
                {
                    Console.WriteLine("Программа, которая формирует и" +
                        " печатает уникальный логин для каждого ученика");
                    const string path = "7.10.input.txt";
                    Collections.GenerateLoginsFromFile(path);
                    break;
                }
        }
    }
}