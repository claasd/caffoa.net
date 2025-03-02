using Caffoa;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace CdIts.Caffoa.Tests.TestClasses;

public enum TestEnum1
{
    Value1,
    Value2,
    Value3
}

[JsonConverter(typeof(CaffoaEnumWrapperConverter<TestEnumWrapper>))]
public class TestEnumWrapper : CaffoaEnumWrapper<TestEnum1>
{
    public TestEnumWrapper(TestEnum1 value) : base(value)
    {
    }

    public TestEnumWrapper(string value) : base(value)
    {
    }

    public TestEnumWrapper()
    {
    }
    public static implicit operator TestEnumWrapper(TestEnum1 value) => new TestEnumWrapper(value);
}

public class EnumClassTestObject
{
    public TestEnumWrapper Data1 { get; set; } = TestEnum1.Value1;
    
    public TestEnumWrapper? Data2 { get; set; }
}