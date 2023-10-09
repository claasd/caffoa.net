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
    public partial class ASPUserWithId : ASPAnyUser, ASPAnyCompleteUser {
        public const string ASPUserWithIdObjectName = "userWithId";
        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonPropertyName("name")]
        [JsonRequired]
        public virtual string Name { get; set; }

        [JsonPropertyName("address")]
        public virtual ASPAddress Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonPropertyName("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonPropertyName("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonPropertyName("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("type")]
        [JsonRequired]
        public virtual TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonPropertyName("role")]
        public virtual RoleValue Role { get; set; } = RoleValue.Reader;

        [Obsolete("do not use this")]
        [JsonPropertyName("ageGroup")]
        public virtual int? AgeGroup { get; set; } = 40;

        [Obsolete("do not use this")]
        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonPropertyName("preferredContactTime")]
        public virtual TimeOnly PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonPropertyName("lastSessionLength")]
        public virtual TimeSpan LastSessionLength { get; set; }

        [JsonPropertyName("id")]
        public virtual string Id { get; set; }

        [JsonPropertyName("registrationDate")]
        public virtual DateTimeOffset RegistrationDate { get; set; }

        [JsonPropertyName("diffs")]
        public virtual JsonElement? Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPUserWithId(){}
        public ASPUserWithId(ASPUserWithId other) {
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
        public virtual ASPAnyUser ToASPAnyUser() => ToASPUserWithId();
        public virtual ASPAnyCompleteUser ToASPAnyCompleteUser() => ToASPUserWithId();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
