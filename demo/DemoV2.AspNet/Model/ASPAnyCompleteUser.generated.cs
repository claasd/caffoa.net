using System.Text.Json.Serialization;
using Caffoa.JsonConverter;

namespace DemoV2.AspNet.Model {
    /// AUTOGENERED BY caffoa ///
    [JsonDerivedType(typeof(ASPUserWithId))]
    [JsonDerivedType(typeof(ASPGuestUser))]
    public interface ASPAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPAnyCompleteUser ToASPAnyCompleteUser();
    }
}
