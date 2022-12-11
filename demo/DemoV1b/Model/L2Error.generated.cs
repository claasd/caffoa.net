using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV1b.Model.Base;

namespace DemoV1b.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class L2Error {
        public const string L2ErrorObjectName = "error";

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

        public L2Error(){}
        public L2Error(L2Error other) {
            Status = other.Status;
            Message = other.Message;
        }
        public L2Error ToL2Error() => new L2Error(this);
    }
}
