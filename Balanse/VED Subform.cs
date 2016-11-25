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
    public partial class VED_Subform : Form
    {

        int drowid = 0;
        private string encoder = "";
        public VED_Subform(DataGridViewRow Info, String encoder)
        {
            InitializeComponent();
            this.encoder = encoder;
            VED_L_User.Text = encoder;
            drowid = Convert.ToInt32(Info.Cells[1].Value.ToString());
            VED_TB_Row.Text = drowid.ToString();
            this.VED_But_Date.Value = DateTime.ParseExact(Info.Cells[0].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

            BalanseConn VEDConn = new BalanseConn();
            DataTable branch = VEDConn.SelectQuery("SELECT BRANCH_NAME FROM BRANCH");
            Dictionary<String, String> test = new Dictionary<string, string>();
            int i = 0;
            foreach (DataRow row in branch.Rows)
            {
                test.Add(i.ToString(), row[0].ToString());
                i++;
            }
            VED_DD_Branch.DataSource = new BindingSource(test, null);

            VED_DD_Branch.DisplayMember = "Value";
            VED_DD_Branch.ValueMember = "Key";

            PopulateDepositsTab();
        }
        public Boolean IsEmpty(string item)
        {
            if (item.Length <= 0)
            {
                return true;
            }
            else return false;
        }
        private void UpdateDepositsTotals()
        {
            //CASH
            Double CASHDEP1 = IsEmpty(VED_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(VED_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(VED_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(VED_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash4.Text);
            Double CASHDEP = CASHDEP1 + CASHDEP2 + CASHDEP3 + CASHDEP4;
            VED_TB_CashTotal.Text = Convert.ToString(CASHDEP);

            //ENC CHECK
            Double ENC1 = IsEmpty(VED_TB_Enc1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc1.Text);
            Double ENC2 = IsEmpty(VED_TB_Enc2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc2.Text);
            Double ENC3 = IsEmpty(VED_TB_Enc3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc3.Text);
            Double ENC4 = IsEmpty(VED_TB_Enc4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc4.Text);
            Double ENC = ENC1 + ENC2 + ENC3 + ENC4;
            VED_TB_EncTotal.Text = Convert.ToString(ENC);

            //CHECK
            Double CHECKDEP1 = IsEmpty(VED_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(VED_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(VED_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(VED_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch4.Text);
            Double CHECKDEP = CHECKDEP1 + CHECKDEP2 + CHECKDEP3 + CHECKDEP4;
            VED_TB_ChTotal.Text = Convert.ToString(CHECKDEP);

            //Total Dep
            Double TOTAL_DEP = CASHDEP + ENC + CHECKDEP;

            VED_TB_TotalDep.Text = Convert.ToString(TOTAL_DEP);
        }
        public void PopulateDepositsTab()
        {
            BalanseConn VEDConn = new BalanseConn();
            DataTable VEDSubform = VEDConn.SelectQuery(@"SELECT CASH1, CASH2, CASH3, CASH4, ENC_CHECK1, ENC_CHECK2, ENC_CHECK3, ENC_CHECK4, CHECK1,CHECK2, CHECK3, CHECK4,
                                                        COMMENTS, BRANCH FROM DEPOSITS WHERE ROWID='" + drowid + "'");

            foreach (DataRow row in VEDSubform.Rows)
            {
                VED_TB_Cash1.Text = row[0].ToString();
                VED_TB_Cash2.Text = row[1].ToString();
                VED_TB_Cash3.Text = row[2].ToString();
                VED_TB_Cash4.Text = row[3].ToString();
                VED_TB_Enc1.Text = row[4].ToString();
                VED_TB_Enc2.Text = row[5].ToString();
                VED_TB_Enc3.Text = row[6].ToString();
                VED_TB_Enc4.Text = row[7].ToString();
                VED_TB_Ch1.Text = row[8].ToString();
                VED_TB_Ch2.Text = row[9].ToString();
                VED_TB_Ch3.Text = row[10].ToString();
                VED_TB_Ch4.Text = row[11].ToString();
                VED_RTB_Comm.Text = row[12].ToString();
                VED_DD_Branch.Text = row[13].ToString();
                UpdateDepositsTotals();
            }
        }

        private void VED_TB_Cash1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Cash2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Cash3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Cash4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Enc1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Enc3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Enc2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Enc4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Ch1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Ch2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Ch3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Ch4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositsTotals();
        }

        private void VED_TB_Cash1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Cash2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Cash3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Cash4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Enc1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Enc2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Enc3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Enc4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Ch1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Ch2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Ch3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VED_TB_Ch4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VEE_But_Add_Click(object sender, EventArgs e)
        {
            BalanseConn VEDConn = new BalanseConn();
            DialogResult result1;
            result1 = MessageBox.Show("This will update the deposits record. Do you want to continue?", "Update Deposits Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                VEDConn.DropDeposits(drowid);
                AddDeposit();
            }
            MessageBox.Show("Record updated.");
            this.Close();
        }
        private int AddDeposit()
        {
            BalanseConn InsertDepTransactionConn = new BalanseConn();


            DateTime DATE = VED_But_Date.Value.Date;
            String BRANCH = VED_DD_Branch.Text;
            //CASH
            Double CASHDEP1 = IsEmpty(VED_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(VED_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(VED_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(VED_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Cash4.Text);
            Double CASHDEP = IsEmpty(VED_TB_CashTotal.Text) ? 0.00 : Convert.ToDouble(VED_TB_CashTotal.Text);
            //ENC CHECK
            Double ENC1 = IsEmpty(VED_TB_Enc1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc1.Text);
            Double ENC2 = IsEmpty(VED_TB_Enc2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc2.Text);
            Double ENC3 = IsEmpty(VED_TB_Enc3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc3.Text);
            Double ENC4 = IsEmpty(VED_TB_Enc4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Enc4.Text);
            Double ENC = IsEmpty(VED_TB_EncTotal.Text) ? 0.00 : Convert.ToDouble(VED_TB_EncTotal.Text);
            //CHECK
            Double CHECKDEP1 = IsEmpty(VED_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(VED_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(VED_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(VED_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(VED_TB_Ch4.Text);
            Double CHECKDEP = IsEmpty(VED_TB_ChTotal.Text) ? 0.00 : Convert.ToDouble(VED_TB_ChTotal.Text);
            //Total Dep
            Double TOTAL_DEP = IsEmpty(VED_TB_TotalDep.Text) ? 0.00 : Convert.ToDouble(VED_TB_TotalDep.Text);
            String DEP_COMMENTS = VED_RTB_Comm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = VED_L_User.Text;

            int DepID = InsertDepTransactionConn.InsertDeposits(DATE, BRANCH, CASHDEP, CASHDEP1, CASHDEP2, CASHDEP3, CASHDEP4, ENC, ENC1, ENC2, ENC3, ENC4, CHECKDEP, CHECKDEP1, CHECKDEP2, CHECKDEP3, CHECKDEP4, TOTAL_DEP, DEP_COMMENTS, REC_DT, ENCODED_BY, 0);
            return DepID;
        }
    }
}
