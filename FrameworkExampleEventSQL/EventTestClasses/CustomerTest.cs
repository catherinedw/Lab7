﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomerClasses;


namespace EventTestClasses
{
    [TestFixture]
    public class CustomerTest
    {
        Customer testc;

        [SetUp]
        public void Setup()
        {
            testc = new Customer();
            testc.customerID = 1;
            testc.name = "Minnie Mouse";
            testc.address = "12 Coconut Drive";
            testc.city = "Key Largo";
            testc.state = 'FL';
            testc.zipCode = '80487';
            testc.ConcurrencyID = 1;
        }

        [Test]
        public void TestCustomer()
        {
            //assert that areEqual all the properties
            Assert.AreEqual(testc.customerID, 1);
            Assert.AreEqual(testc.name, "Minnie Mouse");
            Assert.AreEqual(testc.address, "12 Coconut Drive");
            Assert.AreEqual(testc.city, "Key Largo");
            Assert.AreEqual(testc.state, 'FL');
            Assert.AreEqual(testc.zipCode, '80487');
            Assert.AreEqual(testc.ConcurrencyID, 1);
        }
    }
}
