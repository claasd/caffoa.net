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
    public sealed  partial class GuestUser : AnyUser, AnyCompleteUser, IEquatable<GuestUser> {
        public const string GuestUserObjectName = "guestUser";
        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonProperty("constInt")]
        public int ConstInt { get; set; } = 1;

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
        public AnyUser ToAnyUser() => ToGuestUser();
        public AnyCompleteUser ToAnyCompleteUser() => ToGuestUser();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(GuestUser other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Email == other.Email && Type == other.Type && ConstInt == other.ConstInt;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(GuestUser other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as GuestUser);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Email);
            hashCode.Add((int) Type);
            hashCode.Add(ConstInt);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
