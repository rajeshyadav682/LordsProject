using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LG_Desktop.Data
{
    class DBHelper
    {
        //private readonly IConfiguration _config;
        //private string Connectionstring = "LighthouseConnection";

        //public DBHelper(IConfiguration config)
        //{
        //    _config = config;
        //}
        //public void Dispose()
        //{

        //}

        private DbConnection GetDbconnection()
        {
            //return new MySql.Data.MySqlClient.MySqlConnection("Server=192.168.0.100;Port=49167;Database=test;Uid=root;Pwd=maria");
            return new MySql.Data.MySqlClient.MySqlConnection("Server=RSKBSL-162;Initial Catalog=LordsDB;User ID=sa;Password=hrhk@1234;Connection Timeout=30;");
        }

        internal int Execute(string sp, object parms, CommandType commandType = CommandType.StoredProcedure)
        {
            
            int affectedRows = 0;
            try
            {
                using (IDbConnection db = GetDbconnection())
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            affectedRows = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }             
                }             
            }
            catch (Exception ex)
            {
                LgCommon.Log(ex);
                throw ex;
            }
            finally
            {
                
            }
            return affectedRows;
        }

        internal List<T> GetAll<T>(string sp, object parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = GetDbconnection())
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }        
        }

        internal T Insert<T>(string sp, object parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;           
            try
            {
                using (IDbConnection db = GetDbconnection())
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }                     
                }          
            }
            catch (Exception ex)
            {
                LgCommon.Log(ex);
                throw ex;
            }
            finally
            {

            }

            return result;
        }

    }
}
