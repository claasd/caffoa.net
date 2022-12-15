#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1UserWithId : L1User, L1AnyCompleteUser {
        public const string L1UserWithIdObjectName = "userWithId";

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("registrationDate")]
        public virtual DateTimeOffset RegistrationDate { get; set; }

        [JsonProperty("diffs")]
        public virtual JToken Diffs { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1UserWithId(){}
        public L1UserWithId(L1UserWithId other) : base(other) {
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.DeepClone();
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1UserWithId(L1User other) : base(other) {}
        public L1UserWithId ToL1UserWithId() => new L1UserWithId(this);
        public virtual L1AnyCompleteUser ToL1AnyCompleteUser() => ToL1UserWithId();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
