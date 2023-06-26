using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminario.Models
{
    public class ResponseApi<T>
    {
        public T data { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }
}