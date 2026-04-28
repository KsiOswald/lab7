[Serializable]
public struct BaggageItem
{
    private string _name;
    private double _weight;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _name = value;
            }
            else
            {
                _name = "Сумка";
            }
        }
    }

    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value > 0)
            {
                _weight = value;
            }
            else
            {
                _weight = 0;
            }
        }
    }

    public BaggageItem(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
    public override string ToString()
    {
        return $"{Name} ({Weight} кг)";
    }
}