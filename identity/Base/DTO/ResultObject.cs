using System;
using System.Collections.Generic;
using System.Text;

namespace Base.DTO
{
    public class ResultBool
    {
        public bool result { get; set; }
        public string msg { get; set; }
    }
    public class ResultErrCode<T>
    {
        public int ErrCode { get; set; }
        public T data { get; set; }
        public string msg { get; set; }
    }
}
