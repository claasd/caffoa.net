#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    [JsonConverter(typeof(CaffoaValueTypeConverter<FancyString, string>))]
    public sealed partial class FancyString : ICaffoaValueType<string>,  IEquatable<FancyString> {
        public const string FancyStringObjectName = "fancyString";
        private string _value;
        public string Value { 
            get => _value; 
            set => _value = Validated(value); 
        }
        public FancyString(string value) => Value = value;
        public FancyString(){}
        public FancyString(FancyString other) => Value = other.Value;
        public FancyString ToFancyString() => new FancyString(this);
        public static implicit operator FancyString(string value) => new FancyString(value);
        public static implicit operator string(FancyString value) => value.Value;
        public bool Equals(FancyString other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }
        partial void CustomValidation(string value);
        public string Validated(string value){
            CustomValidation(value);
            return value;
        }
        
    }
}
