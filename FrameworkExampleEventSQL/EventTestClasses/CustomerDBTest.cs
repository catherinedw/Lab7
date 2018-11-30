using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;
using EventDBClasses;

using System.Data;
using DBCommand = System.Data.SqlClient.SqlCommand;

namespace EventTestClasses
{   
    [TestFixture]
    public class CustomerDBTest
    {
        CustomerProps props, testc;
        CustomerSQLDB customerSQLDB;
        List<ProductProps> list;
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

    }
}
