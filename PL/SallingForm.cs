

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

    public partial class SallingForm : notification
    {
        private static List<BL.Product> sellProduct;
        List<float> pricOfproduct;
        private  float totalPrice = 0.0f;
        internal static List<BL.Product> SellProduct
        {
            get { return SallingForm. sellProduct; }
            set { SallingForm.sellProduct = value; }
        }
        private List<int> quantity;

        public List<int> Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

       
        BL.Order order = new BL.Order();  
        List<BL.Product> allProducts;
		
        public SallingForm()
        {
                InitializeComponent();
                reload_Product();
                SellProduct = new List<BL.Product>();
                this.quantity = new List<int>();
                pricOfproduct=new List<float>();
           
        }
        private void reload_Product()
        {      // this function run during laod form and manager update product
            BL.Product pro = new BL.Product();
            allProducts = new List<BL.Product>();
            allProducts = pro.selectAllProduct();
            foreach (BL.Product product in allProducts)
            {
                comboBox1.Items.Add(product.Product_Name1);
                
                
            }
        }
			//add product to list  
        private void addProductSell(string ProductName) {
            foreach (BL.Product product in allProducts) {
                if (product.Product_Name1.Equals(ProductName)) {
                    quantity.Add(Convert.ToInt32(textBox3.Text));
                    sellProduct.Add(product);
                    pricOfproduct.Add(float.Parse(textBox4.Text));
                }
            
            }
        }

        private void button2_Click(object sender, EventArgs e) // close this form show Bill form
        {
            
            this.Hide();
            new Bill(totalPrice,pricOfproduct,this.quantity).ShowDialog();
            this.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.WorkerForm().ShowDialog();
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (BL.Product product in allProducts)    // load all product to combobox
            {
                if (comboBox1.Text == product.Product_Name1)
                {
                 textBox1.Text = product.Avalible_Quantity1.ToString();
                 textBox2.Text = product.Sales_Price1.ToString();       
                 textBox3.Text = "";
                 textBox4.Text = "";
                }
            }
        }
		
		// check product user select it that find in list 
        private bool checkSelelctProduct(string productName) {
            bool flag = true;
            foreach(BL.Product product in sellProduct){
                if (product.Product_Name1.Equals(productName)) {   
                    flag = false;
                }
                }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BL.Order ord = new BL.Order();
            if (!(textBox3.Text.Equals("") || comboBox1.Text.Equals(""))) {
                if (checkSelelctProduct(comboBox1.Text))
                {
                    if (ord.checkavailabilty(allProducts, Convert.ToInt32(textBox3.Text), comboBox1.Text)) 
                    {
                        addProductSell(comboBox1.Text);
                        totalPrice += float.Parse(textBox4.Text);
                        textBox3.Text = "";
                    }
                    else MessageBox.Show("الكمية المطلوبة اكبر من المتاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else {

                    MessageBox.Show("تم شراء المنتج بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("يجب تدخيل كمية الشراء من الصنف ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            //label7.Text = sellProduct.Count.ToString();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)   // 8 meaning backspace
			{
                e.Handled = true;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))  
            {
                textBox4.Text = "";
            }
            else
            {
                try
                {
                    textBox4.Text = (float.Parse(textBox2.Text) * Convert.ToInt32(textBox3.Text)).ToString();
                }
                catch (Exception) { }
            }
        }
    }
}
