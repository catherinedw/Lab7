using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventPropsClasses;
using ToolsCSharp;

using System.Data;
using System.Data.SqlClient;

// *** I use an "alias" for the ado.net classes throughout my code
// When I switch to an oracle database, I ONLY have to change the actual classes here
using DBBase = ToolsCSharp.BaseSQLDB;
using DBConnection = System.Data.SqlClient.SqlConnection;
using DBCommand = System.Data.SqlClient.SqlCommand;
using DBParameter = System.Data.SqlClient.SqlParameter;
using DBDataReader = System.Data.SqlClient.SqlDataReader;
using DBDataAdapter = System.Data.SqlClient.SqlDataAdapter;

namespace EventDBClasses
{
    public class ProductSQLDB : DBBase, IReadDB, IWriteDB
    {
        public IBaseProps Create(IBaseProps props)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IBaseProps props)
        {
            throw new NotImplementedException();
        }

        public IBaseProps Retrieve(object key)
        {
            throw new NotImplementedException();
        }

        public object RetrieveAll(Type type)
        {
            throw new NotImplementedException();
        }

        public bool Update(IBaseProps props)
        {
            throw new NotImplementedException();
        }
    }
}
