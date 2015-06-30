

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
    public partial class DeletEmployee : notification
    {
        BL.Manager manager = new BL.Manager();
        public DeletEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (manager.Check_Name_Manager(textBox1.Text))  // to check name is manger show message can't delet manager name
            {
                if (manager.Delet_Worker(textBox1.Text)) // if delet worker show message box done
                {
                    MessageBox.Show("تم مسح العميل");
                }
                else
                {
                    MessageBox.Show("لا يوجد هذا العميل");
                }
            }
            else {
                MessageBox.Show("لا يسمح بأزالة هذا الاسم ","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

        }

		// close form and show another form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.ManagerForm().ShowDialog();
            this.Close();
        }
    }
}
