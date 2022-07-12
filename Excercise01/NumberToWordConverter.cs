using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Excercise01
{
    public class NumberToWordConverter
    {

        public String translateNumberToWord(BigInteger num_to_convert)
        {
            String str = "";
            if (num_to_convert <= 0)
                return "Number must be 1 and greater";
            //  QT  QD   T   B   M   H   TH
            String mask = "000 000 000 000 000 000 000";
            string strnumber = num_to_convert.ToString("000000000000000000000", new NumberFormatInfo());

            strnumber = strnumber.Replace("\\s", "");

            int quintillion = int.Parse(strnumber.Substring(0, 3));
            int quadrillion = int.Parse(strnumber.Substring(3, 3));
            int trillion = int.Parse(strnumber.Substring(6, 3));
            int billions = int.Parse(strnumber.Substring(9, 3));//000 000 xxx 000 000 000 000 000
            int millions = int.Parse(strnumber.Substring(12, 3));//000 000 000 000 xxx 000 000 000
            int thousands = int.Parse(strnumber.Substring(18, 3));//000 000 000 000 000 000 xxx 000

            if (quintillion > 0)
            {
                String narration = " quintillion,";
                if (quintillion > 99)
                {
                    narration = " hundred and ";
                }
                String and = was_concat ? " hundred " : narration;//prevent double entry of and word
                str = constructWord(quintillion, and, " quintillion,", and);

            }
            if (quadrillion > 0)
            {
                String narration = " quadrillion,";
                if (quadrillion > 99)
                {
                    narration = " hundred and ";
                }
                String and = was_concat ? " hundred " : narration;//prevent double entry of and word
                str = str + "" + constructWord(quadrillion, and, " quadrillion,", and);

            }

            if (trillion > 0)
            {
                String narration = " trillion,";
                if (trillion > 99)
                {
                    narration = " hundred and ";
                }
                String and = was_concat ? " hundred " : narration;
                str = str + "" + constructWord(trillion, and, " trillion,", " trillion,");

            }

            if (billions > 0)
            {
                String narration = " billions,";
                if (billions > 99)
                {
                    narration = " hundred and ";
                }
                String and = was_concat ? " hundred " : narration;
                str = str + "" + constructWord(billions, and, " billions,", narration);

            }
            if (millions > 0)
            {

                String narration = " million,";
                if (millions > 99)
                {
                    narration = " hundred and ";
                }
                String and = was_concat ? " million " : narration;
                str = str + constructWord(millions, and, " million,", and);
                was_concat = true;
            }

            if (thousands > 0)
            {
                strnumber = strnumber.Replace("\\s", "");
                strnumber = strnumber.Substring(strnumber.Length - 6, 6);
                long new_num = long.Parse(strnumber);

                String and = "";
                if (was_concat)
                {
                    if (new_num <= 99)
                    {
                        and = "and  ";
                    }
                }
                str = str + and + numberToWords(new_num);


            }

            str = str.EndsWith("s,") ? str.Substring(0, str.IndexOf("s,")) : str;
            str = str.Replace("  ", " ");
            if (str.EndsWith(","))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }
        String word = "";

        Boolean was_concat = false;

        private String constructWord(long value, String str1, String str2, String str3)
        {
            String str = value.ToString();

            String num_to_word = "";

            int len = str.Length;

            long mod, div;
            switch (len)
            {
                case 3:
                    mod = value % 100;
                    div = value / 100;
                    num_to_word = num_to_word + getZeroToNine(div) + str1 + getTenWord(mod) + str2;
                    break;
                case 2:
                    num_to_word = num_to_word + getTenWord(value) + str3;
                    break;
                case 1:
                    num_to_word = num_to_word + getZeroToNine(value) + str3;
                    break;

            }
            return num_to_word;
        }


        long division;
        private String getTenWord(long num)
        {
            String and = was_concat ? "and " : "";
            division = num % 10;

            if (num >= 90 && num <= 99)
            {

                return word = and + "ninety " + getAndWord(num);
            }
            if (num >= 80 && num <= 89)
            {

                return word = and + "eighty " + getAndWord(num);
            }
            if (num >= 70 && num <= 79)
            {

                return word = and + "seventy " + getAndWord(num);
            }
            if (num >= 60 && num <= 69)
            {

                return word = and + "sixty " + getAndWord(num);
            }
            if (num >= 50 && num <= 59)
            {

                return word = and + "fifty " + getAndWord(num);
            }
            if (num >= 40 && num <= 49)
            {

                word = and + "fourty " + getAndWord(num);

                return word;
            }
            if (num >= 30 && num <= 39)
            {

                return word = and + "thirty " + getAndWord(num);
            }
            if (num >= 20 && num <= 29)
            {

                return word = and + "twenty " + getAndWord(num);
            }

            if (num >= 10 && num <= 19)
            {
                return getTeenWord(num);
            }
            else
            {

                return getZeroToNine(num);
            }

        }

        private static String getAndWord(long num)
        {
            long modulus_ = num % 10;
            String str = "";
            if (modulus_ > 0)
            {
                str = getZeroToNine(modulus_);
            }

            return str;
        }

        private static String getZeroToNine(long num)
        {

            if (num == 9)
            {
                return "nine";
            }
            if (num == 8)
            {
                return "eight";
            }
            if (num == 7)
            {
                return "seven";
            }
            if (num == 6)
            {
                return "six";
            }
            if (num == 5)
            {
                return "five";
            }
            if (num == 4)
            {
                return "four";
            }
            if (num == 3)
            {
                return "three";
            }
            if (num == 2)
            {
                return "two";
            }
            if (num == 1)
            {
                return "one";
            }
            return "";
        }

        private static String getTeenWord(long num)
        {
            if (num == 0)
            {
                return "";
            }
            if (num == 10)
            {
                return "ten";
            }
            if (num == 11)
            {
                return "eleven";
            }
            if (num == 12)
            {
                return "twelve";
            }
            if (num == 13)
            {
                return "thirteen";
            }
            return getAndWord(num) + "teen";

        }

        private String numberToWords(long num)
        {
            was_concat = false;
            String str = num.ToString();
            int len = str.Length;
            long mod, div;


            switch (len)
            {
                case 6:
                    int hundred_thousand = int.Parse(str.Substring(0, 3));
                    int hundred = int.Parse(str.Substring(3, 3));
                    mod = hundred_thousand % 100;
                    String and = "";
                    if (mod > 0)
                    {
                        String ten_word = getTenWord(mod);

                        and = "and " + ten_word;

                    }
                    String suffix = "",
                     prefix;
                    prefix = constructWord(hundred_thousand / 100, "", "", " hundred " + and + " thousand");
                    if (hundred > 0)
                    {
                        and = "";
                        div = hundred / 100;
                        mod = hundred % 100;//400001

                        String hundred_word = hundred > 99 ? " hundred " : "";
                        if (mod > 0)
                        {
                            and = "and " + getTenWord(mod);

                        }
                        suffix = constructWord(div, "", "", hundred_word + and + "");
                    }
                    String concat = suffix.Equals("") ? "" : suffix.StartsWith("and") ? suffix : "," + suffix;
                    word = prefix + " " + concat;
                    word = word.Replace(" ,", ",");
                    break;
                case 5:
                    int thousands = int.Parse(str.Substring(0, 2));
                    hundred = int.Parse(str.Substring(2, 3));
                    prefix = constructWord(thousands, "", "", " thousand");
                    suffix = "";
                    if (hundred > 0)
                    {
                        and = "";
                        div = hundred / 100;
                        mod = hundred % 100;//400001

                        String hundred_word = hundred > 99 ? " hundred " : "";
                        if (mod > 0)
                        {
                            and = "and " + getTenWord(mod);

                        }
                        suffix = constructWord(div, "", "", hundred_word + and + "");
                    }
                    concat = suffix.Equals("") ? "" : suffix.StartsWith("and") ? suffix : "," + suffix;
                    word = prefix + " " + concat;
                    word = word.Replace(" ,", ",");
                    break;
                case 4:
                    thousands = int.Parse(str.Substring(0, 1));
                    hundred = int.Parse(str.Substring(1, 3));

                    suffix = "";
                    prefix = constructWord(thousands, "", "", " thousand");
                    if (hundred > 0)
                    {
                        and = "";
                        div = hundred / 100;
                        mod = hundred % 100;//400001

                        String hundred_word = hundred > 99 ? " hundred " : "";
                        if (mod > 0)
                        {
                            and = "and " + getTenWord(mod);

                        }
                        suffix = constructWord(div, "", "", hundred_word + and + "");
                    }
                    concat = suffix.Equals("") ? "" : suffix.StartsWith("and") ? suffix : "," + suffix;
                    word = prefix + " " + concat;
                    word = word.Replace(" ,", ",");
                    break;
                case 3:
                case 2:
                case 1:
                    and = "";
                    div = num / 100;
                    mod = num % 100;
                    String _hundred_word = num > 99 ? " hundred " : "";
                    if (mod > 0)
                    {
                        String ten_word = getTenWord(mod);
                        and = num <= 99 ? "" + ten_word : "and " + ten_word;

                    }

                    word = constructWord(div, "", "", _hundred_word + and + "");
                    break;
            }

            return word;

        }



    }
}
