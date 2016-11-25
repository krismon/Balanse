using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balanse
{
    public partial class VEE_Subform : Form
    {
        int erowid = 0;
        private string encoder = "";

        public VEE_Subform(DataGridViewRow Info, string encoder)
        {
            InitializeComponent();
            this.encoder = encoder;
            VEE_L_User.Text = encoder;
            erowid = Convert.ToInt32(Info.Cells[1].Value.ToString());
            VEE_TB_Row.Text = erowid.ToString();
            this.VEE_But_Date.Value = DateTime.ParseExact(Info.Cells[0].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

            BalanseConn VEEConn = new BalanseConn();
            DataTable branch = VEEConn.SelectQuery("SELECT BRANCH_NAME FROM BRANCH");
            Dictionary<String, String> test = new Dictionary<string, string>();
            int i = 0;
            foreach (DataRow row in branch.Rows)
            {
                test.Add(i.ToString(), row[0].ToString());
                i++;
            }
            VEE_DD_Branch.DataSource = new BindingSource(test, null);

            VEE_DD_Branch.DisplayMember = "Value";
            VEE_DD_Branch.ValueMember = "Key";
            //PopulatePODGV();
            PopulateExpensesTab();
        }
        public Boolean IsEmpty(string item)
        {
            if (item.Length <= 0)
            {
                return true;
            }
            else return false;
        }

        //Expenses and Deposits Tab Update Total Expenses
        private void UpdateExpensesTotals()
        {
            Double PCF1 = IsEmpty(VEE_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF1.Text);
            Double PCF2 = IsEmpty(VEE_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF2.Text);
            Double PCF3 = IsEmpty(VEE_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF3.Text);
            Double PCF4 = IsEmpty(VEE_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            VEE_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(VEE_TB_WTX.Text) ? 0.00 : Convert.ToDouble(VEE_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(VEE_TB_Ref.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(VEE_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(VEE_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(VEE_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(VEE_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth4.Text);
            Double OTHERS = OTHERS1 + OTHERS2 + OTHERS3 + OTHERS4;
            VEE_TB_OthTotal.Text = Convert.ToString(OTHERS);

            //Total Exp
            Double TOTAL_EXPENSES = PCF + WTX + REFUND + OTHERS;
            VEE_TB_TotalExp.Text = Convert.ToString(TOTAL_EXPENSES);
        }

        public void PopulateExpensesTab()
        {
            BalanseConn VEEConn = new BalanseConn();
            DataTable VEESubform = VEEConn.SelectQuery(@"SELECT PCF_1, PCF_2, PCF_3, PCF_4, WTX, REFUND,  OTH_1, OTH_2, OTH_3, OTH_4,
                                                        COMMENTS, BRANCH FROM EXPENSES WHERE ROWID='" + erowid + "'");

            foreach (DataRow row in VEESubform.Rows)
            {
                VEE_TB_PCF1.Text = row[0].ToString();
                VEE_TB_PCF2.Text = row[1].ToString();
                VEE_TB_PCF3.Text = row[2].ToString();
                VEE_TB_PCF4.Text = row[3].ToString();
                VEE_TB_WTX.Text = row[4].ToString();
                VEE_TB_Ref.Text = row[5].ToString();
                VEE_TB_Oth1.Text = row[6].ToString();
                VEE_TB_Oth2.Text = row[7].ToString();
                VEE_TB_Oth3.Text = row[8].ToString();
                VEE_TB_Oth4.Text = row[9].ToString();
                VEE_RTB_Comm.Text = row[10].ToString();
                VEE_DD_Branch.Text = row[11].ToString();
                UpdateExpensesTotals();
            }
        }
        private int AddExpenses()
        {
            BalanseConn InsertExpTransactionConn = new BalanseConn();
            DateTime DATE = VEE_But_Date.Value.Date;
            String BRANCH = VEE_DD_Branch.Text;
            Double PCF1 = IsEmpty(VEE_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF1.Text);
            Double PCF2 = IsEmpty(VEE_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF2.Text);
            Double PCF3 = IsEmpty(VEE_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF3.Text);
            Double PCF4 = IsEmpty(VEE_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(VEE_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            VEE_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(VEE_TB_WTX.Text) ? 0.00 : Convert.ToDouble(VEE_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(VEE_TB_Ref.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(VEE_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(VEE_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(VEE_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(VEE_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(VEE_TB_Oth4.Text);
            Double OTHERS = IsEmpty(VEE_TB_OthTotal.Text) ? 0.00 : Convert.ToDouble(VEE_TB_OthTotal.Text);


            //Total Exp
            Double TOTAL_EXPENSES = IsEmpty(VEE_TB_TotalExp.Text) ? 0.00 : Convert.ToDouble(VEE_TB_TotalExp.Text);
            String EXP_COMMENTS = VEE_RTB_Comm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = VEE_L_User.Text;
            int ExpenseID = InsertExpTransactionConn.InsertExpenses(DATE, BRANCH, PCF, PCF1, PCF2, PCF3, PCF4, WTX, REFUND, OTHERS, OTHERS1, OTHERS2, OTHERS3, OTHERS4, TOTAL_EXPENSES, EXP_COMMENTS, REC_DT, ENCODED_BY);
            return ExpenseID;

        }
        private void VEE_But_Add_Click(object sender, EventArgs e)
        {
            BalanseConn VEECon = new BalanseConn();
            DialogResult result1;
            result1 = MessageBox.Show("This will update the expenses record. Do you want to continue?", "Update Expenses Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                VEECon.DropExpenses(erowid);
                AddExpenses();
            }
            MessageBox.Show("Record updated.");
            this.Close();
        }

        private void VEE_TB_Row_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_PCF1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_PCF3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_PCF2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_PCF4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_WTX_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Ref_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Oth1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Oth2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Oth3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Oth4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void VEE_TB_Row_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_PCF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_PCF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_PCF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_PCF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_WTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_Ref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_Oth1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_Oth2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_Oth3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_TB_Oth4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("One decimal point only");
            }
        }

        private void VEE_But_Delete_Click(object sender, EventArgs e)
        {
            BalanseConn VESConn = new BalanseConn();

            DialogResult result1;

            result1 = MessageBox.Show("This will delete the expenses record. Do you want to continue?", "Delete Expenses Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                VESConn.DropSales(erowid);
            }
                MessageBox.Show("Record deleted");
                this.Close();

            if (result1 == DialogResult.No)
            {
                Close();
            }
        }

        private void VEE_But_Reset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
