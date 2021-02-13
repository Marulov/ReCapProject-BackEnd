using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
