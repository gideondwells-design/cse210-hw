public class Scripture
{
    Reference reference;
    List<Word> words;

    public Scripture(Reference reference, List<Word> words)
    {
        this.reference = reference;
        this.words = words;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = words
            .Where(word => !word.IsHidden())
            .ToList();
    
        int countToHide = Math.Min(Math.Max(numberToHide, 0), visibleWords.Count);
    
        for (int i = 0; i < countToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }    public string GetDisplayText()
    {
        return $"{reference.GetDisplayText()} {string.Join(" ", words.Select(word => word.GetDisplayText()))}";
    }
    public bool IsCompletelyHidden()
    {
        return words.All(word => word.IsHidden());
    }
}