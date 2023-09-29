using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonDerivedType(typeof(ASPUser), "simple")]
    [JsonDerivedType(typeof(ASPGuestUser), "guest")]
    public interface ASPAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPAnyUser ToASPAnyUser();
    }
}
