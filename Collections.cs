internal class Collections
{
    public static void FillStringListFromConsole(List<string> list)
    {

        Console.Write("Введите количество строк в списке: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
        {
            Console.Write("Ошибка! Введите целое положительное число: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите строку {i}: ");
            string? input = Console.ReadLine();
            while (input == null)
            {
                Console.Write("Ошибка ввода! Попробуйте еще раз" +
                    $" для строки {i}: ");
                input = Console.ReadLine();
            }

            list.Add(input);
        }
    }
    public static void RemoveAllElements<T>(List<T> list, T itemToRemove)
    {
        if (list == null)
        {
            return;
        }
        int i = 0;
        while (i < list.Count)
        {
            if (list[i].Equals(itemToRemove))
            {
                list.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
    }
    public static void FillLinkedListFromConsole(LinkedList<string> list)
    {
        Console.Write("Введите количество элементов: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            return;
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            string? input = Console.ReadLine();
            list.AddLast(input);
        }
    }
    public static void PrintInReverse<T>(LinkedListNode<T> node)
    {
        if (node == null)
        {
            return;
        }
        PrintInReverse(node.Next);
        Console.Write(node.Value + " ");
    }

    public static HashSet<string> CommonFirms(List<HashSet<string>> schoolsPurchases)
    {
        HashSet<string> commonFirms = new HashSet<string>(schoolsPurchases[0]);
        for (int i = 1; i < schoolsPurchases.Count; i++)
        {
            commonFirms.IntersectWith(schoolsPurchases[i]);
        }
        return commonFirms;
    }
    public static HashSet<string> LeastOneFirm(List<HashSet<string>> schoolsPurchases)
    {
        HashSet<string> atLeastOneFirm = new HashSet<string>();
        for (int i = 0; i < schoolsPurchases.Count; i++)
        {
            atLeastOneFirm.UnionWith(schoolsPurchases[i]);
        }
        return atLeastOneFirm;
    }
    public static HashSet<string> NobodyBoughtFirms(List<HashSet<string>> schoolsPurchases,
        HashSet<string> allFirms)
    {
        HashSet<string> nobodyBoughtFirms = new HashSet<string>(allFirms);
        if (schoolsPurchases.Count == 0)
        {
            return nobodyBoughtFirms;
        }
        HashSet<string> atLeastOneFirm = new HashSet<string>();
        atLeastOneFirm = LeastOneFirm(schoolsPurchases);
        nobodyBoughtFirms.ExceptWith(atLeastOneFirm);
        return nobodyBoughtFirms;
    }
    public static void PrintSet(string message, HashSet<string> set)
    {
        Console.WriteLine(message);
        if (set.Count == 0)
        {
            Console.WriteLine("Список пуст");
        }
        else
        {
            foreach (string item in set)
            {
                Console.WriteLine(" " + item);
            }
        }
    }
    public static void PrintVoicedConsonants(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        string voicedPattern = "бвгджзлмнр";
        HashSet<char> foundLetters = new HashSet<char>();
        StreamReader reader = new StreamReader(path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
            string lowerLine = line.ToLower();
            for (int i = 0; i < lowerLine.Length; i++)
            {
                char symbol = lowerLine[i];
                if (voicedPattern.IndexOf(symbol) != -1)
                {
                    foundLetters.Add(symbol);
                }
            }
        }
        reader.Close();
        List<char> sortedLetters = new List<char>();
        foreach (char c in foundLetters)
        {
            sortedLetters.Add(c);
        }
        sortedLetters.Sort();
        Console.WriteLine("Звонкие согласные из текста в алфавитном порядке:");
        if (sortedLetters.Count == 0)
        {
            Console.WriteLine("Звонкие согласные не найдены.");
        }
        else
        {
            for (int i = 0; i < sortedLetters.Count; i++)
            {
                Console.Write(sortedLetters[i] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void GenerateLoginsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        Dictionary<string, int> surnameCounter = new Dictionary<string, int>();
        StreamReader reader = new StreamReader(filePath);
        string firstLine = reader.ReadLine();
        int n = int.Parse(firstLine);
        Console.WriteLine("Итоговые логины: ");
        for (int i = 0; i < n; i++)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                string surname = parts[0];
                if (surnameCounter.ContainsKey(surname))
                {
                    surnameCounter[surname]++;
                    Console.WriteLine(surname + surnameCounter[surname]);
                }
                else
                {
                    surnameCounter.Add(surname, 1);
                    Console.WriteLine(surname);
                }
            }
        }
        reader.Close();
    }
}