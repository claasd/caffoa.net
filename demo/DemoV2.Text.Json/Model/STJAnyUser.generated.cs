using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface STJAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        STJAnyUser ToSTJAnyUser(); 
    }
}
