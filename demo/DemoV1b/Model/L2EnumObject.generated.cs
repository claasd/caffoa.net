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
    public sealed  partial class L2EnumObject : IEquatable<L2EnumObject> {
        public const string L2EnumObjectObjectName = "enumObject";
        [JsonIgnore]
        private string _single;

        [JsonProperty("single")]
        public string Single {
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
        public string WithDefault {
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
        public ICollection<string> Array { get; set; } = new List<string>();

        [JsonIgnore]
        private string _nullable;

        [JsonProperty("nullable")]
        public string Nullable {
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
        public string NullableReferenced {
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
            Array = other.Array?.ToList();
            Nullable = other.Nullable;
            NullableReferenced = other.NullableReferenced;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2EnumObject ToL2EnumObject() => new L2EnumObject(this);
        public bool Equals(L2EnumObject other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Single == other.Single
                && WithDefault == other.WithDefault
                && (other.Array is null ? Array is null : Array?.SequenceEqual(other.Array) ?? other.Array is null)
                && Nullable == other.Nullable
                && NullableReferenced == other.NullableReferenced;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L2EnumObject other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L2EnumObject);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Single);
            hashCode.Add(WithDefault);
            hashCode.Add(Array);
            hashCode.Add(Nullable);
            hashCode.Add(NullableReferenced);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
