using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.AspNetNewtonSoft.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface ASPNAnyUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPNAnyUser ToASPNAnyUser();
    }
}
