using System;
using System.Collections.Generic;
using System.Text;

namespace Groove_Coaster_Converter.Functions
{
    class StringCheck
    {
        public int EndIndexOf(string source, string value)
        {
            int index = source.IndexOf(value);
            if (index >= 0)
            {
                index += value.Length;
            }

            return index;
        }
    }
}
