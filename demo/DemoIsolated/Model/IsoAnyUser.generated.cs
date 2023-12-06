using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoIsolated.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(IsoUser), "simple")]
    [JsonSubtypes.KnownSubType(typeof(IsoGuestUser), "guest")]
    public interface IsoAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        IsoAnyUser ToIsoAnyUser();
    }
}
