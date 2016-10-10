using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using System.Data.SQLite; 
using System.Data; 
using System.Windows.Forms;

namespace Balanse
{
    public class BalanseConn
    {
        public DataTable SelectQuery(string QueryString)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source= C:\\BalanseData\\Balanse"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();


                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    DataTable dt = sh.Select(QueryString + ";");
                    conn.Close();


                    return dt;
                }
            }
        }
        public int InsertQuery(string Table, Dictionary<string, object> Parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source=C:\\BalanseData\\Balanse"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);
                    sh.Insert(Table, Parameters);
                    int Id = Convert.ToInt32(sh.LastInsertRowId());
                    conn.Close();
                    return Id;
                }
            }

        }
        public int InsertSales(int ReportNo, DateTime SalesDate, string Branch, double TotalSales, double Cash, double Charge, double CreditCard, double CreditCard1,
            double CreditCard2, double CreditCard3, double CreditCard4, double CreditCard5, double CreditCard6, double CreditCard7,
            double CreditCard8, double CreditCard9, double CreditCard10, double Check, double GovCheck, double PerCheck, double GiftCheck, double Coupon, double TaxCert, double PO, string Comments, DateTime RecDt, string EncodedBy)
        {
            Dictionary<string, object> InsertSalesParameters = new Dictionary<string, object>();
            InsertSalesParameters.Add("REPORT_NO", ReportNo);
            InsertSalesParameters.Add("DATE", SalesDate);
            InsertSalesParameters.Add("BRANCH", Branch);
            InsertSalesParameters.Add("TOTAL_SALES", TotalSales);
            InsertSalesParameters.Add("CASH", Cash);
            InsertSalesParameters.Add("CHARGE", Charge);
            InsertSalesParameters.Add("CREDIT_CARD", CreditCard);
            InsertSalesParameters.Add("CREDIT_CARD1", CreditCard1);
            InsertSalesParameters.Add("CREDIT_CARD2", CreditCard2);
            InsertSalesParameters.Add("CREDIT_CARD3", CreditCard3);
            InsertSalesParameters.Add("CREDIT_CARD4", CreditCard4);
            InsertSalesParameters.Add("CREDIT_CARD5", CreditCard5);
            InsertSalesParameters.Add("CREDIT_CARD6", CreditCard6);
            InsertSalesParameters.Add("CREDIT_CARD7", CreditCard7);
            InsertSalesParameters.Add("CREDIT_CARD8", CreditCard8);
            InsertSalesParameters.Add("CREDIT_CARD9", CreditCard9);
            InsertSalesParameters.Add("CREDIT_CARD10", CreditCard10);
            InsertSalesParameters.Add("CHECK", Check);
            InsertSalesParameters.Add("GOV_CHECK", GovCheck);
            InsertSalesParameters.Add("PER_CHECK", PerCheck);
            InsertSalesParameters.Add("GIFT_CHECK", GiftCheck);
            InsertSalesParameters.Add("COUPON", Coupon);
            InsertSalesParameters.Add("TAX_CERT", TaxCert);
            InsertSalesParameters.Add("PO", PO);
            InsertSalesParameters.Add("REC_DT", RecDt);
            InsertSalesParameters.Add("ENCODED_BY", EncodedBy);
            int SalesId = InsertQuery("SALES", InsertSalesParameters);
            return SalesId;
        }

        public int InsertPO(int ReportNo, int SalesId, DateTime PODate, string Branch, string POName, double POAmt, string POStatus, DateTime PORecDate, string POEncodedBy)
        {
            Dictionary<string, object> InsertPOParameters = new Dictionary<string, object>();
            InsertPOParameters.Add("SALES_ID", SalesId);
            InsertPOParameters.Add("REPORT_NO", ReportNo);
            InsertPOParameters.Add("PO_DATE", PODate);
            InsertPOParameters.Add("BRANCH", Branch);
            InsertPOParameters.Add("CUSTOMER_NAME", POName);
            InsertPOParameters.Add("PO_AMOUNT", POAmt);
            InsertPOParameters.Add("PO_STATUS", POStatus);
            InsertPOParameters.Add("REC_DT", PORecDate);
            InsertPOParameters.Add("ENCODED_BY", POEncodedBy);
            int POId = InsertQuery("PURCHASE_ORDERS", InsertPOParameters);
            return POId;
        }
        public int InsertExpenses(int ReportNum, DateTime ExpenseDate, string Branch, double Pcf, double Pcf1, double Pcf2, double Pcf3, double Pcf4, double Wtx, double Refund,double Others, double Others1, double Others2, double Others3, double Others4, double TotalExp, string Comments, DateTime Recdt, string Encodedby)
        {
            Dictionary<string, object> InsertExpenseParameters = new Dictionary<string, object>();
            InsertExpenseParameters.Add("REPORT_NO", ReportNum);
            InsertExpenseParameters.Add("DATE", ExpenseDate);
            InsertExpenseParameters.Add("BRANCH", Branch);
            InsertExpenseParameters.Add("PCF", Pcf);
            InsertExpenseParameters.Add("PCF_1", Pcf1);
            InsertExpenseParameters.Add("PCF_2", Pcf2);
            InsertExpenseParameters.Add("PCF_3", Pcf3);
            InsertExpenseParameters.Add("PCF_4", Pcf4);
            InsertExpenseParameters.Add("WTX", Wtx);
            InsertExpenseParameters.Add("REFUND", Refund);
            InsertExpenseParameters.Add("OTHERS", Others);
            InsertExpenseParameters.Add("OTH_1", Others);
            InsertExpenseParameters.Add("OTH_2", Others);
            InsertExpenseParameters.Add("OTH_3", Others);
            InsertExpenseParameters.Add("OTH_4", Others);
            InsertExpenseParameters.Add("COMMENTS", Comments);
            InsertExpenseParameters.Add("TOTAL_EXPENSES", TotalExp);
            InsertExpenseParameters.Add("REC_DT", Recdt);
            InsertExpenseParameters.Add("ENCODED_BY", Encodedby);
            int ExpenseID = InsertQuery("EXPENSES", InsertExpenseParameters);
            return ExpenseID;
        }
        public int InsertDeposit(int DepSummID,int RepNo,DateTime Date, string Branch, string DepositType, double DepAmt, DateTime RecDt, string EncodedBy)
        {
            Dictionary<string, object> InsertDepositParameters = new Dictionary<string, object>();
            InsertDepositParameters.Add("DEPSUMM_ID", DepSummID);
            InsertDepositParameters.Add("REPORT_NO", RepNo);
            InsertDepositParameters.Add("DATE", Date);
            InsertDepositParameters.Add("BRANCH", Branch);
            InsertDepositParameters.Add("DEPOSIT_TYPE", DepositType);
            InsertDepositParameters.Add("AMOUNT", DepAmt);
            InsertDepositParameters.Add("REC_DT", RecDt);
            InsertDepositParameters.Add("ENCODED_BY", EncodedBy);
            int DepositID = InsertQuery("DEPOSIT", InsertDepositParameters);
            return DepositID;
        }
        public int InsertDepositSummary(int RepNo, DateTime Date, string Branch, double Cash, double EncCheck, double Check, double TotalDep, string Comments, DateTime RecDt, string EncodedBy)
        {
            Dictionary<string, object> InsertDepositSummParameters = new Dictionary<string, object>();
            InsertDepositSummParameters.Add("REPORT_NO", RepNo);
            InsertDepositSummParameters.Add("DATE", Date);
            InsertDepositSummParameters.Add("BRANCH", Branch);
            InsertDepositSummParameters.Add("CASH",Cash);
            InsertDepositSummParameters.Add("ENC_CHECK", EncCheck);
            InsertDepositSummParameters.Add("CHECK", Check);
            InsertDepositSummParameters.Add("TOTAL_DEPOSIT", TotalDep);
            InsertDepositSummParameters.Add("COMMENTS", Comments);
            InsertDepositSummParameters.Add("REC_DT", RecDt);
            InsertDepositSummParameters.Add("ENCODED_BY", EncodedBy);
            int DepositID = InsertQuery("DEPOSIT_SUMMARY", InsertDepositSummParameters);
            return DepositID;
        }
    
    }
}

