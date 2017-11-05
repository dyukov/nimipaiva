using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameDay;
using System.Collections.Generic;

namespace NameDayUnitTests
{
    [TestClass]
    public class ProgramUnitTest
    {
        private static readonly List<string> TestNameList = new List<string>()
        {
            "2.9.; Sinikka, Sini, Justus",
            "3.9.;Soile, Soili, Soila",
            "30.11.;Antti",
            "11.10.;Ohto"
        };
        private static readonly List<string> TestNameListEmpty = new List<string>();
        private DateTime dateFoundInList = new DateTime(2017, 9, 2);
        private DateTime dateNotFoundInList = new DateTime(2017, 12, 31);

        [TestMethod]
        public void Valid_Names_Found_For_Existing_Date()
        {
            var names = Program.getNameByDate(TestNameList, dateFoundInList);
            Assert.AreEqual(names, " Sinikka, Sini, Justus");
        }

        [TestMethod]
        public void No_names_found_for_Date_not_in_List()
        {
            var names = Program.getNameByDate(TestNameList, dateNotFoundInList);
            Assert.AreEqual(names, "no name for this date.");
        }

        [TestMethod]
        public void No_names_found_from_Empty_List()
        {
            var names = Program.getNameByDate(TestNameListEmpty, new DateTime());
            Assert.AreEqual(names, "no name for this date.");
        }
    }
}
