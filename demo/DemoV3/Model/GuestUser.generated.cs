using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
	[JsonObject(MemberSerialization.OptIn)]
    public partial class GuestUser : AnyUser, AnyCompleteUser {
        public const string GuestUserObjectName = "guestUser";

        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        // constant values for "type"
        public const string TypeGuestValue = "guest";

        /// <summary>
        /// immutable array containing all allowed values for "type"
        /// </summary>
        public static readonly ImmutableArray<string> AllowedValuesForType = ImmutableArray.Create<string>(TypeGuestValue);

        [JsonIgnore]
        private string _type = "guest";

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

        public GuestUser ToGuestUser() {
            var item = new GuestUser();
            item.UpdateWithGuestUser(this);
            return item;
        }

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public void UpdateWithGuestUser(GuestUser other) {
            Email = other.Email;
			Type = other.Type;
        }

        /// <summary>
        /// Merges all fields of GuestUser that are present in the passed object with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithGuestUser(GuestUser other, JsonMergeSettings mergeSettings = null) {
            MergeWithGuestUser(JObject.FromObject(other), mergeSettings);
        }

        /// <summary>
        /// Merges all fields of GuestUser that are present in the passed JToken with the current object.
        /// If merge settings are not omitted, Arrays will be replaced and null value will replace existing values
        /// </summary>
        public void MergeWithGuestUser(JToken other, JsonMergeSettings mergeSettings = null) {
            mergeSettings ??= new JsonMergeSettings()
            {
                MergeArrayHandling = MergeArrayHandling.Replace,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            };
            var sourceObject = JObject.FromObject(this);
            sourceObject.Merge(other, mergeSettings);
            UpdateWithGuestUser(sourceObject.ToObject<GuestUser>());
        }
    }
}
