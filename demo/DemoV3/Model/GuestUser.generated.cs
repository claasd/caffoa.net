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

        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonIgnore]
        private string _type = "guest";

        [JsonProperty("type", Required = Required.Always)]
        public virtual string Type {
            get => _type;
            set {
                var _value = TypeValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                if (!TypeValues.AllowedValues.Contains(_value))
                {
                    var allowedValues = string.Join(", ", TypeValues.AllowedValues.Select(v => v.ToString()));
                    throw new ArgumentOutOfRangeException("type",
                        $"{value} is not allowed. Allowed values: [{allowedValues}]");
                }
                _type = _value;
            }
        }

        public GuestUser(){}
        public GuestUser(GuestUser other) {
            Email = other.Email;
            Type = other.Type;
        }
        public GuestUser ToGuestUser() => new GuestUser(this);
        public virtual AnyUser ToAnyUser() => ToGuestUser();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();
    }
}
