﻿using System;

namespace shiki.Global_properties.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base(
            "You were trying to access a forbidden information. Check your bot's privileges")
        {
        }
    }
}