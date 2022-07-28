using NUnit.Framework;
using PruebaSII_Thales.Controllers;

namespace PruebaSII_Thales.Tests
{
    public class Tests
    {
        private EmployeeController employee;

        public Tests()
        {
            employee = new EmployeeController();    
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int id = 1;
            var test = employee.Index(id);
            Assert.AreEqual(test.Id, id);
        }
    }
}