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
    public partial class User : AnyUser {
        public const string UserObjectName = "user";

        public static class TypeValues {
            // constant values for "type"
            public const string Simple = "simple";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Simple);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use TypeValues.Simple instead.")]
        public const string TypeSimpleValue = TypeValues.Simple;

        [Obsolete("Will be removed in a future version of caffoa. Use TypeValues.AllowedValues instead")]
        public static ImmutableArray<string> AllowedValuesForType { get => TypeValues.AllowedValues; }

        public static class AgeGroupValues {
            // constant values for "ageGroup"
            public const int _18 = 18;
            public const int _40 = 40;
            public const int _70 = 70;
            public const int _120 = 120;
    
            /// immutable array containing all allowed values for "ageGroup"
            public static readonly ImmutableArray<int?> AllowedValues = ImmutableArray.Create<int?>(_18, _40, _70, _120, null);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use AgeGroupValues._18 instead.")]
        public const int AgeGroup18Value = AgeGroupValues._18;
        [Obsolete("Will be removed in a future version of caffoa. Use AgeGroupValues._40 instead.")]
        public const int AgeGroup40Value = AgeGroupValues._40;
        [Obsolete("Will be removed in a future version of caffoa. Use AgeGroupValues._70 instead.")]
        public const int AgeGroup70Value = AgeGroupValues._70;
        [Obsolete("Will be removed in a future version of caffoa. Use AgeGroupValues._120 instead.")]
        public const int AgeGroup120Value = AgeGroupValues._120;

        [Obsolete("Will be removed in a future version of caffoa. Use AgeGroupValues.AllowedValues instead")]
        public static ImmutableArray<int?> AllowedValuesForAgeGroup { get => AgeGroupValues.AllowedValues; }

        /// <summary>
        /// A fancy string with description
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        [JsonConverter(typeof(CaffoaDateOnlyConverter))]
        [JsonProperty("birthdate")]
        public virtual DateOnly? Birthdate { get; set; }

        [JsonProperty("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        [JsonProperty("descriptions")]
        public virtual Dictionary<string, string> Descriptions { get; set; } = new Dictionary<string, string>();

        [JsonIgnore]
        private string _type = "simple";

        [JsonProperty("type", Required = Required.Always)]
        public virtual string Type {
            get {
                return _type;
            }
            set {
                if (!TypeValues.AllowedValues.Contains(value))
                {
                    var allowedValues = string.Join(", ", TypeValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("type",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _type = value;
            }
        }

        [JsonIgnore]
        private int? _ageGroup = 40;

        [JsonProperty("ageGroup")]
        public virtual int? AgeGroup {
            get {
                return _ageGroup;
            }
            set {
                if (!AgeGroupValues.AllowedValues.Contains(value))
                {
                    var allowedValues = string.Join(", ", AgeGroupValues.AllowedValues.Select(v => v == null ? "null" : v.ToString()));
                    throw new ArgumentOutOfRangeException("ageGroup",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _ageGroup = value;
            }
        }

        public User ToUser() {
            var item = new User();
            item.UpdateWithUser(this);
            return item;
        }

        public virtual AnyUser ToAnyUser() => ToUser();

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithUser(User other) {
            Name = other.Name;
            Address = other.Address?.ToAddress();
            Birthdate = other.Birthdate;
            Emails = other.Emails.ToList();
            Descriptions = other.Descriptions;
            Type = other.Type;
            AgeGroup = other.AgeGroup;
        }

        /// <summary>
        /// Merges all fields of User that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUser(User other, JsonMergeSettings mergeSettings = null) {
            MergeWithUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of User that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithUser(sourceObject.ToObject<User>());
        }
    }
}
