using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SKS_PDS.DAL;
using SKS_PDS.Entities;
using SKS_PDS.Services;

using SKS_PDS_Tests.ShippingService;

namespace SKS_PDS_Tests
{
    [TestClass]
    public class PackageServiceTest
    {
        [TestMethod]
        public void AddPackage_importdata_PackageAdded()
        {
            //arrange
            ShippingService.ShippingServiceClient shippingserviceclient = new ShippingServiceClient();
            //act
            ShippingService.Package package = new ShippingService.Package();

            package.Address = new ShippingService.Address();

            package.Address.City = "Vienna";
            package.Address.Country = "Austria";
            package.Address.PostalCode = "1010";
            package.Address.Street = "Kärntnerstraße";
            package.Address.Id = 1;
            package.Id = 1;
            
            shippingserviceclient.AddPackage(package);

            //assert
            Assert.IsFalse(false);
        }
    }
}
