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

namespace project_soft.PL
{
    public partial class UpdateAndViewProduct : notification
    {
        List<BL.Product> allProducts = new List<BL.Product>();
        BL.Manager manager = new BL.Manager();
        public UpdateAndViewProduct()
        {
            InitializeComponent();

            if (radioButton2.Checked) {
                txtAvailableQuan.Enabled = false;
                txtorigPric.Enabled = false;
                txtsellprice.Enabled = false;
                button1.Enabled = false;
                txtCriticalQuan.Enabled = false;
                button3.Enabled = false;
            }
            reloadProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.ManagerForm().ShowDialog();
            this.Close();
            
        }
        
		// update product data
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!(txtAvailableQuan.Text.Equals("") || txtCriticalQuan.Text.Equals("") || txtorigPric.Text.Equals("") || txtsellprice.Text.Equals("")|| comboBox1.Text.Equals("")))
            {
                BL.Product pro=new BL.Product();
                BL.Product product = new BL.Product(comboBox1.Text, Convert.ToInt32(txtAvailableQuan.Text), Convert.ToInt32(txtCriticalQuan.Text), float.Parse(txtorigPric.Text), float.Parse(txtsellprice.Text));
                if (!product.check_udate_product(product, ref pro))   // check_udate_product return true 
                {
                    MessageBox.Show("البيانات لم تتغير لكى يتم تعديلها");
                }
                else
                {

                    if (manager.Update_Product(product))
                    {
                        MessageBox.Show("تم تعديل البيانات ");
                    }

                }
            }
            else {
                MessageBox.Show("املا جميع الفرغات");
            
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                txtAvailableQuan.Enabled = true;
                txtCriticalQuan.Enabled = true;
                txtorigPric.Enabled = true;
                txtsellprice.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtAvailableQuan.Enabled = false;
                txtorigPric.Enabled = false;
                txtsellprice.Enabled = false;
                button1.Enabled = false;
                txtCriticalQuan.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (BL.Product product in allProducts) {
                if (comboBox1.Text == product.Product_Name1) {
                    txtAvailableQuan.Text = product.Avalible_Quantity1.ToString();
                    txtCriticalQuan.Text = product.Critcal_Quantity1.ToString();
                    txtorigPric.Text = product.Oraginal_Price1.ToString();
                    txtsellprice.Text = product.Sales_Price1.ToString();
                }
            }
        }

        private void txtAvailableQuan_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtAvailableQuan.Text) > 0)
                {
                    if (Convert.ToInt32(txtCriticalQuan.Text) > Convert.ToInt32(txtAvailableQuan.Text))
                    {
                        MessageBox.Show("يجب ان تكون الكميه الحرجه اقل من الكميه المتاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCriticalQuan.Focus();
                        txtCriticalQuan.SelectionStart = 0;
                        txtCriticalQuan.SelectionLength = txtCriticalQuan.TextLength;
                    }
                }
                else {
                    MessageBox.Show("يجب ان تكون الكميه المتاحه اكبر من الصفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAvailableQuan.Focus();
                    txtAvailableQuan.SelectionStart = 0;
                    txtAvailableQuan.SelectionLength = txtAvailableQuan.TextLength;
                }
            }
            catch (Exception) { }
        }

        private void txtCriticalQuan_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCriticalQuan.Text) > 0)
                {
                    if (Convert.ToInt32(txtCriticalQuan.Text) > Convert.ToInt32(txtAvailableQuan.Text))
                    {
                        MessageBox.Show("يجب ان تكون الكميه الحرجه اقل من الكميه المتاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCriticalQuan.Focus();
                        txtCriticalQuan.SelectionStart = 0;
                        txtCriticalQuan.SelectionLength = txtCriticalQuan.TextLength;
                    }
                }
                else {

                    MessageBox.Show("يجب ان تكون الكميه الحرجه اكبر من الصفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCriticalQuan.Focus();
                    txtCriticalQuan.SelectionStart = 0;
                    txtCriticalQuan.SelectionLength = txtCriticalQuan.TextLength;
                }
            }
            catch (Exception) { }
        }

        private void txtAvailableQuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8  )
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void txtCriticalQuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8 )
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void txtorigPric_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8 &&c!=46 )
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void txtsellprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8 &&c !=46 )
            { //8 meaning backspace
                e.Handled = true;
            }
        }
        private void reloadProduct() {      // this function run during laod form and manager update product
            BL.Product pro = new BL.Product();
            allProducts = pro.selectAllProduct();
            foreach (BL.Product product in allProducts)
            {
                comboBox1.Items.Add(product.Product_Name1);
            }
        }
        private void checkAfterUpdate() { 
               
        }

        private void txtorigPric_Validated(object sender, EventArgs e)
        {
            try {
                if (float.Parse(txtorigPric.Text) > 0) {
                    if (float.Parse(txtorigPric.Text) > float.Parse(txtsellprice.Text)) {
                        MessageBox.Show("يجب ان يكو السعر الاصلى اقل من سعر البيع او يساويه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtorigPric.Focus();
                        txtorigPric.SelectionStart = 0;
                        txtorigPric.SelectionLength = txtorigPric.TextLength;

                    }

                }
                else
                {

                    MessageBox.Show("يجب ان يكون السعر الاصلى اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtorigPric.Focus();
                    txtorigPric.SelectionStart = 0;
                    txtorigPric.SelectionLength = txtorigPric.TextLength;
                }
            
            }
            catch (Exception) { }

        }

        private void txtsellprice_Validated(object sender, EventArgs e)
        {
            try { 
            if (float.Parse(txtsellprice.Text) > 0) { 
                if (float.Parse(txtorigPric.Text) > float.Parse(txtsellprice.Text)) {
                        MessageBox.Show("يجب ان يكو السعر الاصلى اقل من سعر البيع او يساويه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtorigPric.Focus();
                        txtorigPric.SelectionStart = 0;
                        txtorigPric.SelectionLength = txtorigPric.TextLength;

                    }

                }
                else
                {

                    MessageBox.Show("يجب ان يكون السعر الاصلى اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsellprice.Focus();
                    txtsellprice.SelectionStart = 0;
                    txtsellprice.SelectionLength = txtsellprice.TextLength;
                }
            }
            catch (Exception) { }
                
            }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                txtAvailableQuan.Enabled = false;
                txtCriticalQuan.Enabled = false;
                txtorigPric.Enabled = false;
                txtsellprice.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                
                BL.Manager manager = new BL.Manager();

                if (MessageBox.Show("هل تريد حذف الصنف المحدد؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BL.Product pro = new BL.Product(comboBox1.Text, Convert.ToInt32(txtAvailableQuan.Text), Convert.ToInt32(txtCriticalQuan.Text), float.Parse(txtorigPric.Text), float.Parse(txtsellprice.Text));
                    if (manager.Delet_Product(pro))
                    {
                        comboBox1.SelectedItem = null;
                        comboBox1.Items.Clear();
                        reloadProduct();
                        txtAvailableQuan.Text = "";
                        txtCriticalQuan.Text = "";
                        txtorigPric.Text = "";
                        txtsellprice.Text = "";
                    }

                    else
                    {
                        MessageBox.Show("المنتج غير موجود ");
                    }
                }
            }
        }
        }

        
    

