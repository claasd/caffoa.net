using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DemoV3.Services
{
    /// <summary>
    /// Example how to ignore all required attributes
    /// when passing data back.
    /// </summary>
    public class RemoveRequiredContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.Required = Required.Default;
            return property;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.ItemRequired = Required.Default;
            return contract;
        }

        protected override JsonProperty CreatePropertyFromConstructorParameter(JsonProperty matchingMemberProperty,
            ParameterInfo parameterInfo)
        {
            var property = base.CreatePropertyFromConstructorParameter(matchingMemberProperty, parameterInfo);
            property.Required = Required.Default;
            return property;
        }
    }
}