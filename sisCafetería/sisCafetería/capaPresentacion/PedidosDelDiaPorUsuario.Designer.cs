namespace sisCafetería.capaPresentacion
{
    partial class PedidosDelDiaPorUsuario
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosDelDiaPorUsuario));
            this.mostrarPedidosDelDiaPorUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipal = new sisCafetería.DataSetPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mostrarPedidosDelDiaPorUsuarioTableAdapter = new sisCafetería.DataSetPrincipalTableAdapters.MostrarPedidosDelDiaPorUsuarioTableAdapter();
            this.MostrarPedidosDelDiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mostrarPedidosDelDiaPorUsuarioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaPorUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarPedidosDelDiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaPorUsuarioBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mostrarPedidosDelDiaPorUsuarioBindingSource
            // 
            this.mostrarPedidosDelDiaPorUsuarioBindingSource.DataMember = "MostrarPedidosDelDiaPorUsuario";
            this.mostrarPedidosDelDiaPorUsuarioBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_PedidosDelDiaPorUsuario";
            reportDataSource1.Value = this.mostrarPedidosDelDiaPorUsuarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sisCafetería.Informe_PedidosDelDiaPorUsuario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1092, 753);
            this.reportViewer1.TabIndex = 0;
            // 
            // mostrarPedidosDelDiaPorUsuarioTableAdapter
            // 
            this.mostrarPedidosDelDiaPorUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarPedidosDelDiaBindingSource
            // 
            this.MostrarPedidosDelDiaBindingSource.DataMember = "MostrarPedidosDelDia";
            this.MostrarPedidosDelDiaBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // mostrarPedidosDelDiaPorUsuarioBindingSource1
            // 
            this.mostrarPedidosDelDiaPorUsuarioBindingSource1.DataMember = "MostrarPedidosDelDiaPorUsuario";
            this.mostrarPedidosDelDiaPorUsuarioBindingSource1.DataSource = this.dataSetPrincipal;
            // 
            // PedidosDelDiaPorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 753);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PedidosDelDiaPorUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte";
            this.Load += new System.EventHandler(this.PedidosDelDiaPorUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaPorUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarPedidosDelDiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaPorUsuarioBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mostrarPedidosDelDiaPorUsuarioBindingSource;
        private DataSetPrincipal dataSetPrincipal;
        private DataSetPrincipalTableAdapters.MostrarPedidosDelDiaPorUsuarioTableAdapter mostrarPedidosDelDiaPorUsuarioTableAdapter;
        private System.Windows.Forms.BindingSource MostrarPedidosDelDiaBindingSource;
        private System.Windows.Forms.BindingSource mostrarPedidosDelDiaPorUsuarioBindingSource1;
    }
}