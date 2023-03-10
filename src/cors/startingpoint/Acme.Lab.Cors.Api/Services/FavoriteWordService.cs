using System.Collections.Generic;

namespace Acme.Lab.Cors.Api;

public class FavoriteWordService : IFavoriteWordsService
{
    private List<string> words = new List<string>
    {
        "Enfarculate",
        "Loathsome"
    };

    public void Add(string word)
    {
        this.words.Add(word);
    }

    public IEnumerable<string> Get()
    {
        return this.words;
    }

    public string Get(int ranking)
    {
        return this.words[ranking];
    }

    public void Remove(string word)
    {
        this.words.Remove(word);
    }
}
