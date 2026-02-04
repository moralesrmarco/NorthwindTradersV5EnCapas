namespace NorthwindTradersV5EnCapas
{
    partial class FrmVentasDetalleCrud
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbVentas = new System.Windows.Forms.GroupBox();
            this.DgvVentas = new System.Windows.Forms.DataGridView();
            this.GrbPedido = new System.Windows.Forms.GroupBox();
            this.BtnNota = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.controlAgregarProducto = new NorthwindTradersV5EnCapas.ControlAgregarProducto();
            this.controlTotalesDeLaVenta = new NorthwindTradersV5EnCapas.ControlTotalesDeLaVenta();
            this.controlDetalleDeLaVenta = new NorthwindTradersV5EnCapas.ControlDetalleDeLaVenta();
            this.controlBuscarVenta = new NorthwindTradersV5EnCapas.ControlBuscarVenta();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).BeginInit();
            this.GrbPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.panel1.Size = new System.Drawing.Size(1525, 741);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1211F));
            this.tableLayoutPanel1.Controls.Add(this.GrbPedido, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.grbVentas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlAgregarProducto, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.controlTotalesDeLaVenta, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.controlDetalleDeLaVenta, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.controlBuscarVenta, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1478, 1272);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1529, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "     Busque la venta y seleccionela en la lista que se muestra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbVentas
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grbVentas, 2);
            this.grbVentas.Controls.Add(this.DgvVentas);
            this.grbVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbVentas.Location = new System.Drawing.Point(8, 35);
            this.grbVentas.Name = "grbVentas";
            this.grbVentas.Padding = new System.Windows.Forms.Padding(10);
            this.grbVentas.Size = new System.Drawing.Size(1529, 250);
            this.grbVentas.TabIndex = 3;
            this.grbVentas.TabStop = false;
            this.grbVentas.Text = "»   Ventas:   «";
            // 
            // DgvVentas
            // 
            this.DgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVentas.Location = new System.Drawing.Point(10, 23);
            this.DgvVentas.Name = "DgvVentas";
            this.DgvVentas.RowHeadersWidth = 51;
            this.DgvVentas.Size = new System.Drawing.Size(1509, 217);
            this.DgvVentas.TabIndex = 0;
            this.DgvVentas.TabStop = false;
            // 
            // GrbPedido
            // 
            this.GrbPedido.Controls.Add(this.BtnNota);
            this.GrbPedido.Controls.Add(this.txtCliente);
            this.GrbPedido.Controls.Add(this.txtId);
            this.GrbPedido.Controls.Add(this.label20);
            this.GrbPedido.Controls.Add(this.label17);
            this.GrbPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrbPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbPedido.Location = new System.Drawing.Point(349, 291);
            this.GrbPedido.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.GrbPedido.Name = "GrbPedido";
            this.GrbPedido.Size = new System.Drawing.Size(1188, 100);
            this.GrbPedido.TabIndex = 7;
            this.GrbPedido.TabStop = false;
            this.GrbPedido.Text = "»   Venta:   «";
            // 
            // BtnNota
            // 
            this.BtnNota.Enabled = false;
            this.BtnNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNota.Location = new System.Drawing.Point(402, 68);
            this.BtnNota.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNota.Name = "BtnNota";
            this.BtnNota.Size = new System.Drawing.Size(176, 26);
            this.BtnNota.TabIndex = 20;
            this.BtnNota.Text = "Nota de remisión";
            this.BtnNota.UseVisualStyleBackColor = true;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(96, 42);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(483, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(96, 15);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(106, 23);
            this.txtId.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(41, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Cliente:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(70, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Id:";
            // 
            // controlAgregarProducto
            // 
            this.controlAgregarProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlAgregarProducto.Location = new System.Drawing.Point(349, 397);
            this.controlAgregarProducto.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.controlAgregarProducto.Name = "controlAgregarProducto";
            this.controlAgregarProducto.Size = new System.Drawing.Size(1188, 393);
            this.controlAgregarProducto.TabIndex = 8;
            // 
            // controlTotalesDeLaVenta
            // 
            this.controlTotalesDeLaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTotalesDeLaVenta.Location = new System.Drawing.Point(349, 796);
            this.controlTotalesDeLaVenta.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.controlTotalesDeLaVenta.Name = "controlTotalesDeLaVenta";
            this.controlTotalesDeLaVenta.Size = new System.Drawing.Size(1188, 165);
            this.controlTotalesDeLaVenta.TabIndex = 9;
            // 
            // controlDetalleDeLaVenta
            // 
            this.controlDetalleDeLaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDetalleDeLaVenta.Location = new System.Drawing.Point(349, 967);
            this.controlDetalleDeLaVenta.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.controlDetalleDeLaVenta.Name = "controlDetalleDeLaVenta";
            this.controlDetalleDeLaVenta.Size = new System.Drawing.Size(1188, 302);
            this.controlDetalleDeLaVenta.TabIndex = 10;
            // 
            // controlBuscarVenta
            // 
            this.controlBuscarVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlBuscarVenta.Location = new System.Drawing.Point(8, 291);
            this.controlBuscarVenta.Name = "controlBuscarVenta";
            this.tableLayoutPanel1.SetRowSpan(this.controlBuscarVenta, 4);
            this.controlBuscarVenta.Size = new System.Drawing.Size(318, 978);
            this.controlBuscarVenta.TabIndex = 11;
            // 
            // FrmVentasDetalleCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1535, 761);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmVentasDetalleCrud";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.Text = "» Mantenimiento de detalle de ventas «";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentasDetalleCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVentasDetalleCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmVentasDetalleCrud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grbVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).EndInit();
            this.GrbPedido.ResumeLayout(false);
            this.GrbPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbVentas;
        private System.Windows.Forms.DataGridView DgvVentas;
        private System.Windows.Forms.GroupBox GrbPedido;
        private System.Windows.Forms.Button BtnNota;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private ControlAgregarProducto controlAgregarProducto;
        private ControlTotalesDeLaVenta controlTotalesDeLaVenta;
        private ControlDetalleDeLaVenta controlDetalleDeLaVenta;
        private ControlBuscarVenta controlBuscarVenta;
    }
}