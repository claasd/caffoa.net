#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public partial class ASPError {
        public const string ASPErrorObjectName = "error";
        /// <summary>
        /// Single string based code describing the error.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonRequired]
        public virtual string Status { get; set; }

        /// <summary>
        /// Human readable error message.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonRequired]
        public virtual string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPError(){}
        public ASPError(ASPError other) {
            Status = other.Status;
            Message = other.Message;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPError ToASPError() => new ASPError(this);
    }
}
