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
    public partial class VES_Subform : Form
    {
        //private int po_id = 0;
        //private int inv_no = 0;
        int srowid = 0;
        private string encoder = "";
        //private decimal po_amount = 0;
        public VES_Subform(DataGridViewRow Info, String encoder)
        {

            InitializeComponent();
            this.encoder=encoder;
            VES_L_User.Text = encoder;
            srowid = Convert.ToInt32(Info.Cells[1].Value.ToString());
            VES_TB_RowiD.Text = srowid.ToString();
            this.VES_But_Date.Value= DateTime.ParseExact(Info.Cells[0].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            
            BalanseConn VESConn = new BalanseConn();
            DataTable branch = VESConn.SelectQuery("SELECT BRANCH_NAME FROM BRANCH");
            Dictionary<String, String> test = new Dictionary<string, string>();
            int i = 0;
            foreach (DataRow row in branch.Rows)
            {
                test.Add(i.ToString(), row[0].ToString());
                i++;
            }
            VES_DD_Branch.DataSource = new BindingSource(test, null);

            VES_DD_Branch.DisplayMember = "Value";
            VES_DD_Branch.ValueMember = "Key";
            PopulatePODGV();
            PopulateSalesTab();

        }
        //to check if textbox is empty
        public Boolean IsEmpty(string item)
        {
            if (item.Length <= 0)
            {
                return true;
            }
            else return false;
        }

        //Sales Tab Update Running Total
        public void UpdateSalesTotals()
        {
            //cash
            Double CASH = IsEmpty(VES_TB_Cash.Text) ? 0.00 : Convert.ToDouble(VES_TB_Cash.Text);
            //credit card
            Double CREDIT_CARD1 = IsEmpty(VES_TB_CC1.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC1.Text);
            Double CREDIT_CARD2 = IsEmpty(VES_TB_CC2.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC2.Text);
            Double CREDIT_CARD3 = IsEmpty(VES_TB_CC3.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC3.Text);
            Double CREDIT_CARD4 = IsEmpty(VES_TB_CC4.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC4.Text);
            Double CREDIT_CARD5 = IsEmpty(VES_TB_CC5.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC5.Text);
            Double CREDIT_CARD6 = IsEmpty(VES_TB_CC6.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC6.Text);
            Double CREDIT_CARD7 = IsEmpty(VES_TB_CC7.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC7.Text);
            Double CREDIT_CARD8 = IsEmpty(VES_TB_CC8.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC8.Text);
            Double CREDIT_CARD9 = IsEmpty(VES_TB_CC9.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC9.Text);
            Double CREDIT_CARD10 = IsEmpty(VES_TB_CC10.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC10.Text);
            Double CREDIT_CARD = CREDIT_CARD1 + CREDIT_CARD2 + CREDIT_CARD3 + CREDIT_CARD4 + CREDIT_CARD5 + CREDIT_CARD6 + CREDIT_CARD7 + CREDIT_CARD8 + CREDIT_CARD9 + CREDIT_CARD10;
            VES_TB_CCTotal.Text = Convert.ToString(CREDIT_CARD);
            //check
            Double GOV_CHECK = IsEmpty(VES_TB_GovCh.Text) ? 0.00 : Convert.ToDouble(VES_TB_GovCh.Text);
            Double PER_CHECK = IsEmpty(VES_TB_PerCh.Text) ? 0.00 : Convert.ToDouble(VES_TB_PerCh.Text);
            Double CHECK = GOV_CHECK + PER_CHECK;
            VES_TB_CheckTotal.Text = Convert.ToString(CHECK);
            //gc
            Double GIFT_CHECK = IsEmpty(VES_TB_GC.Text) ? 0.00 : Convert.ToDouble(VES_TB_GC.Text);
            //coupon
            Double COUPON = IsEmpty(VES_TB_Cou.Text) ? 0.00 : Convert.ToDouble(VES_TB_Cou.Text);
            //tax cert
            Double TAX_CERT = IsEmpty(VES_TB_TaxCert.Text) ? 0.00 : Convert.ToDouble(VES_TB_TaxCert.Text);
            //PO

     
            double total = 0;
            foreach (DataGridViewRow row in VES_DGV_PO.Rows)
            {
                if( row.Cells[3]!=null)
                {
                    if(row.Cells[3].Value!=null)
                    {
                        if(row.Cells[3].Value.ToString()!=null)
                        {
                            total += Convert.ToDouble(row.Cells[3].Value.ToString());
                        }
                    }
                }                  
               
            }
            
            VES_TB_POTotal.Text = total.ToString();
        
            Double PO = IsEmpty(VES_TB_POTotal.Text) ? 0.00 : Convert.ToDouble(VES_TB_POTotal.Text);
            
            //charge
            Double CHARGE = CREDIT_CARD + CHECK + GIFT_CHECK + COUPON + TAX_CERT + PO;
            VES_TB_Charge.Text = Convert.ToString(CHARGE);
            //running total
            Double RUNNING_TOTAL = (CASH + CHARGE);
            VES_TB_RunTotal.Text = Convert.ToString(RUNNING_TOTAL);

        }
        public void PopulateSalesTab()
        {
            BalanseConn VESConn = new BalanseConn();
            DataTable VESSubform = VESConn.SelectQuery(@"SELECT TOTAL_SALES, CASH, CREDIT_CARD1, CREDIT_CARD2, CREDIT_CARD3, CREDIT_CARD4, CREDIT_CARD5,
                                                         CREDIT_CARD6, CREDIT_CARD7, CREDIT_CARD8, CREDIT_CARD9, CREDIT_CARD10, GOV_CHECK, PER_CHECK,
                                                         GIFT_CHECK, COUPON, TAX_CERT, PO, COMMENTS, BRANCH FROM SALES WHERE ROWID='" + srowid + "'");

            foreach (DataRow row in VESSubform.Rows)
            {
                VES_TB_Total.Text = row[0].ToString();
                VES_TB_Cash.Text = row[1].ToString();
                VES_TB_CC1.Text = row[2].ToString();
                VES_TB_CC2.Text = row[3].ToString();
                VES_TB_CC3.Text = row[4].ToString();
                VES_TB_CC4.Text = row[5].ToString();
                VES_TB_CC5.Text = row[6].ToString();
                VES_TB_CC6.Text = row[7].ToString();
                VES_TB_CC7.Text = row[8].ToString();
                VES_TB_CC8.Text = row[9].ToString();
                VES_TB_CC9.Text = row[10].ToString();
                VES_TB_CC10.Text = row[11].ToString();
                VES_TB_GovCh.Text = row[12].ToString();
                VES_TB_PerCh.Text = row[13].ToString();
                VES_TB_GC.Text = row[14].ToString();
                VES_TB_Cou.Text = row[15].ToString();
                VES_TB_TaxCert.Text = row[16].ToString();
                VES_TB_POTotal.Text = row[17].ToString();
                VES_RTB_Comm.Text = row[18].ToString();
                VES_DD_Branch.Text = row[19].ToString();
                UpdateSalesTotals();
            }
        }
        public void PopulatePODGV()
        {
            BalanseConn VESConn = new BalanseConn();
            DataTable VESSubformPO = VESConn.SelectQuery(@"SELECT ROWID, CUSTOMER_NAME, INVOICE_NO, PO_AMOUNT FROM PURCHASE_ORDERS WHERE SALES_ID= '" + srowid + "'");

            this.VES_DGV_PO.DataSource = null;
            this.VES_DGV_PO.Rows.Clear();

            foreach (DataRow arow in VESSubformPO.Rows)
            {
                string recid = arow[0].ToString();
                string customername = arow[1].ToString();
                int invoice = Convert.ToInt32(arow[2].ToString());
                decimal po_amount = Decimal.Parse(arow[3].ToString());
                VES_DGV_PO.Rows.Add(
                    recid,
                    customername,
                    invoice.ToString(),
                    po_amount.ToString("#,##0.00"));
            }

        }
        public int AddSalesTransaction()
        {
            BalanseConn InsertSalesTransactionConn = new BalanseConn();
            DateTime DATE = VES_But_Date.Value;
            String BRANCH = VES_DD_Branch.Text;
            Double TOTAL_SALES = IsEmpty(VES_TB_Total.Text) ? 0.00 : Convert.ToDouble(VES_TB_Total.Text);
            //cash
            Double CASH = IsEmpty(VES_TB_Cash.Text) ? 0.00 : Convert.ToDouble(VES_TB_Cash.Text);
            //credit card
            Double CREDIT_CARD1 = IsEmpty(VES_TB_CC1.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC1.Text);
            Double CREDIT_CARD2 = IsEmpty(VES_TB_CC2.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC2.Text);
            Double CREDIT_CARD3 = IsEmpty(VES_TB_CC3.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC3.Text);
            Double CREDIT_CARD4 = IsEmpty(VES_TB_CC4.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC4.Text);
            Double CREDIT_CARD5 = IsEmpty(VES_TB_CC5.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC5.Text);
            Double CREDIT_CARD6 = IsEmpty(VES_TB_CC6.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC6.Text);
            Double CREDIT_CARD7 = IsEmpty(VES_TB_CC7.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC7.Text);
            Double CREDIT_CARD8 = IsEmpty(VES_TB_CC8.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC8.Text);
            Double CREDIT_CARD9 = IsEmpty(VES_TB_CC9.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC9.Text);
            Double CREDIT_CARD10 = IsEmpty(VES_TB_CC10.Text) ? 0.00 : Convert.ToDouble(VES_TB_CC10.Text);
            Double CREDIT_CARD = IsEmpty(VES_TB_CCTotal.Text) ? 0.00 : Convert.ToDouble(VES_TB_CCTotal.Text);
            //check
            Double GOV_CHECK = IsEmpty(VES_TB_GovCh.Text) ? 0.00 : Convert.ToDouble(VES_TB_GovCh.Text);
            Double PER_CHECK = IsEmpty(VES_TB_PerCh.Text) ? 0.00 : Convert.ToDouble(VES_TB_PerCh.Text);
            Double CHECK = IsEmpty(VES_TB_CheckTotal.Text) ? 0.00 : Convert.ToDouble(VES_TB_CheckTotal.Text);
            //gc
            Double GIFT_CHECK = IsEmpty(VES_TB_GC.Text) ? 0.00 : Convert.ToDouble(VES_TB_GC.Text);
            //coupon
            Double COUPON = IsEmpty(VES_TB_Cou.Text) ? 0.00 : Convert.ToDouble(VES_TB_Cou.Text);
            //tax cert
            Double TAX_CERT = IsEmpty(VES_TB_TaxCert.Text) ? 0.00 : Convert.ToDouble(VES_TB_TaxCert.Text);
            //PO
            Double PO = IsEmpty(VES_TB_POTotal.Text) ? 0.00 : Convert.ToDouble(VES_TB_POTotal.Text);

            Double CHARGE = IsEmpty(VES_TB_Charge.Text) ? 0.00 : Convert.ToDouble(VES_TB_Charge.Text);
            String COMMENTS = IsEmpty(VES_RTB_Comm.Text) ? "" : VES_RTB_Comm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = VES_L_User.Text;
            int SalesID = InsertSalesTransactionConn.InsertSales(DATE, BRANCH, TOTAL_SALES, CASH, CHARGE, CREDIT_CARD, CREDIT_CARD1, CREDIT_CARD2, CREDIT_CARD3, CREDIT_CARD4, CREDIT_CARD5, CREDIT_CARD6, CREDIT_CARD7, CREDIT_CARD8, CREDIT_CARD9, CREDIT_CARD10,
                CHECK, GOV_CHECK, PER_CHECK, GIFT_CHECK, COUPON, TAX_CERT, PO, COMMENTS, REC_DT, ENCODED_BY);

            String POStatus = "Unpaid";

            string outputrowid = "";

            foreach (DataGridViewRow row in VES_DGV_PO.Rows)
            {

                outputrowid += InsertSalesTransactionConn.InsertPO(
                    SalesID,
                    DATE,
                    BRANCH,
                    row.Cells[2].Value.ToString(),
                    Convert.ToDouble(row.Cells[3].Value.ToString()),
                    POStatus,
                    REC_DT,
                    VES_L_User.Text,
                    Convert.ToInt32(row.Cells[2].Value.ToString()),
                    REC_DT);
            }
            return SalesID;
        }
        
        public Boolean CheckPayment(int inv_no)
        {
            Boolean withPayment = true;
            BalanseConn VESConn = new BalanseConn();
            DataTable POPayments= VESConn.SelectQuery("SELECT COUNT(*) FROM PO_PAYMENTS WHERE INVOICE_NO= '"+inv_no+"'");

            if (POPayments.Rows.Count <1)
            {
                withPayment = false;
            }

            return withPayment;

        }

        private void VES_But_Update_Click(object sender, EventArgs e)
        {
            BalanseConn VESConn = new BalanseConn();
            
            DialogResult result1;
           
            result1 = MessageBox.Show("This will update the sales record. All PO payments will be removed. Do you want to continue?", "Update Sales Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                if (!IsEmpty(VES_TB_Total.Text))
                {
                    if (VES_TB_Total.Text == VES_TB_RunTotal.Text)
                    {
                        VESConn.DropSales(srowid);
                        AddSalesTransaction();

                        foreach (DataGridViewRow row in VES_DGV_PO.Rows)
                        {
                            int invoice_no = Convert.ToInt32(row.Cells[2].Value.ToString());

                            if (CheckPayment(invoice_no) == true)
                            {

                                VESConn.DropPayment(invoice_no);
                            }
                        }
                        MessageBox.Show("Record updated.");
                        this.Close();  
                    }
                    if (VES_TB_Total.Text != VES_TB_RunTotal.Text)
                    {
                        DialogResult result2;
                        result2 = MessageBox.Show("Running Total is not equal to Total Sales. Do you still want to add the report?", "Add Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result2 == DialogResult.Yes)
                        {
                            VESConn.DropSales(srowid);
                            AddSalesTransaction();

                            foreach (DataGridViewRow row in VES_DGV_PO.Rows)
                            {
                                int invoice_no = Convert.ToInt32(row.Cells[2].Value.ToString());

                                if (CheckPayment(invoice_no) == true)
                                {

                                    VESConn.DropPayment(invoice_no);
                                }
                            }
                            MessageBox.Show("Record updated.");
                            this.Close();
                        }
                    }
                }
                
            }
            if (result1==DialogResult.No)
            {
                Close();
            }

        }


        private void VES_TB_Total_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_Cash_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC5_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC6_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC7_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC8_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC9_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_CC10_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_GovCh_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_PerCh_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_GC_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_Cou_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_TB_TaxCert_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void VES_DGV_PO_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (VES_DGV_PO.IsCurrentCellDirty)
            {
                VES_DGV_PO.CommitEdit(DataGridViewDataErrorContexts.Commit);
                UpdateSalesTotals();
            }
        }

        private void VES_TB_Total_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_Cash_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_CC10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_GovCh_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_PerCh_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_GC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_Cou_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_TB_TaxCert_KeyPress(object sender, KeyPressEventArgs e)
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

        private void VES_DGV_PO_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(VES_DGV_PO_KeyPress);
            if (VES_DGV_PO.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(VES_DGV_PO_KeyPress);
                }
            }
            if (VES_DGV_PO.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(VES_DGV_PO_KeyPress);
                }
            }
        }

        private void VES_DGV_PO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }
        }

        private void VES_But_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VES_But_Delete_Click(object sender, EventArgs e)
        {
            BalanseConn VESConn = new BalanseConn();

            DialogResult result1;

            result1 = MessageBox.Show("This will delete the sales record. Do you want to continue?", "Delete Sales Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                VESConn.DropSales(srowid);

                foreach (DataGridViewRow row in VES_DGV_PO.Rows)
                {
                    int invoice_no = Convert.ToInt32(row.Cells[2].Value.ToString());

                    if (CheckPayment(invoice_no) == true)
                    {
                        VESConn.DropPayment(invoice_no);
                    }
                }

                MessageBox.Show("Record deleted");
                this.Close();

            }
            if (result1 == DialogResult.No)
            {
                Close();
            }
        }

        private void VES_DGV_PO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VES_DGV_PO.Rows.RemoveAt(e.RowIndex);
            UpdateSalesTotals();
        }
    }
}
