using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
