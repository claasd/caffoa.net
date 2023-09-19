#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPNGuestUser : ASPNAnyUser, ASPNAnyCompleteUser {
        public const string ASPNGuestUserObjectName = "guestUser";
        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonProperty("constInt")]
        public virtual int ConstInt { get; set; } = 1;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNGuestUser(){}
        public ASPNGuestUser(ASPNGuestUser other) {
            Email = other.Email;
            Type = (ASPNGuestUser.TypeValue)other.Type;
            ConstInt = other.ConstInt;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNGuestUser ToASPNGuestUser() => new ASPNGuestUser(this);
        public virtual ASPNAnyUser ToASPNAnyUser() => ToASPNGuestUser();
        public virtual ASPNAnyCompleteUser ToASPNAnyCompleteUser() => ToASPNGuestUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
