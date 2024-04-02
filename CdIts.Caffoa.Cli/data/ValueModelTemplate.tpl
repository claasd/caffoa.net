#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Caffoa.JsonConverter;
using Newtonsoft.Json;

namespace {NAMESPACE} {{
{DESCRIPTION}[JsonConverter(typeof(CaffoaValueTypeConverter<{NAME}, {TYPE}>))]
    public sealed partial class {NAME} : ICaffoaValueType<{TYPE}>,  IEquatable<{NAME}> {{
        public const string {NAME}ObjectName = "{RAWNAME}";
        private {TYPE} _value;
        public {TYPE} Value {{ 
            get => _value; 
            set => _value = Validated(value); 
        }}
        public {NAME}({TYPE} value) => Value = value;
        public {NAME}(){{}}
        public {NAME}({NAME} other) => Value = other.Value;
        public {NAME} To{NAME}() => new {NAME}(this);
        public static implicit operator {NAME}({TYPE} value) => new {NAME}(value);
        public static implicit operator {TYPE}({NAME} value) => value.Value;
        public bool Equals({NAME} other)
        {{
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }}
        partial void CustomValidation({TYPE} value);
        public {TYPE} Validated({TYPE} value){{
            CustomValidation(value);
            return value;
        }}
        
    }}
}}
