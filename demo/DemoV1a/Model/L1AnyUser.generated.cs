using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(L1User), "simple")]
    [JsonSubtypes.KnownSubType(typeof(L1GuestUser), "guest")]
    public interface L1AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L1AnyUser ToL1AnyUser();
    }
}
