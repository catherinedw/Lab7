using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductPropsClasses;

namespace ProductTestClasses
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
            string pString = testp.GetState();
            ProductProps p2 = new ProductProps();
            p2.SetState(pString);
            Assert.AreEqual(testp.ID, p2.ID);
            Assert.AreEqual(testp.quantity, p2.quantity);
            Assert.AreEqual(testp.code, p2.code);
            Assert.AreEqual(testp.price, p2.price);
            Assert.AreEqual(testp.description, p2.description);
            Assert.AreEqual(testp.ConcurrencyID, p2.ConcurrencyID);
        }
    }
}
