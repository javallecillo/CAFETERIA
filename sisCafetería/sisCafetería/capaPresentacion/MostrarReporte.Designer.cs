namespace sisCafetería.capaPresentacion
{
    partial class MostrarReporte
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
            this.mostrarPedidosDelDiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetPrincipal = new sisCafetería.DataSetPrincipal();
            this.dataSetPrincipalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetPrincipalBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mostrarPedidosDelDiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mostrarPedidosDelDiaTableAdapter = new sisCafetería.DataSetPrincipalTableAdapters.MostrarPedidosDelDiaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipalBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mostrarPedidosDelDiaBindingSource
            // 
            this.mostrarPedidosDelDiaBindingSource.DataMember = "MostrarPedidosDelDia";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.mostrarPedidosDelDiaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "sisCafetería.Ventas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1267, 569);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetPrincipal
            // 
            this.dataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.dataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetPrincipalBindingSource
            // 
            this.dataSetPrincipalBindingSource.DataSource = this.dataSetPrincipal;
            this.dataSetPrincipalBindingSource.Position = 0;
            // 
            // dataSetPrincipalBindingSource1
            // 
            this.dataSetPrincipalBindingSource1.DataSource = this.dataSetPrincipal;
            this.dataSetPrincipalBindingSource1.Position = 0;
            // 
            // mostrarPedidosDelDiaBindingSource1
            // 
            this.mostrarPedidosDelDiaBindingSource1.DataMember = "MostrarPedidosDelDia";
            this.mostrarPedidosDelDiaBindingSource1.DataSource = this.dataSetPrincipalBindingSource;
            // 
            // mostrarPedidosDelDiaTableAdapter
            // 
            this.mostrarPedidosDelDiaTableAdapter.ClearBeforeFill = true;
            // 
            // MostrarReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 569);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MostrarReporte";
            this.Text = "MostrarReporte";
            this.Load += new System.EventHandler(this.MostrarReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetPrincipalBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarPedidosDelDiaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource mostrarPedidosDelDiaBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetPrincipal dataSetPrincipal;
        private System.Windows.Forms.BindingSource dataSetPrincipalBindingSource;
        private System.Windows.Forms.BindingSource dataSetPrincipalBindingSource1;
        private System.Windows.Forms.BindingSource mostrarPedidosDelDiaBindingSource1;
        private DataSetPrincipalTableAdapters.MostrarPedidosDelDiaTableAdapter mostrarPedidosDelDiaTableAdapter;
    }
}