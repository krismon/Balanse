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
    public partial class PO_Payment_Subform : Form
    {

        private int po_id = 0;
        private int inv_no = 0;
        private string encoder = "";
        private decimal po_amount = 0;
        public PO_Payment_Subform()
        {
            InitializeComponent();
        }
        public PO_Payment_Subform(DataGridViewRow Info, String encoder)
        {
            InitializeComponent();
            this.encoder = encoder;
            this.po_amount = Convert.ToDecimal(Info.Cells[5].Value.ToString().Replace(",", ""));

            po_id = Convert.ToInt32(Info.Cells[0].Value);
            inv_no = Convert.ToInt32(Info.Cells[1].Value);
            this.POPay_TB_CustName.Text = Info.Cells[4].Value.ToString();
            this.POPay_TB_POAmt.Text = Info.Cells[5].Value.ToString();
            //string PayType = Info.Cells[6].Value.ToString();
            string Status = Info.Cells[6].Value.ToString();
            this.POPay_TB_Branch.Text = Info.Cells[2].Value.ToString();
            this.POPay_TB_PODate.Text = Info.Cells[3].Value.ToString();
            /*for(int i=0;i< this.POPay_DD_PayType.Items.Count; i++)
            {
                if (this.POPay_DD_PayType.Items[i].ToString().ToUpper().Equals(PayType.ToUpper()))
                {
                    this.POPay_DD_PayType.SelectedIndex = i;
                }
            }*/
            for (int i = 0; i < this.POPay_DD_Status.Items.Count; i++)
            {
                if (this.POPay_DD_Status.Items[i].ToString().ToUpper().Equals(Status.ToUpper()))
                {
                    this.POPay_DD_Status.SelectedIndex = i;
                }
            }

            RetrievePayments(inv_no);


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

        public void RecalculatePaymentTotals()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv_PoPayments.Rows)
            {
                total += Convert.ToDecimal(row.Cells[1].Value.ToString());
            }
            txtBalance.Text = (po_amount - total).ToString("#,##0.00");
            txtTotalPayments.Text = total.ToString("#,##0.00");
        }

        public void RetrievePayments(int inv_no)
        {
            BalanseConn conn = new BalanseConn();
            string QueryString = "SELECT PAYMENT_TYPE, PAID_AMOUNT, PAYMENT_DATE FROM PO_PAYMENTS WHERE INVOICE_NO =" + inv_no + ";";
            DataTable dt = conn.SelectQuery(QueryString);
            foreach (DataRow row in dt.Rows)
            {
                dgv_PoPayments.Rows.Add(
                row[0].ToString(),
                Decimal.Parse(row[1].ToString()).ToString("#,##0.00"),
                DateTime.Parse(row[2].ToString()).ToString("MM/dd/yyyy")
                );
            }
             
            RecalculatePaymentTotals();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (!IsEmpty(POPay_DD_PayType.Text) && (!IsEmpty(POPay_TB_PayAmt.Text)))
            {
                dgv_PoPayments.Rows.Add(POPay_DD_PayType.Text, POPay_TB_PayAmt.Text, POPay_But_PayDate.Text);
                POPay_DD_PayType.Text = "";
                POPay_TB_PayAmt.Text = "";
                POPay_CB_Deposit.Checked= false;
                POPay_But_PayDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                RecalculatePaymentTotals();
            }
            else
            {
                MessageBox.Show("Payment type and paid amount should not be empty.");
            }

        }

        private void POSub_But_Save_Click(object sender, EventArgs e)
        {
            BalanseConn conn = new BalanseConn();
            conn.DropPayment(inv_no);
            string outputrowid = "";
            DateTime update_date= DateTime.Now;

            foreach (DataGridViewRow row in dgv_PoPayments.Rows)
            {
                if (POPay_CB_Deposit.Checked)
                {
                    outputrowid += conn.InsertPO_Payment(
                       DateTime.ParseExact(POPay_TB_PODate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                       POPay_TB_Branch.Text,
                       Convert.ToDecimal(POPay_TB_POAmt.Text),
                       row.Cells[0].Value.ToString().ToUpper(),
                       DateTime.ParseExact(row.Cells[2].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture),
                       Convert.ToDecimal(row.Cells[1].Value.ToString()),
                       update_date,
                       this.encoder,
                       inv_no,
                       1) + ",";


                }
                else
                {
                    outputrowid += conn.InsertPO_Payment(
                        DateTime.ParseExact(POPay_TB_PODate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        POPay_TB_Branch.Text,
                        Convert.ToDecimal(POPay_TB_POAmt.Text),
                        row.Cells[0].Value.ToString().ToUpper(),
                        DateTime.ParseExact(row.Cells[2].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        Convert.ToDecimal(row.Cells[1].Value.ToString()),
                        update_date,
                        this.encoder,
                        inv_no,
                        0
                    ) + ",";
                }

                conn.UpdatePOStatus(POPay_DD_Status.Text, inv_no, update_date);
            }
            if ((outputrowid.Split(',').Length - 1) == dgv_PoPayments.Rows.Count)
            {
                MessageBox.Show("Payments Saved");
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an error saving the payments.");
            }

        }

        private void dgv_PoPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_PoPayments.Rows.RemoveAt(e.RowIndex);
            RecalculatePaymentTotals();
        }

        private void POPay_TB_PayAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");
            }
        }
    }
}
