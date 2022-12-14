#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV1a.Model.Base;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L1Error {
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

        public L1Error(){}
        public L1Error(L1Error other) {
            Status = other.Status;
            Message = other.Message;
        }
        public L1Error ToL1Error() => new L1Error(this);
    }
}
