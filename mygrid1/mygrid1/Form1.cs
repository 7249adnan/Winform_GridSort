using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mygrid1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=mydb1");
            con.Open();
            //user the table name as per yours
            MySqlDataAdapter adp = new MySqlDataAdapter("Select * from mytb;", con);

            DataTable dtb1 = new DataTable();

            adp.Fill(dtb1);

            dataGridView1.DataSource = dtb1;


            con.Close();

        }

        class Emp :IComparable<Emp>
        {
            private int empid;
            private String empname;
            private int empsalary;

            public Emp() { }
            public Emp(int empid , String empname , int empsalary) { 
            
                this.empid = empid;
                this.empname = empname;
                this.empsalary = empsalary;
            }


            public int EmpId { 
            
                get { return empid; }   
                set { empid = value; }

            }

            public int EmpSalary
            {

                get { return empsalary; }
                set { empsalary = value; }

            }

            public String EmpName
            {
                get { return empname; }
                set { empname = value; }
            }

            int i = 1;

            public int CompareTo(Emp e1)
            {
                if(i==0)
                return EmpSalary.CompareTo(e1.EmpSalary);

                else
                return EmpId.CompareTo(e1.EmpId);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        

            Emp []emp= new Emp[3];
            emp[0] = new Emp(31, "aaaa", 9000);
            emp[1] = new Emp(82, "bbbb", 8000);
            emp[2] = new Emp(13, "cccc", 3000);

            List<Emp> EmpList = new List<Emp>();
            EmpList.Add(emp[0]);
            EmpList.Add(emp[1]);
            EmpList.Add(emp[2]);
            EmpList.Sort();
            dataGridView2.DataSource = EmpList;

        }
    }
}
