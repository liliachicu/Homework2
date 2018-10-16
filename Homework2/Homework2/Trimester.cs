using System;

namespace Homework2
{
        public static class Trimester
        {
            public static int GetQuarter( DateTime date)
            {
                if (date.Month >= 1 && date.Month <= 3)
                    return 1;
                else if (date.Month >= 4 && date.Month <= 6)
                    return 2;
                else if (date.Month >= 7 && date.Month <= 9)
                    return 3;
                else
                    return 4;
            }
        }
}