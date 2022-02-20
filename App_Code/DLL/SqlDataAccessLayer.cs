using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

/// <summary>
/// Summary description for SqlDataAccessLayer
/// </summary>
/// 
namespace Reports.DataAccessLayer
{
    public class SqlDataAccessLayer
    {
        //protected SqlConnection dbConnection;
        //public static readonly string _connectionString = string.Empty;
        public static readonly string _strconnectionString = string.Empty;
        static SqlDataAccessLayer()
        {
            //_connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            _strconnectionString = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //if (string.IsNullOrEmpty(_connectionString))
            //{
            //    throw new Exception("No connection string configured in Web.Config file");
            //}
            if (string.IsNullOrEmpty(_strconnectionString))
            {
                throw new Exception("No connection string configured in Web.Config file");
            }
        }
    }
}