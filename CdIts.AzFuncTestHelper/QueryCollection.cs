using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace CdIts.AzFuncTestHelper;

public class QueryCollection : IQueryCollection
{
    public Dictionary<string, StringValues> Values { get; } = new();
    public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Values.GetEnumerator();
    public bool ContainsKey(string key) => Values.ContainsKey(key);
    public bool TryGetValue(string key, out StringValues value) => Values.TryGetValue(key, out value);
    public int Count => Values.Count;
    public ICollection<string> Keys => Values.Keys;
    public StringValues this[string key] => Values[key];
}