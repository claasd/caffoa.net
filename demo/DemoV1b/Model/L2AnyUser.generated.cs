using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV1b.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface L2AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        L2AnyUser ToL2AnyUser(); 
    }
}
