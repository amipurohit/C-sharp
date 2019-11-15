namespace Quiz3
{
    partial class frmCarwash
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
            this.rbtnCar = new System.Windows.Forms.RadioButton();
            this.rbtnOwner = new System.Windows.Forms.RadioButton();
            this.grpCar = new System.Windows.Forms.GroupBox();
            this.grpOwner = new System.Windows.Forms.GroupBox();
            this.cmbMake = new System.Windows.Forms.ComboBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblTele = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpCar.SuspendLayout();
            this.grpOwner.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnCar
            // 
            this.rbtnCar.AutoSize = true;
            this.rbtnCar.Location = new System.Drawing.Point(151, 32);
            this.rbtnCar.Name = "rbtnCar";
            this.rbtnCar.Size = new System.Drawing.Size(50, 22);
            this.rbtnCar.TabIndex = 0;
            this.rbtnCar.TabStop = true;
            this.rbtnCar.Text = "Car";
            this.rbtnCar.UseVisualStyleBackColor = true;
            this.rbtnCar.CheckedChanged += new System.EventHandler(this.rbtnCar_CheckedChanged);
            this.rbtnCar.Click += new System.EventHandler(this.rbtnCar_Click);
            // 
            // rbtnOwner
            // 
            this.rbtnOwner.AutoSize = true;
            this.rbtnOwner.Location = new System.Drawing.Point(566, 32);
            this.rbtnOwner.Name = "rbtnOwner";
            this.rbtnOwner.Size = new System.Drawing.Size(70, 22);
            this.rbtnOwner.TabIndex = 1;
            this.rbtnOwner.TabStop = true;
            this.rbtnOwner.Text = "Owner";
            this.rbtnOwner.UseVisualStyleBackColor = true;
            this.rbtnOwner.CheckedChanged += new System.EventHandler(this.rbtnOwner_CheckedChanged);
            this.rbtnOwner.Click += new System.EventHandler(this.rbtnOwner_Click);
            // 
            // grpCar
            // 
            this.grpCar.Controls.Add(this.cmbYear);
            this.grpCar.Controls.Add(this.cmbModel);
            this.grpCar.Controls.Add(this.lblYear);
            this.grpCar.Controls.Add(this.lblModel);
            this.grpCar.Controls.Add(this.lblMake);
            this.grpCar.Controls.Add(this.cmbMake);
            this.grpCar.Location = new System.Drawing.Point(151, 81);
            this.grpCar.Name = "grpCar";
            this.grpCar.Size = new System.Drawing.Size(288, 218);
            this.grpCar.TabIndex = 2;
            this.grpCar.TabStop = false;
            this.grpCar.Text = "Car Registration";
            // 
            // grpOwner
            // 
            this.grpOwner.Controls.Add(this.txtTelephone);
            this.grpOwner.Controls.Add(this.txtLastName);
            this.grpOwner.Controls.Add(this.txtFirstname);
            this.grpOwner.Controls.Add(this.lblTele);
            this.grpOwner.Controls.Add(this.lblLastName);
            this.grpOwner.Controls.Add(this.lblFname);
            this.grpOwner.Location = new System.Drawing.Point(566, 81);
            this.grpOwner.Name = "grpOwner";
            this.grpOwner.Size = new System.Drawing.Size(313, 218);
            this.grpOwner.TabIndex = 3;
            this.grpOwner.TabStop = false;
            this.grpOwner.Text = "Owner";
            // 
            // cmbMake
            // 
            this.cmbMake.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbMake.FormattingEnabled = true;
            this.cmbMake.Location = new System.Drawing.Point(106, 44);
            this.cmbMake.Name = "cmbMake";
            this.cmbMake.Size = new System.Drawing.Size(121, 26);
            this.cmbMake.TabIndex = 0;
            this.cmbMake.SelectedIndexChanged += new System.EventHandler(this.cmbMake_SelectedIndexChanged);
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(17, 47);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(45, 18);
            this.lblMake.TabIndex = 1;
            this.lblMake.Text = "Make";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(17, 105);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(49, 18);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(17, 150);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(38, 18);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year";
            // 
            // cmbModel
            // 
            this.cmbModel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(106, 97);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(121, 26);
            this.cmbModel.TabIndex = 4;
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(106, 142);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 26);
            this.cmbYear.TabIndex = 5;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(22, 56);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(81, 18);
            this.lblFname.TabIndex = 0;
            this.lblFname.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(25, 115);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 18);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // lblTele
            // 
            this.lblTele.AutoSize = true;
            this.lblTele.Location = new System.Drawing.Point(25, 154);
            this.lblTele.Name = "lblTele";
            this.lblTele.Size = new System.Drawing.Size(77, 18);
            this.lblTele.TabIndex = 2;
            this.lblTele.Text = "Telephone";
            // 
            // txtFirstname
            // 
            this.txtFirstname.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFirstname.Location = new System.Drawing.Point(115, 53);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(179, 24);
            this.txtFirstname.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLastName.Location = new System.Drawing.Point(115, 104);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(179, 24);
            this.txtLastName.TabIndex = 4;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTelephone.Location = new System.Drawing.Point(115, 151);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(179, 24);
            this.txtTelephone.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Aquamarine;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(151, 319);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(288, 62);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(566, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(313, 63);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCarwash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(912, 441);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grpOwner);
            this.Controls.Add(this.grpCar);
            this.Controls.Add(this.rbtnOwner);
            this.Controls.Add(this.rbtnCar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCarwash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarWash System";
            this.Load += new System.EventHandler(this.frmCarwash_Load);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.grpOwner.ResumeLayout(false);
            this.grpOwner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCar;
        private System.Windows.Forms.RadioButton rbtnOwner;
        private System.Windows.Forms.GroupBox grpCar;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.ComboBox cmbMake;
        private System.Windows.Forms.GroupBox grpOwner;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label lblTele;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
    }
}

