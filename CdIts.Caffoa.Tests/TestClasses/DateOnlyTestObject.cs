using System;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests.TestClasses;

public class DateOnlyTestObject
{
    [JsonConverter(typeof(CaffoaDateOnlyConverter))]
    public  DateOnly Date { get; set; } = DateOnly.Parse("2022-12-11");
    [JsonConverter(typeof(CaffoaTimeOnlyConverter))]
    public  TimeOnly Time { get; set; } = TimeOnly.Parse("12:30");
}

public class DateOnlyNullableTestObject
{
    [JsonConverter(typeof(CaffoaDateOnlyConverter))]
    public  DateOnly? Date { get; set; } = DateOnly.Parse("2022-12-11");
    [JsonConverter(typeof(CaffoaTimeOnlyConverter))]
    public  TimeOnly? Time { get; set; } = TimeOnly.Parse("12:30");
}