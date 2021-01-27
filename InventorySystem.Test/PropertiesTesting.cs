using InventorySystem.Controllers;
using InventorySystem.Models;
using InventorySystem.Repository;
using InventorySystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace InventorySystem.Test
{
    public class PropertiesTesting
    {
        DatabaseContext context;
        private PropertiesRepository repository;
        public static DbContextOptions<DatabaseContext> dbContextOptions { get; }

        static PropertiesTesting()
        {
            dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(InventorySystem.Test.Connection.String)
                .Options;
        }

        [SetUp]
        public void Setup()
        {
            context = new DatabaseContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new PropertiesRepository(context);
        }

        #region Get By Id 

        [Test]
        public void PropertiesGetById_Return_OkResult()
        {
            //Arrange  
            var controller = new PropertiesController(repository);
            int id = 2;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.IsNotNull(data);
        }

        [Test]
        public void PropertiesGetById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new PropertiesController(repository);
            int id = 3;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.NotFoundResult).ToString());
        }

        [Test]
        public void PropertiesGetById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new PropertiesController(repository);
            int? id = null;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.BadRequestResult).ToString());
        }

        #endregion

        #region Get All  

        [Test]
        public void PropertiesGetAll_Return_OkResult()
        {
            //Arrange
            var controller = new PropertiesController(repository);

            //Act
            var data = controller.Get();

            //Assert
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        #endregion

        #region Update  

        [Test]
        public void PropertiesUpdate_Return_OkResult()
        {
            //Arrange
            var PropertiesRepository = new PropertiesRepository(context);
            int id = 1;
            ComputerView ComputerView = PropertiesRepository.GetById(id);

            Properties Properties = new Properties();
            Properties.ComputerTypeId = ComputerView.ComputerTypeId;
            Properties.Processor = ComputerView.Processor;
            Properties.Brand = ComputerView.Brand;
            Properties.UsbPorts = ComputerView.UsbPorts;
            Properties.RamSlots = ComputerView.RamSlots;
            Properties.FromFactor = ComputerView.FromFactor;
            Properties.Quantity = ComputerView.Quantity;
            Properties.ScreenSize = ComputerView.ScreenSize;

            var controller = new PropertiesController(repository);

            //Act
            Properties.UsbPorts = 3;
            var output = controller.Put(id, Properties);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        #endregion

        #region Delete  

        [Test]
        public void PropertiesDelete_Return_OkResult()
        {
            //Arrange  
            var controller = new PropertiesController(repository);
            int id = 1;

            //Act
            var output = controller.Delete(id);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        public void PropertiesDelete_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new PropertiesController(repository);
            int id = 5;

            //Act
            var output = controller.Delete(id);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.NotFoundResult).ToString());
        }

        #endregion

        #region Add 

        [Test]
        public void PropertiesAdd_Return_OkResult()
        {
            //Arrange
            var controller = new PropertiesController(repository);

            //Act
            Properties Properties = new Properties();
            Properties.ComputerTypeId = 1;
            Properties.Processor = "Intel i7";
            Properties.Brand = "Dell";
            Properties.UsbPorts = 4;
            Properties.RamSlots = 2;
            Properties.FromFactor = "Tower";
            Properties.Quantity = 20;
            Properties.ScreenSize = "";
            var output = controller.Post(Properties);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        [Test]
        public void PropertiesAdd_Return_BadRequestResult()
        {
            //Arrange
            var controller = new PropertiesController(repository);

            //Act
            Properties Properties = new Properties();

            Properties.ComputerTypeId = 0;
            Properties.Processor = "Intel i7";
            Properties.Brand = "Dell";
            Properties.UsbPorts = 4;
            Properties.RamSlots = 2;
            Properties.FromFactor = "Tower";
            Properties.Quantity = 20;
            Properties.ScreenSize = "";

            var output = controller.Post(Properties);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.BadRequestResult).ToString());
        }

        #endregion
    }
}