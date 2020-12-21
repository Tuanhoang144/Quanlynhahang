namespace GUI.QuanLy
{
    partial class Formdangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formdangnhap));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbtaikhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.Guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btndangnhap = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txbmatkhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1011, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 46);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txbtaikhoan);
            this.panel1.Controls.Add(this.Guna2Button1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.btndangnhap);
            this.panel1.Controls.Add(this.txbmatkhau);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 568);
            this.panel1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(684, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 45;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(643, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 43);
            this.label4.TabIndex = 44;
            this.label4.Text = "Quản Lý Nhà Hàng";
            // 
            // txbtaikhoan
            // 
            this.txbtaikhoan.Animated = true;
            this.txbtaikhoan.BorderRadius = 8;
            this.txbtaikhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbtaikhoan.DefaultText = "5951071113";
            this.txbtaikhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbtaikhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbtaikhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbtaikhoan.DisabledState.Parent = this.txbtaikhoan;
            this.txbtaikhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbtaikhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txbtaikhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbtaikhoan.FocusedState.Parent = this.txbtaikhoan;
            this.txbtaikhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbtaikhoan.ForeColor = System.Drawing.Color.Gray;
            this.txbtaikhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbtaikhoan.HoverState.Parent = this.txbtaikhoan;
            this.txbtaikhoan.Location = new System.Drawing.Point(651, 261);
            this.txbtaikhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbtaikhoan.Name = "txbtaikhoan";
            this.txbtaikhoan.PasswordChar = '\0';
            this.txbtaikhoan.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txbtaikhoan.PlaceholderText = "Username";
            this.txbtaikhoan.SelectedText = "";
            this.txbtaikhoan.SelectionStart = 10;
            this.txbtaikhoan.ShadowDecoration.Parent = this.txbtaikhoan;
            this.txbtaikhoan.Size = new System.Drawing.Size(316, 46);
            this.txbtaikhoan.TabIndex = 43;
            // 
            // Guna2Button1
            // 
            this.Guna2Button1.AutoRoundedCorners = true;
            this.Guna2Button1.BorderRadius = 21;
            this.Guna2Button1.CheckedState.Parent = this.Guna2Button1;
            this.Guna2Button1.CustomImages.Parent = this.Guna2Button1;
            this.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.Guna2Button1.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.Guna2Button1.ForeColor = System.Drawing.Color.White;
            this.Guna2Button1.HoverState.Parent = this.Guna2Button1;
            this.Guna2Button1.Location = new System.Drawing.Point(687, 183);
            this.Guna2Button1.Name = "Guna2Button1";
            this.Guna2Button1.ShadowDecoration.Parent = this.Guna2Button1;
            this.Guna2Button1.Size = new System.Drawing.Size(209, 45);
            this.Guna2Button1.TabIndex = 42;
            this.Guna2Button1.Text = "User Login";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(41)))), ((int)(((byte)(144)))));
            this.Label2.Location = new System.Drawing.Point(838, 413);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(118, 20);
            this.Label2.TabIndex = 41;
            this.Label2.Text = "Forgot Password";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(41)))), ((int)(((byte)(144)))));
            this.Label1.Location = new System.Drawing.Point(648, 413);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 17);
            this.Label1.TabIndex = 40;
            this.Label1.Text = "Remember Me";
            // 
            // btndangnhap
            // 
            this.btndangnhap.Animated = true;
            this.btndangnhap.AutoRoundedCorners = true;
            this.btndangnhap.BorderRadius = 22;
            this.btndangnhap.CheckedState.Parent = this.btndangnhap;
            this.btndangnhap.CustomImages.Parent = this.btndangnhap;
            this.btndangnhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btndangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btndangnhap.ForeColor = System.Drawing.Color.White;
            this.btndangnhap.HoverState.Parent = this.btndangnhap;
            this.btndangnhap.Location = new System.Drawing.Point(664, 452);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.ShadowDecoration.Parent = this.btndangnhap;
            this.btndangnhap.Size = new System.Drawing.Size(292, 46);
            this.btndangnhap.TabIndex = 39;
            this.btndangnhap.Text = "LOGIN";
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // txbmatkhau
            // 
            this.txbmatkhau.Animated = true;
            this.txbmatkhau.BorderRadius = 8;
            this.txbmatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbmatkhau.DefaultText = "1";
            this.txbmatkhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbmatkhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbmatkhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbmatkhau.DisabledState.Parent = this.txbmatkhau;
            this.txbmatkhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbmatkhau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txbmatkhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbmatkhau.FocusedState.Parent = this.txbmatkhau;
            this.txbmatkhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbmatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbmatkhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbmatkhau.HoverState.Parent = this.txbmatkhau;
            this.txbmatkhau.Location = new System.Drawing.Point(651, 334);
            this.txbmatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbmatkhau.Name = "txbmatkhau";
            this.txbmatkhau.PasswordChar = '\0';
            this.txbmatkhau.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txbmatkhau.PlaceholderText = "Password";
            this.txbmatkhau.SelectedText = "";
            this.txbmatkhau.SelectionStart = 1;
            this.txbmatkhau.ShadowDecoration.Parent = this.txbmatkhau;
            this.txbmatkhau.Size = new System.Drawing.Size(316, 46);
            this.txbmatkhau.TabIndex = 38;
            this.txbmatkhau.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Size = new System.Drawing.Size(555, 562);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // Formdangnhap
            // 
            this.AcceptButton = this.btndangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1073, 574);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Formdangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formdangnhap";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        internal Guna.UI2.WinForms.Guna2TextBox txbtaikhoan;
        internal Guna.UI2.WinForms.Guna2Button Guna2Button1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal Guna.UI2.WinForms.Guna2GradientButton btndangnhap;
        internal Guna.UI2.WinForms.Guna2TextBox txbmatkhau;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}