using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DBConnection
{
    string _sqlConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    SqlConnection _sqlConnection = null;

    public SqlConnection GetDefaultConnection()
    {
        _sqlConnection = new SqlConnection(_sqlConnectionString);

        if (_sqlConnection.State != ConnectionState.Open)
        {
            _sqlConnection.Open();
        }
        return _sqlConnection;
    }

}