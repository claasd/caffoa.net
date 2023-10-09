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

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPUser : ASPAnyUser {
        public const string ASPUserObjectName = "user";
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

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPUser(){}
        public ASPUser(ASPUser other) {
            Name = other.Name;
            Address = other.Address?.ToASPAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails?.ToList();
            Descriptions = other.Descriptions?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (ASPUser.TypeValue)other.Type;
            Role = (ASPUser.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPUser ToASPUser() => new ASPUser(this);
        public virtual ASPAnyUser ToASPAnyUser() => ToASPUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
