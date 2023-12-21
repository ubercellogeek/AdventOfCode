using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day5
{
    public static class Helpers
    {
        public static (long, bool) GetDestinationValueFromArray(this List<long[]> longs, long srcInput)
        {
            (long, bool) result = (-1, false);

            foreach (var ll in longs)
            {
                result = GetDestinationValue(srcInput, ll[1], ll[0], ll[2]);
                if (result.Item2)
                {
                    return result;
                }
            }

            return result;
        }

        public static (long, bool) GetDestinationValue(long srcInput, long srcStart, long dstStart, long length)
        {
            var comp = (dstStart - srcStart);
            var srcMax = srcStart + (length);

            if (srcInput >= srcMax || srcInput < srcStart)
            {
                return (srcInput, false);
            }

            var mapped = srcInput + comp;
            return (mapped, true);


        }
    }
}