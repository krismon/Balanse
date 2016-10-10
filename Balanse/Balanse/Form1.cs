using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balanse
{
    public partial class Form_LogIn : Form
    {
        public string username = "nikki";
        public string password = "1234";
        public Form_LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string name = L_TB_Name.Text;
            string pw = L_TB_Password.Text;
            if (name == username && pw==password)
            {
                Form_Balanse balanse = new Form_Balanse();
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
