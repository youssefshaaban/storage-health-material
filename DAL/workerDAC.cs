using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class workerDAC : DataAccessLayer
    {
        public bool AddProduct(BL.Product product)
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
            if (ExecuteComand("AddProduct", param))
            {
                close();
                return true;
            }
            else return false;

        }

    }
}
