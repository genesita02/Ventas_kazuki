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
    public partial class Empleado : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CHERRYY-E5440;Initial Catalog=ventas_kazuki;User ID=sa;Password=123456;TrustServerCertificate=True");
        public Empleado()
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

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Empleados", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dtv_empleado.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            // Establecer la consulta SQL para la inserción de datos
            string consulta = "INSERT INTO Empleados (EmpleadoID, Nombre, Apellido, Cargo, Salario, Estado)VALUES (@EmpleadoID, @Nombre, @Apellido, @Cargo, @Salario, @Estado);";

            // Crear una instancia de SqlCommand y establecer la conexión y la consulta
            using (SqlCommand command = new SqlCommand(consulta, conn))
            {
                // Agregar parámetros para evitar la inyección SQL y mejorar la seguridad
                command.Parameters.AddWithValue("@EmpleadoID",txt_codigo_empleado.Text);
                command.Parameters.AddWithValue("@Nombre", txt_nombre_empleado.Text);
                command.Parameters.AddWithValue("@Apellido", txt_apellido_empleado.Text);
                command.Parameters.AddWithValue("@Cargo", cbx_cargo.Text);
                command.Parameters.AddWithValue("@Salario", txt_salario.Text);
                command.Parameters.AddWithValue("@Estado", cbx_estado.Text);

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
        }
        private void LimpiarCampos()
        {
            txt_codigo_empleado.Text ="";
            txt_nombre_empleado.Text = "";
           txt_apellido_empleado.Text = "";
            cbx_cargo.SelectedIndex = -1;
            txt_salario.Text = "";
            cbx_estado.SelectedIndex = -1;
        }

        private void Empleado_Load(object sender, EventArgs e)
        {

        }

        private void btn_consulta_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
