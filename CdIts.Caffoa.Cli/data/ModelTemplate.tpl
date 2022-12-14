#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
{IMPORTS}
namespace {NAMESPACE} {{
    {DESCRIPTION}[JsonObject(MemberSerialization.OptIn)]
    public partial class {NAME}{PARENTS} {{
        public const string {NAME}ObjectName = "{RAWNAME}";

{PROPERTIES}
{ADDITIONAL_PROPS}
        public {NAME}(){{}}
        {CONSTRUCTORS}
        public {NAME} To{NAME}() => new {NAME}(this);
{INTERFACE_METHODS}    }}
}}
