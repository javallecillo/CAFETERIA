namespace sisCafetería.capaPresentacion
{
    partial class Pedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPedidos = new System.Windows.Forms.Panel();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.txtIdDetallePedido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGuardarPedido = new System.Windows.Forms.Button();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.btnTomarPedido = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.grupoProductos = new System.Windows.Forms.GroupBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.dataPedidos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbNombreProducto = new System.Windows.Forms.ComboBox();
            this.btnBuscarFrm = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grupoDatosPedido = new System.Windows.Forms.GroupBox();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.cbTipoPedido = new System.Windows.Forms.ComboBox();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroMesa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.panelPedidos.SuspendLayout();
            this.grupoProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPedidos)).BeginInit();
            this.grupoDatosPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPedidos
            // 
            this.panelPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panelPedidos.Controls.Add(this.btnGuardarPedido);
            this.panelPedidos.Controls.Add(this.btnCancelarPedido);
            this.panelPedidos.Controls.Add(this.btnTomarPedido);
            this.panelPedidos.Controls.Add(this.label9);
            this.panelPedidos.Controls.Add(this.txtTotal);
            this.panelPedidos.Controls.Add(this.grupoProductos);
            this.panelPedidos.Controls.Add(this.label11);
            this.panelPedidos.Controls.Add(this.grupoDatosPedido);
            this.panelPedidos.Controls.Add(this.label7);
            this.panelPedidos.Controls.Add(this.txtCambio);
            this.panelPedidos.Controls.Add(this.txtRecibido);
            this.panelPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPedidos.Location = new System.Drawing.Point(0, 0);
            this.panelPedidos.Name = "panelPedidos";
            this.panelPedidos.Size = new System.Drawing.Size(1556, 699);
            this.panelPedidos.TabIndex = 0;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(1025, 226);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(115, 36);
            this.btnQuitar.TabIndex = 127;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Visible = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // txtIdDetallePedido
            // 
            this.txtIdDetallePedido.BackColor = System.Drawing.Color.White;
            this.txtIdDetallePedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdDetallePedido.Enabled = false;
            this.txtIdDetallePedido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIdDetallePedido.ForeColor = System.Drawing.Color.Black;
            this.txtIdDetallePedido.Location = new System.Drawing.Point(920, 231);
            this.txtIdDetallePedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdDetallePedido.Name = "txtIdDetallePedido";
            this.txtIdDetallePedido.ReadOnly = true;
            this.txtIdDetallePedido.Size = new System.Drawing.Size(99, 30);
            this.txtIdDetallePedido.TabIndex = 137;
            this.txtIdDetallePedido.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.Location = new System.Drawing.Point(854, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 23);
            this.label13.TabIndex = 136;
            this.label13.Text = "ID_DP:";
            this.label13.Visible = false;
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.BackColor = System.Drawing.Color.White;
            this.txtIdPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdPedido.Enabled = false;
            this.txtIdPedido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIdPedido.ForeColor = System.Drawing.Color.Black;
            this.txtIdPedido.Location = new System.Drawing.Point(730, 226);
            this.txtIdPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.ReadOnly = true;
            this.txtIdPedido.Size = new System.Drawing.Size(99, 30);
            this.txtIdPedido.TabIndex = 134;
            this.txtIdPedido.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(660, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 23);
            this.label12.TabIndex = 133;
            this.label12.Text = "ID_P:";
            this.label12.Visible = false;
            // 
            // btnGuardarPedido
            // 
            this.btnGuardarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnGuardarPedido.FlatAppearance.BorderSize = 0;
            this.btnGuardarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPedido.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPedido.Location = new System.Drawing.Point(1276, 169);
            this.btnGuardarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarPedido.Name = "btnGuardarPedido";
            this.btnGuardarPedido.Size = new System.Drawing.Size(248, 42);
            this.btnGuardarPedido.TabIndex = 135;
            this.btnGuardarPedido.Text = "GUARDAR PEDIDO";
            this.btnGuardarPedido.UseVisualStyleBackColor = false;
            this.btnGuardarPedido.Click += new System.EventHandler(this.btnGuardarPedido_Click);
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnCancelarPedido.FlatAppearance.BorderSize = 0;
            this.btnCancelarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarPedido.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPedido.Location = new System.Drawing.Point(1274, 101);
            this.btnCancelarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(248, 42);
            this.btnCancelarPedido.TabIndex = 134;
            this.btnCancelarPedido.Text = "CANCELAR PEDIDO";
            this.btnCancelarPedido.UseVisualStyleBackColor = false;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // btnTomarPedido
            // 
            this.btnTomarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnTomarPedido.FlatAppearance.BorderSize = 0;
            this.btnTomarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomarPedido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTomarPedido.ForeColor = System.Drawing.Color.White;
            this.btnTomarPedido.Location = new System.Drawing.Point(1274, 33);
            this.btnTomarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTomarPedido.Name = "btnTomarPedido";
            this.btnTomarPedido.Size = new System.Drawing.Size(248, 42);
            this.btnTomarPedido.TabIndex = 133;
            this.btnTomarPedido.Text = "TOMAR PEDIDO";
            this.btnTomarPedido.UseVisualStyleBackColor = false;
            this.btnTomarPedido.Click += new System.EventHandler(this.btnTomarPedido_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1273, 544);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 31);
            this.label9.TabIndex = 128;
            this.label9.Text = "*TOTAL:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(1377, 545);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(145, 30);
            this.txtTotal.TabIndex = 129;
            // 
            // grupoProductos
            // 
            this.grupoProductos.BackColor = System.Drawing.Color.Gainsboro;
            this.grupoProductos.Controls.Add(this.txtSubTotal);
            this.grupoProductos.Controls.Add(this.dataPedidos);
            this.grupoProductos.Controls.Add(this.btnAgregar);
            this.grupoProductos.Controls.Add(this.label14);
            this.grupoProductos.Controls.Add(this.cbNombreProducto);
            this.grupoProductos.Controls.Add(this.btnBuscarFrm);
            this.grupoProductos.Controls.Add(this.txtCantidad);
            this.grupoProductos.Controls.Add(this.txtPrecioUnitario);
            this.grupoProductos.Controls.Add(this.label8);
            this.grupoProductos.Controls.Add(this.label10);
            this.grupoProductos.Controls.Add(this.label4);
            this.grupoProductos.Controls.Add(this.label12);
            this.grupoProductos.Controls.Add(this.txtIdPedido);
            this.grupoProductos.Controls.Add(this.label13);
            this.grupoProductos.Controls.Add(this.txtIdDetallePedido);
            this.grupoProductos.Controls.Add(this.btnQuitar);
            this.grupoProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoProductos.Location = new System.Drawing.Point(30, 232);
            this.grupoProductos.Name = "grupoProductos";
            this.grupoProductos.Size = new System.Drawing.Size(1230, 435);
            this.grupoProductos.TabIndex = 126;
            this.grupoProductos.TabStop = false;
            this.grupoProductos.Text = "Productos a ordenar";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.White;
            this.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSubTotal.ForeColor = System.Drawing.Color.Black;
            this.txtSubTotal.Location = new System.Drawing.Point(973, 47);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(91, 30);
            this.txtSubTotal.TabIndex = 139;
            // 
            // dataPedidos
            // 
            this.dataPedidos.AllowUserToAddRows = false;
            this.dataPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPedidos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataPedidos.EnableHeadersVisualStyles = false;
            this.dataPedidos.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataPedidos.Location = new System.Drawing.Point(27, 103);
            this.dataPedidos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataPedidos.Name = "dataPedidos";
            this.dataPedidos.ReadOnly = true;
            this.dataPedidos.RowHeadersVisible = false;
            this.dataPedidos.RowHeadersWidth = 51;
            this.dataPedidos.RowTemplate.Height = 24;
            this.dataPedidos.Size = new System.Drawing.Size(1176, 307);
            this.dataPedidos.TabIndex = 132;
            this.dataPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPedidos_CellContentClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(1088, 43);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 36);
            this.btnAgregar.TabIndex = 126;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.Location = new System.Drawing.Point(896, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 23);
            this.label14.TabIndex = 138;
            this.label14.Text = "*Subtot.:";
            // 
            // cbNombreProducto
            // 
            this.cbNombreProducto.BackColor = System.Drawing.Color.White;
            this.cbNombreProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbNombreProducto.Enabled = false;
            this.cbNombreProducto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbNombreProducto.ForeColor = System.Drawing.Color.Black;
            this.cbNombreProducto.FormattingEnabled = true;
            this.cbNombreProducto.Location = new System.Drawing.Point(120, 47);
            this.cbNombreProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbNombreProducto.Name = "cbNombreProducto";
            this.cbNombreProducto.Size = new System.Drawing.Size(273, 31);
            this.cbNombreProducto.TabIndex = 125;
            this.cbNombreProducto.Tag = "";
            this.cbNombreProducto.SelectedIndexChanged += new System.EventHandler(this.cbNombreProducto_SelectedIndexChanged);
            // 
            // btnBuscarFrm
            // 
            this.btnBuscarFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnBuscarFrm.FlatAppearance.BorderSize = 0;
            this.btnBuscarFrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarFrm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscarFrm.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBuscarFrm.Location = new System.Drawing.Point(399, 43);
            this.btnBuscarFrm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarFrm.Name = "btnBuscarFrm";
            this.btnBuscarFrm.Size = new System.Drawing.Size(88, 36);
            this.btnBuscarFrm.TabIndex = 124;
            this.btnBuscarFrm.Text = "Buscar";
            this.btnBuscarFrm.UseVisualStyleBackColor = false;
            this.btnBuscarFrm.Click += new System.EventHandler(this.btnBuscarFrm_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(601, 47);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(81, 30);
            this.txtCantidad.TabIndex = 123;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(777, 47);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.ReadOnly = true;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(99, 30);
            this.txtPrecioUnitario.TabIndex = 121;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(710, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 23);
            this.label8.TabIndex = 118;
            this.label8.Text = "*Precio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(23, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 23);
            this.label10.TabIndex = 115;
            this.label10.Text = "*Producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(509, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 122;
            this.label4.Text = "*Cantidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.Location = new System.Drawing.Point(1275, 596);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 23);
            this.label11.TabIndex = 130;
            this.label11.Text = "Recibido:";
            // 
            // grupoDatosPedido
            // 
            this.grupoDatosPedido.BackColor = System.Drawing.Color.Gainsboro;
            this.grupoDatosPedido.Controls.Add(this.cbUsuario);
            this.grupoDatosPedido.Controls.Add(this.cbTipoPedido);
            this.grupoDatosPedido.Controls.Add(this.cbFormaPago);
            this.grupoDatosPedido.Controls.Add(this.label6);
            this.grupoDatosPedido.Controls.Add(this.txtNumeroMesa);
            this.grupoDatosPedido.Controls.Add(this.label5);
            this.grupoDatosPedido.Controls.Add(this.label3);
            this.grupoDatosPedido.Controls.Add(this.label2);
            this.grupoDatosPedido.Controls.Add(this.label1);
            this.grupoDatosPedido.Controls.Add(this.txtFecha);
            this.grupoDatosPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoDatosPedido.Location = new System.Drawing.Point(30, 33);
            this.grupoDatosPedido.Name = "grupoDatosPedido";
            this.grupoDatosPedido.Size = new System.Drawing.Size(1230, 178);
            this.grupoDatosPedido.TabIndex = 114;
            this.grupoDatosPedido.TabStop = false;
            this.grupoDatosPedido.Text = "Datos del pedido";
            // 
            // cbUsuario
            // 
            this.cbUsuario.BackColor = System.Drawing.Color.White;
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbUsuario.Enabled = false;
            this.cbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbUsuario.ForeColor = System.Drawing.Color.Black;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(553, 109);
            this.cbUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(247, 31);
            this.cbUsuario.TabIndex = 126;
            // 
            // cbTipoPedido
            // 
            this.cbTipoPedido.BackColor = System.Drawing.Color.White;
            this.cbTipoPedido.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTipoPedido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.cbTipoPedido.FormattingEnabled = true;
            this.cbTipoPedido.Items.AddRange(new object[] {
            "Mesa",
            "Para Llevar",
            "Domicilio"});
            this.cbTipoPedido.Location = new System.Drawing.Point(553, 47);
            this.cbTipoPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoPedido.Name = "cbTipoPedido";
            this.cbTipoPedido.Size = new System.Drawing.Size(247, 31);
            this.cbTipoPedido.TabIndex = 125;
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.BackColor = System.Drawing.Color.White;
            this.cbFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbFormaPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFormaPago.ForeColor = System.Drawing.Color.Black;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Transferencia"});
            this.cbFormaPago.Location = new System.Drawing.Point(166, 109);
            this.cbFormaPago.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(234, 31);
            this.cbFormaPago.TabIndex = 124;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(837, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 23);
            this.label6.TabIndex = 122;
            this.label6.Text = "No. de mesa:";
            // 
            // txtNumeroMesa
            // 
            this.txtNumeroMesa.BackColor = System.Drawing.Color.White;
            this.txtNumeroMesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroMesa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumeroMesa.ForeColor = System.Drawing.Color.Black;
            this.txtNumeroMesa.Location = new System.Drawing.Point(956, 48);
            this.txtNumeroMesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroMesa.Name = "txtNumeroMesa";
            this.txtNumeroMesa.Size = new System.Drawing.Size(247, 30);
            this.txtNumeroMesa.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(432, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 23);
            this.label5.TabIndex = 120;
            this.label5.Text = "*Atendido por:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(432, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 118;
            this.label3.Text = "*Tipo pedido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 116;
            this.label2.Text = "*Forma de pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "*Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFecha.ForeColor = System.Drawing.Color.Black;
            this.txtFecha.Location = new System.Drawing.Point(166, 47);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(234, 30);
            this.txtFecha.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(1275, 639);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 23);
            this.label7.TabIndex = 126;
            this.label7.Text = "Cambio:";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.White;
            this.txtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCambio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCambio.ForeColor = System.Drawing.Color.Black;
            this.txtCambio.Location = new System.Drawing.Point(1377, 637);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(145, 30);
            this.txtCambio.TabIndex = 127;
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.Color.White;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecibido.ForeColor = System.Drawing.Color.Black;
            this.txtRecibido.Location = new System.Drawing.Point(1377, 594);
            this.txtRecibido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.Size = new System.Drawing.Size(145, 30);
            this.txtRecibido.TabIndex = 131;
            this.txtRecibido.TextChanged += new System.EventHandler(this.txtRecibido_TextChanged);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 699);
            this.Controls.Add(this.panelPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.panelPedidos.ResumeLayout(false);
            this.panelPedidos.PerformLayout();
            this.grupoProductos.ResumeLayout(false);
            this.grupoProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPedidos)).EndInit();
            this.grupoDatosPedido.ResumeLayout(false);
            this.grupoDatosPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPedidos;
        private System.Windows.Forms.GroupBox grupoDatosPedido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroMesa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.ComboBox cbTipoPedido;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.GroupBox grupoProductos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbNombreProducto;
        private System.Windows.Forms.Button btnBuscarFrm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataPedidos;
        public System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Button btnGuardarPedido;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.Button btnTomarPedido;
        private System.Windows.Forms.TextBox txtIdDetallePedido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdPedido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCambio;
    }
}