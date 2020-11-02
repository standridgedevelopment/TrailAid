using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrailAid.WebAPI.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
