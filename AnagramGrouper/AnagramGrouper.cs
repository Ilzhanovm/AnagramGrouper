namespace AnagramGrouper;

using System.Text;

/// <summary>
/// Groups anagrams in the given list of words. 
/// </summary>
public class AnagramGrouper
{
    /// <summary>
    /// Hash value for the next new character.
    /// </summary>
    private int _nextHashValue;

    /// <summary>
    /// Stores hash values for each character encountered.
    /// </summary>
    private Dictionary<string, int> _hashValues;

    /// <summary>
    /// Constructor, defines a new grouper.
    /// </summary>
    public AnagramGrouper()
    {
        _nextHashValue = 1;
        _hashValues = new();
    }

    /// <summary>
    /// Generates a unique hash value for the set of characters (+ repetitions) in the given word. 
    /// </summary>
    /// <param name="word">String to hash</param>
    /// <returns>Numeric value unique for the given set of characters</returns>
    private int HashString(string word)
    {
        // hash is regarded as a binary number, where Each digit indicates the presence / absence of a character in the word
        int hash = 0;

        foreach (char character in word)
        {
            char lowerCharacter = char.ToLower(character);
            StringBuilder builder = new();
            string charKey;

            do
            {
                // take into account repeated characters by using number of encounters within charKey
                builder.Append(lowerCharacter);
                charKey = builder.ToString();

                if (!_hashValues.ContainsKey(charKey))
                {
                    _hashValues.Add(charKey, _nextHashValue);

                    // get next digit in a binary representation
                    _nextHashValue *= 2;
                }
                // while this hash value has already been encountered in the word (while corresponding binary digit is one)
            } while ((hash & _hashValues[charKey]) != 0);

            hash += _hashValues[charKey];
        }

        return hash;
    }

    /// <summary>
    /// Group a list of words.
    /// </summary>
    /// <param name="inputWords">List of words</param>
    /// <returns>List of lists containing anagrams</returns>
    public List<List<string>> GroupAnnagrams(List<string> inputWords)
    {
        Dictionary<int, List<string>> groups = new();

        foreach (string word in inputWords)
        {
            int hash = HashString(word);

            if (!groups.ContainsKey(hash))
                groups[hash] = new();

            groups[hash].Add(word);
        }

        return groups.Values.ToList();
    }
}