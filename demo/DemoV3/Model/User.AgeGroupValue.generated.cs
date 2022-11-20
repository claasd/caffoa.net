using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Caffoa.JsonConverter;

namespace DemoV3.Model {
    public partial class User {
        // enum values for "ageGroup"
        [JsonConverter(typeof(CaffoaNumericEnumConverter<AgeGroupValue>))]
        public enum AgeGroupValue : int {
            _18 = 18,
            _40 = 40,
            _70 = 70,
            _120 = 120
        }
    }
}