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
using DemoV2.Model;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class UserWithId : AnyUser, AnyCompleteUser, IEquatable<UserWithId> {
        public const string UserWithIdObjectName = "userWithId";
        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

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

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("registrationDate")]
        public DateTimeOffset RegistrationDate { get; set; }

        [JsonProperty("diffs")]
        public JToken Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public UserWithId(){}
        public UserWithId(UserWithId other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (UserWithId.TypeValue)other.Type;
            Role = (UserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.DeepClone();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public UserWithId(User other, bool deepClone = false) {
            Name = other.Name;
            Address = deepClone ? other.Address?.ToAddress() : other.Address;
            Birthdate = other.Birthdate;
            Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            Type = (UserWithId.TypeValue)other.Type;
            Role = (UserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        public UserWithId ToUserWithId() => new UserWithId(this);
        public AnyUser ToAnyUser() => ToUserWithId();
        public AnyCompleteUser ToAnyCompleteUser() => ToUserWithId();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(UserWithId other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && (Address?.Equals(other.Address) ?? other.Address is null)
                && (Birthdate?.Equals(other.Birthdate) ?? other.Birthdate is null)
                && (other.Emails is null ? Emails is null : Emails?.SequenceEqual(other.Emails) ?? other.Emails is null)
                && (other.Descriptions is null ? Descriptions is null : Descriptions?.SequenceEqual(other.Descriptions) ?? other.Descriptions is null)
                && Type == other.Type
                && Role == other.Role
                && AgeGroup == other.AgeGroup
                && PreferredContactTime == other.PreferredContactTime
                && LastSessionLength == other.LastSessionLength
                && Id == other.Id
                && RegistrationDate == other.RegistrationDate
                && (Diffs?.Equals(other.Diffs) ?? other.Diffs is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(UserWithId other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as UserWithId);
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
            hashCode.Add(Id);
            hashCode.Add(RegistrationDate);
            hashCode.Add(Diffs);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
