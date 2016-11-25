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
    public partial class Form_Balanse : Form
    {
        public Form_Balanse(string name)
        {
            InitializeComponent();
            //user name
            S_L_User.Text = name;
            E_L_User.Text = name;
            D_L_User.Text = name;
            PO_L_User.Text = name;
            Su_L_User.Text = name;
            An_L_User.Text = name;
            VES_L_User.Text = name;
            VED_L_User.Text = name;

            BalanseConn conn = new BalanseConn();
            DateTime DATE = S_But_Date.Value;
            String BRANCH = S_DD_Branch.Text;

            DateTime REC_DT = DateTime.Today;
            //testdate.Text = REC_DT.ToString("MMM-yyyy");

            DataTable branch = conn.SelectQuery("SELECT BRANCH_NAME FROM BRANCH ORDER BY BRANCH_NAME ASC");
            Dictionary<String, String> test = new Dictionary<string, string>();
            int i = 0;
            foreach (DataRow row in branch.Rows)
            {
                test.Add(i.ToString(), row[0].ToString());
                i++;
            }
            S_DD_Branch.DataSource = new BindingSource(test, null);
            E_DD_Branch.DataSource = new BindingSource(test, null);
            PO_DD_Branch.DataSource = new BindingSource(test, null);
            Su_DD_Branch.DataSource = new BindingSource(test, null);
            An_DD_Branch.DataSource = new BindingSource(test, null);
            VES_DD_Branch.DataSource = new BindingSource(test, null);
            VED_DD_Branch.DataSource = new BindingSource(test, null);
            D_DD_Branch.DataSource = new BindingSource(test, null);
            S_DD_Branch.DisplayMember = "Value";
            E_DD_Branch.DisplayMember = "Value";
            PO_DD_Branch.DisplayMember = "Value";
            Su_DD_Branch.DisplayMember = "Value";
            An_DD_Branch.DisplayMember = "Value";
            VES_DD_Branch.DisplayMember = "Value";
            VED_DD_Branch.DisplayMember = "Value";
            D_DD_Branch.DisplayMember = "Value";
            S_DD_Branch.ValueMember = "Key";
            E_DD_Branch.ValueMember = "Key";
            PO_DD_Branch.ValueMember = "Key";
            Su_DD_Branch.ValueMember = "Key";
            An_DD_Branch.ValueMember = "Key";
            VES_DD_Branch.ValueMember = "Key";
            VED_DD_Branch.ValueMember = "Key";
            D_DD_Branch.ValueMember = "Key";

            //month drop down
            DataTable mon = conn.SelectQuery("select distinct case strftime('%m', date) when '01' then 'JANUARY' when '02' then 'FEBRUARY' when '03' then 'MARCH' when '04' then 'APRIL' when '05' then 'MAY' when '06' then 'JUNE' when '07' then 'JULY' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' end as Month from sales order by strftime('%m', date) asc");
            Dictionary<String, String> MonSelection = new Dictionary<string, string>();
            if (mon.Rows.Count > 0)
            {
                int j = 0;
                foreach (DataRow row in mon.Rows)
                {
                    MonSelection.Add(j.ToString(), row[0].ToString());
                    j++;
                }
                Su_DD_Month.DataSource = new BindingSource(MonSelection, null);
                An_DD_Month.DataSource = new BindingSource(MonSelection, null);
                Su_DD_Month.DisplayMember = "Value";
                An_DD_Month.DisplayMember = "Value";
                Su_DD_Month.ValueMember = "Key";
                An_DD_Month.ValueMember = "Key";
            }
            else
            {
                MonSelection.Add("0", "JANUARY");
                MonSelection.Add("1", "FEBRUARY");
                MonSelection.Add("2", "MARCH");
                MonSelection.Add("3", "APRIL");
                MonSelection.Add("4", "MAY");
                MonSelection.Add("5", "JUNE");
                MonSelection.Add("6", "JULY");
                MonSelection.Add("7", "AUGUST");
                MonSelection.Add("8", "SEPTEMBER");
                MonSelection.Add("9", "OCTOBER");
                MonSelection.Add("10", "NOVEMBER");
                MonSelection.Add("11", "DECEMBER");
                Su_DD_Month.DataSource = new BindingSource(MonSelection, null);
                An_DD_Month.DataSource = new BindingSource(MonSelection, null);
                Su_DD_Month.DisplayMember = "Value";
                An_DD_Month.DisplayMember = "Value";
                Su_DD_Month.ValueMember = "Key";
                An_DD_Month.ValueMember = "Key";
            }

            //year drop down
            DataTable year = conn.SelectQuery("select distinct strftime('%Y', date) from sales");
            Dictionary<String, String> YrSelection = new Dictionary<string, string>();
            if (year.Rows.Count > 0)
            {
                int k = 0;
                foreach (DataRow row in year.Rows)
                {
                    YrSelection.Add(k.ToString(), row[0].ToString());
                    k++;
                }
                Su_DD_Year.DataSource = new BindingSource(YrSelection, null);
                An_DD_Year.DataSource = new BindingSource(YrSelection, null);
                Su_DD_Year.DisplayMember = "Value";
                An_DD_Year.DisplayMember = "Value";
                Su_DD_Year.ValueMember = "Key";
                An_DD_Year.ValueMember = "Key";
            }
            else
            {
                YrSelection.Add("0", "2014");
                YrSelection.Add("1", "2015");
                YrSelection.Add("2", "2016");
                Su_DD_Year.DataSource = new BindingSource(YrSelection, null);
                An_DD_Year.DataSource = new BindingSource(YrSelection, null);
                Su_DD_Year.DisplayMember = "Value";
                An_DD_Year.DisplayMember = "Value";
                Su_DD_Year.ValueMember = "Key";
                An_DD_Year.ValueMember = "Key";
            }



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
        public Boolean IsRTBEmpty(RichTextBox item)
        {
            if (item.TextLength <= 0)
            {
                return true;
            }
            else return false;
        }


        public int AddSalesTransaction()
        {
            BalanseConn InsertSalesTransactionConn = new BalanseConn();
            DateTime DATE = S_But_Date.Value.Date;
            String BRANCH = S_DD_Branch.Text;
            Double TOTAL_SALES = IsEmpty(S_TB_Total.Text) ? 0.00 : Convert.ToDouble(S_TB_Total.Text);
            //cash
            Double CASH = IsEmpty(S_TB_Cash.Text) ? 0.00 : Convert.ToDouble(S_TB_Cash.Text);
            //credit card
            Double CREDIT_CARD1 = IsEmpty(S_TB_CC1.Text) ? 0.00 : Convert.ToDouble(S_TB_CC1.Text);
            Double CREDIT_CARD2 = IsEmpty(S_TB_CC2.Text) ? 0.00 : Convert.ToDouble(S_TB_CC2.Text);
            Double CREDIT_CARD3 = IsEmpty(S_TB_CC3.Text) ? 0.00 : Convert.ToDouble(S_TB_CC3.Text);
            Double CREDIT_CARD4 = IsEmpty(S_TB_CC4.Text) ? 0.00 : Convert.ToDouble(S_TB_CC4.Text);
            Double CREDIT_CARD5 = IsEmpty(S_TB_CC5.Text) ? 0.00 : Convert.ToDouble(S_TB_CC5.Text);
            Double CREDIT_CARD6 = IsEmpty(S_TB_CC6.Text) ? 0.00 : Convert.ToDouble(S_TB_CC6.Text);
            Double CREDIT_CARD7 = IsEmpty(S_TB_CC7.Text) ? 0.00 : Convert.ToDouble(S_TB_CC7.Text);
            Double CREDIT_CARD8 = IsEmpty(S_TB_CC8.Text) ? 0.00 : Convert.ToDouble(S_TB_CC8.Text);
            Double CREDIT_CARD9 = IsEmpty(S_TB_CC9.Text) ? 0.00 : Convert.ToDouble(S_TB_CC9.Text);
            Double CREDIT_CARD10 = IsEmpty(S_TB_CC10.Text) ? 0.00 : Convert.ToDouble(S_TB_CC10.Text);
            Double CREDIT_CARD = IsEmpty(S_TB_CCTotal.Text) ? 0.00 : Convert.ToDouble(S_TB_CCTotal.Text);
            //check
            Double GOV_CHECK = IsEmpty(S_TB_GovCh.Text) ? 0.00 : Convert.ToDouble(S_TB_GovCh.Text);
            Double PER_CHECK = IsEmpty(S_TB_PerCh.Text) ? 0.00 : Convert.ToDouble(S_TB_PerCh.Text);
            Double CHECK = IsEmpty(S_TB_CheckTotal.Text) ? 0.00 : Convert.ToDouble(S_TB_CheckTotal.Text);
            //gc
            Double GIFT_CHECK = IsEmpty(S_TB_GC.Text) ? 0.00 : Convert.ToDouble(S_TB_GC.Text);
            //coupon
            Double COUPON = IsEmpty(S_TB_Cou.Text) ? 0.00 : Convert.ToDouble(S_TB_Cou.Text);
            //tax cert
            Double TAX_CERT = IsEmpty(S_TB_TaxCert.Text) ? 0.00 : Convert.ToDouble(S_TB_TaxCert.Text);
            //PO
            Double PO = IsEmpty(S_TB_POTotal.Text) ? 0.00 : Convert.ToDouble(S_TB_POTotal.Text);

            Double CHARGE = IsEmpty(S_TB_Charge.Text) ? 0.00 : Convert.ToDouble(S_TB_Charge.Text);



            String COMMENTS = IsEmpty(S_RTB_Comm.Text) ? "" : S_RTB_Comm.Text;

            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = S_L_User.Text;

            int SalesID = InsertSalesTransactionConn.InsertSales(DATE, BRANCH, TOTAL_SALES, CASH, CHARGE, CREDIT_CARD, CREDIT_CARD1, CREDIT_CARD2, CREDIT_CARD3, CREDIT_CARD4, CREDIT_CARD5, CREDIT_CARD6, CREDIT_CARD7, CREDIT_CARD8, CREDIT_CARD9, CREDIT_CARD10,
                CHECK, GOV_CHECK, PER_CHECK, GIFT_CHECK, COUPON, TAX_CERT, PO, COMMENTS, REC_DT, ENCODED_BY);


            String POStatus = "Unpaid";

            if (!IsEmpty(S_TB_POName1.Text) && !IsEmpty(S_TB_POAmt1.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName1.Text, Convert.ToDouble(S_TB_POAmt1.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv1.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName2.Text) && !IsEmpty(S_TB_POAmt2.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName2.Text, Convert.ToDouble(S_TB_POAmt2.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv2.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName3.Text) && !IsEmpty(S_TB_POAmt3.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName3.Text, Convert.ToDouble(S_TB_POAmt3.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv3.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName4.Text) && !IsEmpty(S_TB_POAmt4.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName4.Text, Convert.ToDouble(S_TB_POAmt4.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv4.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName5.Text) && !IsEmpty(S_TB_POAmt5.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName5.Text, Convert.ToDouble(S_TB_POAmt5.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv5.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName6.Text) && !IsEmpty(S_TB_POAmt6.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName6.Text, Convert.ToDouble(S_TB_POAmt6.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv6.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName7.Text) && !IsEmpty(S_TB_POAmt7.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName7.Text, Convert.ToDouble(S_TB_POAmt7.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv7.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName8.Text) && !IsEmpty(S_TB_POAmt8.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName8.Text, Convert.ToDouble(S_TB_POAmt8.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv8.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName9.Text) && !IsEmpty(S_TB_POAmt9.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName9.Text, Convert.ToDouble(S_TB_POAmt9.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv9.Text), REC_DT);
            }
            if (!IsEmpty(S_TB_POName10.Text) && !IsEmpty(S_TB_POAmt10.Text))
            {
                InsertSalesTransactionConn.InsertPO(SalesID, DATE, BRANCH, S_TB_POName10.Text, Convert.ToDouble(S_TB_POAmt10.Text), POStatus, REC_DT, ENCODED_BY, Convert.ToInt32(S_TB_Inv10.Text), REC_DT);
            }
            return SalesID;
        }
        private int AddExpenses()
        {
            BalanseConn InsertExpTransactionConn = new BalanseConn();
            DateTime DATE = E_But_Date.Value.Date;
            String BRANCH = E_DD_Branch.Text;
            Double PCF1 = IsEmpty(E_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF1.Text);
            Double PCF2 = IsEmpty(E_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF2.Text);
            Double PCF3 = IsEmpty(E_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF3.Text);
            Double PCF4 = IsEmpty(E_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            E_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(E_TB_WTX.Text) ? 0.00 : Convert.ToDouble(E_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(E_TB_Ref.Text) ? 0.00 : Convert.ToDouble(E_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(E_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(E_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(E_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(E_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth4.Text);
            Double OTHERS = IsEmpty(E_TB_OthTotal.Text) ? 0.00 : Convert.ToDouble(E_TB_OthTotal.Text);


            //Total Exp
            Double TOTAL_EXPENSES = IsEmpty(E_TB_TotalExp.Text) ? 0.00 : Convert.ToDouble(E_TB_TotalExp.Text);
            String EXP_COMMENTS = E_RTB_Comm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = E_L_User.Text;
            int ExpenseID = InsertExpTransactionConn.InsertExpenses(DATE, BRANCH, PCF, PCF1, PCF2, PCF3, PCF4, WTX, REFUND, OTHERS, OTHERS1, OTHERS2, OTHERS3, OTHERS4, TOTAL_EXPENSES, EXP_COMMENTS, REC_DT, ENCODED_BY);
            return ExpenseID;


        }
        private int AddDeposit()
        {
            BalanseConn InsertDepTransactionConn = new BalanseConn();


            DateTime DATE = D_But_Date.Value.Date;
            String BRANCH = D_DD_Branch.Text;
            //CASH
            Double CASHDEP1 = IsEmpty(D_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(D_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(D_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(D_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash4.Text);
            Double CASHDEP = IsEmpty(D_TB_CashTotal.Text) ? 0.00 : Convert.ToDouble(D_TB_CashTotal.Text);
            //ENC CHECK
            Double ENC1 = IsEmpty(D_TB_Enc1.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc1.Text);
            Double ENC2 = IsEmpty(D_TB_Enc2.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc2.Text);
            Double ENC3 = IsEmpty(D_TB_Enc3.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc3.Text);
            Double ENC4 = IsEmpty(D_TB_Enc4.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc4.Text);
            Double ENC = IsEmpty(D_TB_EncTotal.Text) ? 0.00 : Convert.ToDouble(D_TB_EncTotal.Text);
            //CHECK
            Double CHECKDEP1 = IsEmpty(D_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(D_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(D_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(D_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch4.Text);
            Double CHECKDEP = IsEmpty(D_TB_ChTotal.Text) ? 0.00 : Convert.ToDouble(D_TB_ChTotal.Text);
            //Total Dep
            Double TOTAL_DEP = IsEmpty(D_TB_TotalDep.Text) ? 0.00 : Convert.ToDouble(D_TB_TotalDep.Text);
            String DEP_COMMENTS = D_RTB_Comm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = E_L_User.Text;
            
            int DepID=InsertDepTransactionConn.InsertDeposits(DATE, BRANCH, CASHDEP, CASHDEP1, CASHDEP2, CASHDEP3, CASHDEP4, ENC, ENC1, ENC2, ENC3, ENC4, CHECKDEP, CHECKDEP1, CHECKDEP2, CHECKDEP3, CHECKDEP4, TOTAL_DEP, DEP_COMMENTS, REC_DT, ENCODED_BY, 0);
            return DepID;

        }
        //Sales Tab Add Sales Button
        private void S_But_Add_Click(object sender, EventArgs e)
        {
            if (!IsEmpty(S_TB_Total.Text))
            {
                string Date = (S_But_Date.Value.ToString("yyyy-MM-dd"));
                string SalesDate = Date + " 00:00:00";
                String Branch = S_DD_Branch.Text;

                if (S_TB_Total.Text == S_TB_RunTotal.Text)
                {
                    AddSalesTransaction();
                    MessageBox.Show("Record added");
                    ResetSales();
                }
                if (S_TB_Total.Text != S_TB_RunTotal.Text)
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("Running Total is not equal to Total Sales. Do you still want to add the report?", "Add Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        AddSalesTransaction();
                        MessageBox.Show("Record added");
                        ResetSales();
                    }
                    
                }
            }
            else MessageBox.Show("Total Sales and Report Number cannot be empty");
        }
        //Sales Tab Update Running Total
        public void UpdateSalesTotals()
        {
            //cash
            Double CASH = IsEmpty(S_TB_Cash.Text) ? 0.00 : Convert.ToDouble(S_TB_Cash.Text);
            //credit card
            Double CREDIT_CARD1 = IsEmpty(S_TB_CC1.Text) ? 0.00 : Convert.ToDouble(S_TB_CC1.Text);
            Double CREDIT_CARD2 = IsEmpty(S_TB_CC2.Text) ? 0.00 : Convert.ToDouble(S_TB_CC2.Text);
            Double CREDIT_CARD3 = IsEmpty(S_TB_CC3.Text) ? 0.00 : Convert.ToDouble(S_TB_CC3.Text);
            Double CREDIT_CARD4 = IsEmpty(S_TB_CC4.Text) ? 0.00 : Convert.ToDouble(S_TB_CC4.Text);
            Double CREDIT_CARD5 = IsEmpty(S_TB_CC5.Text) ? 0.00 : Convert.ToDouble(S_TB_CC5.Text);
            Double CREDIT_CARD6 = IsEmpty(S_TB_CC6.Text) ? 0.00 : Convert.ToDouble(S_TB_CC6.Text);
            Double CREDIT_CARD7 = IsEmpty(S_TB_CC7.Text) ? 0.00 : Convert.ToDouble(S_TB_CC7.Text);
            Double CREDIT_CARD8 = IsEmpty(S_TB_CC8.Text) ? 0.00 : Convert.ToDouble(S_TB_CC8.Text);
            Double CREDIT_CARD9 = IsEmpty(S_TB_CC9.Text) ? 0.00 : Convert.ToDouble(S_TB_CC9.Text);
            Double CREDIT_CARD10 = IsEmpty(S_TB_CC10.Text) ? 0.00 : Convert.ToDouble(S_TB_CC10.Text);
            Double CREDIT_CARD = CREDIT_CARD1 + CREDIT_CARD2 + CREDIT_CARD3 + CREDIT_CARD4 + CREDIT_CARD5 + CREDIT_CARD6 + CREDIT_CARD7 + CREDIT_CARD8 + CREDIT_CARD9 + CREDIT_CARD10;
            S_TB_CCTotal.Text = Convert.ToString(CREDIT_CARD);
            //check
            Double GOV_CHECK = IsEmpty(S_TB_GovCh.Text) ? 0.00 : Convert.ToDouble(S_TB_GovCh.Text);
            Double PER_CHECK = IsEmpty(S_TB_PerCh.Text) ? 0.00 : Convert.ToDouble(S_TB_PerCh.Text);
            Double CHECK = GOV_CHECK + PER_CHECK;
            S_TB_CheckTotal.Text = Convert.ToString(CHECK);
            //gc
            Double GIFT_CHECK = IsEmpty(S_TB_GC.Text) ? 0.00 : Convert.ToDouble(S_TB_GC.Text);
            //coupon
            Double COUPON = IsEmpty(S_TB_Cou.Text) ? 0.00 : Convert.ToDouble(S_TB_Cou.Text);
            //tax cert
            Double TAX_CERT = IsEmpty(S_TB_TaxCert.Text) ? 0.00 : Convert.ToDouble(S_TB_TaxCert.Text);
            //PO
            Double POAmt1 = IsEmpty(S_TB_POAmt1.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt1.Text);
            Double POAmt2 = IsEmpty(S_TB_POAmt2.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt2.Text);
            Double POAmt3 = IsEmpty(S_TB_POAmt3.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt3.Text);
            Double POAmt4 = IsEmpty(S_TB_POAmt4.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt4.Text);
            Double POAmt5 = IsEmpty(S_TB_POAmt5.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt5.Text);
            Double POAmt6 = IsEmpty(S_TB_POAmt6.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt6.Text);
            Double POAmt7 = IsEmpty(S_TB_POAmt7.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt7.Text);
            Double POAmt8 = IsEmpty(S_TB_POAmt8.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt8.Text);
            Double POAmt9 = IsEmpty(S_TB_POAmt9.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt9.Text);
            Double POAmt10 = IsEmpty(S_TB_POAmt10.Text) ? 0.00 : Convert.ToDouble(S_TB_POAmt10.Text);
            Double PO = POAmt1 + POAmt2 + POAmt3 + POAmt4 + POAmt5 + POAmt6 + POAmt7 + POAmt8 + POAmt9 + POAmt10;
            S_TB_POTotal.Text = Convert.ToString(PO);
            //charge
            Double CHARGE = CREDIT_CARD + CHECK + GIFT_CHECK + COUPON + TAX_CERT + PO;
            S_TB_Charge.Text = Convert.ToString(CHARGE);
            //running total
            Double RUNNING_TOTAL = (CASH + CHARGE);
            S_TB_RunTotal.Text = Convert.ToString(RUNNING_TOTAL);

        }

        //Sales Tab Reset Text Boxes
        private void ResetSales()
        {

            S_TB_Cash.Text = "";
            S_TB_Total.Text = "";
            S_TB_CCTotal.Text = "";
            S_TB_CC1.Text = "";
            S_TB_CC2.Text = "";
            S_TB_CC3.Text = "";
            S_TB_CC4.Text = "";
            S_TB_CC5.Text = "";
            S_TB_CC6.Text = "";
            S_TB_CC7.Text = "";
            S_TB_CC8.Text = "";
            S_TB_CC9.Text = "";
            S_TB_CC10.Text = "";
            S_TB_CheckTotal.Text = "";
            S_TB_GovCh.Text = "";
            S_TB_PerCh.Text = "";
            S_TB_GC.Text = "";
            S_TB_Cou.Text = "";
            S_TB_TaxCert.Text = "";
            S_TB_POTotal.Text = "";
            S_TB_POAmt1.Text = "";
            S_TB_POAmt2.Text = "";
            S_TB_POAmt3.Text = "";
            S_TB_POAmt4.Text = "";
            S_TB_POAmt5.Text = "";
            S_TB_POAmt6.Text = "";
            S_TB_POAmt7.Text = "";
            S_TB_POAmt8.Text = "";
            S_TB_POAmt9.Text = "";
            S_TB_POAmt10.Text = "";
            S_RTB_Comm.Text = "";
            S_TB_POName1.Text = "";
            S_TB_POName2.Text = "";
            S_TB_POName3.Text = "";
            S_TB_POName4.Text = "";
            S_TB_POName5.Text = "";
            S_TB_POName6.Text = "";
            S_TB_POName7.Text = "";
            S_TB_POName8.Text = "";
            S_TB_POName9.Text = "";
            S_TB_POName10.Text = "";
            S_TB_Inv1.Text = "";
            S_TB_Inv2.Text = "";
            S_TB_Inv3.Text = "";
            S_TB_Inv4.Text = "";
            S_TB_Inv5.Text = "";
            S_TB_Inv6.Text = "";
            S_TB_Inv7.Text = "";
            S_TB_Inv8.Text = "";
            S_TB_Inv9.Text = "";
            S_TB_Inv10.Text = "";
            S_TB_Charge.Text = "";
            S_TB_RunTotal.Text = "";
        }
        //Expenses and Deposits Tab Update Total Expenses
        private void UpdateExpensesTotals()
        {
            Double PCF1 = IsEmpty(E_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF1.Text);
            Double PCF2 = IsEmpty(E_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF2.Text);
            Double PCF3 = IsEmpty(E_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF3.Text);
            Double PCF4 = IsEmpty(E_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(E_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            E_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(E_TB_WTX.Text) ? 0.00 : Convert.ToDouble(E_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(E_TB_Ref.Text) ? 0.00 : Convert.ToDouble(E_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(E_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(E_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(E_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(E_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(E_TB_Oth4.Text);
            Double OTHERS = OTHERS1 + OTHERS2 + OTHERS3 + OTHERS4;
            E_TB_OthTotal.Text = Convert.ToString(OTHERS);

            //Total Exp
            Double TOTAL_EXPENSES = PCF + WTX + REFUND + OTHERS;
            E_TB_TotalExp.Text = Convert.ToString(TOTAL_EXPENSES);
        }
        //Expenses and Deposits Tab Update Total Deposits
        private void UpdateDepositTotals()
        {
            //CASH
            Double CASHDEP1 = IsEmpty(D_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(D_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(D_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(D_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(D_TB_Cash4.Text);
            Double CASHDEP = CASHDEP1 + CASHDEP2 + CASHDEP3 + CASHDEP4;
            D_TB_CashTotal.Text = Convert.ToString(CASHDEP);

            //ENC CHECK
            Double ENC1 = IsEmpty(D_TB_Enc1.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc1.Text);
            Double ENC2 = IsEmpty(D_TB_Enc2.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc2.Text);
            Double ENC3 = IsEmpty(D_TB_Enc3.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc3.Text);
            Double ENC4 = IsEmpty(D_TB_Enc4.Text) ? 0.00 : Convert.ToDouble(D_TB_Enc4.Text);
            Double ENC = ENC1 + ENC2 + ENC3 + ENC4;
            D_TB_EncTotal.Text = Convert.ToString(ENC);

            //CHECK
            Double CHECKDEP1 = IsEmpty(D_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(D_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(D_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(D_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(D_TB_Ch4.Text);
            Double CHECKDEP = CHECKDEP1 + CHECKDEP2 + CHECKDEP3 + CHECKDEP4;
            D_TB_ChTotal.Text = Convert.ToString(CHECKDEP);

            //Total Dep
            Double TOTAL_DEP = CASHDEP + ENC + CHECKDEP;

            D_TB_TotalDep.Text = Convert.ToString(TOTAL_DEP);
        }
        //Reset Expenses and Deposits Text Boxes
        public void ResetExpenses()
        {

            E_TB_PCF1.Text = "";
            E_TB_PCF2.Text = "";
            E_TB_PCF3.Text = "";
            E_TB_PCF4.Text = "";
            E_TB_PCFTotal.Text = "";
            E_TB_WTX.Text = "";
            E_TB_Ref.Text = "";
            E_TB_Oth1.Text = "";
            E_TB_Oth2.Text = "";
            E_TB_Oth3.Text = "";
            E_TB_Oth4.Text = "";
            E_TB_OthTotal.Text = "";
            E_TB_TotalExp.Text = "";
            E_RTB_Comm.Text = "";

        }
        public void ResetDeposit()
        {
            D_TB_Cash1.Text = "";
            D_TB_Cash2.Text = "";
            D_TB_Cash3.Text = "";
            D_TB_Cash4.Text = "";
            D_TB_CashTotal.Text = "";
            D_TB_Enc1.Text = "";
            D_TB_Enc2.Text = "";
            D_TB_Enc3.Text = "";
            D_TB_Enc4.Text = "";
            D_TB_EncTotal.Text = "";
            D_TB_Ch1.Text = "";
            D_TB_Ch2.Text = "";
            D_TB_Ch3.Text = "";
            D_TB_Ch4.Text = "";
            D_TB_ChTotal.Text = "";
            D_TB_TotalDep.Text = "";
            D_RTB_Comm.Text = "";
        }

        public void ResetPOSearch()
        {
            PO_DD_Branch.Text = "";
            PO_TB_CustNameSearch.Text = "";
            PO_TB_Inv.Text = "";
        }

        public Boolean PopulatePODataGrid()
        {
            //ResetPOSearch();
            this.PO_DGV_POItems.DataSource = null;
            this.PO_DGV_POItems.Rows.Clear();

            Boolean IsSuccess = true;
            String whereClause = "";
            string PODate = "";
            if (PO_TB_CustNameSearch.Text.Length > 0)
            {
                String CustName = PO_TB_CustNameSearch.Text;
                whereClause += "UPPER(A.CUSTOMER_NAME) LIKE UPPER('" + (PO_TB_CustNameSearch.Text) + "')";
            }

            if (chkSearchByPo_Date.Checked)
            {
                if (whereClause.Length > 0)
                {
                    whereClause += " AND ";
                }
                PODate = PO_But_Date.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                whereClause = "A.PO_DATE = '" + PODate + "'";
            }

            if (PO_DD_Branch.Text.Length > 0)
            {
                if (whereClause.Length > 0)
                {
                    whereClause += " AND ";
                }
                whereClause += "A.BRANCH = '" + PO_DD_Branch.Text + "'";
            }
            if (PO_TB_Inv.Text.Length > 0)
            {
                if (whereClause.Length > 0)
                {
                    whereClause += " AND ";
                }
                whereClause += "A.INVOICE_NO=" + PO_TB_Inv.Text;
            }
            if (whereClause.Length > 0)
            {
                whereClause = " WHERE " + whereClause;
            }

            BalanseConn POConn = new BalanseConn();
            DataTable POItems = POConn.SelectQuery(@"SELECT
                                               A.ROWID,
                                               A.INVOICE_NO,
                                               A.BRANCH, 
                                               A.PO_DATE,
                                               A.CUSTOMER_NAME, 
                                               A.PO_AMOUNT,
                                               A.PO_STATUS,
                                               SUM(B.PAID_AMOUNT)
                                               FROM PURCHASE_ORDERS A LEFT JOIN PO_PAYMENTS B 
                                               ON
                                                    A.PO_DATE=B.PO_DATE AND
						                            A.INVOICE_NO=B.INVOICE_NO AND
					                                A.BRANCH=B.BRANCH"
                                                        +
                                                    //A.PO_DATE = B.PO_DATE 
                                                    //AND A.BRANCH = B.BRANCH 
                                                    //AND A.CUSTOMER_NAME = B.CUSTOMER_NAME 
                                                    //AND A.PO_AMOUNT = B.PO_AMOUNT" +
                                                    whereClause + " GROUP BY A.BRANCH, A.CUSTOMER_NAME;"
                                               );

            if (POItems.Rows.Count < 1)
            {
                IsSuccess = false;
                MessageBox.Show("No records match with the details provided.");
                PO_TB_CustNameSearch.Text = "";

            }
            else
                foreach (DataRow row in POItems.Rows)
                {
                    string rowid = row[0].ToString();
                    string invoice = row[1].ToString();
                    string Branch = row[2].ToString();
                    string PO_Date = DateTime.Parse(row[3].ToString()).ToString("MM/dd/yyyy");
                    string CustomerName = row[4].ToString();

                    decimal POAmount = Decimal.Parse(row[5].ToString());
                    string POStatus = row[6].ToString();

                    string PayType = "";
                    if (row[7] != DBNull.Value)
                    {
                        PayType = row[7].ToString();
                    }
                    else PayType = "";

                    decimal PayAmount = 0;
                    if (row[7] != DBNull.Value)
                    {
                        PayAmount = Decimal.Parse(row[7].ToString());
                    }

                    /*string PayDate="";
                    if (row[8] != DBNull.Value)
                    {
                        PayDate =
                        DateTime.Parse(row[8].ToString()).ToString("MM/dd/yyyy");
                    }

                    else PayDate = "";*/


                    PO_DGV_POItems.Rows.Add(
                        rowid,
                        invoice,
                        Branch,
                        PO_Date,
                        CustomerName,
                        POAmount.ToString("#,##0.00"),
                        POStatus,
                        (POAmount - PayAmount).ToString("#,##0.00"));
                    ResetPOSearch();
                }
            return IsSuccess;


        }
        private void S_TB_Cash_KeyPress(object sender, KeyPressEventArgs e)
        {

            UpdateSalesTotals();

        }

        private void S_TB_CC1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC5_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC6_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC7_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC8_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC9_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_CC10_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_GovCh_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_PerCh_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_GC_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_Cou_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_TaxCert_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt5_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt6_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt7_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt8_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt9_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_POAmt10_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_TB_Cash_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateSalesTotals();
        }

        private void S_But_Reset_Click(object sender, EventArgs e)
        {
            ResetSales();
        }

        private void S_TB_Total_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_Cash_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_CC10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_GovCh_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_PerCh_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_GC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_Cou_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_TaxCert_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void S_TB_POAmt10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_PCF1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_PCF2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_PCF3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();

        }

        private void ED_TB_PCF4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_WTX_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Ref_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Oth1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Oth2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Oth3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Oth4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateExpensesTotals();
        }

        private void ED_TB_Cash1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Cash2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Cash3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Cash4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_EncCh1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_EncCh2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_EncCh3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_EncCh4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Ch1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Ch3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Ch2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_Ch4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void ED_TB_PCF1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_PCF2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_PCF3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_PCF4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_WTX_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Ref_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Oth1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Oth2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Oth3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Oth4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Cash1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Cash2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Cash3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Cash4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_EncCh1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_EncCh2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_EncCh3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_EncCh4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Ch1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Ch3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Ch2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ED_TB_Ch4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PO_But_Search_Click(object sender, EventArgs e)
        {
            PopulatePODataGrid();
        }

        private void B_ResetExpDep_But_Click(object sender, EventArgs e)
        {
            ResetExpenses();
        }

        private void ED_TB_ReportNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }
        }

        private void S_TB_RepNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");

            }
        }

        private void PO_But_Reset_Click(object sender, EventArgs e)
        {
            ResetPOSearch();
        }

        private void PO_DGV_POItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PO_Payment_Subform POPayment = new PO_Payment_Subform(PO_DGV_POItems.Rows[e.RowIndex], E_L_User.Text);
            POPayment.ShowDialog();
        }

        private void chkSearchByPo_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchByPo_Date.Checked)
            {
                PO_But_Date.Enabled = true;
            }
            else
            {
                PO_But_Date.Enabled = false;
            }
        }
        //Monthly Sales Tab
        public void ResetMonthlySalesSearch()
        {
            Su_DD_Branch.Text = "";
            Su_DD_Month.Text = "";
            Su_DD_Year.Text = "";
        }
        public Boolean PopulateMonthlySales()
        {

            this.Su_DGV_Sales.DataSource = null;
            this.Su_DGV_Sales.Rows.Clear();
            Boolean IsSuccess = true;
            BalanseConn SummaryConn = new BalanseConn();
            if (Su_CB_All.Checked)
            {
                DataTable SalesItems = SummaryConn.SelectQuery(@"SELECT SALES.DAY, SALES.TOTAL_SALES, SALES.CASH_SALES, SALES.CHARGE, SALES.CC, 
                                                                 SALES.'CHECK', SALES.GC, SALES.COUPON, SALES.TAX_CERT, SALES.PO,
                                                                 EXPENSES.TOTAL_EXPENSES, EXPENSES.PCF, EXPENSES.WTX, EXPENSES.OTHERS,
                                                                 DEPOSIT.CASH, DEPOSIT.'CHECK', DEPOSIT.ENC_CHECK,
                                                                 PO_PAYMENTS.PAID_AMOUNT
                                                                 FROM 
                                                                 (select date, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH,strftime('%d',date) as DAY, sum(total_sales) AS TOTAL_SALES, sum(cash) AS CASH_SALES, 
                                                                  sum(charge) AS CHARGE, sum(credit_card)AS CC, sum('check') AS 'CHECK', sum(gift_check) AS GC, sum(coupon) AS COUPON, sum(tax_cert) AS TAX_CERT,
                                                                  sum(po) AS PO from sales group by DAY) SALES
                                                                 LEFT JOIN  
                                                                (select date, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH,strftime('%d',date) as DAY, sum(total_expenses) as TOTAL_EXPENSES, sum(pcf) as PCF, 
                                                                 sum(wtx) as WTX, sum(others) as OTHERS
                                                                 from expenses group by DAY) EXPENSES 
                                                                ON SALES.DATE=EXPENSES.DATE
                                                                LEFT JOIN
                                                                (select date, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH, strftime('%d', date) AS DAY, 
                                                                    sum(cash) AS CASH, sum('check') AS 'CHECK', sum(enc_check) AS ENC_CHECK from DEPOSITS GROUP BY DAY) DEPOSIT
                                                                ON SALES.DATE=DEPOSIT.DATE 
                                                                LEFT JOIN 
                                                                (select payment_date, strftime('%Y', payment_date) as YEAR, strftime('%m', payment_date) as MONTH, 
                                                                    strftime('%d', payment_date) as DAY, sum(paid_amount) as PAID_AMOUNT
                                                                    from PO_PAYMENTS group by DAY) PO_PAYMENTS
                                                                ON SALES.DATE=PO_PAYMENTS.PAYMENT_DATE 
                                                                where SALES.YEAR='" + Su_DD_Year.Text + "' and case SALES.MONTH when '01' then 'JANUARY' when '02' then 'FEBRUARY' when '03' then 'MARCH' when '04' then 'APRIL' when '05' then 'MAY' when '06' then 'JUNE' when '07' then 'JULY' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' END ='" + Su_DD_Month.Text + "' group by SALES.DAY");
                if (SalesItems.Rows.Count < 1)
                {
                    IsSuccess = false;
                    Su_L_RepName.Text = "";
                    MessageBox.Show("No records were found.");

                }
                else
                {
                    foreach (DataRow row in SalesItems.Rows)
                    {
                        string day = row[0].ToString();

                        decimal total_sales = Decimal.Parse(row[1].ToString());

                        decimal cash = 0;
                        if (row[2] != DBNull.Value)
                        {
                            cash = Decimal.Parse(row[2].ToString());
                        }

                        decimal charge = 0;
                        if (row[3] != DBNull.Value)
                        {
                            charge = Decimal.Parse(row[3].ToString());
                        }
                        decimal cc = 0;
                        if (row[4] != DBNull.Value)
                        {
                            cc = Decimal.Parse(row[4].ToString());
                        }
                        decimal check = 0;
                        if (row[5] != DBNull.Value)
                        {
                            check = Decimal.Parse(row[5].ToString());
                        }
                        decimal gc = 0;
                        if (row[6] != DBNull.Value)
                        {
                            gc = Decimal.Parse(row[6].ToString());
                        }
                        decimal coupon = 0;
                        if (row[7] != DBNull.Value)
                        {
                            coupon = Decimal.Parse(row[7].ToString());
                        }
                        decimal tc = 0;
                        if (row[8] != DBNull.Value)
                        {
                            tc = Decimal.Parse(row[8].ToString());
                        }
                        decimal po = 0;
                        if (row[9] != DBNull.Value)
                        {
                            po = Decimal.Parse(row[9].ToString());
                        }

                        decimal totalExp = 0;
                        if (row[10] != DBNull.Value)
                        {
                            totalExp = Decimal.Parse(row[10].ToString());
                        }
                        decimal pcf = 0;
                        if (row[11] != DBNull.Value)
                        {
                            pcf = Decimal.Parse(row[11].ToString());
                        }
                        decimal wtx = 0;
                        if (row[12] != DBNull.Value)
                        {
                            wtx = Decimal.Parse(row[12].ToString());
                        }
                        decimal others = 0;
                        if (row[13] != DBNull.Value)
                        {
                            others = Decimal.Parse(row[13].ToString());
                        }

                        decimal cashdep = 0;
                        if (row[14] != DBNull.Value)
                        {
                            cashdep = Decimal.Parse(row[14].ToString());
                        }

                        decimal checkdep = 0;
                        if (row[15] != DBNull.Value)
                        {
                            checkdep = Decimal.Parse(row[15].ToString());
                        }
                        decimal encdep = 0;
                        if (row[16] != DBNull.Value)
                        {
                            encdep = Decimal.Parse(row[16].ToString());
                        }

                        decimal podep = 0;
                        if (row[17] != DBNull.Value)
                        {
                            podep = Decimal.Parse(row[17].ToString());
                        }

                        Su_DGV_Sales.Rows.Add(
                        day,
                        total_sales.ToString("#,##0.00"),
                        cash.ToString("#,##0.00"),
                        charge.ToString("#,##0.00"),
                        cc.ToString("#,##0.00"),
                        check.ToString("#,##0.00"),
                        gc.ToString("#,##0.00"),
                        coupon.ToString("#,##0.00"),
                        tc.ToString("#,##0.00"),
                        po.ToString("#,##0.00"),
                        totalExp.ToString("#,##0.00"),
                        pcf.ToString("#,##0.00"),
                        wtx.ToString("#,##0.00"),
                        others.ToString("#,##0.00"),
                        cashdep.ToString("#,##0.00"),
                        checkdep.ToString("#,##0.00"),
                        encdep.ToString("#,##0.00"),
                        podep.ToString("#,##0.00"));


                        Su_L_RepName.Text = Su_DD_Month.Text + " " + Su_DD_Year.Text + " SALES SUMMARY FOR ALL BRANCHES";
                    }
                }
                return IsSuccess;
            }
            else
            {

                DataTable SalesItems = SummaryConn.SelectQuery(@"SELECT SALES.DAY, SALES.TOTAL_SALES, SALES.CASH_SALES, SALES.CHARGE, 
                                                                 SALES.CC, SALES.'CHECK', SALES.GC, SALES.COUPON, SALES.TAX_CERT, SALES.PO,
                                                                 EXPENSES.TOTAL_EXPENSES, EXPENSES.PCF, EXPENSES.WTX, EXPENSES.OTHERS, 
                                                                 DEPOSIT.CASH, DEPOSIT.'CHECK', DEPOSIT.ENC_CHECK,
                                                                 PO_PAYMENTS.PAID_AMOUNT
                                                                 FROM
                                                                 (select date, branch, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH,strftime('%d',date) as DAY, sum(total_sales) AS TOTAL_SALES, sum(cash) AS CASH_SALES, 
                                                                  sum(charge) AS CHARGE, sum(credit_card)AS CC, sum('check') AS 'CHECK', sum(gift_check) AS GC, sum(coupon) AS COUPON, sum(tax_cert) AS TAX_CERT,
                                                                  sum(po) AS PO from sales group by DAY) SALES
                                                                 LEFT JOIN
                                                                 (select date, branch, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH,strftime('%d',date) as DAY, sum(total_expenses) as TOTAL_EXPENSES, sum(pcf) as PCF, 
                                                                  sum(wtx) as WTX, sum(others) as OTHERS
                                                                  from expenses group by DAY) EXPENSES  
                                                                 ON SALES.DATE=EXPENSES.DATE AND SALES.BRANCH=EXPENSES.BRANCH
                                                                 LEFT JOIN
                                                                 (select date, branch, strftime('%Y', date) AS YEAR, strftime('%m', date) AS MONTH, strftime('%d', date) AS DAY, 
                                                                    sum(cash) AS CASH, sum('check') AS 'CHECK', sum(enc_check) AS ENC_CHECK from DEPOSITS GROUP BY DAY) DEPOSIT
                                                                 ON SALES.DATE=DEPOSIT.DATE AND SALES.BRANCH=DEPOSIT.BRANCH
                                                                 LEFT JOIN 
                                                                 (select payment_date, branch, strftime('%Y', payment_date) as YEAR, strftime('%m', payment_date) as MONTH, 
                                                                    strftime('%d', payment_date) as DAY, sum(paid_amount) as PAID_AMOUNT from PO_PAYMENTS group by DAY) PO_PAYMENTS
                                                                 ON SALES.DATE=PO_PAYMENTS.PAYMENT_DATE AND SALES.BRANCH=DEPOSIT.BRANCH
                                                                 where SALES.YEAR='" + Su_DD_Year.Text + "' and case SALES.MONTH when '01' then 'JANUARY' when '02' then 'FEBRUARY' when '03' then 'MARCH' when '04' then 'APRIL' when '05' then 'MAY' when '06' then 'JUNE' when '07' then 'JULY' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' END ='" + Su_DD_Month.Text + "' and SALES.BRANCH= '" + Su_DD_Branch.Text + "' group by SALES.DAY");
                if (SalesItems.Rows.Count < 1)
                {
                    IsSuccess = false;
                    ResetMonthlySalesSearch();
                    Su_L_RepName.Text = "";
                    MessageBox.Show("No records found.");

                }
                else
                {
                    foreach (DataRow row in SalesItems.Rows)
                    {
                        string day = row[0].ToString();

                        decimal total_sales = Decimal.Parse(row[1].ToString());

                        decimal cash = 0;
                        if (row[2] != DBNull.Value)
                        {
                            cash = Decimal.Parse(row[2].ToString());
                        }

                        decimal charge = 0;
                        if (row[3] != DBNull.Value)
                        {
                            charge = Decimal.Parse(row[3].ToString());
                        }
                        decimal cc = 0;
                        if (row[4] != DBNull.Value)
                        {
                            cc = Decimal.Parse(row[4].ToString());
                        }
                        decimal check = 0;
                        if (row[5] != DBNull.Value)
                        {
                            check = Decimal.Parse(row[5].ToString());
                        }
                        decimal gc = 0;
                        if (row[6] != DBNull.Value)
                        {
                            gc = Decimal.Parse(row[6].ToString());
                        }
                        decimal coupon = 0;
                        if (row[7] != DBNull.Value)
                        {
                            coupon = Decimal.Parse(row[7].ToString());
                        }
                        decimal tc = 0;
                        if (row[8] != DBNull.Value)
                        {
                            tc = Decimal.Parse(row[8].ToString());
                        }
                        decimal po = 0;
                        if (row[9] != DBNull.Value)
                        {
                            po = Decimal.Parse(row[9].ToString());
                        }

                        decimal totalExp = 0;
                        if (row[10] != DBNull.Value)
                        {
                            totalExp = Decimal.Parse(row[10].ToString());
                        }
                        decimal pcf = 0;
                        if (row[11] != DBNull.Value)
                        {
                            pcf = Decimal.Parse(row[11].ToString());
                        }
                        decimal wtx = 0;
                        if (row[12] != DBNull.Value)
                        {
                            wtx = Decimal.Parse(row[12].ToString());
                        }
                        decimal others = 0;
                        if (row[13] != DBNull.Value)
                        {
                            others = Decimal.Parse(row[13].ToString());
                        }

                        decimal cashdep = 0;
                        if (row[14] != DBNull.Value)
                        {
                            cashdep = Decimal.Parse(row[14].ToString());
                        }

                        decimal checkdep = 0;
                        if (row[15] != DBNull.Value)
                        {
                            checkdep = Decimal.Parse(row[15].ToString());
                        }
                        decimal encdep = 0;
                        if (row[16] != DBNull.Value)
                        {
                            encdep = Decimal.Parse(row[16].ToString());
                        }

                        decimal podep = 0;
                        if (row[17] != DBNull.Value)
                        {
                            podep = Decimal.Parse(row[17].ToString());
                        }

                        Su_DGV_Sales.Rows.Add(
                        day,
                        total_sales.ToString("#,##0.00"),
                        cash.ToString("#,##0.00"),
                        charge.ToString("#,##0.00"),
                        cc.ToString("#,##0.00"),
                        check.ToString("#,##0.00"),
                        gc.ToString("#,##0.00"),
                        coupon.ToString("#,##0.00"),
                        tc.ToString("#,##0.00"),
                        po.ToString("#,##0.00"),
                        totalExp.ToString("#,##0.00"),
                        pcf.ToString("#,##0.00"),
                        wtx.ToString("#,##0.00"),
                        others.ToString("#,##0.00"),
                        cashdep.ToString("#,##0.00"),
                        checkdep.ToString("#,##0.00"),
                        encdep.ToString("#,##0.00"),
                        podep.ToString("#,##0.00"));
                    }
                }
                return IsSuccess;
            }
        }
        private void Su_But_Search_Click(object sender, EventArgs e)
        {
            PopulateMonthlySales();
            Su_CB_All.Checked = false;
        }

        private void Su_But_Reset_Click(object sender, EventArgs e)
        {
            ResetMonthlySalesSearch();
            Su_CB_All.Checked = false;
        }

        //Analysis Tab
        public void ResetAnalysisSearch()
        {
            Su_DD_Branch.Text = "";
            Su_DD_Month.Text = "";
            Su_DD_Year.Text = "";
        }

        private void PO_TB_Inv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Numeric input only");
            }
        }

        private void An_But_Search_Click(object sender, EventArgs e)
        {

        }

        private void VES_But_Search_Click(object sender, EventArgs e)
        {
            PopulateVES();
        }

        public Boolean PopulateVES()
        {
            this.VES_DGV_Sales.DataSource = null;
            this.VES_DGV_Sales.Rows.Clear();
            string salesdate = VES_But_Date.Value.ToString("yyyy-MM-dd");
            string vesdate = salesdate + " 00:00:00";
            string query1 = "DATE, ROWID, TOTAL_SALES, CASH, CHARGE, CREDIT_CARD, ";
            string chkquery = "\"CHECK\" ";
            string query2 = ", GIFT_CHECK, COUPON, TAX_CERT, PO from SALES where DATE ='" + vesdate + "' AND BRANCH= '" + VES_DD_Branch.Text + "'";



            Boolean IsSuccess = true;
            BalanseConn VESConn = new BalanseConn();

            DataTable VESItems = VESConn.SelectQuery(@"select " + query1 + chkquery + query2);

            if (VESItems.Rows.Count < 1)
            {
                IsSuccess = false;
                MessageBox.Show("No records were found.");
            }
            else
            {
                foreach (DataRow row in VESItems.Rows)
                {
                    string date = DateTime.Parse(row[0].ToString()).ToString("MM/dd/yyyy");
                    string rowid = row[1].ToString();

                    decimal total_sales = Decimal.Parse(row[2].ToString());
                    decimal cash = 0;
                    if (row[3] != DBNull.Value)
                    {
                        cash = Decimal.Parse(row[3].ToString());
                    }

                    decimal charge = 0;
                    if (row[4] != DBNull.Value)
                    {
                        charge = Decimal.Parse(row[4].ToString());
                    }
                    decimal cc = 0;
                    if (row[5] != DBNull.Value)
                    {
                        cc = Decimal.Parse(row[5].ToString());
                    }
                    decimal check = 0;
                    if (row[6] != DBNull.Value)
                    {
                        check = Decimal.Parse(row[6].ToString());
                    }
                    decimal gc = 0;
                    if (row[7] != DBNull.Value)
                    {
                        gc = Decimal.Parse(row[7].ToString());
                    }
                    decimal coupon = 0;
                    if (row[8] != DBNull.Value)
                    {
                        coupon = Decimal.Parse(row[8].ToString());
                    }
                    decimal tc = 0;
                    if (row[9] != DBNull.Value)
                    {
                        tc = Decimal.Parse(row[9].ToString());
                    }
                    decimal po = 0;
                    if (row[10] != DBNull.Value)
                    {
                        po = Decimal.Parse(row[10].ToString());
                    }

                    VES_DGV_Sales.Rows.Add(
                        date,
                        rowid,
                        total_sales.ToString("#,##0.00"),
                        cash.ToString("#,##0.00"),
                        charge.ToString("#,##0.00"),
                        cc.ToString("#,##0.00"),
                        check.ToString("#,##0.00"),
                        gc.ToString("#,##0.00"),
                        coupon.ToString("#,##0.00"),
                        tc.ToString("#,##0.00"),
                        po.ToString("#,##0.00"));
                }
            }
            return IsSuccess;
        }

        public Boolean PopulateVED()
        {
            this.VED_DGV_Exp.DataSource = null;
            this.VED_DGV_Dep.DataSource = null;
            this.VED_DGV_Exp.Rows.Clear();
            this.VED_DGV_Dep.Rows.Clear();
            string salesdate = VED_But_Date.Value.ToString("yyyy-MM-dd");
            string vesdate = salesdate + " 00:00:00";
            string q1 = "DATE, ROWID, CASH, ENC_CHECK, ";
            string q2 = "\"CHECK\" ";
            string q3 = "FROM DEPOSITS WHERE DATE= '" + vesdate + "' AND BRANCH= '" + VED_DD_Branch.Text + "'";


            Boolean IsSuccess = true;
            BalanseConn VESConn = new BalanseConn();

            DataTable VEDExpItems = VESConn.SelectQuery(@"SELECT DATE, ROWID, TOTAL_EXPENSES, PCF, WTX, REFUND, OTHERS FROM EXPENSES WHERE DATE= '" + vesdate + "' AND BRANCH= '" + VED_DD_Branch.Text + "'");
            DataTable VEDDepItems = VESConn.SelectQuery(@"SELECT " + q1 + q2 + q3);


            if (VEDExpItems.Rows.Count < 1 && VEDDepItems.Rows.Count < 1)
            {
                IsSuccess = false;
                MessageBox.Show("No records were found.");
            }
            else
            {
                foreach (DataRow row in VEDExpItems.Rows)
                {
                    string date = DateTime.Parse(row[0].ToString()).ToString("MM/dd/yyyy");
                    string rowid = row[1].ToString();

                    decimal expenses = 0;
                    if (row[2] != DBNull.Value)
                    {
                        expenses = Decimal.Parse(row[2].ToString());
                    }

                    decimal pcf = 0;
                    if (row[3] != DBNull.Value)
                    {
                        pcf = Decimal.Parse(row[3].ToString());
                    }
                    decimal wtx = 0;
                    if (row[4] != DBNull.Value)
                    {
                        wtx = Decimal.Parse(row[4].ToString());
                    }

                    decimal refund = 0;
                    if (row[5] != DBNull.Value)
                    {
                        refund = Decimal.Parse(row[5].ToString());
                    }
                    decimal others = 0;
                    if (row[6] != DBNull.Value)
                    {
                        others = Decimal.Parse(row[6].ToString());
                    }
                    VED_DGV_Exp.Rows.Add(
                        date,
                        rowid,
                        expenses.ToString("#,##0.00"),
                        pcf.ToString("#,##0.00"),
                        wtx.ToString("#,##0.00"),
                        refund.ToString("#,##0.00"),
                        others.ToString("#,##0.00"));
                }

                foreach (DataRow row in VEDDepItems.Rows)
                {
                    string date = DateTime.Parse(row[0].ToString()).ToString("MM/dd/yyyy");
                    string rowid = row[1].ToString();

                    decimal cash = 0;
                    if (row[2] != DBNull.Value)
                    {
                        cash = Decimal.Parse(row[2].ToString());
                    }
                    decimal enc_check = 0;
                    if (row[3] != DBNull.Value)
                    {
                        enc_check = Decimal.Parse(row[3].ToString());
                    }

                    decimal check = 0;
                    if (row[4] != DBNull.Value)
                    {
                        check = Decimal.Parse(row[4].ToString());
                    }

                    VED_DGV_Dep.Rows.Add(
                        date,
                        rowid,
                        cash.ToString("#,##0.00"),
                        enc_check.ToString("#,##0.00"),
                        check.ToString("#,##0.00"));
                }
            }
            return IsSuccess;
        }
        private void VES_DGV_Sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            VES_Subform VESSubform = new VES_Subform(VES_DGV_Sales.Rows[e.RowIndex], VES_L_User.Text);
            VESSubform.ShowDialog();

        }

        private void VED_But_Search_Click(object sender, EventArgs e)
        {
         PopulateVED();
        }

        private void VED_DGV_Exp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VEE_Subform VEESubform = new VEE_Subform(VED_DGV_Exp.Rows[e.RowIndex], VED_L_User.Text);
            VEESubform.ShowDialog();
        }

        private void D_TB_Cash1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Cash2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Cash3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Cash4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Enc1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Enc3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Enc2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Enc4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Check1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Check3_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Check2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Check4_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateDepositTotals();
        }

        private void D_TB_Cash1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Cash3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Cash2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Cash4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Enc1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Enc3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Enc2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Enc4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Check1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Check3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Check2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void D_TB_Check4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void E_B_Add_Click(object sender, EventArgs e)
        {

            string Date = E_But_Date.Value.ToString("yyyy-MM-dd");
            string ExpDate = Date + " 00:00:00";
            string Branch = E_DD_Branch.Text;
            AddExpenses();
            MessageBox.Show("Record added");
            ResetExpenses();
        }

        private void D_But_Add_Click(object sender, EventArgs e)
        {
            string Date = D_But_Date.Value.ToString("yyyy-MM-dd");
            string DepDate = Date + " 00:00:00";
            string Branch = D_DD_Branch.Text;
            AddDeposit();
            MessageBox.Show("Record added");
            ResetDeposit();
        }

        private void D_But_Reset_Click(object sender, EventArgs e)
        {
            ResetDeposit();
        }

        private void VED_DGV_Dep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VED_Subform VEDSubform = new VED_Subform(VED_DGV_Dep.Rows[e.RowIndex], VED_L_User.Text);
            VEDSubform.ShowDialog();

        }
    }
}
