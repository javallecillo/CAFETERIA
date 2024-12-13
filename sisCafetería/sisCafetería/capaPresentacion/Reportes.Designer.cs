namespace sisCafetería.capaPresentacion
{
    partial class Reportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelReportes = new System.Windows.Forms.Panel();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dataReportes = new System.Windows.Forms.DataGridView();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.cbTipoReporte = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelReportes
            // 
            this.panelReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.panelReportes.Controls.Add(this.btnPDF);
            this.panelReportes.Controls.Add(this.btnConsultar);
            this.panelReportes.Controls.Add(this.dataReportes);
            this.panelReportes.Controls.Add(this.dateTimeHasta);
            this.panelReportes.Controls.Add(this.dateTimeDesde);
            this.panelReportes.Controls.Add(this.label3);
            this.panelReportes.Controls.Add(this.label1);
            this.panelReportes.Controls.Add(this.cbUsuario);
            this.panelReportes.Controls.Add(this.cbTipoReporte);
            this.panelReportes.Controls.Add(this.label5);
            this.panelReportes.Controls.Add(this.label2);
            this.panelReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportes.Location = new System.Drawing.Point(0, 0);
            this.panelReportes.Name = "panelReportes";
            this.panelReportes.Size = new System.Drawing.Size(1544, 697);
            this.panelReportes.TabIndex = 0;
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Location = new System.Drawing.Point(33, 631);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(247, 36);
            this.btnPDF.TabIndex = 140;
            this.btnPDF.Text = "Imprimir";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            this.btnConsultar.Enabled = false;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(33, 572);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(247, 36);
            this.btnConsultar.TabIndex = 138;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dataReportes
            // 
            this.dataReportes.AllowUserToAddRows = false;
            this.dataReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataReportes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataReportes.EnableHeadersVisualStyles = false;
            this.dataReportes.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataReportes.Location = new System.Drawing.Point(314, 33);
            this.dataReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataReportes.Name = "dataReportes";
            this.dataReportes.ReadOnly = true;
            this.dataReportes.RowHeadersVisible = false;
            this.dataReportes.RowHeadersWidth = 51;
            this.dataReportes.RowTemplate.Height = 24;
            this.dataReportes.Size = new System.Drawing.Size(1196, 634);
            this.dataReportes.TabIndex = 137;
            this.dataReportes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataReportes_CellContentClick);
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeHasta.Location = new System.Drawing.Point(33, 321);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(247, 30);
            this.dateTimeHasta.TabIndex = 136;
            this.dateTimeHasta.Visible = false;
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.Checked = false;
            this.dateTimeDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDesde.Location = new System.Drawing.Point(33, 234);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(247, 30);
            this.dateTimeDesde.TabIndex = 135;
            this.dateTimeDesde.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimeDesde.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(29, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 133;
            this.label3.Text = "Fecha desde:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(29, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 131;
            this.label1.Text = "Fecha hasta:";
            this.label1.Visible = false;
            // 
            // cbUsuario
            // 
            this.cbUsuario.BackColor = System.Drawing.Color.White;
            this.cbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbUsuario.ForeColor = System.Drawing.Color.Black;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(33, 58);
            this.cbUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(247, 31);
            this.cbUsuario.TabIndex = 130;
            // 
            // cbTipoReporte
            // 
            this.cbTipoReporte.BackColor = System.Drawing.Color.White;
            this.cbTipoReporte.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTipoReporte.ForeColor = System.Drawing.Color.Black;
            this.cbTipoReporte.FormattingEnabled = true;
            this.cbTipoReporte.Items.AddRange(new object[] {
            "Ventas del día",
            "Ventas por fecha"});
            this.cbTipoReporte.Location = new System.Drawing.Point(33, 146);
            this.cbTipoReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipoReporte.Name = "cbTipoReporte";
            this.cbTipoReporte.Size = new System.Drawing.Size(247, 31);
            this.cbTipoReporte.TabIndex = 129;
            this.cbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cbTipoReporte_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(29, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 128;
            this.label5.Text = "Elige el usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 23);
            this.label2.TabIndex = 127;
            this.label2.Text = "Elige el tipo de reporte:";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 697);
            this.Controls.Add(this.panelReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.panelReportes.ResumeLayout(false);
            this.panelReportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReportes;
        public System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.ComboBox cbTipoReporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.DataGridView dataReportes;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnConsultar;
    }
}