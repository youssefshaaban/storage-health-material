

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
    public partial class ManagerForm : notification
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

		// if click this button show form delet employee
		private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.DeletEmployee().ShowDialog();
            this.Close();
        }
		// if click this button show form add worker
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.AddWorker().ShowDialog();
            this.Close();
        }
		// if click this button show form UpdateAndViewProduct
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.UpdateAndViewProduct().ShowDialog();
            this.Close();
        }

		// if click this button show form login
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.LogIn().ShowDialog();
            this.Close();
        }

		// if click this button show form show transcript
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.Transcript().ShowDialog();
            this.Close();
        }



    }
}
