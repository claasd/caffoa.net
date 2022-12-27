using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface L1AnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L1AnyCompleteUser ToL1AnyCompleteUser(); 
    }
}
