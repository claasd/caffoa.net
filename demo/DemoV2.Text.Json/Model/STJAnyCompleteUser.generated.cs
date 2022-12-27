using System.Text.Json.Serialization;

namespace DemoV2.Text.Json.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface STJAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        STJAnyCompleteUser ToSTJAnyCompleteUser(); 
    }
}
