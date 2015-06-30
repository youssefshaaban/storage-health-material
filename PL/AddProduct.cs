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
    public partial class AddProduct : notification
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL.Worker worker = new BL.Worker();
            if (!(txtname.Text.Equals("") || txtOriginalPrice.Text.Equals("") || txtsellPrice.Text.Equals("") || txtCriticalQuantity.Text.Equals("") || txtAvilableQuantiity.Text.Equals(""))) { 
            
                BL.Product product=new BL.Product(txtname.Text,Convert.ToInt32(txtAvilableQuantiity.Text),Convert.ToInt32(txtCriticalQuantity.Text),float.Parse(txtOriginalPrice.Text),float.Parse(txtsellPrice.Text));
                if(worker.AddProduct(product)){     // check product is added if added show user message box Done
                MessageBox.Show("تم اضافة المنج بنجاح");
                txtAvilableQuantiity.Text = "";
                txtCriticalQuantity.Text = "";
                txtname.Text = "";
                txtOriginalPrice.Text = "";
                txtsellPrice.Text = "";
                }
                else{                          // if prduct do not adde show user message Wrong for adding product
                MessageBox.Show("خطا فى الاضافه");
                }
            }
            else { MessageBox.Show("املا جميع الفرغات"); }   //show message box to make user write all fields
        }

        private void button2_Click(object sender, EventArgs e)    // to move another form (worker form)
        {
            this.Hide();
            new PL.WorkerForm().ShowDialog();                        
            this.Close();
           
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)  // to prevent user to enter characters
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            { //8 meaning backspace
                e.Handled = true;
            }
        }
// to prevent user to enter characters
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            { //8 meaning backspace
                e.Handled = true;
            }
        }

		// to prevent user to enter characters
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c)&& c!=8 && c!=46)
            { //8 meaning backspace
                e.Handled = true;
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c)&& c!=8 && c!=46)
            { //8 meaning backspace
                e.Handled = true;
            }
            
        }
//this event fire when user don't focus on it 
        private void txtCriticalQuantity_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtCriticalQuantity.Text) > 0) // check critical quantity more than 0
                {
                    if (Convert.ToInt32(txtCriticalQuantity.Text) > Convert.ToInt32(txtAvilableQuantiity.Text))// if ciritical quantity is more than Available quantity show user message to enter quantity less than Available quantity
                    {
                        MessageBox.Show("يجب ان تكون الكميه الحرجه اقل من الكميه المتاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCriticalQuantity.Focus();     /// focus on text that make cursor don't move on this text
                        txtCriticalQuantity.SelectionStart = 0;
                        txtCriticalQuantity.SelectionLength = txtCriticalQuantity.TextLength;
                    }
                }
                else {
                    MessageBox.Show("يجب ان تكون الكميه الحرجه لا تساوى صفر او قل من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCriticalQuantity.Focus();
                    txtCriticalQuantity.SelectionStart = 0;
                    txtCriticalQuantity.SelectionLength = txtCriticalQuantity.TextLength;
                
                }
            }
            catch(Exception) { }
        }
//this event fire when user don't focus on it 
        private void txtAvilableQuantiity_Validated(object sender, EventArgs e)
        {
            try
            {
                
                if (Convert.ToInt32(txtAvilableQuantiity.Text)>0)    // check quantity more than 0 
                {
                if (Convert.ToInt32(txtCriticalQuantity.Text) > Convert.ToInt32(txtAvilableQuantiity.Text))
                {
                    MessageBox.Show("يجب ان تكون الكميه الحرجه اقل من الكميه المتاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCriticalQuantity.Focus();
                    txtCriticalQuantity.SelectionStart = 0;
                    txtCriticalQuantity.SelectionLength = txtCriticalQuantity.TextLength;
                }
                }
                else{
                    MessageBox.Show("يجب ان تكون الكميه المتاحه اكبر من الصفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAvilableQuantiity.Focus();
                    txtAvilableQuantiity.SelectionStart = 0;
                    txtAvilableQuantiity.SelectionLength = txtAvilableQuantiity.TextLength;
                
                }
            }
            catch (Exception) { }
        }
//this event fire when user don't focus on it 
        private void txtname_Validated(object sender, EventArgs e)   
        {
            BL.Product product = new BL.Product();
            if (product.Check_Product_Name(txtname.Text)) { MessageBox.Show("هذا المنتج موجود بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtname.Focus();
            txtname.SelectionStart = 0;
            txtname.SelectionLength = txtname.TextLength;
            }
        }
//this event fire when user don't focus on it 
        private void txtOriginalPrice_Validated(object sender, EventArgs e)
        {
            try{
                
                if (float.Parse(txtOriginalPrice.Text) > 0) // check price more than 0
                {

                    if (float.Parse(txtOriginalPrice.Text) > float.Parse(txtsellPrice.Text)) // if  original price is more than sellprice show message box original price is less than ssll price
                {
                    
                        MessageBox.Show("يجب ان يكو السعر الاصلى اقل من سعر البيع او يساويه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtOriginalPrice.Focus();
                        txtOriginalPrice.SelectionStart = 0;
                        txtOriginalPrice.SelectionLength = txtOriginalPrice.TextLength;
                    
                }
            
            } else {

                MessageBox.Show("يجب ان يكون السعر الاصلى اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);   /// show message 
                txtOriginalPrice.Focus();
                txtOriginalPrice.SelectionStart = 0;
                txtOriginalPrice.SelectionLength = txtOriginalPrice.TextLength;
            }
            }
            catch(Exception){}
        }
//this event fire when user don't focus on it 
        private void txtsellPrice_Validated(object sender, EventArgs e)
        {
            try
            {
                if (float.Parse(txtsellPrice.Text) > 0)
                {
                    if (float.Parse(txtOriginalPrice.Text) > float.Parse(txtsellPrice.Text))
                    {
                        MessageBox.Show("يجب ان يكو السعر الاصلى اقل من سعر البيع او يساويه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtOriginalPrice.Focus();
                        txtOriginalPrice.SelectionStart = 0;
                        txtOriginalPrice.SelectionLength = txtOriginalPrice.TextLength;
                    }

                }
                else
                {

                    MessageBox.Show("يجب ان يكون سعر البيع اكبر من صفر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsellPrice.Focus();
                    txtsellPrice.SelectionStart = 0;
                    txtsellPrice.SelectionLength = txtsellPrice.TextLength;
                }
            }
            catch (Exception) { }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e) // to prevent special characters
        {
            char c = e.KeyChar;
            if (c == '@' || c == '!' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '(' || c == ')' || c == '_' || c == '-' || c == '=' || c == '+' || c == '.' || c == ',' || c == '/' || c == ';' || c == ':' || c == '?' || c == '؟' || c == '[' || c == ']' || c == '{' || c == '}' || c == '<' || c == '>' || c == '|' || c == '"' || c == '~' || c == '’' || c == 'ّ' || c == '؛')
            {
                e.Handled = true;
            }
        }

        

        
        
       }
}
