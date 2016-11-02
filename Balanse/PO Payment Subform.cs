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
    public partial class PO_Payment_Subform : Form
    {
        public PO_Payment_Subform()
        {
            InitializeComponent();
        }
        public PO_Payment_Subform(DataGridViewRow Info)
        {
            InitializeComponent();
            this.POPay_TB_CustName.Text = Info.Cells[2].Value.ToString();
            this.POPay_TB_POAmt.Text = Info.Cells[3].Value.ToString();
            string PayType = Info.Cells[5].Value.ToString();
            string Status = Info.Cells[4].Value.ToString();
            this.POPay_TB_Branch.Text = Info.Cells[0].Value.ToString();
            this.POPay_TB_PODate.Text = Info.Cells[1].Value.ToString();
            for(int i=0;i< this.POPay_DD_PayType.Items.Count; i++)
            {
                if (this.POPay_DD_PayType.Items[i].ToString().ToUpper().Equals(PayType.ToUpper()))
                {
                    this.POPay_DD_PayType.SelectedIndex = i;
                }
            }
            for (int i = 0; i < this.POPay_DD_Status.Items.Count; i++)
            {
                if (this.POPay_DD_Status.Items[i].ToString().ToUpper().Equals(Status.ToUpper()))
                {
                    this.POPay_DD_Status.SelectedIndex = i;
                }
            }

        }
    }
}
