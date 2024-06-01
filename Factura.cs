﻿using System;
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
    public partial class Factura : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CHERRYY-E5440;Initial Catalog=ventas_kazuki;User ID=sa;Password=123456;");
        public Factura()
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

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM factura", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dvg_factura.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            // Establecer la consulta SQL para la inserción de datos
            string consulta = "INSERT INTO factura (id_factura, producto, descripcion, precio, itbis, cantidad, total)VALUES (@id_factura, @producto, @descripcion, @precio, @itbis, @cantidad, @total);";

            // Crear una instancia de SqlCommand y establecer la conexión y la consulta
            using (SqlCommand command = new SqlCommand(consulta, conn))
            {
                // Agregar parámetros para evitar la inyección SQL y mejorar la seguridad
                command.Parameters.AddWithValue("@id_factura", txt_codigo.Text);
                command.Parameters.AddWithValue("@producto", txt_producto.Text);
                command.Parameters.AddWithValue("@descripcion", txt_descripcion.Text);
                command.Parameters.AddWithValue("@precio", txt_precio.Text);
                command.Parameters.AddWithValue("@itbis", txt_itebis.Text);
                command.Parameters.AddWithValue("@cantidad", txt_cantidad);
                command.Parameters.AddWithValue("@total", txt_total);

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

            decimal itbis;
            itbis = decimal.Parse(txt_itebis.Text);
            decimal v1, v2, r1;
            v1 = decimal.Parse(txt_precio.Text);
            v2 = decimal.Parse(txt_cantidad.Text);

            r1 = v1*v2;

            txt_total.Text = r1.ToString();
        }
        private void LimpiarCampos()
        {
            txt_codigo.Text = "";
            txt_producto.Text = "";
            txt_descripcion.Text = "";
            txt_precio.Text = "";
            txt_itebis.Text ="";
            txt_cantidad.Text ="";
            txt_total.Text ="";
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cargarDatos();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();



            }

        }
    }
}
