using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV1b.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(L2User), "simple")]
    [JsonSubtypes.KnownSubType(typeof(L2GuestUser), "guest")]
    public interface L2AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L2AnyUser ToL2AnyUser();
    }
}
