#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace DemoV2.Model.Base {
/// AUTOGENERED BY caffoa ///
    [JsonConverter(typeof(CaffoaValueTypeConverter<RestrictedInt, int>))]
    public sealed partial class RestrictedInt : ICaffoaValueType<int>,  IEquatable<RestrictedInt> {
        public const string RestrictedIntObjectName = "restrictedInt";
        private int _value;
        public int Value { 
            get => _value; 
            set => _value = Validated(value); 
        }
        public RestrictedInt(int value) => Value = value;
        public RestrictedInt(){}
        public RestrictedInt(RestrictedInt other) => Value = other.Value;
        public RestrictedInt ToRestrictedInt() => new RestrictedInt(this);
        public static implicit operator RestrictedInt(int value) => new RestrictedInt(value);
        public static implicit operator int(RestrictedInt value) => value.Value;
        public bool Equals(RestrictedInt other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }
        partial void CustomValidation(int value);
        public int Validated(int value){
            CustomValidation(value);
            return value;
        }
        
    }
}
