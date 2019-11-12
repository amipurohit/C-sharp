namespace CExam2
{
    partial class frmRegister
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
            this.lblFname = new System.Windows.Forms.Label();
            this.lblLame = new System.Windows.Forms.Label();
            this.lblTnumber = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUserCount = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFname.Location = new System.Drawing.Point(130, 45);
            this.lblFname.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(107, 19);
            this.lblFname.TabIndex = 0;
            this.lblFname.Text = "First Name";
            // 
            // lblLame
            // 
            this.lblLame.AutoSize = true;
            this.lblLame.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLame.Location = new System.Drawing.Point(136, 110);
            this.lblLame.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLame.Name = "lblLame";
            this.lblLame.Size = new System.Drawing.Size(102, 19);
            this.lblLame.TabIndex = 1;
            this.lblLame.Text = "Last name";
            // 
            // lblTnumber
            // 
            this.lblTnumber.AutoSize = true;
            this.lblTnumber.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTnumber.Location = new System.Drawing.Point(136, 180);
            this.lblTnumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTnumber.Name = "lblTnumber";
            this.lblTnumber.Size = new System.Drawing.Size(177, 19);
            this.lblTnumber.TabIndex = 2;
            this.lblTnumber.Text = "Telephone Number";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(471, 48);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(461, 26);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(471, 113);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(461, 26);
            this.txtLastName.TabIndex = 4;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(471, 183);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(461, 26);
            this.txtTelephone.TabIndex = 5;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearForm.Location = new System.Drawing.Point(136, 265);
            this.btnClearForm.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(370, 60);
            this.btnClearForm.TabIndex = 6;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(537, 265);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(370, 60);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUserCount
            // 
            this.btnUserCount.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserCount.Location = new System.Drawing.Point(136, 333);
            this.btnUserCount.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnUserCount.Name = "btnUserCount";
            this.btnUserCount.Size = new System.Drawing.Size(365, 58);
            this.btnUserCount.TabIndex = 8;
            this.btnUserCount.Text = "User Count";
            this.btnUserCount.UseVisualStyleBackColor = true;
            this.btnUserCount.Click += new System.EventHandler(this.btnUserCount_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(537, 333);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(365, 58);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 436);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnUserCount);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblTnumber);
            this.Controls.Add(this.lblLame);
            this.Controls.Add(this.lblFname);
            this.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "frmRegister";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblLame;
        private System.Windows.Forms.Label lblTnumber;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUserCount;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}

