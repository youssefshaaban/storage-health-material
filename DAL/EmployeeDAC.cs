using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class EmployeeDAC :DataAccessLayer
    {
        
        public EmployeeDAC() {
            //employee = new BL.Employee();
        }
        public bool logIn(string User_Name, string User_password,ref BL.Employee emp)
        {
         
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            parm[0].Value = User_Name;
            parm[1] = new SqlParameter("@User_Password", SqlDbType.NVarChar, 50);
            parm[1].Value = User_password;
            DataTable dt = new DataTable();
            dt = SelectTable("SP_Login", parm);
            if (dt.Rows.Count >= 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BL.Employee.Id = Convert.ToInt32(dr["User_Id"]);
                    BL.Employee.User_Name1 = dr["User_Name"].ToString();
                    emp.User_Password1 = dr["User_Password"].ToString();
                    emp.User_Type1 = Convert.ToInt32(dr["User_Type"]);
                    emp.User_Address1 = dr["User_Address"].ToString();
                    emp.User_Phone1 = Convert.ToDouble(dr["User_Phone"]);
                    emp.User_Salary1 = Convert.ToDouble(dr["User_Salary"]);
                    emp.User_Ssn1 = Convert.ToDouble(dr["User_Ssn"]);
                }
         
                return true;
            }
            else
            {
         
                return false;
            }
        }


    }
}
