using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace project_soft.BL
{
public  class Employee
    {

        DAL.EmployeeDAC Emp;
        private static int id;

        public static int Id
        {
            get { return id; }
            set { id = value; }
        }
        private static string User_Name;

        public static string User_Name1
        {
            get { return User_Name; }
            set { User_Name = value; }
        }
        private string User_Password;

        public string User_Password1
        {
            get { return User_Password; }
            set { User_Password = value; }
        }
        private int User_Type;

        public int User_Type1
        {
            get { return User_Type; }
            set { User_Type = value; }
        }
        private string User_Address;

        public string User_Address1
        {
            get { return User_Address; }
            set { User_Address = value; }
        }
        private double User_Phone;

        public double User_Phone1
        {
            get { return User_Phone; }
            set { User_Phone = value; }
        }
        private double User_Ssn;

        public double User_Ssn1
        {
            get { return User_Ssn; }
            set { User_Ssn = value; }
        }
        private double User_Salary;

        public double User_Salary1
        {
            get { return User_Salary; }
            set { User_Salary = value; }
        }
        public Employee() { }

        public bool logIn(string User_Name, string User_password, ref Employee emp)
        {
            try
            {
                Emp = new DAL.EmployeeDAC();
                if (emp == null || User_Name == null || User_password == null || User_Name.Equals("") || User_password.Equals(""))
                {

                    return false;
                }
                else
                {
                    if (Emp.logIn(User_Name, User_password, ref emp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception) {
                return false;
            }
            }
            
        }

    }

