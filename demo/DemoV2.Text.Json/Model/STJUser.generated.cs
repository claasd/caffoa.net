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
    public partial class STJUser : STJAnyUser {
        public const string STJUserObjectName = "user";
        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; set; }

        [JsonPropertyName("address")]
        public virtual STJAddress Address { get; set; }

        [Obsolete]
        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonPropertyName("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonPropertyName("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonPropertyName("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonPropertyName("type")]
        public virtual TypeValue Type { get; set; } = TypeValue.Simple;

        [JsonPropertyName("role")]
        public virtual RoleValue Role { get; set; } = RoleValue.Reader;

        [Obsolete("do not use this")]
        [JsonPropertyName("ageGroup")]
        public virtual int? AgeGroup { get; set; } = 40;

        [JsonConverter(typeof(CustomTimeConverter))]
        [JsonPropertyName("preferredContactTime")]
        public virtual TimeOnly PreferredContactTime { get; set; } = TimeOnly.Parse("12:00");

        [JsonPropertyName("lastSessionLength")]
        public virtual TimeSpan LastSessionLength { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJUser(){}
        public STJUser(STJUser other) {
            Name = other.Name;
            Address = other.Address?.ToSTJAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions.ToDictionary(entry => entry.Key, entry => entry.Value);
            Type = (STJUser.TypeValue)other.Type;
            Role = (STJUser.RoleValue)other.Role;
            AgeGroup = other.AgeGroup;
            PreferredContactTime = other.PreferredContactTime;
            LastSessionLength = other.LastSessionLength;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJUser ToSTJUser() => new STJUser(this);
        public virtual STJAnyUser ToSTJAnyUser() => ToSTJUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
