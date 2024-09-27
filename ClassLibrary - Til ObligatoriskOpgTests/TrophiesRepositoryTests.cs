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
    public class TrophiesRepositoryTests
    {

        private TrophiesRepository repository;

        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            repository = new TrophiesRepository();
            Trophy trophy = new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 };
            Trophy trophy2 = new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 };



            // Act
            repository.Add(trophy);
            repository.Add(trophy2);
            List<Trophy> result = repository.Get(1996, "competition");
            List<Trophy> result2 = repository.Get(2001, "competition");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result2);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual(1996, result[0].Year);
            Assert.AreEqual("Fodbold", result[0].Competition);
            
            Assert.AreEqual(2001, result2[1].Year);
            Assert.AreEqual("Håndbold", result2[1].Competition);


        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            repository = new TrophiesRepository();
            Trophy trophy = new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 };
            Trophy trophy2 = new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 };
            repository.Add(trophy);
            repository.Add(trophy2);

            // Act
            Trophy result = repository.GetById(1);
            Trophy result2 = repository.GetById(2);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result2);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Fodbold", result.Competition);
            Assert.AreEqual(1996, result.Year);

            Assert.AreEqual(2, result2.Id);
            Assert.AreEqual("Håndbold", result2.Competition);
            Assert.AreEqual(2001, result2.Year);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            repository = new TrophiesRepository();
            Trophy trophy = new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 };
            Trophy trophy2 = new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 };
            repository.Add(trophy);
            repository.Add(trophy2);

            // Act
            List<Trophy> result = repository.Get(1996, "competition");
            List<Trophy> result2 = repository.Get(2001, "competition");
            
            
            

            // Assert
            
            Trophy trophy3 = new Trophy { Id = 3, Competition = "Tennis", Year = 2014 };
            Trophy trophy4 = new Trophy { Id = 4, Competition = "Badminton", Year = 2017 };

            repository.Add(trophy3);
            repository.Add(trophy4);

            List<Trophy> result3 = repository.Get(2014, "competition");
            List<Trophy> result4 = repository.Get(2017, "competition");

            Assert.IsNotNull(repository);

            Assert.AreEqual(9, repository.Get().Count);

            // Jeg har tilføjet 4 nye objekter til listen og der lå 5 i i forvejen, så derfor er der 9 objekter i alt i listen.

        }

        [TestMethod()]
        public void RemoveTest()
        {
            // Arrange
            repository = new TrophiesRepository();
            Trophy trophy = new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 };
            Trophy trophy2 = new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 };
            
            repository.Add(trophy);
            repository.Add(trophy2);

            // Act
            repository.Remove(1);
            repository.Remove(2);
            repository.Remove(3);
            repository.Remove(4);
            repository.Remove(5);

            // Assert
            Assert.AreEqual(2, repository.Get().Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            repository = new TrophiesRepository();
            Trophy trophy = new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 };
            Trophy trophy2 = new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 };
            repository.Add(trophy);
            repository.Add(trophy2);

            // Act

            repository.Update(1, new Trophy { Id = 1, Competition = "Dødbold", Year = 2002 });

            // Assert
           
            
            Assert.IsTrue(repository.Get().Any(t => t.Id == 1));
            Assert.IsTrue(repository.Get().Any(t => t.Competition == "Dødbold"));
            Assert.IsTrue(repository.Get().Any(t => t.Year == 2002));
        }
    }
}