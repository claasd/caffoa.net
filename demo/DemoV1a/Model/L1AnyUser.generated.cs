using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV1a.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface L1AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L1AnyUser ToL1AnyUser(); 
    }
}
