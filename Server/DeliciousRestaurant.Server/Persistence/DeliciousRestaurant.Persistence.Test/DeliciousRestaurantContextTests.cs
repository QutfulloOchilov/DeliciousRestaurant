using DeliciousRestaurant.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System;

namespace DeliciousRestaurant.Persistence.Test
{
    public class TestOptionBuilder : BaseDeliciousRestaurantContextOptionBuilder
    {
        public TestOptionBuilder() : base("TestDatabaseForTestingCreateDatabase", false)
        {

        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void CreateDataBase_Successful_Test()
        {
            try
            {
                var testContextOptionBuilder = new TestOptionBuilder();
                var entityContext = new DeliciousRestaurantContext(testContextOptionBuilder);
                Assert.IsFalse((entityContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists(), $"{testContextOptionBuilder.DatabaseName} is exit in database. Make sure database was deleted.");
                entityContext.Database.EnsureCreated();
                Assert.IsTrue((entityContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists(), $"{testContextOptionBuilder.DatabaseName} not exit in database. Makse sure ef will create database.");
                entityContext.Database.EnsureDeleted();
            }
            catch (Exception ex)
            {
                Assert.Fail($"{ex.Message};\r\nMachine name {Environment.MachineName}");
            }
        }
    }
}