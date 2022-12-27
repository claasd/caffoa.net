using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface AnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        AnyUser ToAnyUser(); 
    }
}
