using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class ProductDAC : DataAccessLayer
    {
     
        //retrieve All Product
        public List<BL.Product> retrieveProduct()
        {
            List<BL.Product> allProducts = new List<BL.Product>();


            DataTable dt = new DataTable();
            
            dt = SelectTable("selectAllProduct", null);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BL.Product product = new BL.Product(dr["Product_Name"].ToString(), Convert.ToInt32(dr["Avalible_Quantity"]), Convert.ToInt32(dr["Critcal_Quantity"]), float.Parse(dr["Oraginal_Price"].ToString()), float.Parse(dr["Sales_Price"].ToString()));
                    product.Id = Convert.ToInt32(dr["Product_Id"]);
                    allProducts.Add(product);
                }
            }
            return allProducts;
        }

        public bool Check_Product_Name(string Product_Name)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Product_Name", SqlDbType.NVarChar, 50);
            parm[0].Value = Product_Name;
            DataTable dt = new DataTable();
            dt = SelectTable("Check_Product_Name", parm);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update_Product_After_Salling(BL.Product product)
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
      public  bool check_update_product(ref BL.Product product,string product_Name) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar, 50);
            param[0].Value = product_Name;
            DataTable dt = new DataTable();
            dt = SelectTable("check_Update_product", param);
            if (dt.Rows.Count >=1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    product.Product_Name1 = dr["Product_Name"].ToString();
                    product.Avalible_Quantity1 = Convert.ToInt32(dr["Avalible_Quantity"]);
                    product.Critcal_Quantity1 = Convert.ToInt32(dr["Critcal_Quantity"]);
                    product.Oraginal_Price1 = float.Parse(dr["Oraginal_Price"].ToString());
                    product.Sales_Price1 = float.Parse(dr["Sales_Price"].ToString());
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
