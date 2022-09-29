using System;

namespace shiki.Global_properties.Exceptions
{
    public class FailedRequestException : Exception
    {
        public FailedRequestException(string additionalContent) : base($"Request is failed: {additionalContent}")
        {
        }
    }
}