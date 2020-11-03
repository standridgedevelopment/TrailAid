using System;

namespace TrailAid.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ModelNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
