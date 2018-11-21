using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventDBClasses;
using EventPropsClasses;

namespace EventTestClasses
{
    [TestFixture]
    public class ProductDBTests
    {
        ProductProps props;
        ProductSQLDB db;
        private string dataSource = "DataSource = LAPTOP - S3LF8NDH\\SQLEXPRESS;Initial Catalog=EventCalendar;Integrated Security=True";

        [SetUp]
        public void Setup()
        {
            db = new ProductSQLDB(dataSource);
               
        }

        [Test]
        public void TestRetrieve()
        {
            props = (ProductProps)db.Retrieve(1);
        }
    }
}
