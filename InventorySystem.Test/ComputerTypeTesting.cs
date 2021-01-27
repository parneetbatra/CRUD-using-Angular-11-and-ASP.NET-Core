using InventorySystem.Controllers;
using InventorySystem.Models;
using InventorySystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace InventorySystem.Test
{
    public class ComputerTypeTesting
    {
        DatabaseContext context;
        private ComputerTypeRepository repository;
        public static DbContextOptions<DatabaseContext> dbContextOptions { get; }

        static ComputerTypeTesting()
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

            repository = new ComputerTypeRepository(context);
        }

        #region Get By Id 

        [Test]
        public void ComputerTypeGetById_Return_OkResult()
        {
            //Arrange  
            var controller = new ComputerTypeController(repository);
            int id = 2;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.IsNotNull(data);
        }

        [Test]
        public void ComputerTypeGetById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ComputerTypeController(repository);
            int id = 3;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.NotFoundResult).ToString());
        }

        [Test]
        public void ComputerTypeGetById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ComputerTypeController(repository);
            int? id = null;

            //Act  
            var data = controller.Get(id);

            //Assert 
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.BadRequestResult).ToString());
        }

        #endregion

        #region Get All  

        [Test]
        public void ComputerTypeGetAll_Return_OkResult()
        {
            //Arrange
            var controller = new ComputerTypeController(repository);

            //Act
            var data = controller.Get();

            //Assert
            Assert.AreEqual(data.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        #endregion

        #region Update  

        [Test]
        public void ComputerTypeUpdate_Return_OkResult()
        {
            //Arrange
            var computerTypeRepository = new ComputerTypeRepository(context);
            int id = 1;
            ComputerType computerType = computerTypeRepository.GetById(id);

            var controller = new ComputerTypeController(repository);

            //Act
            computerType.Name = "Desktop PC";
            var output = controller.Put(id, computerType);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        #endregion

        #region Delete  

        [Test]
        public void ComputerTypeDelete_Return_OkResult()
        {
            //Arrange  
            var controller = new ComputerTypeController(repository);
            int id = 1;

            //Act
            var output = controller.Delete(id);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        public void ComputerTypeDelete_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ComputerTypeController(repository);
            int id = 5;

            //Act
            var output = controller.Delete(id);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.NotFoundResult).ToString());
        }

        #endregion

        #region Add 

        [Test]
        public void ComputerTypeAdd_Return_OkResult()
        {
            //Arrange
            var controller = new ComputerTypeController(repository);

            //Act
            ComputerType computerType = new ComputerType();
            computerType.Name = "Server";
            var output = controller.Post(computerType);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.OkObjectResult).ToString());
        }

        [Test]
        public void ComputerTypeAdd_Return_BadRequestResult()
        {
            //Arrange
            var controller = new ComputerTypeController(repository);

            //Act
            ComputerType computerType = new ComputerType();
            computerType.Name = null;
            var output = controller.Post(computerType);

            //Assert 
            Assert.AreEqual(output.Result.ToString(), typeof(Microsoft.AspNetCore.Mvc.BadRequestResult).ToString());
        }

        #endregion
    }
}