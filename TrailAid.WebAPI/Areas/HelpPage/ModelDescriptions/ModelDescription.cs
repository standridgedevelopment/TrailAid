using System;

namespace TrailAid.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Documentation { get; set; }

        public Type ModelType { get; set; }

        public string Name { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member\
