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
    public partial class L1Error : IEquatable<L1Error> {
        public const string L1ErrorObjectName = "error";
        /// <summary>
        /// Single string based code describing the error.
        /// </summary>
        [JsonProperty("status", Required = Required.Always)]
        public virtual string Status { get; set; }

        /// <summary>
        /// Human readable error message.
        /// </summary>
        [JsonProperty("message", Required = Required.Always)]
        public virtual string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public L1Error(){}
        public L1Error(L1Error other) {
            Status = other.Status;
            Message = other.Message;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1Error ToL1Error() => new L1Error(this);
        public bool Equals(L1Error other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && Message == other.Message;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(L1Error other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as L1Error);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Status);
            hashCode.Add(Message);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
