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
            this.po_amount = Convert.ToDecimal(Info.Cells[4].Value.ToString().Replace(",", ""));

            po_id = Convert.ToInt32(Info.Cells[0].Value);
            this.POPay_TB_CustName.Text = Info.Cells[3].Value.ToString();
            this.POPay_TB_POAmt.Text = Info.Cells[4].Value.ToString();
            //string PayType = Info.Cells[6].Value.ToString();
            string Status = Info.Cells[5].Value.ToString();
            this.POPay_TB_Branch.Text = Info.Cells[1].Value.ToString();
            this.POPay_TB_PODate.Text = Info.Cells[2].Value.ToString();
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

            RetrievePayments(po_id);
            

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

        public void RetrievePayments(int po_id)
        {
            BalanseConn conn = new BalanseConn();
            string QueryString = "SELECT PAYMENT_TYPE, PAID_AMOUNT, PAYMENT_DATE FROM PO_PAYMENTS WHERE PO_ID =" + po_id + ";";
            DataTable dt = conn.SelectQuery(QueryString);
            foreach(DataRow row in dt.Rows)
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

            dgv_PoPayments.Rows.Add(POPay_DD_PayType.Text, POPay_TB_PayAmt.Text, POPay_But_PayDate.Text);

            POPay_DD_PayType.Text = "";
            POPay_TB_PayAmt.Text = "";
            POPay_But_PayDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            RecalculatePaymentTotals();


        }

        private void POSub_But_Save_Click(object sender, EventArgs e)
        {
            BalanseConn conn = new BalanseConn();
            conn.DropPayment(po_id);
            String outputrowid = "";
            foreach (DataGridViewRow row in dgv_PoPayments.Rows)
            {
                outputrowid += conn.IntertPO_Payment(
                    po_id,
                    DateTime.ParseExact(row.Cells[2].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    row.Cells[0].Value.ToString(),
                    Convert.ToDecimal(row.Cells[1].Value.ToString()),
                    this.encoder
                    ) + ",";

               
            }
            if((outputrowid.Split(',').Length - 1) == dgv_PoPayments.Rows.Count)
            {
                MessageBox.Show("Payments Saved");
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
    }
}
