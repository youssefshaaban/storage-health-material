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
    public partial class Transcript : Form
    {
        string[] fromDate = new string[4];
        string[] toDate = new string[4];
        DataTable dt = new DataTable();
        public Transcript()
        {
            InitializeComponent();
        }

        private void Transcript_Load(object sender, EventArgs e)
        {
            //Years
            for (int i = 2012; i <= 2016; i++)
            {
                comYear.Items.Add(i);
                combYear.Items.Add(i);
            }
            //Days
            for (int i = 1; i <= 31; i++)
            {
                combday.Items.Add(i);
                combD.Items.Add(i);
            }
            //Months
            for (int i = 1; i <= 12; i++)
            {
                combmon.Items.Add(i);
                combMonth.Items.Add(i);
            }
         
     
        }

        private void combYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            toDate[0]=combYear.Text;
        }

        private void comYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromDate[0] = comYear.Text;
        }

        private void combMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromDate[1]=combMonth.Text;
        }

        private void combmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            toDate[1]=combmon.Text;
        }

        private void combday_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromDate[2]=combday.Text;
        }

        private void combD_SelectedIndexChanged(object sender, EventArgs e)
        {
            toDate[2] = combD.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(combYear.Text.Equals("") || comYear.Text.Equals("") || combmon.Text.Equals("") || combMonth.Text.Equals("") || combday.Text.Equals("") || combD.Text.Equals("")){
                MessageBox.Show("يجب تدخيل اليوم والشهر والسنه ");
            }
            else{
            string fromdate2 = fromDate[0] + "/" + fromDate[1] + "/" + fromDate[2];
            string todate2 = toDate[0] + "/" + toDate[1] + "/" + toDate[2];
            
            BL.Manager manager = new BL.Manager();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            if (manager.ShowTranscript(fromdate2, todate2, ref dt))
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Add("Product_Name", "اسم المنتج");
                dataGridView1.Columns.Add("quantity", " الكمية المباعة");
                dataGridView1.Columns.Add("total", "السعر الكلي");
                int total = 0;
                bool check=true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (check)
                        total += Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    if (i < dt.Rows.Count - 1 && dt.Rows[i]["Product_Name"].Equals(dt.Rows[i + 1]["Product_Name"]))
                    {
                        total += Convert.ToInt32(dt.Rows[i + 1]["Quantity"]);
                        check = false;
                        continue;
                    }
                    dataGridView1.Rows.Add(dt.Rows[i]["Product_Name"], total.ToString(),(Convert.ToInt32( dt.Rows[i]["Sales_Price"])*total).ToString());
                    total = 0;
                    check = true;
                }



            }          
            }
            
            
        }

        private void sorDefaultView(){
            
            dataGridView1.Columns.Add("price", "سعر الوحده");
            dataGridView1.Columns.Add("Availible_Quantity", " الكميه المتبقية ");
            dataGridView1.Columns.Add("Total", "الاجمالي من المنتج");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PL.ManagerForm().ShowDialog();
            this.Close();
        }

    }
}
