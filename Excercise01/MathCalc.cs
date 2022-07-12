using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Excercise01
{
    public static class MathCalc
    {
         public static String Towards(this BigInteger num)
        {
            String msg = new NumberToWordConverter().translateNumberToWord(num);


            return msg;
        }
    }
}
