#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJGuestUser : STJAnyUser, STJAnyCompleteUser, IEquatable<STJGuestUser> {
        public const string STJGuestUserObjectName = "guestUser";
        [JsonPropertyName("email")]
        [JsonRequired]
        public string Email { get; set; }

        [JsonPropertyName("type")]
        [JsonRequired]
        public TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonPropertyName("constInt")]
        public int ConstInt { get; set; } = 1;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJGuestUser(){}
        public STJGuestUser(STJGuestUser other) {
            Email = other.Email;
            Type = (STJGuestUser.TypeValue)other.Type;
            ConstInt = other.ConstInt;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJGuestUser ToSTJGuestUser() => new STJGuestUser(this);
        public STJAnyUser ToSTJAnyUser() => ToSTJGuestUser();
        public STJAnyCompleteUser ToSTJAnyCompleteUser() => ToSTJGuestUser();
        public string TypeDiscriminator => Type.Value();
        public bool Equals(STJGuestUser other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Email == other.Email
                && Type == other.Type
                && ConstInt == other.ConstInt;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJGuestUser other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJGuestUser);
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
