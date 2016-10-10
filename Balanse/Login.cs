using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Balanse
{
    public partial class Form_LogIn : Form
    {  
        public Form_LogIn()
        {
            InitializeComponent();

           
        }


        private void label1_Click(object sender, EventArgs e)
        {
            string name = L_TB_Name.Text;
            string pw = L_TB_Password.Text;


            BalanseConn L_Conn = new BalanseConn();
            DataTable cred = L_Conn.SelectQuery("SELECT USER_NAME, PASSWORD FROM USERS WHERE USER_NAME=LOWER('" + name + "') AND PASSWORD=('" + pw + "')");
        
            
            if (cred.Rows.Count>0)
            {
                this.Hide();
                Form_Balanse balanse = new Form_Balanse(name);
                balanse.Show();

             
            }
            else MessageBox.Show("Incorrect User Name and/or Password");
          
        }
        
        private void L_But_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
