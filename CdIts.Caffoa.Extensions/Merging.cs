using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Caffoa.Extensions;

public static class Merging
{
    public static T MergedWith<T>(this T item, T other) =>
        item.MergedWith<T>(other, null, JsonSerializer.CreateDefault());

    public static T MergedWith<T>(this T item, T other, JsonSerializer serializer) =>
        item.MergedWith<T>(other, null, serializer);

    public static T MergedWith<T>(this T item, T other, JsonSerializerSettings serializerSettings) =>
        item.MergedWith<T>(other, null, JsonSerializer.Create(serializerSettings));

    public static T MergedWith<T>(this T item, T other, JsonMergeSettings mergeSettings) =>
        item.MergedWith<T>(other, mergeSettings, JsonSerializer.CreateDefault());

    public static T MergedWith<T>(this T item, T other, JsonMergeSettings mergeSettings, JsonSerializer serializer) =>
        item.MergedWith<T>(JObject.FromObject(other, serializer), mergeSettings, serializer);

    public static T MergedWith<T>(this T item, JToken other) =>
        item.MergedWith(other, null, JsonSerializer.CreateDefault());

    public static T MergedWith<T>(this T item, JToken other, JsonSerializer serializer) =>
        item.MergedWith(other, null, serializer);

    public static T MergedWith<T>(this T item, JToken other, JsonSerializerSettings serializerSettings) =>
        item.MergedWith(other, null, JsonSerializer.Create(serializerSettings));

    public static T MergedWith<T>(this T item, JToken other, JsonMergeSettings mergeSettings) =>
        item.MergedWith(other, mergeSettings, JsonSerializer.CreateDefault());

    public static T MergedWith<T>(this T item, JToken other, JsonMergeSettings mergeSettings, JsonSerializer serializer)
    {
        return Merged<T>(JObject.FromObject(item, serializer), other, mergeSettings, serializer);
    }

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other) =>
        item.MergedWith(other, null, JsonSerializer.CreateDefault());

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other, JsonSerializer serializer) =>
        item.MergedWith(other, null, serializer);

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other,
        JsonSerializerSettings serializerSettings) =>
        item.MergedWith(other, null, JsonSerializer.Create(serializerSettings));

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other, JsonMergeSettings mergeSettings) =>
        item.MergedWith(other, mergeSettings, JsonSerializer.CreateDefault());


    public static TReturn MergedWith<TData, TReturn>(this TReturn item, TData other, JsonMergeSettings mergeSettings,
        JsonSerializer serializer) =>
        item.MergedWith<TData, TReturn>(JObject.FromObject(other, serializer), mergeSettings, serializer);

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, JToken other) =>
        item.MergedWith<TData, TReturn>(other, null, JsonSerializer.CreateDefault());

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, JToken other, JsonSerializer serializer) =>
        item.MergedWith<TData, TReturn>(other, null, serializer);

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, JToken other,
        JsonSerializerSettings serializerSettings) =>
        item.MergedWith<TData, TReturn>(other, null, JsonSerializer.Create(serializerSettings));

    public static TReturn MergedWith<TData, TReturn>(this TReturn item, JToken other, JsonMergeSettings mergeSettings,
        JsonSerializer serializer)
    {
        var temp = Merged<TData>(JObject.FromObject(item, serializer), other, mergeSettings, serializer);
        return item.MergedWith<TReturn>(JObject.FromObject(temp, serializer), mergeSettings, serializer);
    }

    public static T Merged<T>(JObject target, JToken other, JsonMergeSettings mergeSettings) =>
        Merged<T>(target, other, mergeSettings, JsonSerializer.CreateDefault());

    public static T Merged<T>(JObject target, JToken other, JsonSerializer serializer) =>
        Merged<T>(target, other, null, serializer);

    public static T Merged<T>(JObject target, JToken other, JsonSerializerSettings serializerSettings) =>
        Merged<T>(target, other, null, JsonSerializer.Create(serializerSettings));

    public static T Merged<T>(JObject target, JToken other, JsonMergeSettings mergeSettings, JsonSerializer serializer)
    {
        mergeSettings ??= new JsonMergeSettings()
        {
            MergeArrayHandling = MergeArrayHandling.Replace,
            MergeNullValueHandling = MergeNullValueHandling.Merge
        };
        target.Merge(other, mergeSettings);
        return target.ToObject<T>(serializer);
    }
}
