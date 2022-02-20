using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBOperation
/// </summary>
public class DBOperation
{
    DBConnection _dbConnection = new DBConnection();
    public DataSet GetData(string ProcedureOrText, CommandType commandType, IDataParameter[] OutsqlParams, params IDataParameter[] sqlParams)
    {

        DataSet objresult = new DataSet();
        using (SqlCommand cmd = new SqlCommand(ProcedureOrText, _dbConnection.GetDefaultConnection()))
        {
            cmd.CommandType = commandType;
            if (sqlParams != null)
            {
                foreach (IDataParameter para in sqlParams)
                {
                    para.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(para);
                }
                foreach (IDataParameter paras in OutsqlParams)
                {
                    paras.DbType = DbType.String;
                    paras.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paras);
                }
            }

            cmd.CommandType = commandType;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(objresult);
            return objresult;
        }
    }
    public string ExecuteData(string ProcedureOrText, CommandType commandType, IDataParameter[] OutsqlParams, params IDataParameter[] sqlParams)
    {
        int rows = -1;
        string Rslt = "";
        using (SqlCommand cmd = new SqlCommand(ProcedureOrText, _dbConnection.GetDefaultConnection()))
        {
            if (sqlParams != null)
            {
                foreach (IDataParameter para in sqlParams)
                {
                    para.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(para);
                }
                foreach (IDataParameter paras in OutsqlParams)
                {
                    paras.DbType = DbType.String;
                    paras.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paras);
                }
                cmd.CommandType = commandType;
                rows = cmd.ExecuteNonQuery();
                Rslt = cmd.Parameters["@Msg"].Value.ToString();
            }
        }
        return Rslt;
    }

}