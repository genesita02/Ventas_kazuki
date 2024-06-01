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

    public partial class Cliente : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CHERRYY-E5440;Initial Catalog=ventas_kazuki;User ID=sa;Password=123456;");



        public Cliente()
        {
            InitializeComponent();

        }

        #region "mis variables"
        int id_cliente = 0;
        int EstadoGuarda = 0;
        private readonly string connectionString;

        #endregion


        private void cargarDatos()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dgvResultados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();



            }
        }

        private void estado_botonesprincipales(bool LEstado)
        {
            this.btn_siguente.Enabled = LEstado;
            this.btn_eliminar.Enabled = LEstado;
            this.btn_eliminar.Enabled=LEstado;

        }

        private void Estado_botonesprocesos(bool LEstado)
        {
            this.btn_salir.Enabled = LEstado;
            this.btn_guardar.Enabled = LEstado;


        }


        private void Cliente_Load(object sender, EventArgs e)
        {

        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }



        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cargarDatos();

        }



        private void tbg_listado_Click(object sender, EventArgs e)
        {

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 1;
            this.estado_botonesprincipales(false);
            this.Estado_botonesprocesos(true);
            txt_codigo.Text = "";
            txt_codigo.ReadOnly = false;
            txt_nombre.Text = "";
            txt_nombre.ReadOnly = false;
            txt_telefono.Text ="";
            txt_telefono.ReadOnly = false;
            txt_email.Text ="";
            txt_email.ReadOnly = false;
            txt_apellido.Text ="";
            txt_apellido.ReadOnly = false;
            Tbc_cliente.SelectedIndex = 1;


        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {




            // Establecer la consulta SQL para la inserción de datos
            string consulta = "INSERT INTO Cliente (ClienteID, Nombre, Apellido, Telefono, Email, Estado) VALUES (@ClienteID, @Nombre, @Apellido, @Telefono, @Email, @Estado)";

            // Crear una instancia de SqlCommand y establecer la conexión y la consulta
            using (SqlCommand command = new SqlCommand(consulta, conn))
            {
                // Agregar parámetros para evitar la inyección SQL y mejorar la seguridad
                command.Parameters.AddWithValue("@ClienteID", txt_codigo.Text);
                command.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                command.Parameters.AddWithValue("@Apellido", txt_apellido.Text);
                command.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                command.Parameters.AddWithValue("@Email", txt_email.Text);
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
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            cbx_estado.SelectedIndex = -1;
        }

        private void dgvResultados_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            if (indice == -1 || dgvResultados.SelectedCells[1].Value == null || dgvResultados.SelectedCells[1].Value.ToString() == "")
            {
                MessageBox.Show("Seleccione un registro válido");
            }
            else
            {
                txt_codigo.Text = dgvResultados.SelectedCells[0].Value.ToString();
                txt_nombre.Text = dgvResultados.SelectedCells[1].Value.ToString();
                txt_apellido.Text = dgvResultados.SelectedCells[2].Value.ToString();
                txt_telefono.Text = dgvResultados.SelectedCells[3].Value.ToString();
                txt_email.Text = dgvResultados.SelectedCells[4].Value.ToString();
                cbx_estado.Text = dgvResultados.SelectedCells[5].Value.ToString();

            }
        }
        private void dgvResultados_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_modificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Abre la conexión
                conn.Open();

                // Crear el comando y especificar el tipo como procedimiento almacenado
                SqlCommand cmd = new SqlCommand("ModificarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Añadir los parámetros necesarios
                cmd.Parameters.AddWithValue("@ClienteID", Convert.ToInt32(txt_codigo.Text));
                cmd.Parameters.AddWithValue("@NuevoNombre", txt_nombre.Text);
                cmd.Parameters.AddWithValue("@NuevoApellido", txt_apellido.Text);
                cmd.Parameters.AddWithValue("@NuevoTelefono", txt_telefono.Text);
                cmd.Parameters.AddWithValue("@NuevoEmail", txt_email.Text);
                cmd.Parameters.AddWithValue("@NuevoEstado", cbx_estado.Text);

                // Ejecutar el comando
                int rowsAffected = cmd.ExecuteNonQuery();

                // Informar al usuario del resultado
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Datos actualizados correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre la conexión
                conn.Open();

                // Crear el comando y especificar el tipo como procedimiento almacenado
                SqlCommand cmd = new SqlCommand("EliminarCliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Añadir los parámetros necesarios
                cmd.Parameters.AddWithValue("@ClienteID", Convert.ToInt32(txt_codigo.Text));

                // Ejecutar el comando
                int rowsAffected = cmd.ExecuteNonQuery();

                // Informar al usuario del resultado
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cliente eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
    }
    
  


 


