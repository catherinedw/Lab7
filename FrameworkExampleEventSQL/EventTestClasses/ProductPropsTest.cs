using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductPropsTest
    {
        ProductProps testp;

        [SetUp]
        public void Setup()
        {
            testp = new ProductProps();
            testp.ID = 1;
            testp.quantity = 10;
            testp.code = "XXXX";
            testp.price = 99.99m;
            testp.description = "This is a test product";
            testp.ConcurrencyID = 1;
        }

        [Test]
        //test the methods we wrote
        public void TestClone()
        {
            ProductProps clonedp = (ProductProps)testp.Clone();
            //assert that areEqual all the properties
            Assert.AreEqual(testp.ID, clonedp.ID);
            Assert.AreEqual(testp.quantity, clonedp.quantity);
            Assert.AreEqual(testp.code, clonedp.code);
            Assert.AreEqual(testp.price, clonedp.price);
            Assert.AreEqual(testp.description, clonedp.description);
            Assert.AreEqual(testp.ConcurrencyID, clonedp.ConcurrencyID);

            testp.ID = 4;
                Assert.AreNotEqual(testp.ID, clonedp.ID);
        }

        [Test]
        public void TestGetState()
        {
            string pString = testp.GetState();
                Console.WriteLine(pString);
        }

        [Test]
        public void TestSetState()
        {

        }
    }
}
