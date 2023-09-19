using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoV2.AspNetNewtonSoft.Model {
    /// AUTOGENERED BY caffoa ///
    
    public interface ASPNAnyCompleteUser {
        [JsonIgnore]
        string TypeDiscriminator { get; }
        ASPNAnyCompleteUser ToASPNAnyCompleteUser();
    }
}
