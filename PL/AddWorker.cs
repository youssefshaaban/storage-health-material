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
    public partial class AddWorker : notification
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL.Manager manager=new BL.Manager();
            
			// check all text not empty
            if(!(txtuser.Text.Equals("")|| txtpassword.Text.Equals("")||txttel.Text.Equals("")|| txtSSn.Text.Equals("")||txtprice.Text.Equals(""))){ 
			
             BL.Worker worker = new BL.Worker(txtuser.Text, txtpassword.Text, txtaddress.Text, Convert.ToDouble(txttel.Text), Convert.ToDouble(txtSSn.Text), Convert.ToDouble(txtprice.Text));
                
				///if worker is added show user done
				if (manager.Insert_Worker(worker)) {
                MessageBox.Show("تم تسجيل بيانات العامل بنجاح");
                txtuser.Text = "";
                txtpassword.Text = "";
                txttel.Text = "";
                txtSSn.Text = "";
                txtprice.Text = "";
                txtaddress.Text = "";
                }
                else MessageBox.Show("خطا فى التسجيل");
            }
            else{
            MessageBox.Show("املا جميع الفرغات");
            }

        }

		// close this form show another form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.ManagerForm().ShowDialog();
            this.Close();
        }

		// this action fire when user pressed any key from keyboard
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            //if (c == 46 && textBox1.Text.IndexOf('.') != -1) 
            //{
            //    e.Handled = true;
            //    return;
            //}
            if (!char.IsDigit(c) && c != 8 && c != 46) // 46 .  // don't allow any characters
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && c != 8)
            { //8 meaning backspace
                e.Handled = true;
            }
        }

        private void txtuser_Validated(object sender, EventArgs e)
        {
            BL.Manager manager = new BL.Manager();
            if (txtuser.Text ==""){}
            
            else
            {
                if (txtuser.Text.Length < 5)
                {
                    MessageBox.Show("يجب ان يكون اسم المستخدم اكبر من 5", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtuser.Focus();
                    txtuser.SelectionStart = 0;
                    txtuser.SelectionLength = txtuser.TextLength;
            
                }
                else
                {
                    if (!manager.Vlidate_User_Name(txtuser.Text))
                    {
                        MessageBox.Show("اسم المستخدم موجود يجب تغير الاسم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtuser.Focus();
                        txtuser.SelectionStart = 0;
                        txtuser.SelectionLength = txtuser.TextLength;
                    }
                }
            }
        }
		//prevent special characters
        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsDigit(c) || c == '@' || c == '!' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '(' || c == ')' || c == '_' || c == '-' || c == '=' || c == '+' || c == '.' || c == ',' || c == '/' || c == ';' || c == ':' || c == '?' || c == '؟' || c == '[' || c == ']' || c == '{' || c == '}' || c == '<' || c == '>' || c == '|' || c == '"' || c == '~' || c == '’' || c == 'ّ' || c == '؛')
            {
                e.Handled = true;
            }
        }
		//// prevent special character
		
        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == '@' || c == '!' || c == '#' || c == '$' || c == '%' || c == '^' || c == '&' || c == '*' || c == '(' || c == ')' || c == '_' || c == '-' || c == '=' || c == '+' || c == '.' || c == ',' || c == '/' || c == ';' || c == ':' || c == '?' || c == '؟' || c == '[' || c == ']' || c == '{' || c == '}' || c == '<' || c == '>' || c == '|' || c == '"' || c == '~' || c == '’' || c == 'ّ' || c == '؛')
            {
                e.Handled = true;
            }
        }

       

       
       

       
    }
}
