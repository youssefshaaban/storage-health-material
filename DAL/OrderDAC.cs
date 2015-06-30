using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.DAL
{
    class OrderDAC : DataAccessLayer
    {
    
        public bool Insert_Product_Sell(BL.Order order,int sales_id)
        {
            SqlParameter[] parm = new SqlParameter[3];
            bool flag = false;
            open();
            for (int i=0; i< order.Product.Count;i++)
            {
                parm[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                parm[0].Value = order.Product[i].Id;
                parm[1] = new SqlParameter("@Sales_Id", SqlDbType.Int);
                parm[1].Value = sales_id;
                parm[2] = new SqlParameter("@Quantity", SqlDbType.Int);
                parm[2].Value = order.Quantity[i];
                DataTable dt = new DataTable();
                flag=ExecuteComand("Insert_Product_Sell", parm);
            }
            close();
            return flag;
        }

    
    }
}
