#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using DemoIsolated.Model.Base;

namespace DemoIsolated.Model {
/// AUTOGENERED BY caffoa ///
    public partial class IsoGuestUser : IsoAnyUser, IsoAnyCompleteUser {
        public const string IsoGuestUserObjectName = "guestUser";
        [JsonProperty("email", Required = Required.Always)]
        public virtual string Email { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public virtual TypeValue Type { get; set; } = TypeValue.Guest;

        [JsonProperty("constInt")]
        public virtual int ConstInt { get; set; } = 1;

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public IsoGuestUser(){}
        public IsoGuestUser(IsoGuestUser other) {
            Email = other.Email;
            Type = (IsoGuestUser.TypeValue)other.Type;
            ConstInt = other.ConstInt;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public IsoGuestUser ToIsoGuestUser() => new IsoGuestUser(this);
        public virtual IsoAnyUser ToIsoAnyUser() => ToIsoGuestUser();
        public virtual IsoAnyCompleteUser ToIsoAnyCompleteUser() => ToIsoGuestUser();
        public virtual string TypeDiscriminator => Type.Value();
    }
}
