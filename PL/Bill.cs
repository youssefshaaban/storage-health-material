
/* created by yousef shabaan
email : yousefshabaan0@gmail.com
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project_soft.PL
{
    public partial class Bill : notification
    {
        List<BL.Product> product;
        List<int> quantity;				// list of quantity
        BL.Bill bill;
        BL.Order order;
        BL.Worker worker;
        List<float> priceOfProduct;    // list of price 
        public List<int> Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        internal List<BL.Product> Product
        {
            get { return product; }
            set { product = value; }
        }
        public Bill()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Product_Name","اسم الصنف");
            dataGridView1.Columns.Add("quantity", "كمية الشراء");
            dataGridView1.Columns.Add("price", "سعر الوحده");
           // getSellProduct();
            label2.Text = BL.Employee.User_Name1;
            bill = new BL.Bill();
            order = new BL.Order();
            worker = new BL.Worker();
            
        }
        void getSellProduct() {
            for (int i = 0; i < product.Count; i++) { 
            dataGridView1.Rows.Add(product[i].Product_Name1,quantity[i].ToString(),priceOfProduct[i].ToString());  // show product name and quantity of product and price
            }
        }


        public Bill(float price, List<float> priceProduct,List<int>quan) //overloadin constructor 
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Product_Name", "اسم الصنف");
            dataGridView1.Columns.Add("quantity", "كمية الشراء");
            dataGridView1.Columns.Add("price", "سعر الوحده");
            product = SallingForm.SellProduct;
            quantity = quan;
            label2.Text = BL.Employee.User_Name1;
            label4.Text = price.ToString();
            this.priceOfProduct = priceProduct;
            label6.Text = DateTime.Now.ToString();
            
            getSellProduct();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SallingForm().ShowDialog();
            this.Close();
        }

        private void Update_product_AfterSalling() {    // after confirm selling then updatet quantity
            for (int i = 0; i < product.Count; i++) {
                
                product[i].Avalible_Quantity1 -= quantity[i];
                worker.Update_Product_AfterSalling(product[i]);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)  //to confirm order
        {
            
            worker = new BL.Worker();
            bill = new BL.Bill(BL.Employee.Id, DateTime.Now);
            order = new BL.Order(product, quantity, bill);
            if (worker.Sell_Products(order))
            {
                MessageBox.Show("تم تسجيل الفاتوره بنجاح");
                button1.Enabled = false;
                Update_product_AfterSalling();
                button5.Enabled = true;
            }

            else
            {
                MessageBox.Show("يوجد خطا فى تسجيل الفاتوره");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)  // to make report 
        {
            
            report.report report = new report.report();
            BL.Bill b = new BL.Bill(BL.Employee.Id, DateTime.Now);
            
            bill.return_Bill_Id(b);
           
            report.SetParameterValue("@Sales_id", bill.Sales_Id1);
            project_soft.report.order_customer formm = new project_soft.report.order_customer();
            formm.crystalReportViewer1.ReportSource = report;
            formm.ShowDialog();
            this.Hide();
            new SallingForm().ShowDialog();
            this.Close();
        }

        
    }
}
