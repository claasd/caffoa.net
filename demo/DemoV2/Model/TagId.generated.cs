#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    [JsonConverter(typeof(CaffoaValueTypeConverter<TagId, Guid>))]
    public sealed partial class TagId : ICaffoaValueType<Guid>,  IEquatable<TagId> {
        public const string TagIdObjectName = "tagId";
        private Guid _value;
        public Guid Value { 
            get => _value; 
            set => _value = Validated(value); 
        }
        public TagId(Guid value) => Value = value;
        public TagId(){}
        public TagId(TagId other) => Value = other.Value;
        public TagId ToTagId() => new TagId(this);
        public static implicit operator TagId(Guid value) => new TagId(value);
        public static implicit operator Guid(TagId value) => value.Value;
        public bool Equals(TagId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }
        partial void CustomValidation(Guid value);
        public Guid Validated(Guid value){
            CustomValidation(value);
            return value;
        }
        
    }
}
