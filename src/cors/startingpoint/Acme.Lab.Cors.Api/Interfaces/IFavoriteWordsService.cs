using System;
using System.Collections.Generic;

namespace Acme.Lab.Cors.Api;

public interface IFavoriteWordsService
{
    IEnumerable<String> Get();
    String Get(int ranking);
    void Add(String word);
    void Remove(String word);
}
