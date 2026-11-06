public class Journal
{
    
        public bool HasUnsavedChanges { get; private set; }
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        HasUnsavedChanges = true;
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }
        
        var entriesByMonth = _entries
            .GroupBy(entry =>
            {
                DateTime date = DateTime.Parse(entry._date);
                return new DateTime(date.Year, date.Month, 1);
            })
            .OrderByDescending(monthGroup => monthGroup.Key);
        
        foreach (var monthGroup in entriesByMonth)
        {
            Console.WriteLine(monthGroup.Key.ToString("MMMM yyyy"));
        
            foreach (Entry entry in monthGroup.OrderByDescending(
                entry => DateTime.Parse(entry._date)))
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        HasUnsavedChanges = false;
    }

    public void LoadFormFile(string file)
    {
        _entries.Clear();
        using (StreamReader inputFile = new StreamReader(file))

        {
            while (!inputFile.EndOfStream)
            {
                string[] parts = inputFile.ReadLine().Split('|');
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }
        HasUnsavedChanges = false;
    }
}
