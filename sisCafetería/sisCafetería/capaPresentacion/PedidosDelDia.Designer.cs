namespace sisCafetería.capaPresentacion
{
    partial class PedidosDelDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosDelDia));
            this.mostrarPedidosDelDiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipal = new sisCafetería.DataSetPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mostrarPedidosDelDiaTableAdapter = new sisCafetería.DataSetPrincipalTableAdapters.MostrarPedidosDelDiaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // mostrarPedidosDelDiaBindingSource
            // 
            this.mostrarPedidosDelDiaBindingSource.DataMember = "MostrarPedidosDelDia";
            this.mostrarPedidosDelDiaBindingSource.DataSource = this.dataSetPrincipal;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_PedidosDelDia";
            reportDataSource1.Value = this.mostrarPedidosDelDiaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sisCafetería.Informe_PedidosDelDia.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1092, 753);
            this.reportViewer1.TabIndex = 0;
            // 
            // mostrarPedidosDelDiaTableAdapter
            // 
            this.mostrarPedidosDelDiaTableAdapter.ClearBeforeFill = true;
            // 
            // PedidosDelDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 753);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PedidosDelDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte";
            this.Load += new System.EventHandler(this.PedidosDelDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetPrincipal dataSetPrincipal;
        private System.Windows.Forms.BindingSource mostrarPedidosDelDiaBindingSource;
        private DataSetPrincipalTableAdapters.MostrarPedidosDelDiaTableAdapter mostrarPedidosDelDiaTableAdapter;
    }
}