using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Excercise01
{
    [TestClass]
    public class NumberToWordUnitTest
    {
        [TestMethod]
        public void CheckIfNumberIsPositivie()
        {
            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(1);

            Boolean value = word.Equals("Number must be 1 and greater");
            Assert.IsFalse(value);



        }

        [TestMethod]
        public void CheckHundredWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(585);

            Boolean value = word.Equals("five hundred and eighty five");
            Assert.IsTrue(value);

        }

        [TestMethod]
        public void CheckThousandWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(4236);

            Boolean value = word.Equals("four thousand,two hundred and thirty six");
            Assert.IsTrue(value);

        }

        [TestMethod]
        public void CheckTenThousandWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(14585);

            Boolean value = word.Equals("fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }
        [TestMethod]
        public void CheckHundredThousandWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(514585);

            Boolean value = word.Equals("five hundred and fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }

        [TestMethod]
        public void CheckMillionWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(785514585);

            Boolean value = word.Equals("seven hundred and eighty five million,five hundred and fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }
        [TestMethod]
        public void CheckBillionWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(463785514585L);

            Boolean value = word.Equals("four hundred and sixty three billions,seven hundred and eighty five million,five hundred and fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }
        [TestMethod]
        public void CheckTrillionWord()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(785254789147524L);

            Boolean value = word.Equals("seven hundred and eighty five trillion,two hundred and fifty four billions,seven hundred and eighty nine million,one hundred and fourty seven thousand,five hundred and twenty four");
            Assert.IsTrue(value);

        }
        public void CheckQuadrion()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(625463785514585L);

            Boolean value = word.Equals("four hundred and seventy eight quadrillion,six hundred and twenty five trillion,four hundred and sixty three billions,seven hundred and eighty five million,five hundred and fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }
        public void CheckQuitrion()
        {

            NumberToWordConverter num = new NumberToWordConverter();
            String word = num.translateNumberToWord(625463785514585L);

            Boolean value = word.Equals("four quintillion,four hundred and seventy eight quadrillion,six hundred and twenty five trillion,four hundred and sixty three billions,seven hundred and eighty five million,five hundred and fourteen thousand,five hundred and eighty five");
            Assert.IsTrue(value);

        }
    }
}
