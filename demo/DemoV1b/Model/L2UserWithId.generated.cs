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
using DemoV1b.Model.Base;
using DemoV1b.Model;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2UserWithId : L2AnyUser, L2AnyCompleteUser {
        public const string L2UserWithIdObjectName = "userWithId";
        [JsonProperty("someEnums")]
        public virtual ICollection<string> SomeEnums { get; set; }

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual L2Address Address { get; set; }

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
                // set checkEnums=true in config file to have a value check here //
                // if (!TypeValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", TypeValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("type",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
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
                // set checkEnums=true in config file to have a value check here //
                // if (!RoleValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", RoleValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("role",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
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

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("registrationDate")]
        public virtual DateTimeOffset RegistrationDate { get; set; }

        [JsonProperty("diffs")]
        public virtual JToken Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2UserWithId(){}
        public L2UserWithId(L2UserWithId other) {
            SomeEnums = other.SomeEnums?.ToList();
            Name = other.Name;
            Address = other.Address?.ToL2Address();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = other.Type;
            Role = other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.DeepClone();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2UserWithId(L2User other, bool deepClone = true) {
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            Name = other.Name;
            Address = deepClone ? other.Address?.ToL2Address() : other.Address;
            Birthdate = other.Birthdate;
            Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            Type = other.Type;
            Role = other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        public L2UserWithId ToL2UserWithId() => new L2UserWithId(this);
        public virtual L2AnyUser ToL2AnyUser() => ToL2UserWithId();
        public virtual L2AnyCompleteUser ToL2AnyCompleteUser() => ToL2UserWithId();
        public virtual string TypeDiscriminator => Type;
    }
}
