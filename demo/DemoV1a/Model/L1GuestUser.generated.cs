using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1GuestUser : L1AnyUser, L1AnyCompleteUser {
        public const string L1GuestUserObjectName = "guestUser";

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

        public L1GuestUser(){}
        public L1GuestUser(L1GuestUser other) {
            Email = other.Email;
            Type = other.Type;
        }
        public L1GuestUser ToL1GuestUser() => new L1GuestUser(this);
        public virtual L1AnyUser ToL1AnyUser() => ToL1GuestUser();
        public virtual L1AnyCompleteUser ToL1AnyCompleteUser() => ToL1GuestUser();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
