using System;

namespace shiki.Global_properties.Exceptions
{
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException() : base("Unprocessable entity, the input was wrong")
        {
        }
    }
}