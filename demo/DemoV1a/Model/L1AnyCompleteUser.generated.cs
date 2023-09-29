using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(L1UserWithId), "simple")]
    [JsonSubtypes.KnownSubType(typeof(L1GuestUser), "guest")]
    public interface L1AnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L1AnyCompleteUser ToL1AnyCompleteUser();
    }
}
