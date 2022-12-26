#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
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
    public partial class UserWithId : AnyUser, AnyCompleteUser {
        public const string UserWithIdObjectName = "userWithId";

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonProperty("type")]
        public virtual TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonProperty("role")]
        public virtual RoleValue Role { get; set; } = RoleValue.Reader;

        [Obsolete("do not use this")]
        [JsonProperty("ageGroup")]
        public virtual int? AgeGroup { get; set; } = 40;

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
        public virtual object Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public UserWithId(){}
        public UserWithId(UserWithId other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (UserWithId.TypeValue)other.Type;
            Role = (UserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public UserWithId(User other){
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (UserWithId.TypeValue)other.Type;
            Role = (UserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public User ToUser() => new User() {
            Name = Name,
            Address = Address?.ToAddress(),
            Birthdate = Birthdate,
            Emails = Emails.ToList(),
            Descriptions = Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value),
            Type = (User.TypeValue)Type,
            Role = (User.RoleValue)Role,
            AgeGroup = AgeGroup,
            PreferredContactTime = PreferredContactTime,
            LastSessionLength = LastSessionLength,
            AdditionalProperties = AdditionalProperties != null ? new Dictionary<string, object>(AdditionalProperties) : null
        };
        public UserWithId ToUserWithId() => new UserWithId(this);
        public virtual AnyUser ToAnyUser() => ToUserWithId();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToUserWithId();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
