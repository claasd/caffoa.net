using Newtonsoft.Json.Linq;

namespace Caffoa.Extensions;

public static class Merging
{
    public static T MergedWith<T>(this T item, T other, JsonMergeSettings mergeSettings = null)
    {
        return item.MergedWith(JObject.FromObject(other), mergeSettings);
    }
    
    public static T MergedWith<T>(this T item, JToken other, JsonMergeSettings mergeSettings = null)
    {
        mergeSettings ??= new JsonMergeSettings()
        {
            MergeArrayHandling = MergeArrayHandling.Replace,
            MergeNullValueHandling = MergeNullValueHandling.Merge
        };
        var sourceObject = JObject.FromObject(item);
        sourceObject.Merge(other, mergeSettings);
        return sourceObject.ToObject<T>();
    }
}
