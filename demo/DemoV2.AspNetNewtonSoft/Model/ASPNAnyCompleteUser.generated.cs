using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV2.AspNetNewtonSoft.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(ASPNUserWithId), "simple")]
    [JsonSubtypes.KnownSubType(typeof(ASPNGuestUser), "guest")]
    public interface ASPNAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPNAnyCompleteUser ToASPNAnyCompleteUser();
    }
}
