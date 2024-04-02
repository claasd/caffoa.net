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
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class User : AnyUser, IEquatable<User> {
        public const string UserObjectName = "user";
        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public FancyString Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public Dictionary<string, FancyString> Descriptions { get; set; } = new Dictionary<string, FancyString>();

        [JsonProperty("type", Required = Required.Always)]
        public TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonProperty("role")]
        public RoleValue Role { get; set; } = RoleValue.Reader;

        [Obsolete("do not use this")]
        [JsonProperty("ageGroup")]
        public int? AgeGroup { get; set; } = 40;

        [Obsolete("do not use this")]
        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonProperty("preferredContactTime")]
        public TimeOnly PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonProperty("lastSessionLength")]
        public TimeSpan LastSessionLength { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public User(){}
        public User(User other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToFancyString());
            Type = (User.TypeValue)other.Type;
            Role = (User.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public User ToUser() => new User(this);
        public AnyUser ToAnyUser() => ToUser();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(User other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name.Equals(other.Name) && Address.Equals(other.Address) && Birthdate.Equals(other.Birthdate) && Emails.SequenceEqual(other.Emails) && Descriptions.SequenceEqual(other.Descriptions) && Type == other.Type && Role == other.Role && AgeGroup == other.AgeGroup && PreferredContactTime.Equals(other.PreferredContactTime) && LastSessionLength.Equals(other.LastSessionLength);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(User other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as User);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Address);
            hashCode.Add(Birthdate);
            hashCode.Add(Emails);
            hashCode.Add(Descriptions);
            hashCode.Add((int) Type);
            hashCode.Add((int) Role);
            hashCode.Add(AgeGroup);
            hashCode.Add(PreferredContactTime);
            hashCode.Add(LastSessionLength);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
