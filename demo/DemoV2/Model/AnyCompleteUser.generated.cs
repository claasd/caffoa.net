using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV2.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(UserWithId), "simple")]
    [JsonSubtypes.KnownSubType(typeof(GuestUser), "guest")]
    public interface AnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        AnyCompleteUser ToAnyCompleteUser();
    }
}
