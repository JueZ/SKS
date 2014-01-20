using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SKS_PDS.DAL;
using SKS_PDS.Entities;

namespace SKS_PDS_Tests
{
    [TestClass]
    public class InMemoryPackageRepositoryTest
    {
        [TestMethod]
        public void Get_ByWarehouseID_Warehouse()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();

            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));
            inmemorypackagerepository.Add(new Package(2, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // act
            List<Package> packagelist = inmemorypackagerepository.getPackageByWarehouseid(1);
            
            // assert
            Assert.AreEqual(packagelist.Count, 2);
        }

        [TestMethod]
        public void Add_Item_AddedItem()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();

            // act
            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // assert
            List<Package> packagelist = (List<Package>)inmemorypackagerepository.GetAll();

            Assert.AreEqual(packagelist.Count, 1);
        }

        [TestMethod]
        public void Update_ItemName_UpdatedName()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();
            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // act
            inmemorypackagerepository.Update(new Package(1, "NewName", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // assert
            Assert.AreEqual(inmemorypackagerepository.GetById(1).Sender, "NewName");
        }

        [TestMethod]
        public void Delete_DeleteItem_ItemRemoved()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();
            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // act
            inmemorypackagerepository.Delete(new Package(1, "NewName", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // assert
            Assert.IsNull(inmemorypackagerepository.GetById(1));
        }

        [TestMethod]
        public void GetByID_RetrieveItem_ItemRetrieved()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();
            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // act
            Package package = inmemorypackagerepository.GetById(1);

            // assert
            Assert.AreEqual(package.PackageID, 1);
        }

        [TestMethod]
        public void GetAll_RetrieveAllItems_AllItemsRetrieved()
        {
            // arrange
            InMemoryPackageRepository inmemorypackagerepository = new InMemoryPackageRepository();
            inmemorypackagerepository.Add(new Package(1, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));
            inmemorypackagerepository.Add(new Package(2, "Name", "Adress", "Receiver", "TargetAdress", 1, "City", "Country", "1010", "Street"));

            // act
            List<Package> packagelist = (List<Package>)inmemorypackagerepository.GetAll();

            // assert
            Assert.AreEqual(packagelist.Count, 2);
        }
    }
}
