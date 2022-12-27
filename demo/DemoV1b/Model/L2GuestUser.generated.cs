#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L2GuestUser : L2AnyUser, L2AnyCompleteUser {
        public const string L2GuestUserObjectName = "guestUser";

        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonIgnore]
        private string _type = "guest";

        [JsonProperty("type", Required = Required.Always)]
        public virtual string Type {
            get => _type;
            set {
                var _value = TypeValues.AllowedValues.FirstOrDefault(v=>String.Compare(v, value, StringComparison.OrdinalIgnoreCase) == 0, value);
                // set checkEnums=true in config file to have a value check here //
                // if (!TypeValues.AllowedValues.Contains(_value))
                // {
                //     var allowedValues = string.Join(", ", TypeValues.AllowedValues.Select(v => v.ToString()));
                //     throw new ArgumentOutOfRangeException("type",
                //         $"{value} is not allowed. Allowed values: [{allowedValues}]");
                // }
                _type = _value;
            }
        }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L2GuestUser(){}
        public L2GuestUser(L2GuestUser other) {
            Email = other.Email;
            Type = other.Type;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L2GuestUser ToL2GuestUser() => new L2GuestUser(this);
        public virtual L2AnyUser ToL2AnyUser() => ToL2GuestUser();
        public virtual L2AnyCompleteUser ToL2AnyCompleteUser() => ToL2GuestUser();
        public virtual string TypeDiscriminator => Type;
    }
}
