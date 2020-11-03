using System;
using System.Reflection;

namespace TrailAid.WebAPI.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
