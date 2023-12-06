using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoIsolated.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(IsoUserWithId), "simple")]
    [JsonSubtypes.KnownSubType(typeof(IsoGuestUser), "guest")]
    public interface IsoAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        IsoAnyCompleteUser ToIsoAnyCompleteUser();
    }
}
