using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace project_soft.BL
{
    public class Product
    {

        private DAL.ProductDAC pro;
        private int Product_Id;

        public int Id
        {
            get { return Product_Id; }
            set { Product_Id = value; }
        }
        private string Product_Name;

        public string Product_Name1
        {
            get { return Product_Name; }
            set { Product_Name = value; }
        }
        private int Avalible_Quantity;

        public int Avalible_Quantity1
        {
            get { return Avalible_Quantity; }
            set { Avalible_Quantity = value; }
        }
        private int Critcal_Quantity;

        public int Critcal_Quantity1
        {
            get { return Critcal_Quantity; }
            set { Critcal_Quantity = value; }
        }
        private float Oraginal_Price;
        public float Oraginal_Price1
        {
            get { return Oraginal_Price; }
            set { Oraginal_Price = value; }
        }
        private float Sales_Price;

        public float Sales_Price1
        {
            get { return Sales_Price; }
            set { Sales_Price = value; }
        }
        public Product() { pro = new DAL.ProductDAC(); }

        public Product(string Product_Name, int Avalible_Quantity, int Critcal_Quantity, float Oraginal_Price, float Sales_Price)
        {
            this.Product_Name1 = Product_Name;
            this.Avalible_Quantity1 = Avalible_Quantity;
            this.Critcal_Quantity1 = Critcal_Quantity;
            this.Oraginal_Price1 = Oraginal_Price;
            this.Sales_Price = Sales_Price;
            pro = new DAL.ProductDAC();
        }
        public List<BL.Product> selectAllProduct()
        {
            return pro.retrieveProduct();
        }
        public bool Check_Product_Name(string Product_Name)
        {
            if (Product_Name == null || Product_Name.Equals(""))
            {
                return false;
            }
            else
            {
                return pro.Check_Product_Name(Product_Name);
            }
        }

        public bool Update_Product_After_Salling(BL.Product product)
        {
            if (product==null || product.Product_Name1 == null || product.Avalible_Quantity1 <0 || product.Critcal_Quantity1 <= 0 || product.Oraginal_Price1 <= 0 || product.Sales_Price1 <= 0 || product.Sales_Price1 < product.Oraginal_Price1)
            {
                return false;
            }
            else
            {
                return pro.Update_Product_After_Salling(product);
            }
        }
     public bool check_udate_product(Product pro1, ref Product product)
        {
         
            if (pro1 != null && product != null)
            {
                
                pro.check_update_product(ref product,pro1.Product_Name1);
                if (pro1.Avalible_Quantity1 == product.Avalible_Quantity1 && pro1.Critcal_Quantity1 == product.Critcal_Quantity1 && pro1.Oraginal_Price1 == product.Oraginal_Price1 && pro1.Sales_Price1 == product.Sales_Price1)
                {
                    return false;
                }
                else
                {
                    if (pro1.Product_Name1 == null || pro1.Avalible_Quantity1 <= 0 || pro1.Critcal_Quantity1 <= 0 || pro1.Oraginal_Price1 <= 0 || pro1.Sales_Price1 <= 0 || pro1.Avalible_Quantity1 < pro1.Critcal_Quantity1 || pro1.Sales_Price1 < pro1.Oraginal_Price1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
           
        }

    }
}