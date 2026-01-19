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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GrbTotales = new System.Windows.Forms.GroupBox();
            this.LblSubtotalDelImporteSinIVA = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteSinIVA = new Utilities.NudNoWheel();
            this.label21 = new System.Windows.Forms.Label();
            this.LblSubtotalDelImporteDelIVA = new System.Windows.Forms.Label();
            this.LblSubtotalDelImporteConDescuento = new System.Windows.Forms.Label();
            this.LblSubtotalDelImporteDelDescuento = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteDelIVA = new Utilities.NudNoWheel();
            this.nudSubtotalDelImporteConDescuento = new Utilities.NudNoWheel();
            this.nudSubtotalDelImporteDelDescuento = new Utilities.NudNoWheel();
            this.nudSubtotalDelImporte = new Utilities.NudNoWheel();
            this.LblSubtotalDelImporte = new System.Windows.Forms.Label();
            this.nudNumProd = new Utilities.NudNoWheel();
            this.nudTotalDeUnidades = new Utilities.NudNoWheel();
            this.label22 = new System.Windows.Forms.Label();
            this.nudTotal = new Utilities.NudNoWheel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.GrbDetalle = new System.Windows.Forms.GroupBox();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteDelDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteConDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasaIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteSinIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteDelIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrbAgregarProducto = new System.Windows.Forms.GroupBox();
            this.LblSubtotalDelImporteSinIVA2 = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteSinIVA2 = new Utilities.NudNoWheel();
            this.LblTotal2 = new System.Windows.Forms.Label();
            this.nudTotal2 = new Utilities.NudNoWheel();
            this.LblSubtotalDelImporteDelIVA2 = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteDelIVA2 = new Utilities.NudNoWheel();
            this.LblSubtotalDelImporteConDescuento2 = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteConDescuento2 = new Utilities.NudNoWheel();
            this.LblSubtotalDelImporteDelDescuento2 = new System.Windows.Forms.Label();
            this.nudSubtotalDelImporteDelDescuento2 = new Utilities.NudNoWheel();
            this.nudSubtotalDelImporte2 = new Utilities.NudNoWheel();
            this.LblSubtotalDelImporte2 = new System.Windows.Forms.Label();
            this.pbWarning = new System.Windows.Forms.PictureBox();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pbWarning1 = new System.Windows.Forms.PictureBox();
            this.pbError1 = new System.Windows.Forms.PictureBox();
            this.pbInfo1 = new System.Windows.Forms.PictureBox();
            this.nudDescuento = new Utilities.NudNoWheel();
            this.nudCantidad = new Utilities.NudNoWheel();
            this.nudUInventario = new Utilities.NudNoWheel();
            this.nudPrecio = new Utilities.NudNoWheel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.GrbPedido = new System.Windows.Forms.GroupBox();
            this.BtnNota = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GrbBuscar = new System.Windows.Forms.GroupBox();
            this.nudBIdFin = new System.Windows.Forms.NumericUpDown();
            this.nudBIdIni = new System.Windows.Forms.NumericUpDown();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBDirigidoa = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBCompañiaT = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBEmpleado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpBFEnvioFin = new System.Windows.Forms.DateTimePicker();
            this.dtpBFEnvioIni = new System.Windows.Forms.DateTimePicker();
            this.chkbBFEnvioNull = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpBFRequeridoFin = new System.Windows.Forms.DateTimePicker();
            this.dtpBFRequeridoIni = new System.Windows.Forms.DateTimePicker();
            this.chkbBFRequeridoNull = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkbBFVentaNull = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpBFVentaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpBFVentaIni = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GrbPedidos = new System.Windows.Forms.GroupBox();
            this.DgvVentas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.GrbTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteSinIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.GrbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.GrbAgregarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteSinIVA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.GrbPedido.SuspendLayout();
            this.GrbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdIni)).BeginInit();
            this.GrbPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GrbTotales);
            this.panel1.Controls.Add(this.GrbDetalle);
            this.panel1.Controls.Add(this.GrbAgregarProducto);
            this.panel1.Controls.Add(this.GrbPedido);
            this.panel1.Controls.Add(this.GrbBuscar);
            this.panel1.Controls.Add(this.GrbPedidos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1549, 1025);
            this.panel1.TabIndex = 0;
            // 
            // GrbTotales
            // 
            this.GrbTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbTotales.Controls.Add(this.LblSubtotalDelImporteSinIVA);
            this.GrbTotales.Controls.Add(this.nudSubtotalDelImporteSinIVA);
            this.GrbTotales.Controls.Add(this.label21);
            this.GrbTotales.Controls.Add(this.LblSubtotalDelImporteDelIVA);
            this.GrbTotales.Controls.Add(this.LblSubtotalDelImporteConDescuento);
            this.GrbTotales.Controls.Add(this.LblSubtotalDelImporteDelDescuento);
            this.GrbTotales.Controls.Add(this.nudSubtotalDelImporteDelIVA);
            this.GrbTotales.Controls.Add(this.nudSubtotalDelImporteConDescuento);
            this.GrbTotales.Controls.Add(this.nudSubtotalDelImporteDelDescuento);
            this.GrbTotales.Controls.Add(this.nudSubtotalDelImporte);
            this.GrbTotales.Controls.Add(this.LblSubtotalDelImporte);
            this.GrbTotales.Controls.Add(this.nudNumProd);
            this.GrbTotales.Controls.Add(this.nudTotalDeUnidades);
            this.GrbTotales.Controls.Add(this.label22);
            this.GrbTotales.Controls.Add(this.nudTotal);
            this.GrbTotales.Controls.Add(this.LblTotal);
            this.GrbTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbTotales.Location = new System.Drawing.Point(395, 713);
            this.GrbTotales.Name = "GrbTotales";
            this.GrbTotales.Size = new System.Drawing.Size(1114, 174);
            this.GrbTotales.TabIndex = 7;
            this.GrbTotales.TabStop = false;
            this.GrbTotales.Text = "»   Totales de la venta:   «";
            this.GrbTotales.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // LblSubtotalDelImporteSinIVA
            // 
            this.LblSubtotalDelImporteSinIVA.AutoSize = true;
            this.LblSubtotalDelImporteSinIVA.Location = new System.Drawing.Point(70, 99);
            this.LblSubtotalDelImporteSinIVA.Name = "LblSubtotalDelImporteSinIVA";
            this.LblSubtotalDelImporteSinIVA.Size = new System.Drawing.Size(228, 17);
            this.LblSubtotalDelImporteSinIVA.TabIndex = 30;
            this.LblSubtotalDelImporteSinIVA.Text = "Subtotal del importe sin IVA $:";
            // 
            // nudSubtotalDelImporteSinIVA
            // 
            this.nudSubtotalDelImporteSinIVA.DecimalPlaces = 2;
            this.nudSubtotalDelImporteSinIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteSinIVA.Location = new System.Drawing.Point(305, 97);
            this.nudSubtotalDelImporteSinIVA.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteSinIVA.Name = "nudSubtotalDelImporteSinIVA";
            this.nudSubtotalDelImporteSinIVA.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteSinIVA.TabIndex = 29;
            this.nudSubtotalDelImporteSinIVA.TabStop = false;
            this.nudSubtotalDelImporteSinIVA.ThousandsSeparator = true;
            this.nudSubtotalDelImporteSinIVA.WheelEnabled = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(174, 17);
            this.label21.TabIndex = 28;
            this.label21.Text = "Número de productos: ";
            // 
            // LblSubtotalDelImporteDelIVA
            // 
            this.LblSubtotalDelImporteDelIVA.AutoSize = true;
            this.LblSubtotalDelImporteDelIVA.Location = new System.Drawing.Point(509, 99);
            this.LblSubtotalDelImporteDelIVA.Name = "LblSubtotalDelImporteDelIVA";
            this.LblSubtotalDelImporteDelIVA.Size = new System.Drawing.Size(302, 17);
            this.LblSubtotalDelImporteDelIVA.TabIndex = 27;
            this.LblSubtotalDelImporteDelIVA.Text = "Subtotal del importe del IVA (Incluido) $:";
            // 
            // LblSubtotalDelImporteConDescuento
            // 
            this.LblSubtotalDelImporteConDescuento.AutoSize = true;
            this.LblSubtotalDelImporteConDescuento.Location = new System.Drawing.Point(529, 62);
            this.LblSubtotalDelImporteConDescuento.Name = "LblSubtotalDelImporteConDescuento";
            this.LblSubtotalDelImporteConDescuento.Size = new System.Drawing.Size(284, 17);
            this.LblSubtotalDelImporteConDescuento.TabIndex = 26;
            this.LblSubtotalDelImporteConDescuento.Text = "Subtotal del importe con descuento $:";
            // 
            // LblSubtotalDelImporteDelDescuento
            // 
            this.LblSubtotalDelImporteDelDescuento.AutoSize = true;
            this.LblSubtotalDelImporteDelDescuento.Location = new System.Drawing.Point(20, 62);
            this.LblSubtotalDelImporteDelDescuento.Name = "LblSubtotalDelImporteDelDescuento";
            this.LblSubtotalDelImporteDelDescuento.Size = new System.Drawing.Size(280, 17);
            this.LblSubtotalDelImporteDelDescuento.TabIndex = 25;
            this.LblSubtotalDelImporteDelDescuento.Text = "Subtotal del importe del descuento $:";
            // 
            // nudSubtotalDelImporteDelIVA
            // 
            this.nudSubtotalDelImporteDelIVA.DecimalPlaces = 2;
            this.nudSubtotalDelImporteDelIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteDelIVA.Location = new System.Drawing.Point(814, 97);
            this.nudSubtotalDelImporteDelIVA.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteDelIVA.Name = "nudSubtotalDelImporteDelIVA";
            this.nudSubtotalDelImporteDelIVA.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteDelIVA.TabIndex = 24;
            this.nudSubtotalDelImporteDelIVA.TabStop = false;
            this.nudSubtotalDelImporteDelIVA.ThousandsSeparator = true;
            this.nudSubtotalDelImporteDelIVA.WheelEnabled = true;
            // 
            // nudSubtotalDelImporteConDescuento
            // 
            this.nudSubtotalDelImporteConDescuento.DecimalPlaces = 2;
            this.nudSubtotalDelImporteConDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteConDescuento.Location = new System.Drawing.Point(814, 60);
            this.nudSubtotalDelImporteConDescuento.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteConDescuento.Name = "nudSubtotalDelImporteConDescuento";
            this.nudSubtotalDelImporteConDescuento.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteConDescuento.TabIndex = 24;
            this.nudSubtotalDelImporteConDescuento.TabStop = false;
            this.nudSubtotalDelImporteConDescuento.ThousandsSeparator = true;
            this.nudSubtotalDelImporteConDescuento.WheelEnabled = true;
            // 
            // nudSubtotalDelImporteDelDescuento
            // 
            this.nudSubtotalDelImporteDelDescuento.DecimalPlaces = 2;
            this.nudSubtotalDelImporteDelDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteDelDescuento.Location = new System.Drawing.Point(305, 60);
            this.nudSubtotalDelImporteDelDescuento.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteDelDescuento.Name = "nudSubtotalDelImporteDelDescuento";
            this.nudSubtotalDelImporteDelDescuento.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteDelDescuento.TabIndex = 24;
            this.nudSubtotalDelImporteDelDescuento.TabStop = false;
            this.nudSubtotalDelImporteDelDescuento.ThousandsSeparator = true;
            this.nudSubtotalDelImporteDelDescuento.WheelEnabled = true;
            // 
            // nudSubtotalDelImporte
            // 
            this.nudSubtotalDelImporte.DecimalPlaces = 2;
            this.nudSubtotalDelImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporte.Location = new System.Drawing.Point(814, 26);
            this.nudSubtotalDelImporte.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporte.Name = "nudSubtotalDelImporte";
            this.nudSubtotalDelImporte.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporte.TabIndex = 24;
            this.nudSubtotalDelImporte.TabStop = false;
            this.nudSubtotalDelImporte.ThousandsSeparator = true;
            this.nudSubtotalDelImporte.WheelEnabled = true;
            // 
            // LblSubtotalDelImporte
            // 
            this.LblSubtotalDelImporte.AutoSize = true;
            this.LblSubtotalDelImporte.Location = new System.Drawing.Point(639, 28);
            this.LblSubtotalDelImporte.Name = "LblSubtotalDelImporte";
            this.LblSubtotalDelImporte.Size = new System.Drawing.Size(173, 17);
            this.LblSubtotalDelImporte.TabIndex = 23;
            this.LblSubtotalDelImporte.Text = "Subtotal del importe $:";
            // 
            // nudNumProd
            // 
            this.nudNumProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumProd.Location = new System.Drawing.Point(203, 26);
            this.nudNumProd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNumProd.Name = "nudNumProd";
            this.nudNumProd.Size = new System.Drawing.Size(120, 23);
            this.nudNumProd.TabIndex = 22;
            this.nudNumProd.TabStop = false;
            this.nudNumProd.ThousandsSeparator = true;
            this.nudNumProd.WheelEnabled = true;
            // 
            // nudTotalDeUnidades
            // 
            this.nudTotalDeUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalDeUnidades.Location = new System.Drawing.Point(491, 25);
            this.nudTotalDeUnidades.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTotalDeUnidades.Name = "nudTotalDeUnidades";
            this.nudTotalDeUnidades.Size = new System.Drawing.Size(120, 23);
            this.nudTotalDeUnidades.TabIndex = 22;
            this.nudTotalDeUnidades.TabStop = false;
            this.nudTotalDeUnidades.ThousandsSeparator = true;
            this.nudTotalDeUnidades.WheelEnabled = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(345, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(144, 17);
            this.label22.TabIndex = 21;
            this.label22.Text = "Total de unidades:";
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(814, 133);
            this.nudTotal.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(217, 26);
            this.nudTotal.TabIndex = 21;
            this.nudTotal.TabStop = false;
            this.nudTotal.ThousandsSeparator = true;
            this.nudTotal.WheelEnabled = true;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(739, 136);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(73, 20);
            this.LblTotal.TabIndex = 18;
            this.LblTotal.Text = "Total $:";
            // 
            // GrbDetalle
            // 
            this.GrbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbDetalle.Controls.Add(this.DgvDetalle);
            this.GrbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbDetalle.Location = new System.Drawing.Point(395, 896);
            this.GrbDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.GrbDetalle.Name = "GrbDetalle";
            this.GrbDetalle.Padding = new System.Windows.Forms.Padding(10);
            this.GrbDetalle.Size = new System.Drawing.Size(1114, 305);
            this.GrbDetalle.TabIndex = 6;
            this.GrbDetalle.TabStop = false;
            this.GrbDetalle.Text = "»   Detalle de la venta:   «";
            this.GrbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Importe,
            this.Descuento,
            this.ImporteDelDescuento,
            this.ImporteConDescuento,
            this.TasaIVA,
            this.ImporteSinIVA,
            this.ImporteDelIVA,
            this.Subtotal,
            this.Modificar,
            this.Eliminar,
            this.ProductoId,
            this.RowVersion});
            this.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDetalle.Location = new System.Drawing.Point(10, 26);
            this.DgvDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.RowHeadersWidth = 51;
            this.DgvDetalle.Size = new System.Drawing.Size(1094, 269);
            this.DgvDetalle.TabIndex = 0;
            this.DgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.HeaderText = "N°";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 55;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 83;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 101;
            // 
            // Importe
            // 
            this.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Importe.HeaderText = "Importe";
            this.Importe.MinimumWidth = 6;
            this.Importe.Name = "Importe";
            this.Importe.Width = 91;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.Width = 114;
            // 
            // ImporteDelDescuento
            // 
            this.ImporteDelDescuento.HeaderText = "Importe del descuento";
            this.ImporteDelDescuento.MinimumWidth = 6;
            this.ImporteDelDescuento.Name = "ImporteDelDescuento";
            this.ImporteDelDescuento.Width = 125;
            // 
            // ImporteConDescuento
            // 
            this.ImporteConDescuento.HeaderText = "Importe con descuento";
            this.ImporteConDescuento.MinimumWidth = 6;
            this.ImporteConDescuento.Name = "ImporteConDescuento";
            this.ImporteConDescuento.Width = 125;
            // 
            // TasaIVA
            // 
            this.TasaIVA.HeaderText = "Tasa IVA";
            this.TasaIVA.MinimumWidth = 6;
            this.TasaIVA.Name = "TasaIVA";
            this.TasaIVA.Width = 125;
            // 
            // ImporteSinIVA
            // 
            this.ImporteSinIVA.HeaderText = "Importe sin IVA";
            this.ImporteSinIVA.MinimumWidth = 6;
            this.ImporteSinIVA.Name = "ImporteSinIVA";
            this.ImporteSinIVA.Width = 125;
            // 
            // ImporteDelIVA
            // 
            this.ImporteDelIVA.HeaderText = "Importe del IVA (Incluido)";
            this.ImporteDelIVA.MinimumWidth = 6;
            this.ImporteDelIVA.Name = "ImporteDelIVA";
            this.ImporteDelIVA.Width = 125;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.MinimumWidth = 6;
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.Width = 125;
            // 
            // Modificar
            // 
            this.Modificar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Modificar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Modificar.HeaderText = "Modificar producto";
            this.Modificar.MinimumWidth = 6;
            this.Modificar.Name = "Modificar";
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Modificar.Width = 134;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Eliminar.HeaderText = "Eliminar producto";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Eliminar.Width = 127;
            // 
            // ProductoId
            // 
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.MinimumWidth = 6;
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.Visible = false;
            this.ProductoId.Width = 125;
            // 
            // RowVersion
            // 
            this.RowVersion.HeaderText = "RowVersion";
            this.RowVersion.MinimumWidth = 6;
            this.RowVersion.Name = "RowVersion";
            this.RowVersion.Visible = false;
            this.RowVersion.Width = 125;
            // 
            // GrbAgregarProducto
            // 
            this.GrbAgregarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbAgregarProducto.Controls.Add(this.LblSubtotalDelImporteSinIVA2);
            this.GrbAgregarProducto.Controls.Add(this.nudSubtotalDelImporteSinIVA2);
            this.GrbAgregarProducto.Controls.Add(this.LblTotal2);
            this.GrbAgregarProducto.Controls.Add(this.nudTotal2);
            this.GrbAgregarProducto.Controls.Add(this.LblSubtotalDelImporteDelIVA2);
            this.GrbAgregarProducto.Controls.Add(this.nudSubtotalDelImporteDelIVA2);
            this.GrbAgregarProducto.Controls.Add(this.LblSubtotalDelImporteConDescuento2);
            this.GrbAgregarProducto.Controls.Add(this.nudSubtotalDelImporteConDescuento2);
            this.GrbAgregarProducto.Controls.Add(this.LblSubtotalDelImporteDelDescuento2);
            this.GrbAgregarProducto.Controls.Add(this.nudSubtotalDelImporteDelDescuento2);
            this.GrbAgregarProducto.Controls.Add(this.nudSubtotalDelImporte2);
            this.GrbAgregarProducto.Controls.Add(this.LblSubtotalDelImporte2);
            this.GrbAgregarProducto.Controls.Add(this.pbWarning);
            this.GrbAgregarProducto.Controls.Add(this.pbError);
            this.GrbAgregarProducto.Controls.Add(this.pbInfo);
            this.GrbAgregarProducto.Controls.Add(this.pbWarning1);
            this.GrbAgregarProducto.Controls.Add(this.pbError1);
            this.GrbAgregarProducto.Controls.Add(this.pbInfo1);
            this.GrbAgregarProducto.Controls.Add(this.nudDescuento);
            this.GrbAgregarProducto.Controls.Add(this.nudCantidad);
            this.GrbAgregarProducto.Controls.Add(this.nudUInventario);
            this.GrbAgregarProducto.Controls.Add(this.nudPrecio);
            this.GrbAgregarProducto.Controls.Add(this.label4);
            this.GrbAgregarProducto.Controls.Add(this.btnAgregar);
            this.GrbAgregarProducto.Controls.Add(this.label38);
            this.GrbAgregarProducto.Controls.Add(this.label39);
            this.GrbAgregarProducto.Controls.Add(this.LblPrecio);
            this.GrbAgregarProducto.Controls.Add(this.cboProducto);
            this.GrbAgregarProducto.Controls.Add(this.cboCategoria);
            this.GrbAgregarProducto.Controls.Add(this.label37);
            this.GrbAgregarProducto.Controls.Add(this.label36);
            this.GrbAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbAgregarProducto.Location = new System.Drawing.Point(395, 501);
            this.GrbAgregarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.GrbAgregarProducto.Name = "GrbAgregarProducto";
            this.GrbAgregarProducto.Padding = new System.Windows.Forms.Padding(4);
            this.GrbAgregarProducto.Size = new System.Drawing.Size(1114, 206);
            this.GrbAgregarProducto.TabIndex = 5;
            this.GrbAgregarProducto.TabStop = false;
            this.GrbAgregarProducto.Text = "»   Agregar producto:   «";
            this.GrbAgregarProducto.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // LblSubtotalDelImporteSinIVA2
            // 
            this.LblSubtotalDelImporteSinIVA2.AutoSize = true;
            this.LblSubtotalDelImporteSinIVA2.Location = new System.Drawing.Point(565, 134);
            this.LblSubtotalDelImporteSinIVA2.Name = "LblSubtotalDelImporteSinIVA2";
            this.LblSubtotalDelImporteSinIVA2.Size = new System.Drawing.Size(228, 17);
            this.LblSubtotalDelImporteSinIVA2.TabIndex = 48;
            this.LblSubtotalDelImporteSinIVA2.Text = "Subtotal del importe sin IVA $:";
            // 
            // nudSubtotalDelImporteSinIVA2
            // 
            this.nudSubtotalDelImporteSinIVA2.DecimalPlaces = 2;
            this.nudSubtotalDelImporteSinIVA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteSinIVA2.Location = new System.Drawing.Point(801, 132);
            this.nudSubtotalDelImporteSinIVA2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteSinIVA2.Name = "nudSubtotalDelImporteSinIVA2";
            this.nudSubtotalDelImporteSinIVA2.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteSinIVA2.TabIndex = 47;
            this.nudSubtotalDelImporteSinIVA2.TabStop = false;
            this.nudSubtotalDelImporteSinIVA2.ThousandsSeparator = true;
            this.nudSubtotalDelImporteSinIVA2.WheelEnabled = true;
            // 
            // LblTotal2
            // 
            this.LblTotal2.AutoSize = true;
            this.LblTotal2.Location = new System.Drawing.Point(634, 170);
            this.LblTotal2.Name = "LblTotal2";
            this.LblTotal2.Size = new System.Drawing.Size(160, 17);
            this.LblTotal2.TabIndex = 46;
            this.LblTotal2.Text = "Total del producto $:";
            // 
            // nudTotal2
            // 
            this.nudTotal2.DecimalPlaces = 2;
            this.nudTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal2.Location = new System.Drawing.Point(804, 168);
            this.nudTotal2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotal2.Name = "nudTotal2";
            this.nudTotal2.Size = new System.Drawing.Size(167, 23);
            this.nudTotal2.TabIndex = 45;
            this.nudTotal2.TabStop = false;
            this.nudTotal2.ThousandsSeparator = true;
            this.nudTotal2.WheelEnabled = true;
            // 
            // LblSubtotalDelImporteDelIVA2
            // 
            this.LblSubtotalDelImporteDelIVA2.AutoSize = true;
            this.LblSubtotalDelImporteDelIVA2.Location = new System.Drawing.Point(11, 170);
            this.LblSubtotalDelImporteDelIVA2.Name = "LblSubtotalDelImporteDelIVA2";
            this.LblSubtotalDelImporteDelIVA2.Size = new System.Drawing.Size(302, 17);
            this.LblSubtotalDelImporteDelIVA2.TabIndex = 44;
            this.LblSubtotalDelImporteDelIVA2.Text = "Subtotal del importe del IVA (Incluido) $:";
            // 
            // nudSubtotalDelImporteDelIVA2
            // 
            this.nudSubtotalDelImporteDelIVA2.DecimalPlaces = 2;
            this.nudSubtotalDelImporteDelIVA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteDelIVA2.Location = new System.Drawing.Point(313, 168);
            this.nudSubtotalDelImporteDelIVA2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteDelIVA2.Name = "nudSubtotalDelImporteDelIVA2";
            this.nudSubtotalDelImporteDelIVA2.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteDelIVA2.TabIndex = 43;
            this.nudSubtotalDelImporteDelIVA2.TabStop = false;
            this.nudSubtotalDelImporteDelIVA2.ThousandsSeparator = true;
            this.nudSubtotalDelImporteDelIVA2.WheelEnabled = true;
            // 
            // LblSubtotalDelImporteConDescuento2
            // 
            this.LblSubtotalDelImporteConDescuento2.AutoSize = true;
            this.LblSubtotalDelImporteConDescuento2.Location = new System.Drawing.Point(29, 134);
            this.LblSubtotalDelImporteConDescuento2.Name = "LblSubtotalDelImporteConDescuento2";
            this.LblSubtotalDelImporteConDescuento2.Size = new System.Drawing.Size(284, 17);
            this.LblSubtotalDelImporteConDescuento2.TabIndex = 42;
            this.LblSubtotalDelImporteConDescuento2.Text = "Subtotal del importe con descuento $:";
            // 
            // nudSubtotalDelImporteConDescuento2
            // 
            this.nudSubtotalDelImporteConDescuento2.DecimalPlaces = 2;
            this.nudSubtotalDelImporteConDescuento2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteConDescuento2.Location = new System.Drawing.Point(313, 132);
            this.nudSubtotalDelImporteConDescuento2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteConDescuento2.Name = "nudSubtotalDelImporteConDescuento2";
            this.nudSubtotalDelImporteConDescuento2.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteConDescuento2.TabIndex = 41;
            this.nudSubtotalDelImporteConDescuento2.TabStop = false;
            this.nudSubtotalDelImporteConDescuento2.ThousandsSeparator = true;
            this.nudSubtotalDelImporteConDescuento2.WheelEnabled = true;
            // 
            // LblSubtotalDelImporteDelDescuento2
            // 
            this.LblSubtotalDelImporteDelDescuento2.AutoSize = true;
            this.LblSubtotalDelImporteDelDescuento2.Location = new System.Drawing.Point(514, 99);
            this.LblSubtotalDelImporteDelDescuento2.Name = "LblSubtotalDelImporteDelDescuento2";
            this.LblSubtotalDelImporteDelDescuento2.Size = new System.Drawing.Size(280, 17);
            this.LblSubtotalDelImporteDelDescuento2.TabIndex = 40;
            this.LblSubtotalDelImporteDelDescuento2.Text = "Subtotal del importe del descuento $:";
            // 
            // nudSubtotalDelImporteDelDescuento2
            // 
            this.nudSubtotalDelImporteDelDescuento2.DecimalPlaces = 2;
            this.nudSubtotalDelImporteDelDescuento2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporteDelDescuento2.Location = new System.Drawing.Point(804, 97);
            this.nudSubtotalDelImporteDelDescuento2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporteDelDescuento2.Name = "nudSubtotalDelImporteDelDescuento2";
            this.nudSubtotalDelImporteDelDescuento2.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporteDelDescuento2.TabIndex = 39;
            this.nudSubtotalDelImporteDelDescuento2.TabStop = false;
            this.nudSubtotalDelImporteDelDescuento2.ThousandsSeparator = true;
            this.nudSubtotalDelImporteDelDescuento2.WheelEnabled = true;
            // 
            // nudSubtotalDelImporte2
            // 
            this.nudSubtotalDelImporte2.DecimalPlaces = 2;
            this.nudSubtotalDelImporte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotalDelImporte2.Location = new System.Drawing.Point(313, 97);
            this.nudSubtotalDelImporte2.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotalDelImporte2.Name = "nudSubtotalDelImporte2";
            this.nudSubtotalDelImporte2.Size = new System.Drawing.Size(167, 23);
            this.nudSubtotalDelImporte2.TabIndex = 38;
            this.nudSubtotalDelImporte2.TabStop = false;
            this.nudSubtotalDelImporte2.ThousandsSeparator = true;
            this.nudSubtotalDelImporte2.WheelEnabled = true;
            // 
            // LblSubtotalDelImporte2
            // 
            this.LblSubtotalDelImporte2.AutoSize = true;
            this.LblSubtotalDelImporte2.Location = new System.Drawing.Point(140, 100);
            this.LblSubtotalDelImporte2.Name = "LblSubtotalDelImporte2";
            this.LblSubtotalDelImporte2.Size = new System.Drawing.Size(173, 17);
            this.LblSubtotalDelImporte2.TabIndex = 37;
            this.LblSubtotalDelImporte2.Text = "Subtotal del importe $:";
            // 
            // pbWarning
            // 
            this.pbWarning.Location = new System.Drawing.Point(805, 61);
            this.pbWarning.Name = "pbWarning";
            this.pbWarning.Size = new System.Drawing.Size(20, 20);
            this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarning.TabIndex = 34;
            this.pbWarning.TabStop = false;
            // 
            // pbError
            // 
            this.pbError.Location = new System.Drawing.Point(779, 61);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(20, 20);
            this.pbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbError.TabIndex = 35;
            this.pbError.TabStop = false;
            // 
            // pbInfo
            // 
            this.pbInfo.Location = new System.Drawing.Point(753, 61);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(20, 20);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo.TabIndex = 36;
            this.pbInfo.TabStop = false;
            // 
            // pbWarning1
            // 
            this.pbWarning1.Location = new System.Drawing.Point(544, 60);
            this.pbWarning1.Name = "pbWarning1";
            this.pbWarning1.Size = new System.Drawing.Size(20, 20);
            this.pbWarning1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarning1.TabIndex = 31;
            this.pbWarning1.TabStop = false;
            // 
            // pbError1
            // 
            this.pbError1.Location = new System.Drawing.Point(518, 60);
            this.pbError1.Name = "pbError1";
            this.pbError1.Size = new System.Drawing.Size(20, 20);
            this.pbError1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbError1.TabIndex = 32;
            this.pbError1.TabStop = false;
            // 
            // pbInfo1
            // 
            this.pbInfo1.Location = new System.Drawing.Point(492, 60);
            this.pbInfo1.Name = "pbInfo1";
            this.pbInfo1.Size = new System.Drawing.Size(20, 20);
            this.pbInfo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo1.TabIndex = 33;
            this.pbInfo1.TabStop = false;
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDescuento.Location = new System.Drawing.Point(963, 59);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(85, 23);
            this.nudDescuento.TabIndex = 3;
            this.nudDescuento.WheelEnabled = true;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudDescuento.Leave += new System.EventHandler(this.nudDescuento_Leave);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(653, 59);
            this.nudCantidad.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 23);
            this.nudCantidad.TabIndex = 2;
            this.nudCantidad.ThousandsSeparator = true;
            this.nudCantidad.WheelEnabled = true;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            this.nudCantidad.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudCantidad.Leave += new System.EventHandler(this.nudCantidad_Leave);
            // 
            // nudUInventario
            // 
            this.nudUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudUInventario.Location = new System.Drawing.Point(395, 59);
            this.nudUInventario.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudUInventario.Name = "nudUInventario";
            this.nudUInventario.Size = new System.Drawing.Size(90, 23);
            this.nudUInventario.TabIndex = 10;
            this.nudUInventario.TabStop = false;
            this.nudUInventario.ThousandsSeparator = true;
            this.nudUInventario.WheelEnabled = true;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(75, 59);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 23);
            this.nudPrecio.TabIndex = 9;
            this.nudPrecio.TabStop = false;
            this.nudPrecio.ThousandsSeparator = true;
            this.nudPrecio.WheelEnabled = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unidades en inventario:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(1074, 53);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 37);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(846, 62);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(120, 17);
            this.label38.TabIndex = 7;
            this.label38.Text = "Descuento (%):";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(580, 62);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(77, 17);
            this.label39.TabIndex = 6;
            this.label39.Text = "Cantidad:";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(5, 62);
            this.LblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(73, 17);
            this.LblPrecio.TabIndex = 5;
            this.LblPrecio.Text = "Precio $:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(622, 23);
            this.cboProducto.Margin = new System.Windows.Forms.Padding(4);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(421, 25);
            this.cboProducto.TabIndex = 1;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(109, 23);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(393, 25);
            this.cboCategoria.TabIndex = 0;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(539, 28);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(78, 17);
            this.label37.TabIndex = 0;
            this.label37.Text = "Producto:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 28);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(83, 17);
            this.label36.TabIndex = 0;
            this.label36.Text = "Categoría:";
            // 
            // GrbPedido
            // 
            this.GrbPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbPedido.Controls.Add(this.BtnNota);
            this.GrbPedido.Controls.Add(this.txtCliente);
            this.GrbPedido.Controls.Add(this.txtId);
            this.GrbPedido.Controls.Add(this.label20);
            this.GrbPedido.Controls.Add(this.label2);
            this.GrbPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbPedido.Location = new System.Drawing.Point(395, 368);
            this.GrbPedido.Margin = new System.Windows.Forms.Padding(4);
            this.GrbPedido.Name = "GrbPedido";
            this.GrbPedido.Padding = new System.Windows.Forms.Padding(4);
            this.GrbPedido.Size = new System.Drawing.Size(1114, 125);
            this.GrbPedido.TabIndex = 4;
            this.GrbPedido.TabStop = false;
            this.GrbPedido.Text = "»   Venta:   «";
            this.GrbPedido.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // BtnNota
            // 
            this.BtnNota.Enabled = false;
            this.BtnNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNota.Location = new System.Drawing.Point(503, 85);
            this.BtnNota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNota.Name = "BtnNota";
            this.BtnNota.Size = new System.Drawing.Size(220, 33);
            this.BtnNota.TabIndex = 20;
            this.BtnNota.Text = "Nota de remisión";
            this.BtnNota.UseVisualStyleBackColor = true;
            this.BtnNota.Click += new System.EventHandler(this.BtnNota_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(120, 52);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(603, 23);
            this.txtCliente.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(120, 19);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(132, 26);
            this.txtId.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(51, 57);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 17);
            this.label20.TabIndex = 18;
            this.label20.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Id:";
            // 
            // GrbBuscar
            // 
            this.GrbBuscar.Controls.Add(this.nudBIdFin);
            this.GrbBuscar.Controls.Add(this.nudBIdIni);
            this.GrbBuscar.Controls.Add(this.btnLimpiar);
            this.GrbBuscar.Controls.Add(this.btnBuscar);
            this.GrbBuscar.Controls.Add(this.label19);
            this.GrbBuscar.Controls.Add(this.txtBDirigidoa);
            this.GrbBuscar.Controls.Add(this.label18);
            this.GrbBuscar.Controls.Add(this.txtBCompañiaT);
            this.GrbBuscar.Controls.Add(this.label17);
            this.GrbBuscar.Controls.Add(this.txtBEmpleado);
            this.GrbBuscar.Controls.Add(this.label15);
            this.GrbBuscar.Controls.Add(this.label16);
            this.GrbBuscar.Controls.Add(this.dtpBFEnvioFin);
            this.GrbBuscar.Controls.Add(this.dtpBFEnvioIni);
            this.GrbBuscar.Controls.Add(this.chkbBFEnvioNull);
            this.GrbBuscar.Controls.Add(this.label14);
            this.GrbBuscar.Controls.Add(this.label12);
            this.GrbBuscar.Controls.Add(this.label13);
            this.GrbBuscar.Controls.Add(this.dtpBFRequeridoFin);
            this.GrbBuscar.Controls.Add(this.dtpBFRequeridoIni);
            this.GrbBuscar.Controls.Add(this.chkbBFRequeridoNull);
            this.GrbBuscar.Controls.Add(this.label11);
            this.GrbBuscar.Controls.Add(this.chkbBFVentaNull);
            this.GrbBuscar.Controls.Add(this.label10);
            this.GrbBuscar.Controls.Add(this.label9);
            this.GrbBuscar.Controls.Add(this.dtpBFVentaFin);
            this.GrbBuscar.Controls.Add(this.dtpBFVentaIni);
            this.GrbBuscar.Controls.Add(this.label8);
            this.GrbBuscar.Controls.Add(this.txtBCliente);
            this.GrbBuscar.Controls.Add(this.label7);
            this.GrbBuscar.Controls.Add(this.label6);
            this.GrbBuscar.Controls.Add(this.label5);
            this.GrbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbBuscar.Location = new System.Drawing.Point(6, 368);
            this.GrbBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.GrbBuscar.Name = "GrbBuscar";
            this.GrbBuscar.Padding = new System.Windows.Forms.Padding(4);
            this.GrbBuscar.Size = new System.Drawing.Size(381, 829);
            this.GrbBuscar.TabIndex = 3;
            this.GrbBuscar.TabStop = false;
            this.GrbBuscar.Text = "»   Buscar una venta:   «";
            this.GrbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // nudBIdFin
            // 
            this.nudBIdFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBIdFin.Location = new System.Drawing.Point(114, 65);
            this.nudBIdFin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBIdFin.Name = "nudBIdFin";
            this.nudBIdFin.Size = new System.Drawing.Size(140, 23);
            this.nudBIdFin.TabIndex = 1;
            this.nudBIdFin.ValueChanged += new System.EventHandler(this.nudBIdFin_ValueChanged);
            this.nudBIdFin.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudBIdFin.Leave += new System.EventHandler(this.nudBIdFin_Leave);
            // 
            // nudBIdIni
            // 
            this.nudBIdIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBIdIni.Location = new System.Drawing.Point(114, 31);
            this.nudBIdIni.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudBIdIni.Name = "nudBIdIni";
            this.nudBIdIni.Size = new System.Drawing.Size(140, 23);
            this.nudBIdIni.TabIndex = 0;
            this.nudBIdIni.ValueChanged += new System.EventHandler(this.nudBIdIni_ValueChanged);
            this.nudBIdIni.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudBIdIni.Leave += new System.EventHandler(this.nudBIdIni_Leave);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(93, 491);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 28);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(237, 491);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 28);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(31, 446);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 17);
            this.label19.TabIndex = 62;
            this.label19.Text = "Enviar a:";
            // 
            // txtBDirigidoa
            // 
            this.txtBDirigidoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDirigidoa.Location = new System.Drawing.Point(114, 441);
            this.txtBDirigidoa.Margin = new System.Windows.Forms.Padding(4);
            this.txtBDirigidoa.MaxLength = 40;
            this.txtBDirigidoa.Name = "txtBDirigidoa";
            this.txtBDirigidoa.Size = new System.Drawing.Size(255, 23);
            this.txtBDirigidoa.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1, 400);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 31);
            this.label18.TabIndex = 61;
            this.label18.Text = "Compañía transportista:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBCompañiaT
            // 
            this.txtBCompañiaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCompañiaT.Location = new System.Drawing.Point(114, 402);
            this.txtBCompañiaT.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCompañiaT.MaxLength = 40;
            this.txtBCompañiaT.Name = "txtBCompañiaT";
            this.txtBCompañiaT.Size = new System.Drawing.Size(255, 23);
            this.txtBCompañiaT.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 363);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 17);
            this.label17.TabIndex = 60;
            this.label17.Text = "Vendedor:";
            // 
            // txtBEmpleado
            // 
            this.txtBEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBEmpleado.Location = new System.Drawing.Point(114, 358);
            this.txtBEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.txtBEmpleado.MaxLength = 40;
            this.txtBEmpleado.Name = "txtBEmpleado";
            this.txtBEmpleado.Size = new System.Drawing.Size(255, 23);
            this.txtBEmpleado.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(187, 308);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 31);
            this.label15.TabIndex = 59;
            this.label15.Text = "Fecha final:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 308);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 31);
            this.label16.TabIndex = 58;
            this.label16.Text = "Fecha inicial:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFEnvioFin
            // 
            this.dtpBFEnvioFin.Checked = false;
            this.dtpBFEnvioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFEnvioFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFEnvioFin.Location = new System.Drawing.Point(243, 311);
            this.dtpBFEnvioFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFEnvioFin.Name = "dtpBFEnvioFin";
            this.dtpBFEnvioFin.ShowCheckBox = true;
            this.dtpBFEnvioFin.Size = new System.Drawing.Size(125, 23);
            this.dtpBFEnvioFin.TabIndex = 11;
            this.dtpBFEnvioFin.ValueChanged += new System.EventHandler(this.dtpBFEnvioFin_ValueChanged);
            this.dtpBFEnvioFin.Leave += new System.EventHandler(this.dtpBFEnvioFin_Leave);
            // 
            // dtpBFEnvioIni
            // 
            this.dtpBFEnvioIni.Checked = false;
            this.dtpBFEnvioIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFEnvioIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFEnvioIni.Location = new System.Drawing.Point(61, 311);
            this.dtpBFEnvioIni.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFEnvioIni.Name = "dtpBFEnvioIni";
            this.dtpBFEnvioIni.ShowCheckBox = true;
            this.dtpBFEnvioIni.Size = new System.Drawing.Size(125, 23);
            this.dtpBFEnvioIni.TabIndex = 10;
            this.dtpBFEnvioIni.ValueChanged += new System.EventHandler(this.dtpBFEnvioIni_ValueChanged);
            this.dtpBFEnvioIni.Leave += new System.EventHandler(this.dtpBFEnvioIni_Leave);
            // 
            // chkbBFEnvioNull
            // 
            this.chkbBFEnvioNull.AutoSize = true;
            this.chkbBFEnvioNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbBFEnvioNull.Location = new System.Drawing.Point(257, 280);
            this.chkbBFEnvioNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFEnvioNull.Name = "chkbBFEnvioNull";
            this.chkbBFEnvioNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFEnvioNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFEnvioNull.TabIndex = 9;
            this.chkbBFEnvioNull.Text = "Fecha = null";
            this.chkbBFEnvioNull.UseVisualStyleBackColor = true;
            this.chkbBFEnvioNull.CheckedChanged += new System.EventHandler(this.chkbBFEnvioNull_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 279);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 17);
            this.label14.TabIndex = 57;
            this.label14.Text = "Fecha de envío:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(187, 235);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 31);
            this.label12.TabIndex = 56;
            this.label12.Text = "Fecha final:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 235);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 31);
            this.label13.TabIndex = 54;
            this.label13.Text = "Fecha inicial:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFRequeridoFin
            // 
            this.dtpBFRequeridoFin.Checked = false;
            this.dtpBFRequeridoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFRequeridoFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFRequeridoFin.Location = new System.Drawing.Point(243, 237);
            this.dtpBFRequeridoFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFRequeridoFin.Name = "dtpBFRequeridoFin";
            this.dtpBFRequeridoFin.ShowCheckBox = true;
            this.dtpBFRequeridoFin.Size = new System.Drawing.Size(125, 23);
            this.dtpBFRequeridoFin.TabIndex = 8;
            this.dtpBFRequeridoFin.ValueChanged += new System.EventHandler(this.dtpBFRequeridoFin_ValueChanged);
            this.dtpBFRequeridoFin.Leave += new System.EventHandler(this.dtpBFRequeridoFin_Leave);
            // 
            // dtpBFRequeridoIni
            // 
            this.dtpBFRequeridoIni.Checked = false;
            this.dtpBFRequeridoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFRequeridoIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFRequeridoIni.Location = new System.Drawing.Point(61, 237);
            this.dtpBFRequeridoIni.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFRequeridoIni.Name = "dtpBFRequeridoIni";
            this.dtpBFRequeridoIni.ShowCheckBox = true;
            this.dtpBFRequeridoIni.Size = new System.Drawing.Size(125, 23);
            this.dtpBFRequeridoIni.TabIndex = 7;
            this.dtpBFRequeridoIni.ValueChanged += new System.EventHandler(this.dtpBFRequeridoIni_ValueChanged);
            this.dtpBFRequeridoIni.Leave += new System.EventHandler(this.dtpBFRequeridoIni_Leave);
            // 
            // chkbBFRequeridoNull
            // 
            this.chkbBFRequeridoNull.AutoSize = true;
            this.chkbBFRequeridoNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbBFRequeridoNull.Location = new System.Drawing.Point(257, 205);
            this.chkbBFRequeridoNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFRequeridoNull.Name = "chkbBFRequeridoNull";
            this.chkbBFRequeridoNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFRequeridoNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFRequeridoNull.TabIndex = 6;
            this.chkbBFRequeridoNull.Text = "Fecha = null";
            this.chkbBFRequeridoNull.UseVisualStyleBackColor = true;
            this.chkbBFRequeridoNull.CheckedChanged += new System.EventHandler(this.chkbBFRequeridoNull_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 205);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 50;
            this.label11.Text = "Fecha de entrega:";
            // 
            // chkbBFVentaNull
            // 
            this.chkbBFVentaNull.AutoSize = true;
            this.chkbBFVentaNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbBFVentaNull.Location = new System.Drawing.Point(257, 137);
            this.chkbBFVentaNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFVentaNull.Name = "chkbBFVentaNull";
            this.chkbBFVentaNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFVentaNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFVentaNull.TabIndex = 3;
            this.chkbBFVentaNull.Text = "Fecha = null";
            this.chkbBFVentaNull.UseVisualStyleBackColor = true;
            this.chkbBFVentaNull.CheckedChanged += new System.EventHandler(this.chkbBFVentaNull_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(187, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 31);
            this.label10.TabIndex = 46;
            this.label10.Text = "Fecha final:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 163);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 31);
            this.label9.TabIndex = 44;
            this.label9.Text = "Fecha inicial:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFVentaFin
            // 
            this.dtpBFVentaFin.Checked = false;
            this.dtpBFVentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFVentaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFVentaFin.Location = new System.Drawing.Point(243, 166);
            this.dtpBFVentaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFVentaFin.Name = "dtpBFVentaFin";
            this.dtpBFVentaFin.ShowCheckBox = true;
            this.dtpBFVentaFin.Size = new System.Drawing.Size(125, 23);
            this.dtpBFVentaFin.TabIndex = 5;
            this.dtpBFVentaFin.ValueChanged += new System.EventHandler(this.dtpBFPedidoFin_ValueChanged);
            this.dtpBFVentaFin.Leave += new System.EventHandler(this.dtpBFVentaFin_Leave);
            // 
            // dtpBFVentaIni
            // 
            this.dtpBFVentaIni.Checked = false;
            this.dtpBFVentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFVentaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFVentaIni.Location = new System.Drawing.Point(61, 166);
            this.dtpBFVentaIni.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFVentaIni.Name = "dtpBFVentaIni";
            this.dtpBFVentaIni.ShowCheckBox = true;
            this.dtpBFVentaIni.Size = new System.Drawing.Size(125, 23);
            this.dtpBFVentaIni.TabIndex = 4;
            this.dtpBFVentaIni.ValueChanged += new System.EventHandler(this.dtpBFPedidoIni_ValueChanged);
            this.dtpBFVentaIni.Leave += new System.EventHandler(this.dtpBFVentaIni_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Fecha de venta:";
            // 
            // txtBCliente
            // 
            this.txtBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCliente.Location = new System.Drawing.Point(114, 97);
            this.txtBCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCliente.MaxLength = 40;
            this.txtBCliente.Name = "txtBCliente";
            this.txtBCliente.Size = new System.Drawing.Size(255, 23);
            this.txtBCliente.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Cliente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Id final:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Id inicial:";
            // 
            // GrbPedidos
            // 
            this.GrbPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbPedidos.Controls.Add(this.DgvVentas);
            this.GrbPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbPedidos.Location = new System.Drawing.Point(6, 59);
            this.GrbPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.GrbPedidos.Name = "GrbPedidos";
            this.GrbPedidos.Padding = new System.Windows.Forms.Padding(4);
            this.GrbPedidos.Size = new System.Drawing.Size(1503, 295);
            this.GrbPedidos.TabIndex = 2;
            this.GrbPedidos.TabStop = false;
            this.GrbPedidos.Text = "»   Ventas:   «";
            this.GrbPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // DgvVentas
            // 
            this.DgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvVentas.Location = new System.Drawing.Point(4, 20);
            this.DgvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.DgvVentas.Name = "DgvVentas";
            this.DgvVentas.RowHeadersWidth = 51;
            this.DgvVentas.Size = new System.Drawing.Size(1495, 271);
            this.DgvVentas.TabIndex = 0;
            this.DgvVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVentas_CellClick);
            this.DgvVentas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvVentas_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1503, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "     Busque la venta y seleccionela en la lista que se muestra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmVentasDetalleCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1579, 1055);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVentasDetalleCrud";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "» Mantenimiento de detalle de ventas «";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentasDetalleCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVentasDetalleCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmVentasDetalleCrud_Load);
            this.panel1.ResumeLayout(false);
            this.GrbTotales.ResumeLayout(false);
            this.GrbTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteSinIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.GrbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.GrbAgregarProducto.ResumeLayout(false);
            this.GrbAgregarProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteSinIVA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.GrbPedido.ResumeLayout(false);
            this.GrbPedido.PerformLayout();
            this.GrbBuscar.ResumeLayout(false);
            this.GrbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdIni)).EndInit();
            this.GrbPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrbPedidos;
        private System.Windows.Forms.DataGridView DgvVentas;
        private System.Windows.Forms.GroupBox GrbBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtBDirigidoa;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBCompañiaT;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBEmpleado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioFin;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioIni;
        private System.Windows.Forms.CheckBox chkbBFEnvioNull;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoFin;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoIni;
        private System.Windows.Forms.CheckBox chkbBFRequeridoNull;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkbBFVentaNull;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpBFVentaFin;
        private System.Windows.Forms.DateTimePicker dtpBFVentaIni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox GrbPedido;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrbAgregarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GrbDetalle;
        private System.Windows.Forms.DataGridView DgvDetalle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BtnNota;
        private System.Windows.Forms.NumericUpDown nudBIdIni;
        private System.Windows.Forms.NumericUpDown nudBIdFin;
        private System.Windows.Forms.GroupBox GrbTotales;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelIVA;
        private System.Windows.Forms.Label LblSubtotalDelImporteConDescuento;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelDescuento;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelIVA;
        private Utilities.NudNoWheel nudSubtotalDelImporteConDescuento;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelDescuento;
        private Utilities.NudNoWheel nudSubtotalDelImporte;
        private System.Windows.Forms.Label LblSubtotalDelImporte;
        private Utilities.NudNoWheel nudNumProd;
        private Utilities.NudNoWheel nudTotalDeUnidades;
        private System.Windows.Forms.Label label22;
        private Utilities.NudNoWheel nudTotal;
        private System.Windows.Forms.Label LblTotal;
        private Utilities.NudNoWheel nudPrecio;
        private Utilities.NudNoWheel nudUInventario;
        private Utilities.NudNoWheel nudCantidad;
        private Utilities.NudNoWheel nudDescuento;
        private System.Windows.Forms.PictureBox pbWarning1;
        private System.Windows.Forms.PictureBox pbError1;
        private System.Windows.Forms.PictureBox pbInfo1;
        private System.Windows.Forms.PictureBox pbWarning;
        private System.Windows.Forms.PictureBox pbError;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelIVA2;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelIVA2;
        private System.Windows.Forms.Label LblSubtotalDelImporteConDescuento2;
        private Utilities.NudNoWheel nudSubtotalDelImporteConDescuento2;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelDescuento2;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelDescuento2;
        private Utilities.NudNoWheel nudSubtotalDelImporte2;
        private System.Windows.Forms.Label LblSubtotalDelImporte2;
        private System.Windows.Forms.Label LblTotal2;
        private Utilities.NudNoWheel nudTotal2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteDelDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteConDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TasaIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteSinIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteDelIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowVersion;
        private System.Windows.Forms.Label LblSubtotalDelImporteSinIVA2;
        private Utilities.NudNoWheel nudSubtotalDelImporteSinIVA2;
        private System.Windows.Forms.Label LblSubtotalDelImporteSinIVA;
        private Utilities.NudNoWheel nudSubtotalDelImporteSinIVA;
    }
}