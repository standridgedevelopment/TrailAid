using System;

namespace TrailAid.WebAPI.Areas.HelpPage
{
    /// <summary>
    /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
    /// </summary>
    public class InvalidSample
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public InvalidSample(string errorMessage)
        {
            ErrorMessage = errorMessage ?? throw new ArgumentNullException("errorMessage");
        }

        public string ErrorMessage { get; private set; }

        public override bool Equals(object obj)
        {
            InvalidSample other = obj as InvalidSample;
            return other != null && ErrorMessage == other.ErrorMessage;
        }

        public override int GetHashCode()
        {
            return ErrorMessage.GetHashCode();
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
