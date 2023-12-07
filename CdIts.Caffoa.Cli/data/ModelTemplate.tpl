#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
{IMPORTS}
namespace {NAMESPACE} {{
{DESCRIPTION}public partial class {NAME}{PARENTS} {{
        public const string {NAME}ObjectName = "{RAWNAME}";
{PROPERTIES}
{ADDITIONAL_PROPS}
        public {NAME}(){{}}
        {CONSTRUCTORS}
        public {NAME} To{NAME}() => new {NAME}(this);
{INTERFACE_METHODS}{EQUALS_METHODS}    }}
}}
