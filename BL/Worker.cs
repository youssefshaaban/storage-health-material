using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.BL
{
    public class Worker:BL.Employee
    {
        DAL.workerDAC wo;
        public Worker() { wo = new DAL.workerDAC(); }

        public Worker(string User_Name, string User_Password, string User_Address, double User_Phone, double User_Ssn, double User_Salary) {
            Worker.User_Name1 = User_Name;
            this.User_Password1 = User_Password;
            this.User_Type1 = 2;
            this.User_Address1 = User_Address;
            this.User_Phone1 = User_Phone;
            this.User_Ssn1 = User_Ssn;
            this.User_Salary1 = User_Salary;
            wo = new DAL.workerDAC();
        }
        public bool AddProduct(BL.Product product)
        {
            if (product == null || product.Check_Product_Name(product.Product_Name1) || product.Product_Name1 == "" || product.Product_Name1 == null)
                return false;
            if (product.Sales_Price1 <= 0 && product.Sales_Price1 <= product.Oraginal_Price1)
                return false;
            if (product.Oraginal_Price1 < 0)
                return false;
            if (product.Avalible_Quantity1 < product.Critcal_Quantity1 || product.Avalible_Quantity1 <= 0)
                return false;
            if (product.Critcal_Quantity1 <= 0)
                return false;
            else return wo.AddProduct(product);
        }
        public bool Update_Product_AfterSalling(BL.Product product) {
            if (product.Update_Product_After_Salling(product)) return true;
            else return false;
        }

        public bool Sell_Products(Order order) {
            if (order == null || order.Product == null || order.Quantity == null || order.B==null|| order.Product.Count == 0 || order.Quantity.Count == 0)
            {
                return false;
            }
            else { 
            
                if (order.B.Insert_Bill(order.B))
                {
                    if (order.B.return_Bill_Id(order.B))
                    {
                        if (order.Insert_Product_Sell(order,order.B.Sales_Id1))
                        {

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            
            }
        }

    }
}
