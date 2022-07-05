using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Caffoa.JsonConverter;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class User : AnyUser {
        public const string UserObjectName = "user";

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateConverter))]
        [JsonProperty("birthdate")]
        public virtual DateTime? Birthdate { get; set; }

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

        [JsonIgnore]
        private int? _ageGroup = 40;

        [Obsolete("do not use this")]
        [JsonProperty("ageGroup")]
        public virtual int? AgeGroup {
            get => _ageGroup;
            set {
                var _value = value;
                if (!AgeGroupValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", AgeGroupValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("ageGroup",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _ageGroup = _value;
            }
        }

        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonProperty("preferredContactTime")]
        public virtual TimeSpan PreferredContactTime { get; set; } = TimeSpan.Parse("12:00");

        public User(){}
        public User(User other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions;
            Type = other.Type;
            Role = other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
        }
        public User ToUser() => new User(this);
        public virtual AnyUser ToAnyUser() => ToUser();
    }
}
