using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using Caffoa.JsonConverter;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class User : AnyUser {
        public const string UserObjectName = "user";

        /// <summary>
		/// A fancy string with description
		/// </summary>
		[JsonProperty("name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        [JsonConverter(typeof(CaffoaDateConverter))]
		[JsonProperty("birthdate")]
        public virtual DateTime? Birthdate { get; set; }

        [JsonProperty("emails")]
        public virtual ICollection<string> Emails { get; set; } = new List<string>();

        // constant values for "type"
        public const string TypeSimpleValue = "simple";

        /// <summary>
        /// immutable array containing all allowed values for "type"
        /// </summary>
        public static readonly ImmutableArray<string> AllowedValuesForType = ImmutableArray.Create<string>(TypeSimpleValue);

        [JsonIgnore]
        private string _type = "simple";

        [JsonProperty("type", Required = Required.Always)]
        public virtual string Type {
            get {
                return _type;
            }
            set {
                if (!AllowedValuesForType.Contains(value))
                {
                    var allowedValues = string.Join(", ", AllowedValuesForType.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("type",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _type = value;
            }
        }

        // constant values for "ageGroup"
        public const int AgeGroup18Value = 18;
		public const int AgeGroup40Value = 40;
		public const int AgeGroup70Value = 70;
		public const int AgeGroup120Value = 120;

        /// <summary>
        /// immutable array containing all allowed values for "ageGroup"
        /// </summary>
        public static readonly ImmutableArray<int?> AllowedValuesForAgeGroup = ImmutableArray.Create<int?>(AgeGroup18Value, AgeGroup40Value, AgeGroup70Value, AgeGroup120Value, null);

        [JsonIgnore]
        private int? _ageGroup = 40;

        [JsonProperty("ageGroup")]
        public virtual int? AgeGroup {
            get {
                return _ageGroup;
            }
            set {
                if (!AllowedValuesForAgeGroup.Contains(value))
                {
                    var allowedValues = string.Join(", ", AllowedValuesForAgeGroup.Select(v => v == null ? "null" : v.ToString()));
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

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithUser(User other) {
            Name = other.Name;
			Address = other.Address?.ToAddress();
			Birthdate = other.Birthdate;
			Emails = other.Emails.ToList();
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
