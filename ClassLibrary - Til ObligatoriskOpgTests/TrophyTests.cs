using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary___Til_ObligatoriskOpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary___Til_ObligatoriskOpg.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            Trophy trophy = new Trophy();

            // Act
            trophy.Id = 1;
            trophy.Competition = "Fodbold";
            trophy.Year = 2020;
            trophy.ToString();

            // Assert
            Assert.AreEqual("ID: 1, Competition: Fodbold, Year: 2020", trophy.ToString());
            Assert.IsTrue(trophy.ToString().Contains("ID: 1, Competition: Fodbold, Year: 2020"));

        }

        [TestMethod()]
        public void validateIDTest()
        {
            // Arrange
            Trophy trophy = new Trophy();
            trophy.Id = 1;


            // Act
            trophy.validateID();


            // Assert
            Assert.AreEqual(1, trophy.Id);
        }

        [TestMethod()]
        public void validateCompetitionTest()
        {
            // Arrange
            Trophy trophy = new Trophy();
            Trophy trophy1 = new Trophy();
            trophy.Competition = "Fodbold";
            trophy1.Competition = "Håndbold";

            // Act
            trophy.validateCompetition();
            trophy1.validateCompetition();


            // Assert
            Assert.AreEqual("Fodbold", trophy.Competition);
            Assert.AreEqual("Håndbold", trophy1.Competition);
        }

        [TestMethod()]
        public void validateYearTest()
        {
            // Arrange
            Trophy trophy = new Trophy();
            trophy.Year = 2020;


            // Act
            trophy.validateYear();


            // Assert
            Assert.AreEqual(2020, trophy.Year);

        }

        
    }


}