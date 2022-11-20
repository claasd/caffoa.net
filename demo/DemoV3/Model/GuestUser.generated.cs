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

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        public GuestUser(){}
        public GuestUser(GuestUser other) {
            Email = other.Email;
            Type = other.Type;
        }
        public GuestUser ToGuestUser() => new GuestUser(this);
        public virtual AnyUser ToAnyUser() => ToGuestUser();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
