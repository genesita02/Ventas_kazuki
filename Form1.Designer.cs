namespace Ventas_kazuki
{
    partial class menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_salir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTN_CLIENTE = new System.Windows.Forms.Button();
            this.BTN_INVENTARIO = new System.Windows.Forms.Button();
            this.BTN_FACTURACION = new System.Windows.Forms.Button();
            this.BTN_EMPLEADP = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(587, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.BTN_CLIENTE);
            this.panel1.Controls.Add(this.BTN_INVENTARIO);
            this.panel1.Controls.Add(this.BTN_FACTURACION);
            this.panel1.Controls.Add(this.BTN_EMPLEADP);
            this.panel1.Location = new System.Drawing.Point(2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 559);
            this.panel1.TabIndex = 8;
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(107, 417);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(75, 23);
            this.btn_salir.TabIndex = 5;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BTN_CLIENTE
            // 
            this.BTN_CLIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CLIENTE.Location = new System.Drawing.Point(30, 177);
            this.BTN_CLIENTE.Name = "BTN_CLIENTE";
            this.BTN_CLIENTE.Size = new System.Drawing.Size(104, 23);
            this.BTN_CLIENTE.TabIndex = 0;
            this.BTN_CLIENTE.Text = "CLIENTE";
            this.BTN_CLIENTE.UseVisualStyleBackColor = true;
            this.BTN_CLIENTE.Click += new System.EventHandler(this.BTN_CLIENTE_Click);
            // 
            // BTN_INVENTARIO
            // 
            this.BTN_INVENTARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_INVENTARIO.Location = new System.Drawing.Point(30, 328);
            this.BTN_INVENTARIO.Name = "BTN_INVENTARIO";
            this.BTN_INVENTARIO.Size = new System.Drawing.Size(104, 23);
            this.BTN_INVENTARIO.TabIndex = 3;
            this.BTN_INVENTARIO.Text = "INVENTATIO";
            this.BTN_INVENTARIO.UseVisualStyleBackColor = true;
            this.BTN_INVENTARIO.Click += new System.EventHandler(this.BTN_INVENTARIO_Click);
            // 
            // BTN_FACTURACION
            // 
            this.BTN_FACTURACION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_FACTURACION.Location = new System.Drawing.Point(30, 227);
            this.BTN_FACTURACION.Name = "BTN_FACTURACION";
            this.BTN_FACTURACION.Size = new System.Drawing.Size(116, 23);
            this.BTN_FACTURACION.TabIndex = 1;
            this.BTN_FACTURACION.Text = "FACTURACiÓN";
            this.BTN_FACTURACION.UseVisualStyleBackColor = true;
            this.BTN_FACTURACION.Click += new System.EventHandler(this.BTN_FACTURACION_Click);
            // 
            // BTN_EMPLEADP
            // 
            this.BTN_EMPLEADP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_EMPLEADP.Location = new System.Drawing.Point(30, 275);
            this.BTN_EMPLEADP.Name = "BTN_EMPLEADP";
            this.BTN_EMPLEADP.Size = new System.Drawing.Size(104, 23);
            this.BTN_EMPLEADP.TabIndex = 2;
            this.BTN_EMPLEADP.Text = "EMPLEADO";
            this.BTN_EMPLEADP.UseVisualStyleBackColor = true;
            this.BTN_EMPLEADP.Click += new System.EventHandler(this.BTN_EMPLEADP_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Name = "menu";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTN_CLIENTE;
        private System.Windows.Forms.Button BTN_INVENTARIO;
        private System.Windows.Forms.Button BTN_FACTURACION;
        private System.Windows.Forms.Button BTN_EMPLEADP;
    }
}

