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
using DemoIsolated.Model.Base;
using DemoIsolated.Model;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public partial class IsoUserWithId : IsoAnyUser, IsoAnyCompleteUser {
        public const string IsoUserWithIdObjectName = "userWithId";
        [JsonProperty("someEnums")]
        public virtual ICollection<IsoSomeEnum> SomeEnums { get; set; }

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual IsoAddress Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonProperty("role")]
        public virtual RoleValue Role { get; set; } = RoleValue.Reader;

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

        public IsoUserWithId(){}
        public IsoUserWithId(IsoUserWithId other) {
            SomeEnums = other.SomeEnums?.ToList();
            Name = other.Name;
            Address = other.Address?.ToIsoAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (IsoUserWithId.TypeValue)other.Type;
            Role = (IsoUserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.DeepClone();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoUserWithId(IsoUser other, bool deepClone = true) {
            SomeEnums = deepClone ? other.SomeEnums?.ToList() : other.SomeEnums;
            Name = other.Name;
            Address = deepClone ? other.Address?.ToIsoAddress() : other.Address;
            Birthdate = other.Birthdate;
            Emails = deepClone ? other.Emails?.ToList() : other.Emails;
            Descriptions = deepClone ? other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Descriptions;
            Type = (IsoUserWithId.TypeValue)other.Type;
            Role = (IsoUserWithId.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = deepClone ? (other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null) : other.AdditionalProperties;
        }
        public IsoUserWithId ToIsoUserWithId() => new IsoUserWithId(this);
        public virtual IsoAnyUser ToIsoAnyUser() => ToIsoUserWithId();
        public virtual IsoAnyCompleteUser ToIsoAnyCompleteUser() => ToIsoUserWithId();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
