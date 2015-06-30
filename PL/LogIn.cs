
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
    public partial class LogIn : Form
    {
        BL.Employee emp;
        public LogIn()
        {
            InitializeComponent();
           emp = new BL.Employee();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (emp.logIn(textBox1.Text, textBox2.Text, ref emp))   // check account if user type is 1 show form for manager
                {

                    if (emp.User_Type1 == 1)
                    {
                        this.Hide();
                        new PL.ManagerForm().ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        new PL.WorkerForm().ShowDialog();      // show form for worker
                        this.Close();
                    }
                }
                else     // wrong username or password
                {

                    MessageBox.Show("يوجد خطأ فى اسم المستخدم او كلمة المرور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
