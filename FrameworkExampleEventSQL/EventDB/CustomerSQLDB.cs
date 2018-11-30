﻿using System;
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
    class CustomerSQLDB : DBBase, IReadDB, IWriteDB
    { 
    #region Constructors

    public CustomerSQLDB() : base() { }
    public CustomerSQLDB(string cnString) : base(cnString) { }
    public CustomerSQLDB(DBConnection cn) : base(cn) { }

    #endregion

    // Implementation of methods required by the interfaces
    // Notice that they use ADO.NET objects and call methods in the SQL base class
    #region IReadDB Members
    /// <summary>
    /// </summary>
    /// 
    public IBaseProps Retrieve(Object key)
    {
        DBDataReader data = null;
        CustomerProps props = new CustomerProps();
        DBCommand command = new DBCommand();

        command.CommandText = "usp_CustomerSelect";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters["@CustomerID"].Value = (Int32)key;

        try
        {
            data = RunProcedure(command);
            if (!data.IsClosed)
            {
                if (data.Read())
                {
                    props.SetState(data);
                }
                else
                    throw new Exception("Record does not exist in the database.");
            }
            return props;
        }
        catch (Exception e)
        {
            // log this exception
            throw;
        }
        finally
        {
            if (data != null)
            {
                if (!data.IsClosed)
                    data.Close();
            }
        }
    } //end of Retrieve()

    // retrieves a list of objects
    public object RetrieveAll(Type type)
    {
        List<CustomerProps> list = new List<CustomerProps>();
        DBDataReader reader = null;
        CustomerProps props;

        try
        {
            reader = RunProcedure("usp_CustomerSelectAll");
            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    props = new CustomerProps();
                    props.SetState(reader);
                    list.Add(props);
                }
            }
            return list;
        }
        catch (Exception e)
        {
            // log this exception
            throw;
        }
        finally
        {
            if (!reader.IsClosed)
            {
                reader.Close();
            }
        }
    }
    #endregion

    #region IWriteDB Members
    /// <summary>
    /// </summary>
    public IBaseProps Create(IBaseProps p)
    {
        int rowsAffected = 0;
        CustomerProps props = (CustomerProps)p;

        DBCommand command = new DBCommand();
        command.CommandText = "usp_CustomerCreate";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters.Add("@Name", SqlDbType.VarChar);
        command.Parameters.Add("@Addess", SqlDbType.VarChar);
        command.Parameters.Add("@City", SqlDbType.VarChar);
        command.Parameters.Add("@State", SqlDbType.Char);
        command.Parameters.Add("@ZipCode", SqlDbType.Char);
        command.Parameters[0].Direction = ParameterDirection.Output;
        command.Parameters["@CustomerID"].Value = props.customerID;
        command.Parameters["@Name"].Value = props.name;
        command.Parameters["@Address"].Value = props.address;
        command.Parameters["@City"].Value = props.city;
        command.Parameters["@State"].Value = props.state;
            command.Parameters["@ZipCode"].Value = props.zipCode;

            try
        {
            rowsAffected = RunNonQueryProcedure(command);
            if (rowsAffected == 1)
            {
                props.customerID = (int)command.Parameters[0].Value;
                props.ConcurrencyID = 1;
                return props;
            }
            else
                throw new Exception("Unable to insert record. " + props.ToString());
        }
        catch (Exception e)
        {
            // log this error
            throw;
        }
        finally
        {
            if (mConnection.State == ConnectionState.Open)
                mConnection.Close();
        }
    }

    /// <summary>
    /// </summary>
    public bool Delete(IBaseProps p)
    {
        CustomerProps props = (CustomerProps)p;
        int rowsAffected = 0;

        DBCommand command = new DBCommand();
        command.CommandText = "usp_CustomerDelete";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters.Add("@ConcurrencyID", SqlDbType.Int);
        command.Parameters["@CustomerID"].Value = props.customerID;
        command.Parameters["@ConcurrencyID"].Value = props.ConcurrencyID;

        try
        {
            rowsAffected = RunNonQueryProcedure(command);
            if (rowsAffected == 1)
            {
                return true;
            }
            else
            {
                string message = "Record cannot be deleted. It has been edited by another user.";
                throw new Exception(message);
            }

        }
        catch (Exception e)
        {
            // log this exception
            throw;
        }
        finally
        {
            if (mConnection.State == ConnectionState.Open)
                mConnection.Close();
        }
    } // end of Delete()

    /// <summary>
    /// </summary>
    public bool Update(IBaseProps p)
    {
        int rowsAffected = 0;
        CustomerProps props = (CustomerProps)p;

        DBCommand command = new DBCommand();
     
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters.Add("@Name", SqlDbType.VarChar);
        command.Parameters.Add("@Addess", SqlDbType.VarChar);
        command.Parameters.Add("@City", SqlDbType.VarChar);
        command.Parameters.Add("@State", SqlDbType.Char);
        command.Parameters.Add("@ZipCode", SqlDbType.Char);
        command.Parameters.Add("@ConcurrencyID", SqlDbType.Int);
        command.Parameters[0].Direction = ParameterDirection.Output;
        command.Parameters["@CustomerID"].Value = props.customerID;
        command.Parameters["@Name"].Value = props.name;
        command.Parameters["@Address"].Value = props.address;
        command.Parameters["@City"].Value = props.city;
        command.Parameters["@State"].Value = props.state;
        command.Parameters["@ZipCode"].Value = props.zipCode;
        command.Parameters["@ConcurrencyID"].Value = props.ConcurrencyID;

            try
        {
            rowsAffected = RunNonQueryProcedure(command);
            if (rowsAffected == 1)
            {
                props.ConcurrencyID++;
                return true;
            }
            else
            {
                string message = "Record cannot be updated. It has been edited by another user.";
                throw new Exception(message);
            }
        }
        catch (Exception e)
        {
            // log this exception
            throw;
        }
        finally
        {
            if (mConnection.State == ConnectionState.Open)
                mConnection.Close();
        }
    } // end of Update()
    #endregion

    // the version of the delete called from the 
    // static method in the Business Class.  It ignores the concurrency id
    public void Delete(int key)
    {
        int rowsAffected = 0;

        DBCommand command = new DBCommand();
        command.CommandText = "usp_CustomerStaticDelete";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CustomerID", SqlDbType.Int);
        command.Parameters["@CustomerID"].Value = key;

        try
        {
            rowsAffected = RunNonQueryProcedure(command);
            if (rowsAffected != 1)
            {
                string message = "Record was not deleted. Perhaps the key you specified does not exist.";
                throw new Exception(message);
            }
        }
        catch (Exception e)
        {
            // log this error
            throw;
        }
        finally
        {
            if (mConnection.State == ConnectionState.Open)
                mConnection.Close();
        }
    }

        /*
    // Shows you how to use a data table rather than a list of objects
    public DataTable RetrieveTable()
    {
        DataTable t = new DataTable("CustomerList");
        DBDataReader reader = null;
        DataRow row;

        t.Columns.Add("ID", System.Type.GetType("System.Int32"));
        t.Columns.Add("UserID", System.Type.GetType("System.Int32"));
        t.Columns.Add("Date", System.Type.GetType("System.DateTime"));
        t.Columns.Add("Title", System.Type.GetType("System.String"));
        t.Columns.Add("Description", System.Type.GetType("System.String"));

        try
        {
            reader = RunProcedure("usp_CustomerSelectAll");
            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    row = t.NewRow();
                    row["ID"] = reader["CustomerId"];
                    row["UserID"] = reader["UserId"];
                    row["Date"] = reader["CustomerDate"];
                    row["Title"] = reader["CustomerTitle"];
                    row["Description"] = reader["CustomerDescription"];
                    t.Rows.Add(row);
                }
            }
            t.AcceptChanges();
            return t;
        }
        catch (Exception e)
        {
            // log this exception
            throw;
        }
        finally
        {
            if (!reader.IsClosed)
            {
                reader.Close();
            }
        }
        */
}

