CountsInDictionary("banana");

void CountsInDictionary(string message)
{
    var counts = new Dictionary<char, int>();

    foreach (var letter in message)
    {
        if (counts.ContainsKey(letter))
        {
            counts[letter]++;
        }
        else
        {
            counts[letter] = 1;
        }
    }

    foreach (var count in counts)
    {
        Console.WriteLine($"{count.Key}: {count.Value}");
    }
}


