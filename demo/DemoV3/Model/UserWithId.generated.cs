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
        public virtual AgeGroupValue? AgeGroup { get; set; } = AgeGroupValue._40;

        [JsonConverter(typeof(CaffoaTimeOnlyConverter))]
        [JsonProperty("preferredContactTime")]
        public virtual TimeOnly? PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("registrationDate")]
        public virtual DateTime RegistrationDate { get; set; }

        public UserWithId(){}
        public UserWithId(UserWithId other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (TypeValue)other.Type;
            Role = (RoleValue)other.Role;
            AgeGroup = other.AgeGroup is null ? null : (AgeGroupValue)other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
        }
        public UserWithId(User other){
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (TypeValue)other.Type;
            Role = (RoleValue)other.Role;
            AgeGroup = other.AgeGroup is null ? null : (AgeGroupValue)other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
        }
        public UserWithId ToUserWithId() => new UserWithId(this);
        public virtual AnyUser ToAnyUser() => ToUserWithId();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToUserWithId();
        public virtual string TypeDiscriminator => Type.ToString();
        public virtual User ToUser() => new User(this);
    }
}
