using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonSubTypes;

namespace DemoV2.AspNetNewtonSoft.Model {
    /// AUTOGENERED BY caffoa ///
    
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(ASPNUser), "simple")]
    [JsonSubtypes.KnownSubType(typeof(ASPNGuestUser), "guest")]
    public interface ASPNAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPNAnyUser ToASPNAnyUser();
    }
}
