#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Caffoa.JsonConverter;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1User : L1AnyUser {
        public const string L1UserObjectName = "user";
        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual L1Address Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonIgnore]
        private string _type = "simple";

        [JsonProperty("type", Required = Required.Always)]
        public virtual string Type {
            get => _type;
            set {
                var _value = TypeValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                if (!TypeValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", TypeValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("type",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _type = _value;
            }
        }

        [JsonIgnore]
        private string _role = "reader";

        [JsonProperty("role")]
        public virtual string Role {
            get => _role;
            set {
                var _value = RoleValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                if (!RoleValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", RoleValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("role",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _role = _value;
            }
        }

        [Obsolete("do not use this")]
        [JsonProperty("ageGroup")]
        public virtual int? AgeGroup { get; set; } = 40;

        [Obsolete("do not use this")]
        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonProperty("preferredContactTime")]
        public virtual TimeOnly PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonProperty("lastSessionLength")]
        public virtual TimeSpan LastSessionLength { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1User(){}
        public L1User(L1User other) {
            Name = other.Name;
            Address = other.Address?.ToL1Address();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = other.Type;
            Role = other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1User ToL1User() => new L1User(this);
        public virtual L1AnyUser ToL1AnyUser() => ToL1User();
        public virtual string TypeDiscriminator => Type;
    }
}
