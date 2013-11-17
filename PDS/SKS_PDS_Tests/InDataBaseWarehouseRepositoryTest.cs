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
    public class InDatabaseWarehouseRepositoryTest
    {
        [TestMethod]
        public void Add_AddItem_ItemAdded()
        {
            // arrange
            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<DbSet<Warehouse>>();

            mockContext.Setup(m => m.Warehouses).Returns(mockSet.Object);
            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);

            // act
            repostitory.Add(new Warehouse(1, 10, 10));

            // assert
            mockSet.Verify(m => m.Add(It.IsAny<Warehouse>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        public void Delete_DeleteItem_ItemDeleted()
        {
            // arrange
            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<DbSet<Warehouse>>();

            mockContext.Setup(m => m.Warehouses).Returns(mockSet.Object);
            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);
            repostitory.Add(new Warehouse(1, 10, 10));

            // act
            repostitory.Delete(new Warehouse(1, 10, 10));

            // assert
            mockSet.Verify(m => m.Remove(It.IsAny<Warehouse>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void getWarehousesByCoordinate_retrievewarehouse_itemretrieved()
        {
            // Arrange
            var data = new List<Warehouse>
            {
                new Warehouse(1, 10, 10),
                new Warehouse(2, 15, 20),
                new Warehouse(3, 25, 30),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Warehouse>>();
            mockContext.Setup(c => c.Warehouses).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);

            // Act
            var packages = repostitory.getWarehousesByCoordinate(15, 20);

            // Assert
            Assert.AreEqual(1, packages.Count);
            Assert.AreEqual(15, packages[0].X);
            Assert.AreEqual(20, packages[0].Y);
        }
        [TestMethod]
        public void Update_updateitem_itemupdated()
        {
            // Arrange
            var data = new List<Warehouse>
            {
                new Warehouse(1, 10, 10),
                new Warehouse(2, 15, 20),
                new Warehouse(3, 25, 30),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Warehouse>>();
            mockContext.Setup(c => c.Warehouses).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);

            // Act
            repostitory.Update(new Warehouse(2, 20, 20));

            var packages = repostitory.GetById(2);

            // Assert
            Assert.AreEqual(20, packages.X);
        }

        [TestMethod]
        public void GetbyID_getItem_ItemRetrieved()
        {
            // Arrange
            var data = new List<Warehouse>
            {
                new Warehouse(1, 10, 10),
                new Warehouse(2, 15, 20),
                new Warehouse(3, 25, 30),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Warehouse>>();
            mockContext.Setup(c => c.Warehouses).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);

            // Act
            var packages = repostitory.GetById(2);

            // Assert
            Assert.AreEqual(2, packages.Warehouseid);
        }

        [TestMethod]
        public void GetAll_retrieveallitems_allitemsretrieved()
        {
            // Arrange
            var data = new List<Warehouse>
            {
                new Warehouse(1, 10, 10),
                new Warehouse(2, 15, 20),
                new Warehouse(3, 25, 30),
            }.AsQueryable();

            var mockContext = new Mock<PDSDatabase>();
            var mockSet = new Mock<MockableDbSetWithIQueryable<Warehouse>>();
            mockContext.Setup(c => c.Warehouses).Returns(mockSet.Object);

            mockSet.Setup(m => m.Provider).Returns(data.Provider);
            mockSet.Setup(m => m.Expression).Returns(data.Expression);
            mockSet.Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repostitory = new InDatabaseWarehouseRepository(mockContext.Object);

            // Act
            var warehouses = (List<Warehouse>)repostitory.GetAll();

            // Assert
            Assert.AreEqual(3, warehouses.Count);
        }
    }
}
