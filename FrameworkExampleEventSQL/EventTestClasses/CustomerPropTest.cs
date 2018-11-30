using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;


namespace CustomerTestClasses
{
    [TestFixture]
    public class CustomerPropTest
    {
        CustomerProps testc;

        [SetUp]
        public void Setup()
        {
            testc = new CustomerProps();
            testc.customerID = 20;
            testc.name = "Minnie Mouse";
            testc.address = "12 Coconut Drive";
            testc.city = "Key Largo";
            testc.state = "FL";
            testc.zipCode = "80487";
            testc.ConcurrencyID = 1;
        }

        [Test]
        public void TestCustomer()
        {
            //assert that areEqual all the properties
            Assert.AreEqual(testc.customerID, 20);
            Assert.AreEqual(testc.name, "Minnie Mouse");
            Assert.AreEqual(testc.address, "12 Coconut Drive");
            Assert.AreEqual(testc.city, "Key Largo");
            Assert.AreEqual(testc.state, "FL");
            Assert.AreEqual(testc.zipCode, "80487");
            Assert.AreEqual(testc.ConcurrencyID, 1);
            
        }

        [Test]
        //test the methods we wrote
        public void TestClone()
        {
            CustomerProps c2 = (CustomerProps)testc.Clone();
            //assert that areEqual all the properties
            Assert.AreEqual(testc.customerID, c2.customerID);
            Assert.AreEqual(testc.name, c2.name);
            Assert.AreEqual(testc.address, c2.address);
            Assert.AreEqual(testc.city, c2.city);
            Assert.AreEqual(testc.state, c2.state);
            Assert.AreEqual(testc.zipCode, c2.zipCode);
            Assert.AreEqual(testc.ConcurrencyID, c2.ConcurrencyID);

            testc.customerID = 4;
            Assert.AreNotEqual(testc.customerID, c2.customerID);
        }

        [Test]
        public void TestGetState()
        {
            string cString = testc.GetState();
            Console.WriteLine(cString);
        }

        [Test]
        public void TestSetState()
        {
            string cString = testc.GetState();
            CustomerProps c2 = new CustomerProps();
            c2.SetState(cString);
            Assert.AreEqual(testc.customerID, c2.customerID);
            Assert.AreEqual(testc.name, c2.name);
            Assert.AreEqual(testc.address, c2.address);
            Assert.AreEqual(testc.city, c2.city);
            Assert.AreEqual(testc.state, c2.state);
            Assert.AreEqual(testc.zipCode, c2.zipCode);
            Assert.AreEqual(testc.ConcurrencyID, c2.ConcurrencyID);

        }
    }
}
