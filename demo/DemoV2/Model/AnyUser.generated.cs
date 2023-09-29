using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV2.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(User), "simple")]
    [JsonSubtypes.KnownSubType(typeof(GuestUser), "guest")]
    public interface AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        AnyUser ToAnyUser();
    }
}
