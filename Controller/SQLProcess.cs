using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SampleApp.Controller
{
    public class SQLProcess
    {
        public static string Configuration()
        {
            string input;
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["appcon"].ConnectionString);//appconbdo
                input = con.ConnectionString + "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return input; 
        }

        public static string SBGetConnectionString()
        {
            return Configuration();
        }  
        public static string CleanSQL(string data)
        {
            return data.Replace("'", "''");
        }

        public static int ExecuteNonQuery(string SQL)
        {
            using (SqlConnection conn = new SqlConnection(Configuration()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                int result = cmd.ExecuteNonQuery();

                conn.Close();
                return result;
            }
        }

        public static object ExecuteScalar(string SQL)
        {
            using (SqlConnection conn = new SqlConnection(Configuration()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL, conn);
                object result = cmd.ExecuteScalar();

                conn.Close();
                return result;
            }
        }

        public class SqlCommandEx : IDisposable
        {
            private SqlConnection conn;
            public SqlCommand CommandObject;

            public SqlCommandEx(string SQL)
            {
                conn = new SqlConnection(Configuration());
                conn.Open();
                CommandObject = new SqlCommand(SQL, conn);

            }

            public DataTable GetDataTable()
            {
                SqlDataAdapter da = new SqlDataAdapter(CommandObject);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            public DataSet GetDataSet()
            {
                SqlDataAdapter da = new SqlDataAdapter(CommandObject);
                DataSet DS = new DataSet();
                da.Fill(DS);
                return DS;
            }

            public void AddWithValue(string parameter, object value)
            {
                CommandObject.Parameters.AddWithValue(parameter, value);
            }

            public void Dispose()
            {
                conn.Close();
            }
        }

        public static DataTable GetDataTable(string SQL)
        {
            using (SqlConnection conn = new SqlConnection(Configuration()))
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
                DataTable result = new DataTable();
                da.Fill(result);

                conn.Close();
                return result;
            }
        }
    }
}