using System;
using System.Collections.Generic;
using System.Text;

namespace Model.General
{
    public class BaseDecimalPrecision : Attribute
    {
        public BaseDecimalPrecision(byte precision, byte scale)
        {
            Precision = precision;
            Scale = scale;
        }

        public byte Precision { get; set; }
        public byte Scale { get; set; }


    }
}
