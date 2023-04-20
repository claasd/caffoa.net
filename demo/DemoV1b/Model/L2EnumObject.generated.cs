#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2EnumObject {
        public const string L2EnumObjectObjectName = "enumObject";
        [JsonIgnore]
        private string _single;

        [JsonProperty("single")]
        public virtual string Single {
            get => _single;
            set {
                var _value = SingleValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!SingleValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", SingleValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("single",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _single = _value;
            }
        }

        [JsonIgnore]
        private string _withDefault = "undefined";

        [JsonProperty("withDefault")]
        public virtual string WithDefault {
            get => _withDefault;
            set {
                var _value = WithDefaultValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!WithDefaultValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", WithDefaultValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("withDefault",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _withDefault = _value;
            }
        }

        [JsonProperty("array")]
        public virtual ICollection<string> Array { get; set; } = new List<string>();

        [JsonIgnore]
        private string _nullable;

        [JsonProperty("nullable")]
        public virtual string Nullable {
            get => _nullable;
            set {
                var _value = NullableValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!NullableValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", NullableValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                //     throw new ArgumentOutOfRangeException("nullable",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _nullable = _value;
            }
        }

        [JsonIgnore]
        private string _nullableReferenced;

        [JsonProperty("nullableReferenced")]
        public virtual string NullableReferenced {
            get => _nullableReferenced;
            set {
                var _value = NullableReferencedValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!NullableReferencedValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", NullableReferencedValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                //     throw new ArgumentOutOfRangeException("nullableReferenced",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _nullableReferenced = _value;
            }
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2EnumObject(){}
        public L2EnumObject(L2EnumObject other) {
            Single = other.Single;
            WithDefault = other.WithDefault;
            Array = other.Array.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2EnumObject ToL2EnumObject() => new L2EnumObject(this);
    }
}
