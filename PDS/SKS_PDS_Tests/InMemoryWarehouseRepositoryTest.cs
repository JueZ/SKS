using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SKS_PDS.DAL;
using SKS_PDS.Entities;

namespace SKS_PDS_Tests
{
    [TestClass]
    public class InMemoryWarehouseRepositoryTest
    {
        [TestMethod]
        public void getWarehousesByCoordinate_retrievewarehouse_itemretrieved()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();

            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));
            inmemorywarehouserepository.Add(new Warehouse(2, 15, 20));

            // act
            List<Warehouse> warehouselist = inmemorywarehouserepository.getWarehousesByCoordinate(15, 20);

            // assert
            Assert.AreEqual(warehouselist.Count, 1);
            Assert.AreEqual(warehouselist[0].Warehouseid, 2);
        }

        [TestMethod]
        public void Add_Item_AddedItem()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();

            // act
            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));

            // assert
            List<Warehouse> warehouselist = (List<Warehouse>)inmemorywarehouserepository.GetAll();

            Assert.AreEqual(warehouselist.Count, 1);
        }

        [TestMethod]
        public void Update_ItemCoord_UpdatedCoord()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();
            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));
            inmemorywarehouserepository.Add(new Warehouse(2, 15, 20));

            // act
            inmemorywarehouserepository.Update(new Warehouse(1, 15, 10));

            // assert
            Assert.AreEqual(inmemorywarehouserepository.GetById(1).X, 15);
        }

        [TestMethod]
        public void Delete_DeleteItem_ItemRemoved()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();
            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));

            // act
            inmemorywarehouserepository.Delete(new Warehouse(1, 10, 10));

            // assert
            Assert.IsNull(inmemorywarehouserepository.GetById(1));
        }

        [TestMethod]
        public void GetByID_RetrieveItem_ItemRetrieved()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();
            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));

            // act
            Warehouse warehouse = inmemorywarehouserepository.GetById(1);

            // assert
            Assert.AreEqual(warehouse.Warehouseid, 1);
        }

        [TestMethod]
        public void GetAll_RetrieveAllItems_AllItemsRetrieved()
        {
            // arrange
            InMemoryWarehouseRepository inmemorywarehouserepository = new InMemoryWarehouseRepository();
            inmemorywarehouserepository.Add(new Warehouse(1, 10, 10));
            inmemorywarehouserepository.Add(new Warehouse(1, 15, 20));

            // act
            List<Warehouse> warehouselist = (List<Warehouse>)inmemorywarehouserepository.GetAll();

            // assert
            Assert.AreEqual(warehouselist.Count, 2);
        }
    }
}
