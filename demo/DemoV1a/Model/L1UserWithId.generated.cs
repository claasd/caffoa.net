#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
/// AUTOGENERED BY caffoa ///
    public partial class L1UserWithId : L1User, L1AnyCompleteUser, IEquatable<L1UserWithId> {
        public const string L1UserWithIdObjectName = "userWithId";
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("registrationDate")]
        public virtual DateTimeOffset RegistrationDate { get; set; }

        [JsonProperty("diffs")]
        public virtual JToken Diffs { get; set; }

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
        public bool Equals(L1UserWithId other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && RegistrationDate == other.RegistrationDate
                && (Diffs?.Equals(other.Diffs) ?? other.Diffs is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1UserWithId other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1UserWithId);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(RegistrationDate);
            hashCode.Add(Diffs);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
