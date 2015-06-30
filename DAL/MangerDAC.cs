using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class MangerDAC : DataAccessLayer
    {
        
        public bool Insert_Worker(BL.Worker wo)
        {

            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            parm[0].Value = BL.Worker.User_Name1;
            parm[1] = new SqlParameter("@User_Password", SqlDbType.NVarChar, 50);
            parm[1].Value = wo.User_Password1;
            parm[2] = new SqlParameter("@User_Type", SqlDbType.Int);
            parm[2].Value = wo.User_Type1;
            parm[3] = new SqlParameter("@User_Address", SqlDbType.NVarChar, 50);
            parm[3].Value = wo.User_Address1;
            parm[4] = new SqlParameter("@User_Phone", SqlDbType.Float);
            parm[4].Value = wo.User_Phone1;
            parm[5] = new SqlParameter("@User_Ssn", SqlDbType.Float);
            parm[5].Value = wo.User_Ssn1;
            parm[6] = new SqlParameter("@User_Salary", SqlDbType.Float);
            parm[6].Value = wo.User_Salary1;
        
            open();
            if (ExecuteComand("Insert_Worker", parm))
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
        public bool Vlidate_User_Name(string User_Name)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            parm[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = SelectTable("Vlidate_User_Name", parm);
            if (dt.Rows.Count >0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Delet_Worker(string User_Name)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            parm[0].Value = User_Name;
            open();
            if (ExecuteComand("Delet_Worker", parm))
            {
                close();
                return true;
            }
            else return false;


        }
        public bool Check_Name_Manager(string User_Name)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@User_Name", SqlDbType.VarChar, 50);
            parm[0].Value = User_Name;
            DataTable dt = new DataTable();
            dt = SelectTable("Check_Name_Manager", parm);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool Delet_Product(BL.Product product)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar, 50);
            param[0].Value = product.Product_Name1;
            open();
            if (ExecuteComand("Delet_Product", param))
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
        public bool Update_Product(BL.Product product)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar, 50);
            param[0].Value = product.Product_Name1;

            param[1] = new SqlParameter("@Avalible_Quantity", SqlDbType.Int);
            param[1].Value = product.Avalible_Quantity1;

            param[2] = new SqlParameter("@Critcal_Quantity", SqlDbType.Int);
            param[2].Value = product.Critcal_Quantity1;

            param[3] = new SqlParameter("@Oraginal_Price", SqlDbType.Int);
            param[3].Value = product.Oraginal_Price1;

            param[4] = new SqlParameter("@Sales_Price", SqlDbType.Int);
            param[4].Value = product.Sales_Price1;
            open();
            if (ExecuteComand("Update_Product", param))
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
        public bool ShowTranscript(string fromDate, string toDate ,ref DataTable dt)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fromDateOfBill", SqlDbType.NVarChar, 50);
            param[0].Value = fromDate;

            param[1] = new SqlParameter("@toDateOfBill", SqlDbType.NVarChar, 50);
            param[1].Value = toDate;
            dt =SelectTable("Transcript", param);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
    }
}
