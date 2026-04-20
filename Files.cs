using System.Xml.Serialization;

[Serializable]
public struct BaggageItem
{
    private string name;
    private double weight;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = value;
        }
    }

    public BaggageItem(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
    }
}

[Serializable]
public struct Passenger
{
    private string lastName;
    private BaggageItem[] items;

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            lastName = value;
        }
    }

    public BaggageItem[] Items
    {
        get
        {
            return items;
        }
        set
        {
            items = value;
        }
    }

    public Passenger(string lastName, BaggageItem[] items)
    {
        this.lastName = lastName;
        this.items = items;
    }
}
internal class Files
{
    
    public static void CreateRandomIntFile(string path)
    {
        var rand = new Random();
        int sizeOfFile = rand.Next(1, 12345) * 2;
        StreamWriter writer = new StreamWriter(path, false);
        for (int i = 0; i < sizeOfFile; i++)
        {
            writer.WriteLine(rand.Next(-99999, 99999));
        }
        writer.Close();
    }
    public static int LengthOfFile(string path)
    {
        int length = 0;
        StreamReader reader = new StreamReader(path);
        while (reader.ReadLine() != null)
        {
            length++;
        }
        reader.Close();
        return length;
    }

    public static int DiffOfHalves(string path, int length)
    {
        int sumOfFirstHalf = 0;
        int sumOfSecondHalf = 0;
        StreamReader reader = new StreamReader(path);
        int i = 0;
        for (i = 0; i < length / 2; i++)
        {
            string? new_number = reader.ReadLine();
            sumOfFirstHalf += int.Parse(new_number);
        }
        while (i < length)
        {
            string? new_number = reader.ReadLine();
            sumOfSecondHalf += int.Parse(new_number);
            i++;
        }
        reader.Close();
        return sumOfFirstHalf - sumOfSecondHalf;
    }

    public static void CreateFileLotIntNumbers(string path)
    {
        var rand = new Random();
        int sizeOfFile = rand.Next(1, 1234);
        StreamWriter writer = new StreamWriter(path, false);
        for (int countOfStrings = 0;
            countOfStrings < sizeOfFile; countOfStrings++)
        {
            int quantity = rand.Next(1, 6);
            for (int countOfNumbers = 0;
                countOfNumbers < quantity; countOfNumbers++)
            {
                writer.Write(rand.Next(-1000, 1001) + " ");
            }
            writer.WriteLine();
        }
        writer.Close();
    }

    public static int SumOfFile(string path)
    {
        int sum = 0;
        string newNumber;
        char newChar;
        StreamReader reader = new StreamReader(path, false);
        while (reader.Peek() != -1)
        {
            newNumber = "";
            while (((char)reader.Peek() != ' ') && 
                ((char)reader.Peek() != '\r'))
            {
                newChar = (char)reader.Read();
                newNumber += newChar;
            }
            if (reader.Peek() == ' ')
            {
                sum += int.Parse(newNumber);
                reader.Read();
            }
            else if (reader.Peek() == '\r')
            {
                reader.Read();
                reader.Read();
            }
        }
        reader.Close();
        return sum;
    }
    public static string FindMinStr(string path)
    {
        string? newStr;
        string? minStr;
        StreamReader reader = new StreamReader(path);
        newStr = reader.ReadLine();
        minStr = newStr;
        while (newStr != null)
        {
            newStr = reader.ReadLine();
            if ((newStr != null) && (newStr.Length < minStr.Length))
            {
                minStr = newStr;
            }
        }
        reader.Close();
        return minStr;
    }

    public static string FindMaxStr(string path)
    {
        string? newStr;
        string? maxStr;
        StreamReader reader = new StreamReader(path);
        newStr = reader.ReadLine();
        maxStr = newStr;
        while (newStr != null)
        {
            newStr = reader.ReadLine();
            if ((newStr != null) && (newStr.Length > maxStr.Length))
            {
                maxStr = newStr;
            }
        }
        reader.Close();
        return maxStr;
    }
    public static void WriteStrToFile(string str)
    {
        const string path = "newFile7.3.txt";
        StreamWriter writer = new StreamWriter(path);
        writer.Write(str);
        Console.WriteLine("Информация записана в файл " + path);
        writer.Close();
    }
    public static void FillBinaryFile(string path)
    {
        Random rand = new Random();
        int count = rand.Next(1,1001);
        BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(rand.Next(1, 10001));
            }
        }
        writer.Close();
    }
    public static int GetSumOfEvenNumbers(string path)
    {
        int sum = 0;
        BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            int number = reader.ReadInt32();
            if (number % 2 == 0)
            {
                sum += number;
            }
        }
        reader.Close();
        return sum;
    }
    public static void FillBaggageFile(string path)
    {
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

        XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
        FileStream fs = new FileStream(path, FileMode.Create);
        serializer.Serialize(fs, passengers);
        fs.Close();
    }

    public static void FindBaggage(string path, double m)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
        Passenger[] passengers;
        FileStream file = new FileStream(path, FileMode.Open);
        {
            passengers = (Passenger[])serializer.Deserialize(file);
        }
        file.Close();

        double totalWeight = 0;
        int totalItemsCount = 0;
        for (int i = 0; i < passengers.Length; i++)
        {
            BaggageItem[] currentItems = passengers[i].Items;
            for (int j = 0; j < currentItems.Length; j++)
            {
                totalWeight += currentItems[j].Weight;
                totalItemsCount++;
            }
        }

        double overallAverage = totalWeight / totalItemsCount;
        Console.WriteLine("Общая средняя масса: " + overallAverage);

        for (int i = 0; i < passengers.Length; i++)
        {
            double currentSum = 0;
            BaggageItem[] currentItems = passengers[i].Items;
            for (int j = 0; j < currentItems.Length; j++)
            {
                currentSum += currentItems[j].Weight;
            }
            double currentAverage = currentSum / currentItems.Length;
            double diff = currentAverage - overallAverage;
            if (Math.Abs(diff) <= m)
            {
                Console.WriteLine("Пассажир: " + passengers[i].LastName +
                                  " Средняя масса: " + currentAverage);
            }
        }
    }
}