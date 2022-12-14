#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class UserWithId : User, AnyCompleteUser {
        public const string UserWithIdObjectName = "userWithId";

        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("registrationDate")]
        public virtual DateTimeOffset RegistrationDate { get; set; }

        [JsonProperty("diffs")]
        public virtual JToken Diffs { get; set; }

        public UserWithId(){}
        public UserWithId(UserWithId other) : base(other) {
            Id = other.Id;
            RegistrationDate = other.RegistrationDate;
            Diffs = other.Diffs?.DeepClone();
        }
        public UserWithId(User other) : base(other) {}
        public UserWithId ToUserWithId() => new UserWithId(this);
        public virtual AnyCompleteUser ToAnyCompleteUser() => ToUserWithId();
        public virtual string TypeDiscriminator => Type.ToString();
    }
}
