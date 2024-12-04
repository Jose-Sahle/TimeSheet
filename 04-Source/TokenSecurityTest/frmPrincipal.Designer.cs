namespace TokenSecurityTest
{
    partial class frmPrincipal
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
            this.lblCredencial = new System.Windows.Forms.Label();
            this.txtCredencial = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblHash = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblToken = new System.Windows.Forms.Label();
            this.cmdGerarHash = new System.Windows.Forms.Button();
            this.cmdSolicitarToken = new System.Windows.Forms.Button();
            this.txtURITokenSecurity = new System.Windows.Forms.TextBox();
            this.lblURITokenSecurity = new System.Windows.Forms.Label();
            this.txtValidar = new System.Windows.Forms.TextBox();
            this.lblValidar = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.cmdValidar = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCredencial
            // 
            this.lblCredencial.AutoSize = true;
            this.lblCredencial.Location = new System.Drawing.Point(27, 58);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(57, 13);
            this.lblCredencial.TabIndex = 0;
            this.lblCredencial.Text = "Credencial";
            // 
            // txtCredencial
            // 
            this.txtCredencial.Location = new System.Drawing.Point(88, 55);
            this.txtCredencial.Name = "txtCredencial";
            this.txtCredencial.Size = new System.Drawing.Size(159, 20);
            this.txtCredencial.TabIndex = 1;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(316, 55);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(291, 20);
            this.txtURL.TabIndex = 3;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(283, 58);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 2;
            this.lblURL.Text = "URL";
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Location = new System.Drawing.Point(27, 102);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(32, 13);
            this.lblHash.TabIndex = 4;
            this.lblHash.Text = "Hash";
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point(88, 98);
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size(519, 20);
            this.txtHash.TabIndex = 5;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(88, 136);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(519, 20);
            this.txtToken.TabIndex = 7;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(27, 140);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(38, 13);
            this.lblToken.TabIndex = 6;
            this.lblToken.Text = "Token";
            // 
            // cmdGerarHash
            // 
            this.cmdGerarHash.Location = new System.Drawing.Point(411, 313);
            this.cmdGerarHash.Name = "cmdGerarHash";
            this.cmdGerarHash.Size = new System.Drawing.Size(75, 23);
            this.cmdGerarHash.TabIndex = 8;
            this.cmdGerarHash.Text = "Gerar Hash";
            this.cmdGerarHash.UseVisualStyleBackColor = true;
            this.cmdGerarHash.Click += new System.EventHandler(this.cmdGerarHash_Click);
            // 
            // cmdSolicitarToken
            // 
            this.cmdSolicitarToken.Location = new System.Drawing.Point(505, 313);
            this.cmdSolicitarToken.Name = "cmdSolicitarToken";
            this.cmdSolicitarToken.Size = new System.Drawing.Size(103, 23);
            this.cmdSolicitarToken.TabIndex = 9;
            this.cmdSolicitarToken.Text = "Solicitar Token";
            this.cmdSolicitarToken.UseVisualStyleBackColor = true;
            this.cmdSolicitarToken.Click += new System.EventHandler(this.cmdSolicitarToken_Click);
            // 
            // txtURITokenSecurity
            // 
            this.txtURITokenSecurity.Location = new System.Drawing.Point(136, 12);
            this.txtURITokenSecurity.Name = "txtURITokenSecurity";
            this.txtURITokenSecurity.Size = new System.Drawing.Size(471, 20);
            this.txtURITokenSecurity.TabIndex = 11;
            // 
            // lblURITokenSecurity
            // 
            this.lblURITokenSecurity.AutoSize = true;
            this.lblURITokenSecurity.Location = new System.Drawing.Point(29, 15);
            this.lblURITokenSecurity.Name = "lblURITokenSecurity";
            this.lblURITokenSecurity.Size = new System.Drawing.Size(101, 13);
            this.lblURITokenSecurity.TabIndex = 10;
            this.lblURITokenSecurity.Text = "URI Token Security";
            // 
            // txtValidar
            // 
            this.txtValidar.Location = new System.Drawing.Point(88, 210);
            this.txtValidar.Multiline = true;
            this.txtValidar.Name = "txtValidar";
            this.txtValidar.Size = new System.Drawing.Size(487, 97);
            this.txtValidar.TabIndex = 13;
            // 
            // lblValidar
            // 
            this.lblValidar.AutoSize = true;
            this.lblValidar.Location = new System.Drawing.Point(28, 214);
            this.lblValidar.Name = "lblValidar";
            this.lblValidar.Size = new System.Drawing.Size(39, 13);
            this.lblValidar.TabIndex = 12;
            this.lblValidar.Text = "Validar";
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(587, 214);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(10, 13);
            this.lblAccess.TabIndex = 14;
            this.lblAccess.Text = "-";
            // 
            // cmdValidar
            // 
            this.cmdValidar.Location = new System.Drawing.Point(88, 313);
            this.cmdValidar.Name = "cmdValidar";
            this.cmdValidar.Size = new System.Drawing.Size(75, 23);
            this.cmdValidar.TabIndex = 15;
            this.cmdValidar.Text = "Validar";
            this.cmdValidar.UseVisualStyleBackColor = true;
            this.cmdValidar.Click += new System.EventHandler(this.cmdValidar_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(86, 173);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(521, 20);
            this.txtKey.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Key";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 346);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdValidar);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.txtValidar);
            this.Controls.Add(this.lblValidar);
            this.Controls.Add(this.txtURITokenSecurity);
            this.Controls.Add(this.lblURITokenSecurity);
            this.Controls.Add(this.cmdSolicitarToken);
            this.Controls.Add(this.cmdGerarHash);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.txtHash);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.txtCredencial);
            this.Controls.Add(this.lblCredencial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPrincipal";
            this.Text = "TokenSecurity Test";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCredencial;
        private System.Windows.Forms.TextBox txtCredencial;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Button cmdGerarHash;
        private System.Windows.Forms.Button cmdSolicitarToken;
        private System.Windows.Forms.TextBox txtURITokenSecurity;
        private System.Windows.Forms.Label lblURITokenSecurity;
        private System.Windows.Forms.TextBox txtValidar;
        private System.Windows.Forms.Label lblValidar;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.Button cmdValidar;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
    }
}

