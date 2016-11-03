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
            this.POPay_TB_PODate = new System.Windows.Forms.TextBox();
            this.dgv_PoPayments = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalPayments = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PoPayments)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "PO Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "PO Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Paid Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(313, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(304, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 132);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Comments:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(313, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Branch:";
            // 
            // POPay_TB_Branch
            // 
            this.POPay_TB_Branch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_Branch.Location = new System.Drawing.Point(399, 19);
            this.POPay_TB_Branch.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_TB_Branch.Name = "POPay_TB_Branch";
            this.POPay_TB_Branch.ReadOnly = true;
            this.POPay_TB_Branch.Size = new System.Drawing.Size(132, 25);
            this.POPay_TB_Branch.TabIndex = 11;
            // 
            // POPay_TB_CustName
            // 
            this.POPay_TB_CustName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_CustName.Location = new System.Drawing.Point(146, 60);
            this.POPay_TB_CustName.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_TB_CustName.Name = "POPay_TB_CustName";
            this.POPay_TB_CustName.ReadOnly = true;
            this.POPay_TB_CustName.Size = new System.Drawing.Size(388, 25);
            this.POPay_TB_CustName.TabIndex = 12;
            // 
            // POPay_TB_POAmt
            // 
            this.POPay_TB_POAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_POAmt.Location = new System.Drawing.Point(146, 101);
            this.POPay_TB_POAmt.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_TB_POAmt.Name = "POPay_TB_POAmt";
            this.POPay_TB_POAmt.ReadOnly = true;
            this.POPay_TB_POAmt.Size = new System.Drawing.Size(132, 25);
            this.POPay_TB_POAmt.TabIndex = 13;
            // 
            // POPay_TB_PayAmt
            // 
            this.POPay_TB_PayAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_PayAmt.Location = new System.Drawing.Point(146, 70);
            this.POPay_TB_PayAmt.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_TB_PayAmt.Name = "POPay_TB_PayAmt";
            this.POPay_TB_PayAmt.Size = new System.Drawing.Size(132, 25);
            this.POPay_TB_PayAmt.TabIndex = 14;
            // 
            // POPay_But_PayDate
            // 
            this.POPay_But_PayDate.CustomFormat = "MM/dd/yyyy";
            this.POPay_But_PayDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_But_PayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.POPay_But_PayDate.Location = new System.Drawing.Point(397, 29);
            this.POPay_But_PayDate.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_But_PayDate.Name = "POPay_But_PayDate";
            this.POPay_But_PayDate.Size = new System.Drawing.Size(108, 25);
            this.POPay_But_PayDate.TabIndex = 15;
            // 
            // POPay_RTB_Comm
            // 
            this.POPay_RTB_Comm.Location = new System.Drawing.Point(12, 149);
            this.POPay_RTB_Comm.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_RTB_Comm.Name = "POPay_RTB_Comm";
            this.POPay_RTB_Comm.Size = new System.Drawing.Size(519, 84);
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
            "Paid",
            "Turned Over"});
            this.POPay_DD_Status.Location = new System.Drawing.Point(399, 99);
            this.POPay_DD_Status.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_DD_Status.Name = "POPay_DD_Status";
            this.POPay_DD_Status.Size = new System.Drawing.Size(132, 25);
            this.POPay_DD_Status.TabIndex = 17;
            // 
            // POSub_But_Save
            // 
            this.POSub_But_Save.Location = new System.Drawing.Point(231, 702);
            this.POSub_But_Save.Margin = new System.Windows.Forms.Padding(2);
            this.POSub_But_Save.Name = "POSub_But_Save";
            this.POSub_But_Save.Size = new System.Drawing.Size(78, 26);
            this.POSub_But_Save.TabIndex = 18;
            this.POSub_But_Save.Text = "Save";
            this.POSub_But_Save.UseVisualStyleBackColor = true;
            this.POSub_But_Save.Click += new System.EventHandler(this.POSub_But_Save_Click);
            // 
            // POSub_But_Reset
            // 
            this.POSub_But_Reset.Location = new System.Drawing.Point(337, 702);
            this.POSub_But_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.POSub_But_Reset.Name = "POSub_But_Reset";
            this.POSub_But_Reset.Size = new System.Drawing.Size(74, 26);
            this.POSub_But_Reset.TabIndex = 20;
            this.POSub_But_Reset.Text = "Reset";
            this.POSub_But_Reset.UseVisualStyleBackColor = true;
            // 
            // POPay_CB_Deposit
            // 
            this.POPay_CB_Deposit.AutoSize = true;
            this.POPay_CB_Deposit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_CB_Deposit.Location = new System.Drawing.Point(307, 72);
            this.POPay_CB_Deposit.Margin = new System.Windows.Forms.Padding(2);
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
            "Cash",
            "Check"});
            this.POPay_DD_PayType.Location = new System.Drawing.Point(146, 32);
            this.POPay_DD_PayType.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_DD_PayType.Name = "POPay_DD_PayType";
            this.POPay_DD_PayType.Size = new System.Drawing.Size(132, 25);
            this.POPay_DD_PayType.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Payment Type:";
            // 
            // POPay_TB_PODate
            // 
            this.POPay_TB_PODate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POPay_TB_PODate.Location = new System.Drawing.Point(146, 22);
            this.POPay_TB_PODate.Margin = new System.Windows.Forms.Padding(2);
            this.POPay_TB_PODate.Name = "POPay_TB_PODate";
            this.POPay_TB_PODate.ReadOnly = true;
            this.POPay_TB_PODate.Size = new System.Drawing.Size(132, 25);
            this.POPay_TB_PODate.TabIndex = 24;
            // 
            // dgv_PoPayments
            // 
            this.dgv_PoPayments.AllowUserToAddRows = false;
            this.dgv_PoPayments.AllowUserToDeleteRows = false;
            this.dgv_PoPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PoPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PoPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_PoPayments.Location = new System.Drawing.Point(26, 459);
            this.dgv_PoPayments.Name = "dgv_PoPayments";
            this.dgv_PoPayments.ReadOnly = true;
            this.dgv_PoPayments.RowHeadersVisible = false;
            this.dgv_PoPayments.Size = new System.Drawing.Size(547, 142);
            this.dgv_PoPayments.TabIndex = 25;
            this.dgv_PoPayments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PoPayments_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Payment Type";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Paid Amount";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Payment Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Action";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "REMOVE";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Payments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPayment);
            this.groupBox1.Controls.Add(this.POPay_DD_PayType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.POPay_TB_PayAmt);
            this.groupBox1.Controls.Add(this.POPay_But_PayDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.POPay_CB_Deposit);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 145);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Payment";
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.Location = new System.Drawing.Point(237, 114);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(78, 26);
            this.btnAddPayment.TabIndex = 24;
            this.btnAddPayment.Text = "Add";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.POPay_TB_PODate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.POPay_TB_Branch);
            this.groupBox2.Controls.Add(this.POPay_DD_Status);
            this.groupBox2.Controls.Add(this.POPay_TB_CustName);
            this.groupBox2.Controls.Add(this.POPay_RTB_Comm);
            this.groupBox2.Controls.Add(this.POPay_TB_POAmt);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 250);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PO Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 609);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 24);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total";
            // 
            // txtTotalPayments
            // 
            this.txtTotalPayments.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayments.Location = new System.Drawing.Point(104, 607);
            this.txtTotalPayments.Name = "txtTotalPayments";
            this.txtTotalPayments.Size = new System.Drawing.Size(469, 30);
            this.txtTotalPayments.TabIndex = 30;
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(104, 639);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(469, 30);
            this.txtBalance.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 641);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 24);
            this.label12.TabIndex = 31;
            this.label12.Text = "Balance";
            // 
            // PO_Payment_Subform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 748);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalPayments);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv_PoPayments);
            this.Controls.Add(this.POSub_But_Reset);
            this.Controls.Add(this.POSub_But_Save);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PO_Payment_Subform";
            this.Text = "Add/Edit Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PoPayments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox POPay_TB_PODate;
        private System.Windows.Forms.DataGridView dgv_PoPayments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalPayments;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}