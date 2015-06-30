using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.BL
{
    public class Manager : BL.Employee
    {
        private DAL.MangerDAC mang;
        public Manager()
        {
            mang = new DAL.MangerDAC();
        }
        public bool Insert_Worker(BL.Worker wo)
        {
            if (wo == null || !Vlidate_User_Name(Worker.User_Name1) || wo.User_Address1 == null || wo.User_Password1 == null || wo.User_Phone1 <= 0 || wo.User_Salary1 <= 0 || wo.User_Ssn1 <= 0 || wo.User_Type1 <= 1 || wo.User_Address1 == "" || wo.User_Password1 == "" || Worker.User_Name1 == null || Worker.User_Name1 == "")
            {
                return false;
            }
            else
            {
                return mang.Insert_Worker(wo);
            }
        }
        public bool Vlidate_User_Name(string User_Name)
        {
            if (User_Name == null || User_Name.Equals("")) return false;
            else return mang.Vlidate_User_Name(User_Name);
        }
        public bool Delet_Worker(string User_Name)
        {
            if (User_Name == null || User_Name.Equals("")) return false;
            else return mang.Delet_Worker(User_Name);
        }

        public bool Check_Name_Manager(string User_Name)
        {

            if (User_Name == null || User_Name == "") return false;
            return !mang.Check_Name_Manager(User_Name);
        }
        public bool Delet_Product(Product product)
        {
            if (product == null || product.Product_Name1 == null || product.Product_Name1 == "" || !product.Check_Product_Name(product.Product_Name1)) return false;
            return mang.Delet_Product(product);
        }
        public bool Update_Product(BL.Product product)
        {
            BL.Product pro = new Product();
            if (product == null || !product.Check_Product_Name(product.Product_Name1) || product.Product_Name1 == "" || product.Product_Name1 == null)
                return false;
            if (product.Sales_Price1 <= 0 && product.Sales_Price1 <= product.Oraginal_Price1)
                return false;
            if (product.Oraginal_Price1 < 0)
                return false;
            if (product.Avalible_Quantity1 < product.Critcal_Quantity1 || product.Avalible_Quantity1 <= 0)
                return false;
            if (product.Critcal_Quantity1 <= 0)
                return false;

            return mang.Update_Product(product);


        }
        public bool ShowTranscript(string fromDate, string toDate,ref DataTable dt)
        {
            //fromDate.IndexOf(
            if (fromDate == null || toDate == null || fromDate =="//" || toDate=="//" )
                return false;
            else
                return mang.ShowTranscript(fromDate, toDate,ref dt);


        }
    }
}