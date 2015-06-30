

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
using project_soft.BL;
namespace project_soft.PL
{
    public partial class notification : Form
    {
        public ToolStripMenuItem b = new ToolStripMenuItem();
        public notification()
        {
            InitializeComponent();
            Product product = new Product();
            List<Product> product_list = new List<Product>();
            product_list = product.selectAllProduct();
            foreach (Product p in product_list)  
            {
              // show notification if citical >= available
                if (p.Critcal_Quantity1 >= p.Avalible_Quantity1)
                {
                    notficationToolStripMenuItem.BackColor = Color.Red;
                    ToolStripMenuItem b1 = new ToolStripMenuItem();
                    b1.Name = "tttytfytToolStripMenuItem";
                    b1.Size = new System.Drawing.Size(152, 22);
                    b1.Text = p.Product_Name1 + "  " + "انت تحتاج"+(p.Critcal_Quantity1-p.Avalible_Quantity1).ToString();


                    this.notficationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
             b1});
                }
              
            }

        }
    }
}
