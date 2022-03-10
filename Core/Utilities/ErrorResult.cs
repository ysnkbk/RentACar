using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(message, true)
        {

        }
        public ErrorResult() : base(true)
        {

        }
    }
}