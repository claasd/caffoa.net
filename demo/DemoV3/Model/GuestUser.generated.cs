using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class GuestUser : AnyUser, AnyCompleteUser {
        public const string GuestUserObjectName = "guestUser";

        public static class TypeValues {
            // constant values for "type"
            public const string Guest = "guest";
    
            /// immutable array containing all allowed values for "type"
            public static readonly ImmutableArray<string> AllowedValues = ImmutableArray.Create<string>(Guest);
        }
        
        [Obsolete("Will be removed in a future version of caffoa. Use TypeValues.Guest instead.")]
        public const string TypeGuestValue = TypeValues.Guest;

        [Obsolete("Will be removed in a future version of caffoa. Use TypeValues.AllowedValues instead")]
        public static ImmutableArray<string> AllowedValuesForType { get => TypeValues.AllowedValues; }

        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonIgnore]
        private string _type = "guest";

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

        public GuestUser ToGuestUser() {
            var item = new GuestUser();
            item.UpdateWithGuestUser(this);
            return item;
        }

        public virtual AnyUser ToAnyUser() => ToGuestUser();

        public virtual AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();

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
