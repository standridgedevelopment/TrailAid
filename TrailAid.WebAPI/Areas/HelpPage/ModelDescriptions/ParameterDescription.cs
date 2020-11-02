using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrailAid.WebAPI.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParameterDescription
    {
        public ParameterDescription()
        {
            Annotations = new Collection<ParameterAnnotation>();
        }

        public Collection<ParameterAnnotation> Annotations { get; private set; }

        public string Documentation { get; set; }

        public string Name { get; set; }

        public ModelDescription TypeDescription { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
