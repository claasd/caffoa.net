using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Caffoa.Extensions;

public static class Merging
{
    public static T MergedWith<T>(this T item, JToken other, JsonMergeSettings mergeSettings= null, JsonSerializer serializer = null,
        ICaffoaErrorHandler errorHandler = null)
    {
        serializer ??= JsonSerializer.CreateDefault();
        return Merged<T>(
            errorHandler != null ? errorHandler.ToJObject(item, serializer) : JObject.FromObject(item, serializer),
            other, mergeSettings, serializer, errorHandler);
    }

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other,
        JsonMergeSettings mergeSettings = null,
        JsonSerializer serializer = null, ICaffoaErrorHandler errorHandler = null)
    {
        serializer ??= JsonSerializer.CreateDefault();
        return item.MergedWith<TData, TReturn>(
            errorHandler != null ? errorHandler.ToJObject(other, serializer) : JObject.FromObject(other, serializer),
            mergeSettings, serializer, errorHandler);
    }

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, JToken other,
        JsonMergeSettings mergeSettings = null,
        JsonSerializer serializer = null, ICaffoaErrorHandler errorHandler = null)
    {
        serializer ??= JsonSerializer.CreateDefault();
        var temp = Merged<TData>(
            errorHandler != null ? errorHandler.ToJObject(item, serializer) : JObject.FromObject(item, serializer),
            other, mergeSettings, serializer, errorHandler);
        return Merged<TReturn>(
            errorHandler != null ? errorHandler.ToJObject(item, serializer) : JObject.FromObject(item, serializer),
            errorHandler != null ? errorHandler.ToJObject(temp, serializer) : JObject.FromObject(temp, serializer),
            mergeSettings, serializer, errorHandler);
    }

    public static T Merged<T>(JObject target, JToken other, JsonMergeSettings mergeSettings = null,
        JsonSerializer serializer = null, ICaffoaErrorHandler errorHandler = null)
    {
        serializer ??= JsonSerializer.CreateDefault();
        mergeSettings ??= new JsonMergeSettings()
        {
            MergeArrayHandling = MergeArrayHandling.Replace,
            MergeNullValueHandling = MergeNullValueHandling.Merge
        };
        target.Merge(other, mergeSettings);
        return errorHandler != null ? errorHandler.FromJObject<T>(target, serializer) : target.ToObject<T>(serializer);
    }
    
    public static JObject ToJObject<T>(this ICaffoaErrorHandler handler, T item, JsonSerializer serializer)
    {
        try
        {
            return JObject.FromObject(item, serializer);
        }
        catch (Exception e)
        {
            throw handler.JsonParseError(e);
        }
    }
    
    public static T FromJObject<T>(this ICaffoaErrorHandler handler, JObject item, JsonSerializer serializer)
    {
        try
        {
            return item.ToObject<T>(serializer);
        }
        catch (Exception e)
        {
            throw handler.JsonParseError(e);
        }
    }
}
