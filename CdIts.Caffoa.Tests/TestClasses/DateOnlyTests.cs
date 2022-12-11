using System;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests.TestClasses;

public class DateOnlyTests
{
    [JsonConverter(typeof(CaffoaDateOnlyConverter))]
    public  DateOnly Date { get; set; } = DateOnly.Parse("2022-12-11");
}

public class DateOnlyTestsNullable
{
    [JsonConverter(typeof(CaffoaDateOnlyConverter))]
    public  DateOnly? Date { get; set; } = DateOnly.Parse("2022-12-11");
}