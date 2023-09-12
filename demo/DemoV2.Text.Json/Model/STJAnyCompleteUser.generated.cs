using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.Text.Json.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonDerivedType(typeof(STJUserWithId))]
    [JsonDerivedType(typeof(STJGuestUser))]
    public interface STJAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        STJAnyCompleteUser ToSTJAnyCompleteUser();
    }
}
