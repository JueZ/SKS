using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.Data.Entity;

using SKS_PDS.DAL;
using SKS_PDS.Entities;

namespace SKS_PDS_Tests
{
    [TestClass]
    public class InDataBasePackageRepositoryTest
    {
        [TestMethod]
        public void Add_AddItem_ItemAdded()
        {
            // arrange
            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<DbSet<Package>>();
            
            mockContext.Setup(m => m.Packages).Returns(mockSet.Object);
            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // act
            repostitory.Add(new Package(1, "Test", "TestAdress", "Recipient", "TestAdress", 1, "City", "Country", "1010", "Street"));
            
            // assert
            mockSet.Verify(m => m.Add(It.IsAny<Package>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        public void Delete_DeleteItem_ItemDeleted()
        {
            // arrange
            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<DbSet<Package>>();

            mockContext.Setup(m => m.Packages).Returns(mockSet.Object);
            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // act
            repostitory.Add(new Package(1, "Test", "TestAdress", "Recipient", "TestAdress", 1, "City", "Country", "1010", "Street"));
            repostitory.Delete(new Package(1, "Test", "TestAdress", "Recipient", "TestAdress", 1, "City", "Country", "1010", "Street"));

            // assert
            mockSet.Verify(m => m.Remove(It.IsAny<Package>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void getPackageByWarehouseid_Retrieve_Retrieved()
        {
            // Arrange
            var data = new List<Package>
            {
                new Package(1, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(2, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(3, "S", "SA", "R", "RA", 2, "City", "Country", "1010", "Street"),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Package>>();
            mockContext.Setup(c => c.Packages).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // Act
            var packages = repostitory.getPackageByWarehouseid(1);

            // Assert
            Assert.AreEqual(2, packages.Count);
            Assert.AreEqual(1, packages[0].PackageID);
            Assert.AreEqual(2, packages[1].PackageID);
        }
        [TestMethod]
        public void Update_updateitem_itemupdated()
        {
            // Arrange
            var data = new List<Package>
            {
                new Package(1, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(2, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(3, "S", "SA", "R", "RA", 2, "City", "Country", "1010", "Street"),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Package>>();
            mockContext.Setup(c => c.Packages).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // Act
            repostitory.Update(new Package(2, "S", "SA", "R", "RA", 2, "City", "Country", "1010", "Street"));

            var packages = repostitory.GetById(2);

            // Assert
            Assert.AreEqual(2, packages.Regionid);
        }

        [TestMethod]
        public void GetbyID_getItem_ItemRetrieved()
        {
            // Arrange
            var data = new List<Package>
            {
                new Package(1, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(2, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(3, "S", "SA", "R", "RA", 2, "City", "Country", "1010", "Street"),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Package>>();
            mockContext.Setup(c => c.Packages).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // Act
            var packages = repostitory.GetById(2);

            // Assert
            Assert.AreEqual(2, packages.PackageID);
        }

        [TestMethod]
        public void GetAll_retrieveallitems_allitemsretrieved()
        {
            // Arrange
            var data = new List<Package>
            {
                new Package(1, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(2, "S", "SA", "R", "RA", 1, "City", "Country", "1010", "Street"),
                new Package(3, "S", "SA", "R", "RA", 2, "City", "Country", "1010", "Street"),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Package>>();
            mockContext.Setup(c => c.Packages).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabasePackageRepository(mockContext.Object);

            // Act
            var packages = (List<Package>)repostitory.GetAll();

            // Assert
            Assert.AreEqual(3, packages.Count);
        }
    }
}
