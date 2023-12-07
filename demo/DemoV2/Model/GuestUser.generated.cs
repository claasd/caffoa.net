#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Model.Base;

namespace DemoV2.Model {
/// AUTOGENERED BY caffoa ///
    public partial class GuestUser : AnyUser, AnyCompleteUser, IEquatable<GuestUser> {
        public const string GuestUserObjectName = "guestUser";
        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonProperty("constInt")]
        public virtual int ConstInt { get; set; } = 1;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public GuestUser(){}
        public GuestUser(GuestUser other) {
            Email = other.Email;
            Type = (GuestUser.TypeValue)other.Type;
            ConstInt = other.ConstInt;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public GuestUser ToGuestUser() => new GuestUser(this);
        public virtual AnyUser ToAnyUser() => ToGuestUser();
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();
        public virtual string TypeDiscriminator => Type.Value();
        public bool Equals(GuestUser other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Email == other.Email && Type == other.Type && ConstInt == other.ConstInt;
        }
        public override bool Equals(object obj) => Equals(obj as GuestUser);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Email);
            hashCode.Add((int) Type);
            hashCode.Add(ConstInt);
            return hashCode.ToHashCode();
        }
    }
}
