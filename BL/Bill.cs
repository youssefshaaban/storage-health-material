using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_soft.BL
{
   public class Bill
    {
        private  int Sales_Id;

        public  int Sales_Id1
        {
            get { return Sales_Id; }
            set { Sales_Id = value; }
        }
        private int User_Id;

        public int User_Id1
        {
            get { return User_Id; }
            set { User_Id = value; }
        }
        private DateTime Date;

        public DateTime Date1
        {
            get { return Date; }
            set { Date = value; }
        }
        DAL.BillDAC bill;
        public Bill() {
            bill = new DAL.BillDAC();
        }
        public Bill(int user_Id, DateTime date) {
            bill = new DAL.BillDAC();
            this.User_Id1 = user_Id;
            this.Date1 = date;
        }
        public bool Insert_Bill(Bill b) {
            if ( b==null|| b.User_Id1 != Employee.Id || b.User_Id1==0  ||b.Date1.DayOfYear==1 )
            {
                return false;
            }
            else
            {
                return bill.Insert_Bill(b);
            }
        }

        public bool Delete_Bill(int User_Id)
        {
            if (User_Id <= 0)
                return false;
            else
                return bill.Delete_Bill(User_Id);
        }


        public bool Delete_Bill(DateTime DateOfBill)
        {
            if (DateOfBill == null || DateOfBill.ToString().Equals(""))
                return false;
            else
                return bill.Delete_Bill(DateOfBill);
        }
        public bool return_Bill_Id(Bill bill1) {
            if (bill1==null  || bill1.User_Id1<=0)
            {
                return false;
            }
            else
            {
                return bill.return_Bill_Id(bill1);
            }
        }

    }
}
