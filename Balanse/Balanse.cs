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
            ED_L_User.Text = name;
            PO_L_User.Text = name;
            Su_L_User.Text = name;
            An_L_User.Text = name;
            
            BalanseConn conn = new BalanseConn();
            DateTime DATE = S_But_Date.Value;
            String BRANCH = S_DD_Branch.Text;

            DateTime REC_DT = DateTime.Today;
            //testdate.Text = REC_DT.ToString("MMM-yyyy");

            DataTable branch = conn.SelectQuery("SELECT BRANCH_NAME FROM BRANCH");
            Dictionary<String, String> test = new Dictionary<string, string>();
            int i = 0;
            foreach (DataRow row in branch.Rows)
            {
                test.Add(i.ToString(), row[0].ToString());
                i++;
            }
            S_DD_Branch.DataSource = new BindingSource(test, null);
            ED_DD_Branch.DataSource = new BindingSource(test, null);
            PO_DD_Branch.DataSource = new BindingSource(test, null);
            Su_DD_Branch.DataSource = new BindingSource(test, null);
            An_DD_Branch.DataSource = new BindingSource(test, null);
            S_DD_Branch.DisplayMember = "Value";
            ED_DD_Branch.DisplayMember = "Value";
            PO_DD_Branch.DisplayMember = "Value";
            Su_DD_Branch.DisplayMember = "Value";
            An_DD_Branch.DisplayMember = "Value";
            S_DD_Branch.ValueMember = "Key";
            ED_DD_Branch.ValueMember = "Key";
            PO_DD_Branch.ValueMember = "Key";
            Su_DD_Branch.ValueMember = "Key";
            An_DD_Branch.ValueMember = "Key";

            //month drop down
            DataTable mon = conn.SelectQuery("select distinct case strftime('%m', date) when '01' then 'JAN' when '02' then 'FEB' when '03' then 'MAR' when '04' then 'APR' when '05' then 'MAY' when '06' then 'JUN' when '07' then 'JUL' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' end as Month from sales order by strftime('%m', date) asc");
            Dictionary<String, String> MonSelection = new Dictionary<string, string>();
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
            //year drop down
            DataTable year = conn.SelectQuery("select distinct strftime('%Y', date) from sales");
            Dictionary<String, String> YrSelection = new Dictionary<string, string>();
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

        //to check if textbox is empty
        public Boolean IsEmpty(string item)
        {
            if (item.Length <= 0)
            {
                return true;
            }
            else return false;
        }
        //to check if RepNum is unique
        public Boolean RepNoExists(string Table, int RepNo, string Date, string Branch)
        {
            BalanseConn conn = new BalanseConn();

            DataTable RepNums = conn.SelectQuery("SELECT REPORT_NO FROM " +Table+ " WHERE DATE= '"+Date+ "' AND REPORT_NO= " +RepNo+" AND BRANCH= '"+Branch+"'");
            if (RepNums.Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        private int AddSalesTransaction()
        {
            BalanseConn InsertSalesTransactionConn = new BalanseConn();
            int RepNo = Convert.ToInt32(S_TB_RepNum.Text);
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
            int SalesID = InsertSalesTransactionConn.InsertSales(RepNo, DATE, BRANCH, TOTAL_SALES, CASH, CHARGE, CREDIT_CARD, CREDIT_CARD1, CREDIT_CARD2, CREDIT_CARD3, CREDIT_CARD4, CREDIT_CARD5, CREDIT_CARD6, CREDIT_CARD7, CREDIT_CARD8, CREDIT_CARD9, CREDIT_CARD10,
                CHECK, GOV_CHECK, PER_CHECK, GIFT_CHECK, COUPON, TAX_CERT, PO, COMMENTS, REC_DT, ENCODED_BY);
            
            String POStatus = "Unpaid";

            if (!IsEmpty(S_TB_POName1.Text) && !IsEmpty(S_TB_POAmt1.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName1.Text, Convert.ToDouble(S_TB_POAmt1.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName2.Text) && !IsEmpty(S_TB_POAmt2.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo, SalesID, DATE, BRANCH, S_TB_POName2.Text, Convert.ToDouble(S_TB_POAmt2.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName3.Text) && !IsEmpty(S_TB_POAmt3.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo, SalesID, DATE, BRANCH, S_TB_POName3.Text, Convert.ToDouble(S_TB_POAmt3.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName4.Text) && !IsEmpty(S_TB_POAmt4.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName4.Text, Convert.ToDouble(S_TB_POAmt4.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName5.Text) && !IsEmpty(S_TB_POAmt5.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName5.Text, Convert.ToDouble(S_TB_POAmt5.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName6.Text) && !IsEmpty(S_TB_POAmt6.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName6.Text, Convert.ToDouble(S_TB_POAmt6.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName7.Text) && !IsEmpty(S_TB_POAmt7.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName7.Text, Convert.ToDouble(S_TB_POAmt7.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName8.Text) && !IsEmpty(S_TB_POAmt8.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName8.Text, Convert.ToDouble(S_TB_POAmt8.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName9.Text) && !IsEmpty(S_TB_POAmt9.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo,SalesID, DATE, BRANCH, S_TB_POName9.Text, Convert.ToDouble(S_TB_POAmt9.Text), POStatus, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(S_TB_POName10.Text) && !IsEmpty(S_TB_POAmt10.Text))
            {
                InsertSalesTransactionConn.InsertPO(RepNo, SalesID, DATE, BRANCH, S_TB_POName10.Text, Convert.ToDouble(S_TB_POAmt10.Text), POStatus, REC_DT, ENCODED_BY);
            }
            return SalesID;
        }
        private int AddExpenses()
        {
            BalanseConn InsertExpTransactionConn = new BalanseConn();
            int REPNO = Convert.ToInt32(ED_TB_ReportNum.Text);
            DateTime DATE = ED_But_Date.Value.Date;
            String BRANCH = ED_DD_Branch.Text;
            Double PCF1 = IsEmpty(ED_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF1.Text);
            Double PCF2 = IsEmpty(ED_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF2.Text);
            Double PCF3 = IsEmpty(ED_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF3.Text);
            Double PCF4 = IsEmpty(ED_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            ED_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(ED_TB_WTX.Text) ? 0.00 : Convert.ToDouble(ED_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(ED_TB_Ref.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(ED_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(ED_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(ED_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(ED_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth4.Text);
            Double OTHERS = IsEmpty(ED_TB_OthTotal.Text) ? 0.00 : Convert.ToDouble(ED_TB_OthTotal.Text);


            //Total Exp
            Double TOTAL_EXPENSES = IsEmpty(ED_TB_TotalExp.Text) ? 0.00 : Convert.ToDouble(ED_TB_TotalExp.Text);
            String EXP_COMMENTS = ED_RTB_ExpComm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = ED_L_User.Text;
            int ExpenseID = InsertExpTransactionConn.InsertExpenses(REPNO, DATE, BRANCH, PCF, PCF1, PCF2, PCF3, PCF4, WTX, REFUND, OTHERS, OTHERS1, OTHERS2, OTHERS3, OTHERS4,TOTAL_EXPENSES, EXP_COMMENTS, REC_DT, ENCODED_BY);
            return ExpenseID;


        }
        private int AddDeposit()
        {
            BalanseConn InsertDepTransactionConn = new BalanseConn();
            int REPNO = Convert.ToInt32(ED_TB_ReportNum.Text);

            DateTime DATE = ED_But_Date.Value.Date;
            String BRANCH = ED_DD_Branch.Text;
            //CASH
            Double CASHDEP1 = IsEmpty(ED_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(ED_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(ED_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(ED_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash4.Text);
            Double CASHDEP = IsEmpty(ED_TB_CashTotal.Text) ? 0.00 : Convert.ToDouble(ED_TB_CashTotal.Text);
            //ENC CHECK
            Double ENC1 = IsEmpty(ED_TB_EncCh1.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh1.Text);
            Double ENC2 = IsEmpty(ED_TB_EncCh2.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh2.Text);
            Double ENC3 = IsEmpty(ED_TB_EncCh3.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh3.Text);
            Double ENC4 = IsEmpty(ED_TB_EncCh4.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh4.Text);
            Double ENC = IsEmpty(ED_TB_EncChTotal.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncChTotal.Text);
            //CHECK
            Double CHECKDEP1 = IsEmpty(ED_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(ED_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(ED_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(ED_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch4.Text);
            Double CHECKDEP = IsEmpty(ED_TB_ChTotal.Text) ? 0.00 : Convert.ToDouble(ED_TB_ChTotal.Text);
            //Total Dep
            Double TOTAL_DEP = IsEmpty(ED_TB_TotalDep.Text) ? 0.00 : Convert.ToDouble(ED_TB_TotalDep.Text);
            String DEP_COMMENTS = ED_RTB_DepComm.Text;
            DateTime REC_DT = DateTime.Now;
            String ENCODED_BY = ED_L_User.Text;
            // insert TOTALS to DEPOSIT SUMMARY
            int DepID=InsertDepTransactionConn.InsertDepositSummary(REPNO, DATE, BRANCH, CASHDEP, ENC, CHECKDEP, TOTAL_DEP, DEP_COMMENTS, REC_DT, ENCODED_BY);
            //insert DETAILS to DEPOSIT
            if (!IsEmpty(ED_TB_Cash1.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CASH", CASHDEP1, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Cash2.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CASH", CASHDEP2, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Cash3.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CASH", CASHDEP3, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Cash4.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CASH", CASHDEP4, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_EncCh1.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "ENC CHECK", ENC1, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_EncCh2.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "ENC CHECK", ENC2, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_EncCh3.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "ENC CHECK", ENC3, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_EncCh4.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "ENC CHECK", ENC4, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Ch1.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CHECK", CHECKDEP1, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Ch2.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CHECK", CHECKDEP2, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Ch3.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CHECK", CHECKDEP3, REC_DT, ENCODED_BY);
            }
            if (!IsEmpty(ED_TB_Ch4.Text))
            {
                InsertDepTransactionConn.InsertDeposit(DepID, REPNO, DATE, BRANCH, "CHECK", CHECKDEP4, REC_DT, ENCODED_BY);
            }
            return DepID;
            
        }
        //Sales Tab Add Sales Button
        private void S_But_Add_Click(object sender, EventArgs e)
        {
            if (!IsEmpty(S_TB_Total.Text) && !IsEmpty(S_TB_RepNum.Text))
            {
                int RepNum = Convert.ToInt32(S_TB_RepNum.Text);
                string Date = (S_But_Date.Value.ToString("yyyy-MM-dd"));
                string SalesDate = Date + " 00:00:00";
                String Branch = S_DD_Branch.Text;

                if (!RepNoExists("SALES", RepNum, SalesDate, Branch))
                {
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
                else MessageBox.Show("Report Number already exists for that date and branch");
            }
            else MessageBox.Show("Total Sales and Report Number cannot be empty");
        }
        //Add Expenses and Deposits
        private void ED_B_Add_Click(object sender, EventArgs e)
        {

            if (!IsEmpty(ED_TB_ReportNum.Text))
            {
                int RepNum = Convert.ToInt32(ED_TB_ReportNum.Text);
                string Date = ED_But_Date.Value.ToString("yyyy-MM-dd");
                string DepExpDate = Date + " 00:00:00";
                string Branch = ED_DD_Branch.Text;
                if (!RepNoExists("DEPOSIT_SUMMARY", RepNum, DepExpDate, Branch))
                {
                    AddExpenses();
                    AddDeposit();
                    MessageBox.Show("Record added");
                    ResetExpensesDeposits();
                }
                else MessageBox.Show("Report Number already exists for this date and branch");            
            }
            else MessageBox.Show("Report Number cannot be Empty");
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
            S_TB_RepNum.Text = "";
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
            S_TB_Charge.Text = "";
            S_TB_RunTotal.Text = "";
        }
        //Expenses and Deposits Tab Update Total Expenses
        private void UpdateExpensesTotals()
        {
            Double PCF1 = IsEmpty(ED_TB_PCF1.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF1.Text);
            Double PCF2 = IsEmpty(ED_TB_PCF2.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF2.Text);
            Double PCF3 = IsEmpty(ED_TB_PCF3.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF3.Text);
            Double PCF4 = IsEmpty(ED_TB_PCF4.Text) ? 0.00 : Convert.ToDouble(ED_TB_PCF4.Text);
            Double PCF = PCF1 + PCF2 + PCF3 + PCF4;
            ED_TB_PCFTotal.Text = Convert.ToString(PCF);

            //wtx
            Double WTX = IsEmpty(ED_TB_WTX.Text) ? 0.00 : Convert.ToDouble(ED_TB_WTX.Text);
            //Refund
            Double REFUND = IsEmpty(ED_TB_Ref.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ref.Text);

            //others
            Double OTHERS1 = IsEmpty(ED_TB_Oth1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth1.Text);
            Double OTHERS2 = IsEmpty(ED_TB_Oth2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth2.Text);
            Double OTHERS3 = IsEmpty(ED_TB_Oth3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth3.Text);
            Double OTHERS4 = IsEmpty(ED_TB_Oth4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Oth4.Text);
            Double OTHERS = OTHERS1 + OTHERS2 + OTHERS3 + OTHERS4;
            ED_TB_OthTotal.Text = Convert.ToString(OTHERS);

            //Total Exp
            Double TOTAL_EXPENSES = PCF + WTX + REFUND + OTHERS;
            ED_TB_TotalExp.Text = Convert.ToString(TOTAL_EXPENSES);
        }
        //Expenses and Deposits Tab Update Total Deposits
        private void UpdateDepositTotals()
        {
            //CASH
            Double CASHDEP1 = IsEmpty(ED_TB_Cash1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash1.Text);
            Double CASHDEP2 = IsEmpty(ED_TB_Cash2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash2.Text);
            Double CASHDEP3 = IsEmpty(ED_TB_Cash3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash3.Text);
            Double CASHDEP4 = IsEmpty(ED_TB_Cash4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Cash4.Text);
            Double CASHDEP = CASHDEP1 + CASHDEP2 + CASHDEP3 + CASHDEP4;
            ED_TB_CashTotal.Text = Convert.ToString(CASHDEP);

            //ENC CHECK
            Double ENC1 = IsEmpty(ED_TB_EncCh1.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh1.Text);
            Double ENC2 = IsEmpty(ED_TB_EncCh2.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh2.Text);
            Double ENC3 = IsEmpty(ED_TB_EncCh3.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh3.Text);
            Double ENC4 = IsEmpty(ED_TB_EncCh4.Text) ? 0.00 : Convert.ToDouble(ED_TB_EncCh4.Text);
            Double ENC = ENC1 + ENC2 + ENC3 + ENC4;
            ED_TB_EncChTotal.Text = Convert.ToString(ENC);

            //CHECK
            Double CHECKDEP1 = IsEmpty(ED_TB_Ch1.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch1.Text);
            Double CHECKDEP2 = IsEmpty(ED_TB_Ch2.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch2.Text);
            Double CHECKDEP3 = IsEmpty(ED_TB_Ch3.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch3.Text);
            Double CHECKDEP4 = IsEmpty(ED_TB_Ch4.Text) ? 0.00 : Convert.ToDouble(ED_TB_Ch4.Text);
            Double CHECKDEP = CHECKDEP1 + CHECKDEP2 + CHECKDEP3 + CHECKDEP4;
            ED_TB_ChTotal.Text= Convert.ToString(CHECKDEP);

            //Total Dep
            Double TOTAL_DEP = CASHDEP + ENC + CHECKDEP;

            ED_TB_TotalDep.Text = Convert.ToString(TOTAL_DEP);
        }
        //Reset Expenses and Deposits Text Boxes
        public void ResetExpensesDeposits()
        {
            ED_TB_ReportNum.Text = "";
            ED_TB_PCF1.Text="";
            ED_TB_PCF2.Text="";
            ED_TB_PCF3.Text="";
            ED_TB_PCF4.Text="";
            ED_TB_PCFTotal.Text="";
            ED_TB_WTX.Text="";
            ED_TB_Ref.Text="";
            ED_TB_Oth1.Text="";
            ED_TB_Oth2.Text="";
            ED_TB_Oth3.Text="";
            ED_TB_Oth4.Text="";
            ED_TB_OthTotal.Text = "";
            ED_TB_TotalExp.Text = "";
            ED_TB_Cash1.Text="";
            ED_TB_Cash2.Text="";
            ED_TB_Cash3.Text="";
            ED_TB_Cash4.Text="";
            ED_TB_CashTotal.Text = "";
            ED_TB_EncCh1.Text="";
            ED_TB_EncCh2.Text="";
            ED_TB_EncCh3.Text="";
            ED_TB_EncCh4.Text="";
            ED_TB_EncChTotal.Text = "";
            ED_TB_Ch1.Text="";
            ED_TB_Ch2.Text="";
            ED_TB_Ch3.Text="";
            ED_TB_Ch4.Text="";
            ED_TB_ChTotal.Text = "";
            ED_TB_TotalDep.Text = "";
            ED_RTB_ExpComm.Text = "";
            ED_RTB_DepComm.Text = "";
        }
        
        public void ResetPOSearch()
        {
            PO_DD_Branch.Text = "";
            PO_TB_CustNameSearch.Text = "";
        }

        public Boolean PopulatePODataGrid()
        {
            ResetPOSearch();
            this.PO_DGV_POItems.DataSource = null;
            this.PO_DGV_POItems.Rows.Clear();
            
            Boolean IsSuccess = true;
            String whereClause = "";
            string PODate = "";
            if (PO_TB_CustNameSearch.Text.Length > 0)
            {
                String CustName = PO_TB_CustNameSearch.Text;
                whereClause += "UPPER(CUSTOMER_NAME) LIKE UPPER(' " +(PO_TB_CustNameSearch.Text)+ "')";
            }
            
            if (chkSearchByPo_Date.Checked)
            {
                if(whereClause.Length > 0)
                {
                    whereClause += " AND ";
                }
                PODate = PO_But_Date.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                whereClause = "A.PO_DATE = '" + PODate + "'";
            }
            
            if(PO_DD_Branch.Text.Length > 0)
            {
                if (whereClause.Length > 0)
                {
                    whereClause += " AND ";
                }
                whereClause += "A.BRANCH = '" + PO_DD_Branch.Text + "'";
            }
            if (whereClause.Length > 0)
            {
                whereClause = " WHERE " + whereClause;
            }

            BalanseConn POConn = new BalanseConn();
            DataTable POItems = POConn.SelectQuery(@"SELECT
                                               A.ROWID,
                                               A.BRANCH, 
                                               A.PO_DATE,
                                               A.CUSTOMER_NAME, 
                                               A.PO_AMOUNT,
                                               A.PO_STATUS,
                                               SUM(B.PAID_AMOUNT)
                                               FROM PURCHASE_ORDERS A LEFT JOIN PO_PAYMENTS B
                                               ON
                                                    a.rowid = b.po_id" +  
                                                    //A.PO_DATE = B.PO_DATE 
                                                    //AND A.BRANCH = B.BRANCH 
                                                    //AND A.CUSTOMER_NAME = B.CUSTOMER_NAME 
                                                    //AND A.PO_AMOUNT = B.PO_AMOUNT" +
                                                    whereClause
                                               );
            
            if (POItems.Rows.Count < 1)
            {
                IsSuccess = false;
                MessageBox.Show("No records match with the details provided.");

            }
            else
            foreach (DataRow row in POItems.Rows)
                {
                    string rowid = row[0].ToString();
                    string Branch = row[1].ToString();
                    string PO_Date = DateTime.Parse(row[2].ToString()).ToString("MM/dd/yyyy");
                    string CustomerName = row[3].ToString();
                    
                    decimal POAmount = Decimal.Parse(row[4].ToString());
                    string POStatus = row[5].ToString();
                    
                    string PayType = "";
                    if (row[6]!=DBNull.Value)
                    {
                        PayType = row[6].ToString();
                    }
                    else PayType = "";
                    
                    decimal PayAmount = 0;
                    if (row[6] != DBNull.Value)
                    {
                       PayAmount = Decimal.Parse(row[6].ToString());
                    }

                    /*string PayDate="";
                    if (row[8] != DBNull.Value)
                    {
                        PayDate = DateTime.Parse(row[8].ToString()).ToString("MM/dd/yyyy");
                    }

                    else PayDate = "";*/
                   

                    PO_DGV_POItems.Rows.Add(
                        rowid,
                        Branch,
                        PO_Date,
                        CustomerName,
                        POAmount.ToString("#,##0.00"),
                        POStatus,
                        (POAmount-PayAmount).ToString("#,##0.00"));                     
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
            ResetExpensesDeposits();
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
            PO_Payment_Subform POPayment = new PO_Payment_Subform(PO_DGV_POItems.Rows[e.RowIndex], ED_L_User.Text);
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
                DataTable SalesItems = SummaryConn.SelectQuery(@"select strftime('%d',date), sum(total_sales), sum(cash), sum(charge), sum(credit_card), sum('check'), sum(gift_check), sum(coupon), sum(tax_cert),sum(po), comments from sales where strftime('%Y',date)='" + Su_DD_Year.Text + "' and case strftime('%m', date) when '01' then 'JANUARY' when '02' then 'FEBRUARY' when '03' then 'MARCH' when '04' then 'APRIL' when '05' then 'MAY' when '06' then 'JUNE' when '07' then 'JULY' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' END ='" + Su_DD_Month.Text + "' group by strftime('%d',date)");
                if (SalesItems.Rows.Count < 1)
                {
                    IsSuccess = false;
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

                        decimal credit_card = 0;
                        if (row[4] != DBNull.Value)
                        {
                            credit_card = Decimal.Parse(row[4].ToString());
                        }

                        decimal check = 0;
                        if (row[5] != DBNull.Value)
                        {
                            check = Decimal.Parse(row[5].ToString());
                        }
                        decimal gift_check = 0;
                        if (row[6] != DBNull.Value)
                        {
                            gift_check = Decimal.Parse(row[6].ToString());
                        }

                        decimal coupon = 0;
                        if (row[7] != DBNull.Value)
                        {
                            coupon = Decimal.Parse(row[7].ToString());
                        }

                        decimal tax_cert = 0;

                        if (row[8] != DBNull.Value)
                        {
                            tax_cert = Decimal.Parse(row[8].ToString());
                        }

                        decimal po = 0;
                        if (row[9] != DBNull.Value)
                        {
                            po = Decimal.Parse(row[9].ToString());
                        }

                        string comments = row[10].ToString();
                        Su_DGV_Sales.Rows.Add(
                        day,
                        total_sales.ToString("#,##0.00"),
                        cash.ToString("#,##0.00"),
                        charge.ToString("#,##0.00"),
                        credit_card.ToString("#,##0.00"),
                        check.ToString("#,##0.00"),
                        gift_check.ToString("#,##0.00"),
                        coupon.ToString("#,##0.00"),
                        tax_cert.ToString("#,##0.00"),
                        po.ToString("#,##0.00"),
                        comments);

                        Su_L_RepName.Text = Su_DD_Month.Text+ " " + Su_DD_Year.Text+ " SALES SUMMARY FOR ALL BRANCHES";
                    }
                }
                return IsSuccess;
            }
            else
            {

                DataTable SalesItems = SummaryConn.SelectQuery(@"select strftime('%d',date), sum(total_sales), sum(cash), sum(charge), sum(credit_card), sum('check'), sum(gift_check), sum(coupon), sum(tax_cert),sum(po), comments from sales where strftime('%Y',date)='" + Su_DD_Year.Text + "' and case strftime('%m', date) when '01' then 'JANUARY' when '02' then 'FEBRUARY' when '03' then 'MARCH' when '04' then 'APRIL' when '05' then 'MAY' when '06' then 'JUNE' when '07' then 'JULY' when '08' then 'AUGUST' when '09' then 'SEPTEMBER' when '10' then 'OCTOBER' when '11' then 'NOVEMBER' when '12' then 'DECEMBER' else 'N/A' END ='" + Su_DD_Month.Text + "' and branch='" + Su_DD_Branch.Text + "' group by strftime('%d',date)");
                if (SalesItems.Rows.Count < 1)
                {
                    IsSuccess = false;
                    ResetMonthlySalesSearch();
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

                        decimal credit_card = 0;
                        if (row[4] != DBNull.Value)
                        {
                            credit_card = Decimal.Parse(row[4].ToString());
                        }

                        decimal check = 0;
                        if (row[5] != DBNull.Value)
                        {
                            check = Decimal.Parse(row[5].ToString());
                        }
                        decimal gift_check = 0;
                        if (row[6] != DBNull.Value)
                        {
                            gift_check = Decimal.Parse(row[6].ToString());
                        }

                        decimal coupon = 0;
                        if (row[7] != DBNull.Value)
                        {
                            coupon = Decimal.Parse(row[7].ToString());
                        }

                        decimal tax_cert = 0;

                        if (row[8] != DBNull.Value)
                        {
                            tax_cert = Decimal.Parse(row[8].ToString());
                        }

                        decimal po = 0;
                        if (row[9] != DBNull.Value)
                        {
                            po = Decimal.Parse(row[9].ToString());
                        }
                        string comments = row[10].ToString();

                        Su_L_RepName.Text = Su_DD_Month.Text + " " + Su_DD_Year.Text + " SALES SUMMARY FOR " + Su_DD_Branch.Text;
                        Su_DGV_Sales.Rows.Add(
                        day,
                        total_sales.ToString("#,##0.00"),
                        cash.ToString("#,##0.00"),
                        charge.ToString("#,##0.00"),
                        credit_card.ToString("#,##0.00"),
                        check.ToString("#,##0.00"),
                        gift_check.ToString("#,##0.00"),
                        coupon.ToString("#,##0.00"),
                        tax_cert.ToString("#,##0.00"),
                        po.ToString("#,##0.00"),
                        comments);
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
    }
}
