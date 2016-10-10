namespace Balanse
{
    partial class PO_Payment_Subform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.POPay_TB_Branch = new System.Windows.Forms.TextBox();
            this.POPay_TB_CustName = new System.Windows.Forms.TextBox();
            this.POPay_TB_POAmt = new System.Windows.Forms.TextBox();
            this.POPay_TB_PayAmt = new System.Windows.Forms.TextBox();
            this.POPay_But_PayDate = new System.Windows.Forms.DateTimePicker();
            this.POPay_RTB_Comm = new System.Windows.Forms.RichTextBox();
            this.POPay_DD_Status = new System.Windows.Forms.ComboBox();
            this.POSub_But_Save = new System.Windows.Forms.Button();
            this.POSub_But_Reset = new System.Windows.Forms.Button();
            this.POPay_CB_Deposit = new System.Windows.Forms.CheckBox();
            this.POPay_DD_PayType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.POPay_But_PODate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "PO Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "PO Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Payment Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(482, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(77, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Comments:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(482, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Branch:";
            // 
            // POPay_TB_Branch
            // 
            this.POPay_TB_Branch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_Branch.Location = new System.Drawing.Point(597, 79);
            this.POPay_TB_Branch.Name = "POPay_TB_Branch";
            this.POPay_TB_Branch.ReadOnly = true;
            this.POPay_TB_Branch.Size = new System.Drawing.Size(174, 25);
            this.POPay_TB_Branch.TabIndex = 11;
            // 
            // POPay_TB_CustName
            // 
            this.POPay_TB_CustName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_CustName.Location = new System.Drawing.Point(221, 124);
            this.POPay_TB_CustName.Name = "POPay_TB_CustName";
            this.POPay_TB_CustName.ReadOnly = true;
            this.POPay_TB_CustName.Size = new System.Drawing.Size(550, 25);
            this.POPay_TB_CustName.TabIndex = 12;
            // 
            // POPay_TB_POAmt
            // 
            this.POPay_TB_POAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_POAmt.Location = new System.Drawing.Point(221, 175);
            this.POPay_TB_POAmt.Name = "POPay_TB_POAmt";
            this.POPay_TB_POAmt.ReadOnly = true;
            this.POPay_TB_POAmt.Size = new System.Drawing.Size(174, 25);
            this.POPay_TB_POAmt.TabIndex = 13;
            // 
            // POPay_TB_PayAmt
            // 
            this.POPay_TB_PayAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_PayAmt.Location = new System.Drawing.Point(221, 267);
            this.POPay_TB_PayAmt.Name = "POPay_TB_PayAmt";
            this.POPay_TB_PayAmt.Size = new System.Drawing.Size(174, 25);
            this.POPay_TB_PayAmt.TabIndex = 14;
            // 
            // POPay_But_PayDate
            // 
            this.POPay_But_PayDate.CustomFormat = "MM/dd/yyyy";
            this.POPay_But_PayDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_But_PayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.POPay_But_PayDate.Location = new System.Drawing.Point(597, 217);
            this.POPay_But_PayDate.Name = "POPay_But_PayDate";
            this.POPay_But_PayDate.Size = new System.Drawing.Size(174, 25);
            this.POPay_But_PayDate.TabIndex = 15;
            // 
            // POPay_RTB_Comm
            // 
            this.POPay_RTB_Comm.Location = new System.Drawing.Point(80, 342);
            this.POPay_RTB_Comm.Name = "POPay_RTB_Comm";
            this.POPay_RTB_Comm.Size = new System.Drawing.Size(691, 246);
            this.POPay_RTB_Comm.TabIndex = 16;
            this.POPay_RTB_Comm.Text = "";
            // 
            // POPay_DD_Status
            // 
            this.POPay_DD_Status.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_DD_Status.FormattingEnabled = true;
            this.POPay_DD_Status.Items.AddRange(new object[] {
            "Unpaid",
            "Partially Paid",
            "Paid"});
            this.POPay_DD_Status.Location = new System.Drawing.Point(597, 177);
            this.POPay_DD_Status.Name = "POPay_DD_Status";
            this.POPay_DD_Status.Size = new System.Drawing.Size(174, 25);
            this.POPay_DD_Status.TabIndex = 17;
            // 
            // POSub_But_Save
            // 
            this.POSub_But_Save.Location = new System.Drawing.Point(317, 619);
            this.POSub_But_Save.Name = "POSub_But_Save";
            this.POSub_But_Save.Size = new System.Drawing.Size(104, 32);
            this.POSub_But_Save.TabIndex = 18;
            this.POSub_But_Save.Text = "Save";
            this.POSub_But_Save.UseVisualStyleBackColor = true;
            // 
            // POSub_But_Reset
            // 
            this.POSub_But_Reset.Location = new System.Drawing.Point(433, 619);
            this.POSub_But_Reset.Name = "POSub_But_Reset";
            this.POSub_But_Reset.Size = new System.Drawing.Size(99, 32);
            this.POSub_But_Reset.TabIndex = 20;
            this.POSub_But_Reset.Text = "Reset";
            this.POSub_But_Reset.UseVisualStyleBackColor = true;
            // 
            // POPay_CB_Deposit
            // 
            this.POPay_CB_Deposit.AutoSize = true;
            this.POPay_CB_Deposit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_CB_Deposit.Location = new System.Drawing.Point(485, 270);
            this.POPay_CB_Deposit.Name = "POPay_CB_Deposit";
            this.POPay_CB_Deposit.Size = new System.Drawing.Size(94, 22);
            this.POPay_CB_Deposit.TabIndex = 21;
            this.POPay_CB_Deposit.Text = "Deposit?";
            this.POPay_CB_Deposit.UseVisualStyleBackColor = true;
            // 
            // POPay_DD_PayType
            // 
            this.POPay_DD_PayType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_DD_PayType.FormattingEnabled = true;
            this.POPay_DD_PayType.Items.AddRange(new object[] {
            "Unpaid",
            "Partially Paid",
            "Paid"});
            this.POPay_DD_PayType.Location = new System.Drawing.Point(221, 220);
            this.POPay_DD_PayType.Name = "POPay_DD_PayType";
            this.POPay_DD_PayType.Size = new System.Drawing.Size(174, 25);
            this.POPay_DD_PayType.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Payment Type:";
            // 
            // POPay_But_PODate
            // 
            this.POPay_But_PODate.CustomFormat = "MM/dd/yyyy";
            this.POPay_But_PODate.Enabled = false;
            this.POPay_But_PODate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_But_PODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.POPay_But_PODate.Location = new System.Drawing.Point(221, 76);
            this.POPay_But_PODate.Name = "POPay_But_PODate";
            this.POPay_But_PODate.Size = new System.Drawing.Size(174, 25);
            this.POPay_But_PODate.TabIndex = 24;
            // 
            // PO_Payment_Subform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 675);
            this.Controls.Add(this.POPay_But_PODate);
            this.Controls.Add(this.POPay_DD_PayType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.POPay_CB_Deposit);
            this.Controls.Add(this.POSub_But_Reset);
            this.Controls.Add(this.POSub_But_Save);
            this.Controls.Add(this.POPay_DD_Status);
            this.Controls.Add(this.POPay_RTB_Comm);
            this.Controls.Add(this.POPay_But_PayDate);
            this.Controls.Add(this.POPay_TB_PayAmt);
            this.Controls.Add(this.POPay_TB_POAmt);
            this.Controls.Add(this.POPay_TB_CustName);
            this.Controls.Add(this.POPay_TB_Branch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PO_Payment_Subform";
            this.Text = "Add/Edit Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox POPay_TB_Branch;
        private System.Windows.Forms.TextBox POPay_TB_CustName;
        private System.Windows.Forms.TextBox POPay_TB_POAmt;
        private System.Windows.Forms.TextBox POPay_TB_PayAmt;
        private System.Windows.Forms.DateTimePicker POPay_But_PayDate;
        private System.Windows.Forms.RichTextBox POPay_RTB_Comm;
        private System.Windows.Forms.ComboBox POPay_DD_Status;
        private System.Windows.Forms.Button POSub_But_Save;
        private System.Windows.Forms.Button POSub_But_Reset;
        private System.Windows.Forms.CheckBox POPay_CB_Deposit;
        private System.Windows.Forms.ComboBox POPay_DD_PayType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker POPay_But_PODate;
    }
}