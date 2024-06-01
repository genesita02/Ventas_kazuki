using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventas_kazuki
{
    public partial class Producto : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CHERRYY-E5440;Initial Catalog=ventas_kazuki;User ID=sa;Password=123456;");
        public Producto()
        {
            InitializeComponent();
        }

        private void cargarDatos()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Inventario", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dtg_inventatio.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            // Establecer la consulta SQL para la inserción de datos
            string consulta = "INSERT INTO inventario (codigo, nombre_producto, descripcion, precio, stock_inicial, entrada, salida, stock_total)VALUES (@codigo, @nombre_producto, @descripcion, @precio, @stock_inicial, @entrada, @salida, @stock_total)\r\n";

            // Crear una instancia de SqlCommand y establecer la conexión y la consulta
            using (SqlCommand command = new SqlCommand(consulta, conn))
            {
                // Agregar parámetros para evitar la inyección SQL y mejorar la seguridad
                command.Parameters.AddWithValue("@codigo", txt_codigo.Text);
                command.Parameters.AddWithValue("@nombre_producto", txt_producto.Text);
                command.Parameters.AddWithValue("@descripcion", txt_descripcion.Text);
                command.Parameters.AddWithValue("@Precio", txt_precio.Text);
                command.Parameters.AddWithValue("@stock_inicial", txt_stock_inicial.Text);
                command.Parameters.AddWithValue("@entrada", txt_entrada.Text);
                command.Parameters.AddWithValue("@salida", txt_salida);
                command.Parameters.AddWithValue("@stock_total", txt_stock_total);

                try
                {
                    // Abrir la conexión
                    conn.Open();
                    // Ejecutar la consulta
                    int filasAfectadas = command.ExecuteNonQuery();
                    // Cerrar la conexión
                    conn.Close();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro almacenado correctamente.");
                        // Limpiar los campos después de guardar
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo almacenar el registro.");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la ejecución de la consulta
                    MessageBox.Show("Error al almacenar el registro: " + ex.Message);
                }

            }

            string producto = txt_producto.Text;
            string precio = txt_precio.Text;
            string entrada = txt_entrada.Text;
            string salida = txt_salida.Text;

            decimal v1;
            decimal v2;
            decimal v3;

            decimal resultado;
            v1 = decimal.Parse(txt_stock_inicial.Text);
            v2 = decimal.Parse(txt_entrada.Text);
            v3 = decimal.Parse(txt_salida.Text);

            resultado = v1 + v2 - v3;
            txt_stock_total.Text = resultado.ToString();
        }
        private void LimpiarCampos()
        {
            txt_codigo.Text = "";
            txt_producto.Text = "";
            txt_descripcion.Text = "";
            txt_precio.Text = "";
            txt_stock_inicial.Text = "";
            txt_entrada.Text = "";
            txt_salida.Text = "";
            txt_stock_total.Text = "";
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();



            }
        }
    }
}
