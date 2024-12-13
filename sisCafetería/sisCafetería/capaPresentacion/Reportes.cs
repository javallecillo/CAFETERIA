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
using sisCafetería.capaDatos;
using sisCafetería.capaLogica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace sisCafetería.capaPresentacion
{
    public partial class Reportes : Form
    {
        PedidosCD oPedidosCD;

        public Reportes()
        {
            oPedidosCD = new PedidosCD();
            InitializeComponent();
            LimpiarTextBox();
        }

        private void LimpiarTextBox()
        {
            cbUsuario.SelectedIndex = -1;
            cbTipoReporte.SelectedIndex = -1;

            btnConsultar.Enabled = false;
            btnPDF.Enabled = false;
            btnExcel.Enabled = false;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

            // Definir las columnas del DataGridView si no se han definido en el diseñador
            if (dataReportes.Columns.Count == 0) // Solo agregar columnas si no existen
            {
                DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
                btnDetalles.Name = ""; // Nombre de la columna
                btnDetalles.Text = "Detalles";
                btnDetalles.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnDetalles.Width = 110;
                btnDetalles.FlatStyle = FlatStyle.Flat;
                btnDetalles.UseColumnTextForButtonValue = true; // El texto es fijo (Eliminar)

                // Definir el estilo para la columna
                DataGridViewCellStyle style = new DataGridViewCellStyle
                {
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    SelectionBackColor = Color.Black,
                    SelectionForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };
                btnDetalles.DefaultCellStyle = style;

                dataReportes.Columns.Add(btnDetalles);
            }

            // Configurar DataGridView al cargar el formulario
            if (!dataReportes.Columns.Contains("ID"))
            {
                DataGridViewTextBoxColumn colIdPedido = new DataGridViewTextBoxColumn();
                colIdPedido.Name = "ID";
                colIdPedido.HeaderText = "ID";
                colIdPedido.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                colIdPedido.Width = 70;
                colIdPedido.Visible = false; // La columna no será visible
                dataReportes.Columns.Add(colIdPedido);
            }

            UsuariosCD objUsuario = new UsuariosCD();
            cbUsuario.DataSource = objUsuario.MostrarUsuarios().Tables[0];
            cbUsuario.DisplayMember = "Usuario";
            cbUsuario.ValueMember = "IdUsuario";
            LimpiarTextBox();
        }

        private void dataReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna del botón
            if (e.RowIndex >= 0 && dataReportes.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Obtener el ID del pedido de la fila seleccionada
                int idPedido = Convert.ToInt32(dataReportes.Rows[e.RowIndex].Cells["ID"].Value);

                // Crear y mostrar el formulario de detalles
                DetallePedidos detalleForm = new DetallePedidos(idPedido);
                detalleForm.ShowDialog(); // Abrir como cuadro de diálogo modal
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Variables para filtros
                int idUsuario = Convert.ToInt32(cbUsuario.SelectedValue); // Asumiendo que el ComboBox tiene los IDs de usuario como valores
                string tipoReporte = cbTipoReporte.SelectedItem?.ToString(); // "Ventas del día" o "Ventas por fecha"
                DataSet ds;

                btnPDF.Enabled = true;
                btnExcel.Enabled = true;

                // Instancia de la capa de datos
                PedidosCD pedidosCD = new PedidosCD();

                // Selección de tipo de reporte
                if (tipoReporte == "Ventas del día")
                {
                    if (idUsuario > 0) // Si hay un usuario seleccionado
                    {
                        ds = pedidosCD.MostrarPedidosDelDiaPorUsuario(idUsuario); // Consulta específica
                    }
                    else
                    {
                        ds = pedidosCD.MostrarPedidosDelDia(); // Consulta general para ventas del día
                    }
                }
                else if (tipoReporte == "Ventas por fecha")
                {
                    label1.Visible = true;
                    label3.Visible = true;
                    dateTimeDesde.Visible = true;
                    dateTimeHasta.Visible = true;

                    // Validar que los DateTimePickers sean visibles y tengan fechas válidas
                    if (!dateTimeDesde.Visible || !dateTimeHasta.Visible)
                    {
                        MessageBox.Show("Por favor selecciona un rango de fechas válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DateTime fechaDesde = dateTimeDesde.Value.Date;
                    DateTime fechaHasta = dateTimeHasta.Value.Date;

                    if (fechaDesde > fechaHasta)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (idUsuario > 0) // Si hay un usuario seleccionado
                    {
                        // Generar la consulta con filtro de usuario y fechas
                        ds = pedidosCD.MostrarPedidosPorFechaYUsuario(idUsuario, fechaDesde, fechaHasta);
                    }
                    else
                    {
                        ds = pedidosCD.MostrarPedidosPorFechaGeneral(fechaDesde, fechaHasta); // Consulta general para ventas por fecha
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecciona un tipo de reporte válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mostrar resultados en el DataGridView
                dataReportes.DataSource = ds.Tables[0];

                // Asegurarse de que exista la columna oculta 'IdPedido'
                if (!dataReportes.Columns.Contains("ID"))
                {
                    DataGridViewTextBoxColumn colIdPedido = new DataGridViewTextBoxColumn
                    {
                        Name = "ID",
                        HeaderText = "ID",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 70,
                        Visible = false // Hacerla oculta
                    };
                    dataReportes.Columns.Add(colIdPedido);
                }

                // Asignar valores a la columna oculta 'IdPedido' desde los datos
                foreach (DataGridViewRow row in dataReportes.Rows)
                {
                    if (row.DataBoundItem is DataRowView dataRowView)
                    {
                        row.Cells["ID"].Value = dataRowView["ID"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al consultar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado en cbTipoReporte
            string tipoReporte = cbTipoReporte.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(tipoReporte))
            {
                // Habilitar botones si hay un valor seleccionado
                btnConsultar.Enabled = true;

                // Mostrar u ocultar los controles de fecha según el tipo de reporte seleccionado
                if (tipoReporte == "Ventas por fecha")
                {
                    label1.Visible = true;
                    label3.Visible = true;
                    dateTimeDesde.Visible = true;
                    dateTimeHasta.Visible = true;
                }
                else if (tipoReporte == "Ventas del día")
                {
                    label1.Visible = false;
                    label3.Visible = false;
                    dateTimeDesde.Visible = false;
                    dateTimeHasta.Visible = false;
                }
            }
            else
            {
                // Deshabilitar botones si no hay valor seleccionado
                btnConsultar.Enabled = false;
                btnPDF.Enabled = false;
                btnExcel.Enabled = false;

                // Ocultar los controles de fecha por defecto
                label1.Visible = false;
                label3.Visible = false;
                dateTimeDesde.Visible = false;
                dateTimeHasta.Visible = false;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            MostrarReporte mostrarReporte = new MostrarReporte();

            mostrarReporte.ShowDialog();
        }
    }
}
