using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_soft.BL
{
   public class Order
    {


        private List<BL.Product> product;

        internal List<BL.Product> Product
        {
            get { return product; }
            set { product = value; }
        }
        private List<int> quantity;

        public List<int> Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        Bill b;

        internal Bill B
        {
            get { return b; }
            set { b = value; }
        }
        public Order(List<BL.Product> product,List<int> quan,Bill bill) {
            this.B = bill;
            this.Product = product;
            this.Quantity = quan;
        }
        public Order() { }
        public bool Insert_Product_Sell(Order order,int Sales_Id) {
            DAL.OrderDAC order1 = new DAL.OrderDAC();
            if (order.Product.Count == 0 || order.Quantity.Count == 0 || Sales_Id == 0  || order==null) return false;
            else
            {
             order1.Insert_Product_Sell(order,b.Sales_Id1);
                return true;
            }

            }




        public bool checkavailabilty(List<BL.Product> SellProduct, int demand,string name) {

            foreach (BL.Product pro in SellProduct) { 
            if(name==pro.Product_Name1&&pro.Avalible_Quantity1>=demand){
                return true;
 }
           }
            return false;
        
        }




        }
    }

