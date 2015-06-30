using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class DataAccessLayer
    {
        
        private SqlConnection conection;
        private string nameOfDatabase;

        public string NameOfDatabase
        {
            get { return nameOfDatabase; }
            set { nameOfDatabase = value; }
        }
        private string nameOfServer;

        public string NameOfServer
        {
            get { return nameOfServer; }
            set { nameOfServer = value; }
        }

        // this construct Intialize the connection object
        public DataAccessLayer()
        {
            
                this.NameOfDatabase = "Project_Soft";
                this.NameOfServer = "JOE-PC";
                conection = new SqlConnection(@"server='" + this.NameOfServer + "'; Database='" + this.NameOfDatabase + "'; Integrated Security=true");
            
            
        }
        // return objectData
        
        // method open connection
        public void open()
        {
            if (conection.State != ConnectionState.Open)
            {
                conection.Open();
            }
        }
        // method close conection
        public void close()
        {
            if (conection.State != ConnectionState.Closed)
            {
                conection.Close();
            }
        }
        // Read from DataBase
        public DataTable SelectTable(string stored_procedure, SqlParameter[] parm)
        {
                DataTable dt = new DataTable();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = conection;
                if (parm != null)
                {
                    for (int i = 0; i < parm.Length; i++)
                    {
                        sqlcmd.Parameters.Add(parm[i]);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                return dt;
        }
        // method to insert,update,delete
        public bool ExecuteComand(string stored_procedure, SqlParameter[] parm)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = conection;
            if (parm != null)
            {
                for (int i = 0; i < parm.Length; i++)
                {
                    sqlcmd.Parameters.Add(parm[i]);
                }
            }
            int x = sqlcmd.ExecuteNonQuery();
            if (x > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
            
            
        }
    }

