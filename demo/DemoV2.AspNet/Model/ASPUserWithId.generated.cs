#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Caffoa.JsonConverter;
using DemoV2.AspNet.Model.Base;
using DemoV2.AspNet.Model;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPUserWithId : ASPAnyUser, ASPAnyCompleteUser, IEquatable<ASPUserWithId> {
        public const string ASPUserWithIdObjectName = "userWithId";
        [JsonPropertyName("someEnums")]
        public ICollection<ASPSomeEnum> SomeEnums { get; set; }

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonPropertyName("name")]
        [JsonRequired]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public ASPAddress Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonPropertyName("birthdate")]
        public DateOnly? Birthdate { get; set; }

        [JsonPropertyName("emails")]
        public ICollection<string> Emails { get; set; } = new List<string>();

        [JsonPropertyName("descriptions")]
        public Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("type")]
        [JsonRequired]
        public TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonPropertyName("role")]
        public RoleValue Role { get; set; } = RoleValue.Reader;

        [Obsolete("do not use this")]
        [JsonPropertyName("ageGroup")]
        public int? AgeGroup { get; set; } = 40;

        [Obsolete("do not use this")]
        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonPropertyName("preferredContactTime")]
        public TimeOnly PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonPropertyName("lastSessionLength")]
        public TimeSpan LastSessionLength { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("registrationDate")]
        public DateTimeOffset RegistrationDate { get; set; }

        [JsonPropertyName("diffs")]
        public JsonElement? Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPUserWithId(){}
        public ASPUserWithId(ASPUserWithId other) {
            SomeEnums = other.SomeEnums?.ToList();
            Name = other.Name;
            Address = other.Address?.ToASPAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (ASPUserWithId.TypeValue)other.Type;
            Role = (ASPUserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.Clone();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPUserWithId(ASPUser other, bool deepClone = true) {
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            Name = other.Name;
            Address = deepClone ? other.Address?.ToASPAddress() : other.Address;
            Birthdate = other.Birthdate;
            Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            Type = (ASPUserWithId.TypeValue)other.Type;
            Role = (ASPUserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        public ASPUserWithId ToASPUserWithId() => new ASPUserWithId(this);
        public ASPAnyUser ToASPAnyUser() => ToASPUserWithId();
        public ASPAnyCompleteUser ToASPAnyCompleteUser() => ToASPUserWithId();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(ASPUserWithId other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.SomeEnums is null ? SomeEnums is null : SomeEnums?.SequenceEqual(other.SomeEnums) ?? other.SomeEnums is null)
                && Name == other.Name
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
        partial void _PartialEquals(ASPUserWithId other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPUserWithId);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(SomeEnums);
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
