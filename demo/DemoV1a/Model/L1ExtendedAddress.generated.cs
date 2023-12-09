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
    public partial class L1ExtendedAddress : L1Address {
        public const string L1ExtendedAddressObjectName = "extendedAddress";
        [JsonProperty("addressType2")]
        public virtual string AddressType2 { get; set; }

        public L1ExtendedAddress(){}
        public L1ExtendedAddress(L1ExtendedAddress other) : base(other) {
            AddressType2 = other.AddressType2;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public L1ExtendedAddress(L1Address other) : base(other) {}
        public L1ExtendedAddress ToL1ExtendedAddress() => new L1ExtendedAddress(this);
    }
}
