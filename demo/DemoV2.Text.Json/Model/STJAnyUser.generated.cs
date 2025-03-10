using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonDerivedType(typeof(STJUser), "simple")]
    [JsonDerivedType(typeof(STJGuestUser), "guest")]
    public interface STJAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        STJAnyUser ToSTJAnyUser();
    }
}
