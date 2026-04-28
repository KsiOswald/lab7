[Serializable]
public struct Passenger
{
    private string _lastName;
    private BaggageItem[] _items;

    public Passenger(string lastName, BaggageItem[] items)
    {
        LastName = lastName;
        Items = items;
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _lastName = value;
            }
            else
            {
                _lastName = "Петров";
            }
        }
    }
    public BaggageItem[] Items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
        }
    }
    
    public override string ToString()
    {
        string itemsList = string.Join(", ", _items);

        return $"{LastName}: {itemsList}";
    }
}

