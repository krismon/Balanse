namespace Balanse
{
    partial class Form_LogIn
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
            this.label2 = new System.Windows.Forms.Label();
            this.L_TB_Name = new System.Windows.Forms.TextBox();
            this.L_TB_Password = new System.Windows.Forms.TextBox();
            this.L_But_OK = new System.Windows.Forms.Button();
            this.L_But_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // L_TB_Name
            // 
            this.L_TB_Name.Location = new System.Drawing.Point(210, 95);
            this.L_TB_Name.Name = "L_TB_Name";
            this.L_TB_Name.Size = new System.Drawing.Size(220, 26);
            this.L_TB_Name.TabIndex = 2;
            // 
            // L_TB_Password
            // 
            this.L_TB_Password.Location = new System.Drawing.Point(210, 148);
            this.L_TB_Password.Name = "L_TB_Password";
            this.L_TB_Password.PasswordChar = '*';
            this.L_TB_Password.Size = new System.Drawing.Size(220, 26);
            this.L_TB_Password.TabIndex = 3;
            // 
            // L_But_OK
            // 
            this.L_But_OK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_But_OK.Location = new System.Drawing.Point(93, 219);
            this.L_But_OK.Name = "L_But_OK";
            this.L_But_OK.Size = new System.Drawing.Size(134, 35);
            this.L_But_OK.TabIndex = 4;
            this.L_But_OK.Text = "OK";
            this.L_But_OK.UseVisualStyleBackColor = true;
            this.L_But_OK.Click += new System.EventHandler(this.label1_Click);
            this.L_But_OK.Enter += new System.EventHandler(this.label1_Click);
            // 
            // L_But_Cancel
            // 
            this.L_But_Cancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_But_Cancel.Location = new System.Drawing.Point(258, 219);
            this.L_But_Cancel.Name = "L_But_Cancel";
            this.L_But_Cancel.Size = new System.Drawing.Size(134, 35);
            this.L_But_Cancel.TabIndex = 5;
            this.L_But_Cancel.Text = "Cancel";
            this.L_But_Cancel.UseVisualStyleBackColor = true;
            this.L_But_Cancel.Click += new System.EventHandler(this.L_But_Cancel_Click);
            // 
            // Form_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(491, 350);
            this.Controls.Add(this.L_But_Cancel);
            this.Controls.Add(this.L_But_OK);
            this.Controls.Add(this.L_TB_Password);
            this.Controls.Add(this.L_TB_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LogIn";
            this.Text = "Log In";
            this.Click += new System.EventHandler(this.label1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox L_TB_Name;
        private System.Windows.Forms.TextBox L_TB_Password;
        private System.Windows.Forms.Button L_But_OK;
        private System.Windows.Forms.Button L_But_Cancel;
    }
}

