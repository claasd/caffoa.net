#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1EnumObject {
        public const string L1EnumObjectObjectName = "enumObject";
        [JsonIgnore]
        private string _single;

        [JsonProperty("single")]
        public virtual string Single {
            get => _single;
            set {
                var _value = SingleValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                if (!SingleValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", SingleValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("single",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _single = _value;
            }
        }

        [JsonProperty("array")]
        public virtual ICollection<string> Array { get; set; } = new List<string>();

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1EnumObject(){}
        public L1EnumObject(L1EnumObject other) {
            Single = other.Single;
            Array = other.Array.ToList();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1EnumObject ToL1EnumObject() => new L1EnumObject(this);
    }
}
