using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class BillDAC : DataAccessLayer
    {
        public bool Insert_Bill(BL.Bill b) {
            
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@User_Id", SqlDbType.Int);
            parm[0].Value = b.User_Id1;
            parm[1] = new SqlParameter("@DateOfBill", SqlDbType.DateTime);
            parm[1].Value = b.Date1;
            open();
            if (ExecuteComand("Insert_Bill", parm)) {
                close();
                return true; }
            else
            {
                close();
                return false;
            }

        }
        public bool Delete_Bill(int User_Id)
        {

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
            param[0].Value = User_Id;
            param[1] = new SqlParameter("@DateOfBill", SqlDbType.DateTime);
            param[1].Value = null;
            open();
            if (ExecuteComand("Delet_Bill", param))
            {
                close();
                return true;
            }
            else
            {
                close();
                return false;
            }

        }



        public bool Delete_Bill(DateTime DateOFBill)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@user_Id", SqlDbType.Int);
            param[0].Value = 0;
            param[1] = new SqlParameter("@DateOfBill", SqlDbType.DateTime);
            param[1].Value = DateOFBill;

            open();
            if (ExecuteComand("Delet_Bill", param))
            {
                close();
                return true;
            }
            else
            {
                close();
                return false;
            }
        }

        public bool return_Bill_Id(BL.Bill bill) {
            DataTable dt = new DataTable();
            dt=SelectTable("Retrun_Sales_Id", null);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows) {
                    bill.Sales_Id1 = Convert.ToInt32(dr["Sales_Id"]);
                    bill.Date1 = Convert.ToDateTime(dr["DateOfBill"]);
                    break;
                }

                return true;
            }
            else {

                return false;
            }
        }
    }
}
