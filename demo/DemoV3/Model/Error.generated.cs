using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoV3.Model.Base;

namespace DemoV3.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Error {
        public const string ErrorObjectName = "error";

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

        public Error(){}
        public Error(Error other) {
            Status = other.Status;
            Message = other.Message;
        }
        public Error ToError() => new Error(this);
    }
}
