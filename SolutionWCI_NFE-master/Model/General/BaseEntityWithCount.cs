using System;
using System.Collections.Generic;
using System.Text;

namespace Model.General
{
    public class BaseEntityWithCount<T> where T : class
    {
        public T Entity { get; set; }
        public int Count { get; set; }
    }
}
