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
    public partial class STJGuestUser : STJAnyUser, STJAnyCompleteUser {
        public const string STJGuestUserObjectName = "guestUser";
        [JsonPropertyName("email")]
        public virtual string Email { get; set; }

        [JsonPropertyName("type")]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonPropertyName("constInt")]
        public virtual int ConstInt { get; set; } = 1;

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
        public virtual STJAnyUser ToSTJAnyUser() => ToSTJGuestUser();
        public virtual STJAnyCompleteUser ToSTJAnyCompleteUser() => ToSTJGuestUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
