#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public partial class GuestUser : AnyUser, AnyCompleteUser {
        public const string GuestUserObjectName = "guestUser";

        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public GuestUser(){}
        public GuestUser(GuestUser other) {
            Email = other.Email;
            Type = (GuestUser.TypeValue)other.Type;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public GuestUser ToGuestUser() => new GuestUser(this);
        public virtual AnyUser ToAnyUser() => ToGuestUser();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
