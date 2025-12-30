namespace NorthwindTradersV5EnCapas
{
    partial class FrmVentasCrud
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
            this.GrbOperaciones = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnNota = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.GrbTotales = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
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
            this.label36 = new System.Windows.Forms.Label();
            this.nudTotal = new Utilities.NudNoWheel();
            this.LblTotal = new System.Windows.Forms.Label();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteDelDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteConDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasaIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteDelIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RowVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbVenta = new System.Windows.Forms.GroupBox();
            this.grbProducto = new System.Windows.Forms.GroupBox();
            this.nudDescuento = new Utilities.NudNoWheel();
            this.nudCantidad = new Utilities.NudNoWheel();
            this.nudUInventario = new Utilities.NudNoWheel();
            this.nudPrecio = new Utilities.NudNoWheel();
            this.label43 = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.grbTransportista = new System.Windows.Forms.GroupBox();
            this.nudFlete = new Utilities.NudNoWheel();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDirigidoa = new System.Windows.Forms.TextBox();
            this.LblCargo = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.cboTransportista = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpHoraEnvio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraRequerido = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraVenta = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpEnvio = new System.Windows.Forms.DateTimePicker();
            this.dtpRequerido = new System.Windows.Forms.DateTimePicker();
            this.dtpVenta = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
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
            this.grbVentas = new System.Windows.Forms.GroupBox();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.tabcOperacion = new System.Windows.Forms.TabControl();
            this.tabpConsultar = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabpRegistrar = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabpModificar = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabpEliminar = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.GrbOperaciones.SuspendLayout();
            this.GrbTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.grbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.grbVenta.SuspendLayout();
            this.grbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.grbTransportista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlete)).BeginInit();
            this.grbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdIni)).BeginInit();
            this.grbVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.tabcOperacion.SuspendLayout();
            this.tabpConsultar.SuspendLayout();
            this.tabpRegistrar.SuspendLayout();
            this.tabpModificar.SuspendLayout();
            this.tabpEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GrbOperaciones);
            this.panel1.Controls.Add(this.GrbTotales);
            this.panel1.Controls.Add(this.grbDetalle);
            this.panel1.Controls.Add(this.grbVenta);
            this.panel1.Controls.Add(this.grbBuscar);
            this.panel1.Controls.Add(this.grbVentas);
            this.panel1.Controls.Add(this.tabcOperacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1579, 1372);
            this.panel1.TabIndex = 0;
            // 
            // GrbOperaciones
            // 
            this.GrbOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbOperaciones.Controls.Add(this.btnNuevo);
            this.GrbOperaciones.Controls.Add(this.btnNota);
            this.GrbOperaciones.Controls.Add(this.btnGenerar);
            this.GrbOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbOperaciones.Location = new System.Drawing.Point(448, 967);
            this.GrbOperaciones.Name = "GrbOperaciones";
            this.GrbOperaciones.Size = new System.Drawing.Size(1101, 69);
            this.GrbOperaciones.TabIndex = 3;
            this.GrbOperaciones.TabStop = false;
            this.GrbOperaciones.Text = "»   Operaciones:   «";
            this.GrbOperaciones.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(475, 21);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(180, 37);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nueva venta";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnNota
            // 
            this.btnNota.AutoSize = true;
            this.btnNota.Enabled = false;
            this.btnNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNota.Location = new System.Drawing.Point(673, 21);
            this.btnNota.Margin = new System.Windows.Forms.Padding(4);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(216, 37);
            this.btnNota.TabIndex = 2;
            this.btnNota.Text = "Nota de remisión";
            this.btnNota.UseVisualStyleBackColor = true;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(907, 21);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(180, 37);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar venta";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // GrbTotales
            // 
            this.GrbTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbTotales.Controls.Add(this.label39);
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
            this.GrbTotales.Controls.Add(this.label36);
            this.GrbTotales.Controls.Add(this.nudTotal);
            this.GrbTotales.Controls.Add(this.LblTotal);
            this.GrbTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbTotales.Location = new System.Drawing.Point(448, 830);
            this.GrbTotales.Name = "GrbTotales";
            this.GrbTotales.Size = new System.Drawing.Size(1101, 132);
            this.GrbTotales.TabIndex = 5;
            this.GrbTotales.TabStop = false;
            this.GrbTotales.Text = "»   Totales de la venta:   «";
            this.GrbTotales.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(20, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(174, 17);
            this.label39.TabIndex = 28;
            this.label39.Text = "Número de productos: ";
            // 
            // LblSubtotalDelImporteDelIVA
            // 
            this.LblSubtotalDelImporteDelIVA.AutoSize = true;
            this.LblSubtotalDelImporteDelIVA.Location = new System.Drawing.Point(20, 99);
            this.LblSubtotalDelImporteDelIVA.Name = "LblSubtotalDelImporteDelIVA";
            this.LblSubtotalDelImporteDelIVA.Size = new System.Drawing.Size(229, 17);
            this.LblSubtotalDelImporteDelIVA.TabIndex = 27;
            this.LblSubtotalDelImporteDelIVA.Text = "Subtotal del importe del IVA $:";
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
            this.nudSubtotalDelImporteDelIVA.Location = new System.Drawing.Point(255, 97);
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
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(345, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(144, 17);
            this.label36.TabIndex = 21;
            this.label36.Text = "Total de unidades:";
            // 
            // nudTotal
            // 
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.Location = new System.Drawing.Point(870, 93);
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
            this.LblTotal.Location = new System.Drawing.Point(790, 96);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(73, 20);
            this.LblTotal.TabIndex = 18;
            this.LblTotal.Text = "Total $:";
            // 
            // grbDetalle
            // 
            this.grbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDetalle.Controls.Add(this.dgvDetalle);
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(448, 1046);
            this.grbDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Padding = new System.Windows.Forms.Padding(4);
            this.grbDetalle.Size = new System.Drawing.Size(1101, 302);
            this.grbDetalle.TabIndex = 6;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "»   Detalle de la venta:   «";
            this.grbDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint2);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Importe,
            this.Descuento,
            this.ImporteDelDescuento,
            this.ImporteConDescuento,
            this.TasaIVA,
            this.ImporteDelIVA,
            this.Subtotal,
            this.Eliminar,
            this.ProductoId,
            this.RowVersion});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(4, 20);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.Size = new System.Drawing.Size(1093, 278);
            this.dgvDetalle.TabIndex = 0;
            this.dgvDetalle.TabStop = false;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            this.dgvDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetalle_CellFormatting);
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
            this.Importe.HeaderText = "Importe";
            this.Importe.MinimumWidth = 6;
            this.Importe.Name = "Importe";
            this.Importe.Width = 125;
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
            this.ImporteConDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ImporteConDescuento.HeaderText = "Importe con descuento";
            this.ImporteConDescuento.MinimumWidth = 6;
            this.ImporteConDescuento.Name = "ImporteConDescuento";
            this.ImporteConDescuento.Width = 184;
            // 
            // TasaIVA
            // 
            this.TasaIVA.HeaderText = "Tasa IVA";
            this.TasaIVA.MinimumWidth = 6;
            this.TasaIVA.Name = "TasaIVA";
            this.TasaIVA.Width = 125;
            // 
            // ImporteDelIVA
            // 
            this.ImporteDelIVA.HeaderText = "Importe del IVA";
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
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Eliminar.Width = 72;
            // 
            // ProductoId
            // 
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.MinimumWidth = 6;
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // grbVenta
            // 
            this.grbVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbVenta.Controls.Add(this.grbProducto);
            this.grbVenta.Controls.Add(this.grbTransportista);
            this.grbVenta.Controls.Add(this.dtpHoraEnvio);
            this.grbVenta.Controls.Add(this.dtpHoraRequerido);
            this.grbVenta.Controls.Add(this.dtpHoraVenta);
            this.grbVenta.Controls.Add(this.label28);
            this.grbVenta.Controls.Add(this.label27);
            this.grbVenta.Controls.Add(this.label26);
            this.grbVenta.Controls.Add(this.dtpEnvio);
            this.grbVenta.Controls.Add(this.dtpRequerido);
            this.grbVenta.Controls.Add(this.dtpVenta);
            this.grbVenta.Controls.Add(this.label25);
            this.grbVenta.Controls.Add(this.label24);
            this.grbVenta.Controls.Add(this.label23);
            this.grbVenta.Controls.Add(this.cboEmpleado);
            this.grbVenta.Controls.Add(this.label22);
            this.grbVenta.Controls.Add(this.cboCliente);
            this.grbVenta.Controls.Add(this.label21);
            this.grbVenta.Controls.Add(this.txtId);
            this.grbVenta.Controls.Add(this.label20);
            this.grbVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbVenta.Location = new System.Drawing.Point(448, 426);
            this.grbVenta.Margin = new System.Windows.Forms.Padding(4);
            this.grbVenta.Name = "grbVenta";
            this.grbVenta.Padding = new System.Windows.Forms.Padding(4);
            this.grbVenta.Size = new System.Drawing.Size(1101, 395);
            this.grbVenta.TabIndex = 2;
            this.grbVenta.TabStop = false;
            this.grbVenta.Text = "»   Venta:   «";
            this.grbVenta.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // grbProducto
            // 
            this.grbProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProducto.Controls.Add(this.nudDescuento);
            this.grbProducto.Controls.Add(this.nudCantidad);
            this.grbProducto.Controls.Add(this.nudUInventario);
            this.grbProducto.Controls.Add(this.nudPrecio);
            this.grbProducto.Controls.Add(this.label43);
            this.grbProducto.Controls.Add(this.cboProducto);
            this.grbProducto.Controls.Add(this.cboCategoria);
            this.grbProducto.Controls.Add(this.btnAgregar);
            this.grbProducto.Controls.Add(this.label41);
            this.grbProducto.Controls.Add(this.label40);
            this.grbProducto.Controls.Add(this.LblPrecio);
            this.grbProducto.Controls.Add(this.label38);
            this.grbProducto.Controls.Add(this.label37);
            this.grbProducto.Location = new System.Drawing.Point(11, 276);
            this.grbProducto.Margin = new System.Windows.Forms.Padding(4);
            this.grbProducto.Name = "grbProducto";
            this.grbProducto.Padding = new System.Windows.Forms.Padding(4);
            this.grbProducto.Size = new System.Drawing.Size(1053, 98);
            this.grbProducto.TabIndex = 1;
            this.grbProducto.TabStop = false;
            this.grbProducto.Text = "»   Agregar producto:   «";
            this.grbProducto.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint2);
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
            this.nudDescuento.Location = new System.Drawing.Point(858, 61);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(85, 23);
            this.nudDescuento.TabIndex = 3;
            this.nudDescuento.WheelEnabled = true;
            this.nudDescuento.Enter += new System.EventHandler(this.Nud_Enter);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(631, 61);
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
            this.nudCantidad.Enter += new System.EventHandler(this.Nud_Enter);
            // 
            // nudUInventario
            // 
            this.nudUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudUInventario.Location = new System.Drawing.Point(444, 61);
            this.nudUInventario.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudUInventario.Name = "nudUInventario";
            this.nudUInventario.Size = new System.Drawing.Size(90, 23);
            this.nudUInventario.TabIndex = 9;
            this.nudUInventario.TabStop = false;
            this.nudUInventario.ThousandsSeparator = true;
            this.nudUInventario.WheelEnabled = true;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(129, 61);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 23);
            this.nudPrecio.TabIndex = 8;
            this.nudPrecio.TabStop = false;
            this.nudPrecio.ThousandsSeparator = true;
            this.nudPrecio.WheelEnabled = true;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(256, 64);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(181, 17);
            this.label43.TabIndex = 5;
            this.label43.Text = "Unidades en inventario:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(619, 20);
            this.cboProducto.Margin = new System.Windows.Forms.Padding(4);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(404, 25);
            this.cboProducto.TabIndex = 1;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(128, 20);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(332, 25);
            this.cboCategoria.TabIndex = 0;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(971, 53);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 37);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "+";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(738, 64);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(120, 17);
            this.label41.TabIndex = 4;
            this.label41.Text = "Descuento (%):";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(544, 64);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 17);
            this.label40.TabIndex = 3;
            this.label40.Text = "Cantidad:";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(43, 64);
            this.LblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(73, 17);
            this.LblPrecio.TabIndex = 2;
            this.LblPrecio.Text = "Precio $:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(527, 25);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 17);
            this.label38.TabIndex = 1;
            this.label38.Text = "Producto:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(33, 25);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(83, 17);
            this.label37.TabIndex = 0;
            this.label37.Text = "Categoría:";
            // 
            // grbTransportista
            // 
            this.grbTransportista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbTransportista.Controls.Add(this.nudFlete);
            this.grbTransportista.Controls.Add(this.txtCP);
            this.grbTransportista.Controls.Add(this.txtCiudad);
            this.grbTransportista.Controls.Add(this.txtDirigidoa);
            this.grbTransportista.Controls.Add(this.LblCargo);
            this.grbTransportista.Controls.Add(this.label35);
            this.grbTransportista.Controls.Add(this.label34);
            this.grbTransportista.Controls.Add(this.label33);
            this.grbTransportista.Controls.Add(this.txtPais);
            this.grbTransportista.Controls.Add(this.txtRegion);
            this.grbTransportista.Controls.Add(this.txtDomicilio);
            this.grbTransportista.Controls.Add(this.cboTransportista);
            this.grbTransportista.Controls.Add(this.label32);
            this.grbTransportista.Controls.Add(this.label31);
            this.grbTransportista.Controls.Add(this.label30);
            this.grbTransportista.Controls.Add(this.label29);
            this.grbTransportista.Location = new System.Drawing.Point(11, 118);
            this.grbTransportista.Margin = new System.Windows.Forms.Padding(4);
            this.grbTransportista.Name = "grbTransportista";
            this.grbTransportista.Padding = new System.Windows.Forms.Padding(4);
            this.grbTransportista.Size = new System.Drawing.Size(1053, 148);
            this.grbTransportista.TabIndex = 0;
            this.grbTransportista.TabStop = false;
            this.grbTransportista.Text = "»   Forma de envío:   «";
            this.grbTransportista.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint2);
            // 
            // nudFlete
            // 
            this.nudFlete.DecimalPlaces = 2;
            this.nudFlete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFlete.Location = new System.Drawing.Point(619, 110);
            this.nudFlete.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFlete.Name = "nudFlete";
            this.nudFlete.Size = new System.Drawing.Size(120, 23);
            this.nudFlete.TabIndex = 7;
            this.nudFlete.ThousandsSeparator = true;
            this.nudFlete.WheelEnabled = true;
            this.nudFlete.Enter += new System.EventHandler(this.Nud_Enter);
            // 
            // txtCP
            // 
            this.txtCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP.Location = new System.Drawing.Point(619, 79);
            this.txtCP.Margin = new System.Windows.Forms.Padding(4);
            this.txtCP.MaxLength = 10;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(132, 23);
            this.txtCP.TabIndex = 5;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiudad.Location = new System.Drawing.Point(619, 49);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(169, 23);
            this.txtCiudad.TabIndex = 3;
            // 
            // txtDirigidoa
            // 
            this.txtDirigidoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirigidoa.Location = new System.Drawing.Point(619, 20);
            this.txtDirigidoa.Margin = new System.Windows.Forms.Padding(4);
            this.txtDirigidoa.MaxLength = 40;
            this.txtDirigidoa.Name = "txtDirigidoa";
            this.txtDirigidoa.Size = new System.Drawing.Size(404, 23);
            this.txtDirigidoa.TabIndex = 1;
            // 
            // LblCargo
            // 
            this.LblCargo.AutoSize = true;
            this.LblCargo.Location = new System.Drawing.Point(461, 113);
            this.LblCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCargo.Name = "LblCargo";
            this.LblCargo.Size = new System.Drawing.Size(143, 17);
            this.LblCargo.TabIndex = 9;
            this.LblCargo.Text = "Cargo por envío $:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(492, 84);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(112, 17);
            this.label35.TabIndex = 8;
            this.label35.Text = "Código postal:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(543, 54);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 17);
            this.label34.TabIndex = 7;
            this.label34.Text = "Ciudad:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(532, 25);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 17);
            this.label33.TabIndex = 6;
            this.label33.Text = "Enviar a:";
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.Location = new System.Drawing.Point(128, 108);
            this.txtPais.Margin = new System.Windows.Forms.Padding(4);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(137, 23);
            this.txtPais.TabIndex = 6;
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(128, 79);
            this.txtRegion.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegion.MaxLength = 15;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(137, 23);
            this.txtRegion.TabIndex = 4;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(128, 49);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.MaxLength = 60;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(332, 23);
            this.txtDomicilio.TabIndex = 2;
            // 
            // cboTransportista
            // 
            this.cboTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransportista.FormattingEnabled = true;
            this.cboTransportista.Location = new System.Drawing.Point(128, 20);
            this.cboTransportista.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransportista.Name = "cboTransportista";
            this.cboTransportista.Size = new System.Drawing.Size(332, 25);
            this.cboTransportista.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(73, 113);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 17);
            this.label32.TabIndex = 3;
            this.label32.Text = "País:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(55, 84);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 17);
            this.label31.TabIndex = 2;
            this.label31.Text = "Región:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(40, 54);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 17);
            this.label30.TabIndex = 1;
            this.label30.Text = "Domicilio:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(32, 25);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 17);
            this.label29.TabIndex = 0;
            this.label29.Text = "Compañía:";
            // 
            // dtpHoraEnvio
            // 
            this.dtpHoraEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEnvio.Location = new System.Drawing.Point(875, 79);
            this.dtpHoraEnvio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoraEnvio.Name = "dtpHoraEnvio";
            this.dtpHoraEnvio.ShowUpDown = true;
            this.dtpHoraEnvio.Size = new System.Drawing.Size(151, 23);
            this.dtpHoraEnvio.TabIndex = 7;
            // 
            // dtpHoraRequerido
            // 
            this.dtpHoraRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraRequerido.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraRequerido.Location = new System.Drawing.Point(875, 49);
            this.dtpHoraRequerido.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoraRequerido.Name = "dtpHoraRequerido";
            this.dtpHoraRequerido.ShowUpDown = true;
            this.dtpHoraRequerido.Size = new System.Drawing.Size(151, 23);
            this.dtpHoraRequerido.TabIndex = 5;
            // 
            // dtpHoraVenta
            // 
            this.dtpHoraVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraVenta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraVenta.Location = new System.Drawing.Point(875, 20);
            this.dtpHoraVenta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHoraVenta.Name = "dtpHoraVenta";
            this.dtpHoraVenta.ShowUpDown = true;
            this.dtpHoraVenta.Size = new System.Drawing.Size(151, 23);
            this.dtpHoraVenta.TabIndex = 3;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(821, 84);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 17);
            this.label28.TabIndex = 14;
            this.label28.Text = "Hora:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(821, 54);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 17);
            this.label27.TabIndex = 13;
            this.label27.Text = "Hora:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(821, 25);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 17);
            this.label26.TabIndex = 12;
            this.label26.Text = "Hora:";
            // 
            // dtpEnvio
            // 
            this.dtpEnvio.Checked = false;
            this.dtpEnvio.CustomFormat = "dd/MMM/yyyy";
            this.dtpEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnvio.Location = new System.Drawing.Point(629, 79);
            this.dtpEnvio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnvio.Name = "dtpEnvio";
            this.dtpEnvio.ShowCheckBox = true;
            this.dtpEnvio.Size = new System.Drawing.Size(177, 23);
            this.dtpEnvio.TabIndex = 6;
            this.dtpEnvio.ValueChanged += new System.EventHandler(this.dtpEnvio_ValueChanged);
            // 
            // dtpRequerido
            // 
            this.dtpRequerido.Checked = false;
            this.dtpRequerido.CustomFormat = "dd/MMM/yyyy";
            this.dtpRequerido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequerido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequerido.Location = new System.Drawing.Point(629, 49);
            this.dtpRequerido.Margin = new System.Windows.Forms.Padding(4);
            this.dtpRequerido.Name = "dtpRequerido";
            this.dtpRequerido.ShowCheckBox = true;
            this.dtpRequerido.Size = new System.Drawing.Size(177, 23);
            this.dtpRequerido.TabIndex = 4;
            this.dtpRequerido.ValueChanged += new System.EventHandler(this.dtpRequerido_ValueChanged);
            // 
            // dtpVenta
            // 
            this.dtpVenta.CustomFormat = "dd/MMM/yyyy";
            this.dtpVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVenta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVenta.Location = new System.Drawing.Point(629, 20);
            this.dtpVenta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVenta.Name = "dtpVenta";
            this.dtpVenta.ShowCheckBox = true;
            this.dtpVenta.Size = new System.Drawing.Size(177, 23);
            this.dtpVenta.TabIndex = 2;
            this.dtpVenta.ValueChanged += new System.EventHandler(this.dtpVenta_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(493, 84);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(124, 17);
            this.label25.TabIndex = 8;
            this.label25.Text = "Fecha de envío:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(480, 54);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(141, 17);
            this.label24.TabIndex = 7;
            this.label24.Text = "Fecha de entrega:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(487, 25);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 17);
            this.label23.TabIndex = 6;
            this.label23.Text = "Fecha de venta:";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(139, 79);
            this.cboEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(332, 25);
            this.cboEmpleado.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(48, 84);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 17);
            this.label22.TabIndex = 4;
            this.label22.Text = "Vendedor:";
            // 
            // cboCliente
            // 
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(139, 49);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(332, 25);
            this.cboCliente.TabIndex = 0;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 54);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 17);
            this.label21.TabIndex = 2;
            this.label21.Text = "Cliente:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(139, 14);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(150, 26);
            this.txtId.TabIndex = 8;
            this.txtId.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(107, 19);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Id:";
            // 
            // grbBuscar
            // 
            this.grbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscar.Controls.Add(this.nudBIdFin);
            this.grbBuscar.Controls.Add(this.nudBIdIni);
            this.grbBuscar.Controls.Add(this.btnLimpiar);
            this.grbBuscar.Controls.Add(this.btnBuscar);
            this.grbBuscar.Controls.Add(this.label19);
            this.grbBuscar.Controls.Add(this.txtBDirigidoa);
            this.grbBuscar.Controls.Add(this.label18);
            this.grbBuscar.Controls.Add(this.txtBCompañiaT);
            this.grbBuscar.Controls.Add(this.label17);
            this.grbBuscar.Controls.Add(this.txtBEmpleado);
            this.grbBuscar.Controls.Add(this.label15);
            this.grbBuscar.Controls.Add(this.label16);
            this.grbBuscar.Controls.Add(this.dtpBFEnvioFin);
            this.grbBuscar.Controls.Add(this.dtpBFEnvioIni);
            this.grbBuscar.Controls.Add(this.chkbBFEnvioNull);
            this.grbBuscar.Controls.Add(this.label14);
            this.grbBuscar.Controls.Add(this.label12);
            this.grbBuscar.Controls.Add(this.label13);
            this.grbBuscar.Controls.Add(this.dtpBFRequeridoFin);
            this.grbBuscar.Controls.Add(this.dtpBFRequeridoIni);
            this.grbBuscar.Controls.Add(this.chkbBFRequeridoNull);
            this.grbBuscar.Controls.Add(this.label11);
            this.grbBuscar.Controls.Add(this.chkbBFVentaNull);
            this.grbBuscar.Controls.Add(this.label10);
            this.grbBuscar.Controls.Add(this.label9);
            this.grbBuscar.Controls.Add(this.dtpBFVentaFin);
            this.grbBuscar.Controls.Add(this.dtpBFVentaIni);
            this.grbBuscar.Controls.Add(this.label8);
            this.grbBuscar.Controls.Add(this.txtBCliente);
            this.grbBuscar.Controls.Add(this.label7);
            this.grbBuscar.Controls.Add(this.label6);
            this.grbBuscar.Controls.Add(this.label5);
            this.grbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBuscar.Location = new System.Drawing.Point(27, 426);
            this.grbBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Padding = new System.Windows.Forms.Padding(4);
            this.grbBuscar.Size = new System.Drawing.Size(396, 927);
            this.grbBuscar.TabIndex = 4;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "»   Buscar una venta:   «";
            this.grbBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // nudBIdFin
            // 
            this.nudBIdFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBIdFin.Location = new System.Drawing.Point(115, 73);
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
            this.nudBIdIni.Location = new System.Drawing.Point(115, 37);
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
            this.btnLimpiar.Location = new System.Drawing.Point(94, 505);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 28);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(238, 505);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 28);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 460);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 17);
            this.label19.TabIndex = 29;
            this.label19.Text = "Enviar a:";
            // 
            // txtBDirigidoa
            // 
            this.txtBDirigidoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDirigidoa.Location = new System.Drawing.Point(115, 456);
            this.txtBDirigidoa.Margin = new System.Windows.Forms.Padding(4);
            this.txtBDirigidoa.MaxLength = 40;
            this.txtBDirigidoa.Name = "txtBDirigidoa";
            this.txtBDirigidoa.Size = new System.Drawing.Size(255, 23);
            this.txtBDirigidoa.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(2, 414);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 31);
            this.label18.TabIndex = 27;
            this.label18.Text = "Compañía transportista:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBCompañiaT
            // 
            this.txtBCompañiaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCompañiaT.Location = new System.Drawing.Point(115, 416);
            this.txtBCompañiaT.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCompañiaT.MaxLength = 40;
            this.txtBCompañiaT.Name = "txtBCompañiaT";
            this.txtBCompañiaT.Size = new System.Drawing.Size(255, 23);
            this.txtBCompañiaT.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 377);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "Vendedor:";
            // 
            // txtBEmpleado
            // 
            this.txtBEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBEmpleado.Location = new System.Drawing.Point(115, 372);
            this.txtBEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.txtBEmpleado.MaxLength = 31;
            this.txtBEmpleado.Name = "txtBEmpleado";
            this.txtBEmpleado.Size = new System.Drawing.Size(255, 23);
            this.txtBEmpleado.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(189, 323);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 31);
            this.label15.TabIndex = 23;
            this.label15.Text = "Fecha final:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 323);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 31);
            this.label16.TabIndex = 22;
            this.label16.Text = "Fecha inicial:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFEnvioFin
            // 
            this.dtpBFEnvioFin.Checked = false;
            this.dtpBFEnvioFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFEnvioFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFEnvioFin.Location = new System.Drawing.Point(245, 325);
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
            this.dtpBFEnvioIni.Location = new System.Drawing.Point(62, 325);
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
            this.chkbBFEnvioNull.Location = new System.Drawing.Point(258, 294);
            this.chkbBFEnvioNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFEnvioNull.Name = "chkbBFEnvioNull";
            this.chkbBFEnvioNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFEnvioNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFEnvioNull.TabIndex = 9;
            this.chkbBFEnvioNull.Text = "Fecha = null";
            this.chkbBFEnvioNull.UseVisualStyleBackColor = true;
            this.chkbBFEnvioNull.CheckedChanged += new System.EventHandler(this.chkBFEnvioNull_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 293);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Fecha de envío:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(189, 249);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 31);
            this.label12.TabIndex = 17;
            this.label12.Text = "Fecha final:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 249);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 31);
            this.label13.TabIndex = 16;
            this.label13.Text = "Fecha inicial:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFRequeridoFin
            // 
            this.dtpBFRequeridoFin.Checked = false;
            this.dtpBFRequeridoFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFRequeridoFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFRequeridoFin.Location = new System.Drawing.Point(245, 251);
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
            this.dtpBFRequeridoIni.Location = new System.Drawing.Point(62, 251);
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
            this.chkbBFRequeridoNull.Location = new System.Drawing.Point(258, 219);
            this.chkbBFRequeridoNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFRequeridoNull.Name = "chkbBFRequeridoNull";
            this.chkbBFRequeridoNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFRequeridoNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFRequeridoNull.TabIndex = 6;
            this.chkbBFRequeridoNull.Text = "Fecha = null";
            this.chkbBFRequeridoNull.UseVisualStyleBackColor = true;
            this.chkbBFRequeridoNull.CheckedChanged += new System.EventHandler(this.chkBFRequeridoNull_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 219);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Fecha de entrega:";
            // 
            // chkbBFVentaNull
            // 
            this.chkbBFVentaNull.AutoSize = true;
            this.chkbBFVentaNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbBFVentaNull.Location = new System.Drawing.Point(258, 152);
            this.chkbBFVentaNull.Margin = new System.Windows.Forms.Padding(4);
            this.chkbBFVentaNull.Name = "chkbBFVentaNull";
            this.chkbBFVentaNull.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbBFVentaNull.Size = new System.Drawing.Size(99, 17);
            this.chkbBFVentaNull.TabIndex = 3;
            this.chkbBFVentaNull.Text = "Fecha = null";
            this.chkbBFVentaNull.UseVisualStyleBackColor = true;
            this.chkbBFVentaNull.CheckedChanged += new System.EventHandler(this.chkBFVentaNull_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(189, 177);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 31);
            this.label10.TabIndex = 10;
            this.label10.Text = "Fecha final:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 31);
            this.label9.TabIndex = 9;
            this.label9.Text = "Fecha inicial:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpBFVentaFin
            // 
            this.dtpBFVentaFin.Checked = false;
            this.dtpBFVentaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFVentaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFVentaFin.Location = new System.Drawing.Point(245, 180);
            this.dtpBFVentaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFVentaFin.Name = "dtpBFVentaFin";
            this.dtpBFVentaFin.ShowCheckBox = true;
            this.dtpBFVentaFin.Size = new System.Drawing.Size(125, 23);
            this.dtpBFVentaFin.TabIndex = 5;
            this.dtpBFVentaFin.ValueChanged += new System.EventHandler(this.dtpBFVentaFin_ValueChanged);
            this.dtpBFVentaFin.Leave += new System.EventHandler(this.dtpBFVentaFin_Leave);
            // 
            // dtpBFVentaIni
            // 
            this.dtpBFVentaIni.Checked = false;
            this.dtpBFVentaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBFVentaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBFVentaIni.Location = new System.Drawing.Point(62, 180);
            this.dtpBFVentaIni.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBFVentaIni.Name = "dtpBFVentaIni";
            this.dtpBFVentaIni.ShowCheckBox = true;
            this.dtpBFVentaIni.Size = new System.Drawing.Size(125, 23);
            this.dtpBFVentaIni.TabIndex = 4;
            this.dtpBFVentaIni.ValueChanged += new System.EventHandler(this.dtpBFVentaIni_ValueChanged);
            this.dtpBFVentaIni.Leave += new System.EventHandler(this.dtpBFVentaIni_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Fecha de venta:";
            // 
            // txtBCliente
            // 
            this.txtBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBCliente.Location = new System.Drawing.Point(115, 111);
            this.txtBCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCliente.MaxLength = 40;
            this.txtBCliente.Name = "txtBCliente";
            this.txtBCliente.Size = new System.Drawing.Size(255, 23);
            this.txtBCliente.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 116);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Cliente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Id final:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Id inicial:";
            // 
            // grbVentas
            // 
            this.grbVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbVentas.Controls.Add(this.dgvVentas);
            this.grbVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbVentas.Location = new System.Drawing.Point(27, 104);
            this.grbVentas.Margin = new System.Windows.Forms.Padding(4);
            this.grbVentas.Name = "grbVentas";
            this.grbVentas.Padding = new System.Windows.Forms.Padding(4);
            this.grbVentas.Size = new System.Drawing.Size(1526, 307);
            this.grbVentas.TabIndex = 1;
            this.grbVentas.TabStop = false;
            this.grbVentas.Text = "»   Ventas:   «";
            this.grbVentas.Paint += new System.Windows.Forms.PaintEventHandler(this.GrbPaint);
            // 
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(4, 20);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.Size = new System.Drawing.Size(1518, 283);
            this.dgvVentas.TabIndex = 0;
            this.dgvVentas.TabStop = false;
            this.dgvVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellClick);
            this.dgvVentas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVentas_ColumnHeaderMouseClick);
            // 
            // tabcOperacion
            // 
            this.tabcOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcOperacion.Controls.Add(this.tabpConsultar);
            this.tabcOperacion.Controls.Add(this.tabpRegistrar);
            this.tabcOperacion.Controls.Add(this.tabpModificar);
            this.tabcOperacion.Controls.Add(this.tabpEliminar);
            this.tabcOperacion.Location = new System.Drawing.Point(25, 27);
            this.tabcOperacion.Margin = new System.Windows.Forms.Padding(4);
            this.tabcOperacion.Name = "tabcOperacion";
            this.tabcOperacion.SelectedIndex = 0;
            this.tabcOperacion.Size = new System.Drawing.Size(1524, 69);
            this.tabcOperacion.TabIndex = 0;
            this.tabcOperacion.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabcOperacion_Selecting);
            this.tabcOperacion.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabcOperacion_Selected);
            // 
            // tabpConsultar
            // 
            this.tabpConsultar.Controls.Add(this.label1);
            this.tabpConsultar.Location = new System.Drawing.Point(4, 25);
            this.tabpConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.tabpConsultar.Name = "tabpConsultar";
            this.tabpConsultar.Padding = new System.Windows.Forms.Padding(4);
            this.tabpConsultar.Size = new System.Drawing.Size(1516, 40);
            this.tabpConsultar.TabIndex = 0;
            this.tabpConsultar.Text = "   Consultar venta   ";
            this.tabpConsultar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busque la venta y seleccionela en la lista que se muesta para ver su detalle";
            // 
            // tabpRegistrar
            // 
            this.tabpRegistrar.Controls.Add(this.label2);
            this.tabpRegistrar.Location = new System.Drawing.Point(4, 25);
            this.tabpRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.tabpRegistrar.Name = "tabpRegistrar";
            this.tabpRegistrar.Padding = new System.Windows.Forms.Padding(4);
            this.tabpRegistrar.Size = new System.Drawing.Size(1516, 40);
            this.tabpRegistrar.TabIndex = 1;
            this.tabpRegistrar.Text = "   Registrar venta   ";
            this.tabpRegistrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proporcione los datos de la venta a registrar";
            // 
            // tabpModificar
            // 
            this.tabpModificar.Controls.Add(this.label3);
            this.tabpModificar.Location = new System.Drawing.Point(4, 25);
            this.tabpModificar.Margin = new System.Windows.Forms.Padding(4);
            this.tabpModificar.Name = "tabpModificar";
            this.tabpModificar.Padding = new System.Windows.Forms.Padding(4);
            this.tabpModificar.Size = new System.Drawing.Size(1516, 40);
            this.tabpModificar.TabIndex = 2;
            this.tabpModificar.Text = "   Modificar venta   ";
            this.tabpModificar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(565, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Busque la venta y seleccionela en la lista que se muestra para que pueda modifica" +
    "r sus datos";
            // 
            // tabpEliminar
            // 
            this.tabpEliminar.Controls.Add(this.label4);
            this.tabpEliminar.Location = new System.Drawing.Point(4, 25);
            this.tabpEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.tabpEliminar.Name = "tabpEliminar";
            this.tabpEliminar.Padding = new System.Windows.Forms.Padding(4);
            this.tabpEliminar.Size = new System.Drawing.Size(1516, 40);
            this.tabpEliminar.TabIndex = 3;
            this.tabpEliminar.Text = "   Eliminar venta   ";
            this.tabpEliminar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Busque la venta a eliminar y seleccionela en la lista que se muestra";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmVentasCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1579, 1372);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVentasCrud";
            this.Text = "» Mantenimiento de Ventas «";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentasCrud_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVentasCrud_FormClosed);
            this.Load += new System.EventHandler(this.FrmVentasCrud_Load);
            this.panel1.ResumeLayout(false);
            this.GrbOperaciones.ResumeLayout(false);
            this.GrbOperaciones.PerformLayout();
            this.GrbTotales.ResumeLayout(false);
            this.GrbTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteConDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporteDelDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotalDelImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDeUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.grbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.grbVenta.ResumeLayout(false);
            this.grbVenta.PerformLayout();
            this.grbProducto.ResumeLayout(false);
            this.grbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.grbTransportista.ResumeLayout(false);
            this.grbTransportista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlete)).EndInit();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBIdIni)).EndInit();
            this.grbVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.tabcOperacion.ResumeLayout(false);
            this.tabpConsultar.ResumeLayout(false);
            this.tabpConsultar.PerformLayout();
            this.tabpRegistrar.ResumeLayout(false);
            this.tabpRegistrar.PerformLayout();
            this.tabpModificar.ResumeLayout(false);
            this.tabpModificar.PerformLayout();
            this.tabpEliminar.ResumeLayout(false);
            this.tabpEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabcOperacion;
        private System.Windows.Forms.TabPage tabpConsultar;
        private System.Windows.Forms.TabPage tabpRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabpModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabpEliminar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbVentas;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpBFVentaIni;
        private System.Windows.Forms.DateTimePicker dtpBFVentaFin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkbBFVentaNull;
        private System.Windows.Forms.CheckBox chkbBFRequeridoNull;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoFin;
        private System.Windows.Forms.DateTimePicker dtpBFRequeridoIni;
        private System.Windows.Forms.CheckBox chkbBFEnvioNull;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioFin;
        private System.Windows.Forms.DateTimePicker dtpBFEnvioIni;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBEmpleado;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBCompañiaT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtBDirigidoa;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox grbVenta;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpEnvio;
        private System.Windows.Forms.DateTimePicker dtpRequerido;
        private System.Windows.Forms.DateTimePicker dtpVenta;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dtpHoraEnvio;
        private System.Windows.Forms.DateTimePicker dtpHoraRequerido;
        private System.Windows.Forms.DateTimePicker dtpHoraVenta;
        private System.Windows.Forms.GroupBox grbTransportista;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.ComboBox cboTransportista;
        private System.Windows.Forms.Label LblCargo;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtDirigidoa;
        private System.Windows.Forms.GroupBox grbProducto;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button btnNota;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.NumericUpDown nudBIdFin;
        private System.Windows.Forms.NumericUpDown nudBIdIni;
        private Utilities.NudNoWheel nudFlete;
        private Utilities.NudNoWheel nudPrecio;
        private Utilities.NudNoWheel nudUInventario;
        private Utilities.NudNoWheel nudCantidad;
        private Utilities.NudNoWheel nudDescuento;
        private Utilities.NudNoWheel nudTotal;
        private System.Windows.Forms.GroupBox GrbTotales;
        private System.Windows.Forms.GroupBox GrbOperaciones;
        private System.Windows.Forms.Label label36;
        private Utilities.NudNoWheel nudTotalDeUnidades;
        private Utilities.NudNoWheel nudSubtotalDelImporte;
        private System.Windows.Forms.Label LblSubtotalDelImporte;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelDescuento;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelDescuento;
        private System.Windows.Forms.Label LblSubtotalDelImporteConDescuento;
        private System.Windows.Forms.Label LblSubtotalDelImporteDelIVA;
        private Utilities.NudNoWheel nudSubtotalDelImporteConDescuento;
        private Utilities.NudNoWheel nudSubtotalDelImporteDelIVA;
        private System.Windows.Forms.Label label39;
        private Utilities.NudNoWheel nudNumProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteDelDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteConDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TasaIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteDelIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowVersion;
    }
}