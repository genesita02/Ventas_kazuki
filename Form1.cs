using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ventas_kazuki
{
    public partial class menu : Form
    {
        

        public menu()
        {
            InitializeComponent();
        }

        private void BTN_CLIENTE_Click(object sender, EventArgs e)
        {
            Form formulario = new Cliente();
            formulario.Show();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BTN_EMPLEADP_Click(object sender, EventArgs e)
        {
            Form formulario = new Empleado();
            formulario.Show();
        }

        private void BTN_INVENTARIO_Click(object sender, EventArgs e)
        {
            Form formulario = new Producto();
            formulario.Show();
        }

        private void BTN_FACTURACION_Click(object sender, EventArgs e)
        {
            Form formulario = new Factura();
            formulario.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
