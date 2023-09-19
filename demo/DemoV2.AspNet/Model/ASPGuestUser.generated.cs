#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPGuestUser : ASPAnyUser, ASPAnyCompleteUser {
        public const string ASPGuestUserObjectName = "guestUser";
        [JsonPropertyName("email")]
        public virtual string Email { get; set; }

        [JsonPropertyName("type")]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonPropertyName("constInt")]
        public virtual int ConstInt { get; set; } = 1;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPGuestUser(){}
        public ASPGuestUser(ASPGuestUser other) {
            Email = other.Email;
            Type = (ASPGuestUser.TypeValue)other.Type;
            ConstInt = other.ConstInt;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPGuestUser ToASPGuestUser() => new ASPGuestUser(this);
        public virtual ASPAnyUser ToASPAnyUser() => ToASPGuestUser();
        public virtual ASPAnyCompleteUser ToASPAnyCompleteUser() => ToASPGuestUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
