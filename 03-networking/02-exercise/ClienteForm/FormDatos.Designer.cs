namespace ClienteForm
{
    partial class FormDatos
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
            this.txbIp = new System.Windows.Forms.TextBox();
            this.txbPuerto = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.txbDNI = new System.Windows.Forms.TextBox();
            this.lblDNIDatos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbIp
            // 
            this.txbIp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbIp.Location = new System.Drawing.Point(87, 6);
            this.txbIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbIp.Name = "txbIp";
            this.txbIp.Size = new System.Drawing.Size(184, 25);
            this.txbIp.TabIndex = 0;
            // 
            // txbPuerto
            // 
            this.txbPuerto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbPuerto.Location = new System.Drawing.Point(110, 86);
            this.txbPuerto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbPuerto.Name = "txbPuerto";
            this.txbPuerto.Size = new System.Drawing.Size(161, 25);
            this.txbPuerto.TabIndex = 1;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIp.Location = new System.Drawing.Point(12, 9);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(26, 18);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "IP:";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPuerto.Location = new System.Drawing.Point(12, 93);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(60, 18);
            this.lblPuerto.TabIndex = 3;
            this.lblPuerto.Text = "Puerto:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(167, 157);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 48);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblGuardar
            // 
            this.lblGuardar.AutoSize = true;
            this.lblGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGuardar.Location = new System.Drawing.Point(12, 173);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(59, 16);
            this.lblGuardar.TabIndex = 5;
            this.lblGuardar.Text = "Guardar";
            // 
            // txbDNI
            // 
            this.txbDNI.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txbDNI.Location = new System.Drawing.Point(87, 44);
            this.txbDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbDNI.Name = "txbDNI";
            this.txbDNI.Size = new System.Drawing.Size(184, 25);
            this.txbDNI.TabIndex = 6;
            // 
            // lblDNIDatos
            // 
            this.lblDNIDatos.AutoSize = true;
            this.lblDNIDatos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDNIDatos.Location = new System.Drawing.Point(12, 51);
            this.lblDNIDatos.Name = "lblDNIDatos";
            this.lblDNIDatos.Size = new System.Drawing.Size(38, 18);
            this.lblDNIDatos.TabIndex = 7;
            this.lblDNIDatos.Text = "DNI:";
            // 
            // FormDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(283, 242);
            this.Controls.Add(this.lblDNIDatos);
            this.Controls.Add(this.txbDNI);
            this.Controls.Add(this.lblGuardar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblPuerto);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.txbPuerto);
            this.Controls.Add(this.txbIp);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDatos";
            this.Text = "Cambiar Datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDatos_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbIp;
        private TextBox txbPuerto;
        private Label lblIp;
        private Label lblPuerto;
        private Button btnGuardar;
        private Label lblGuardar;
        private TextBox txbDNI;
        private Label lblDNIDatos;
    }
}