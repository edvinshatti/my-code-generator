using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCodeGenerator
{
    public enum ResultType
    {
        Success = 0,
        Failed = -1
    }

    [Serializable]
    public class Result
    {
        public ResultType Type { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public Object ResultObj { get; set; }
    }

    [Serializable]
    public class Result<T>
    {
        public ResultType Type { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public T ResultObj { get; set; }
    }
}
