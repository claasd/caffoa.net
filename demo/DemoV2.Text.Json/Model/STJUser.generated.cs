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
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJUser : STJAnyUser, IEquatable<STJUser> {
        public const string STJUserObjectName = "user";
        [JsonPropertyName("someEnums")]
        public ICollection<STJSomeEnum> SomeEnums { get; set; }

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public STJAddress Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonPropertyName("birthdate")]
        public DateOnly? Birthdate { get; set; }

        [JsonPropertyName("emails")]
        public ICollection<string> Emails { get; set; } = new List<string>();

        [JsonPropertyName("descriptions")]
        public Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("type")]
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

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJUser(){}
        public STJUser(STJUser other) {
            SomeEnums = other.SomeEnums?.ToList();
            Name = other.Name;
            Address = other.Address?.ToSTJAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (STJUser.TypeValue)other.Type;
            Role = (STJUser.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJUser ToSTJUser() => new STJUser(this);
        public STJAnyUser ToSTJAnyUser() => ToSTJUser();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(STJUser other) {
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
                && LastSessionLength == other.LastSessionLength;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJUser other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJUser);
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
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
