using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface AnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        AnyCompleteUser ToAnyCompleteUser();
    }
}
