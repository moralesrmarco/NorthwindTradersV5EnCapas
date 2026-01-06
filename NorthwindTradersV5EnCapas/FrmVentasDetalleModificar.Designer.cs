namespace NorthwindTradersV5EnCapas
{
    partial class FrmVentasDetalleModificar
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
            this.label1 = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblImporteDelDecuento = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudDescuento = new Utilities.NudNoWheel();
            this.nudCantidad = new Utilities.NudNoWheel();
            this.nudUInventario = new Utilities.NudNoWheel();
            this.nudPrecio = new Utilities.NudNoWheel();
            this.LblImporteConDescunto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblImporteDelIVA = new System.Windows.Forms.Label();
            this.LblSubtotal = new System.Windows.Forms.Label();
            this.nudImporteDelIVA = new Utilities.NudNoWheel();
            this.nudImporteConDescuento = new Utilities.NudNoWheel();
            this.nudImporteDelDescuento = new Utilities.NudNoWheel();
            this.nudSubtotal = new Utilities.NudNoWheel();
            this.nudTasaIVA = new Utilities.NudNoWheel();
            this.LblImporte = new System.Windows.Forms.Label();
            this.nudImporte = new Utilities.NudNoWheel();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.pbWarning = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbInfo1 = new System.Windows.Forms.PictureBox();
            this.pbError1 = new System.Windows.Forms.PictureBox();
            this.pbWarning1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteDelIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteConDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteDelDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasaIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecio.Location = new System.Drawing.Point(76, 107);
            this.LblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(73, 17);
            this.LblPrecio.TabIndex = 0;
            this.LblPrecio.Text = "Precio $:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unidades en inventario:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 270);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Descuento %:";
            // 
            // LblImporteDelDecuento
            // 
            this.LblImporteDelDecuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporteDelDecuento.Location = new System.Drawing.Point(46, 301);
            this.LblImporteDelDecuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblImporteDelDecuento.Name = "LblImporteDelDecuento";
            this.LblImporteDelDecuento.Size = new System.Drawing.Size(103, 39);
            this.LblImporteDelDecuento.TabIndex = 0;
            this.LblImporteDelDecuento.Text = "Importe del descuento $:";
            this.LblImporteDelDecuento.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(160, 64);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(479, 22);
            this.txtProducto.TabIndex = 5;
            this.txtProducto.TabStop = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(398, 471);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(139, 28);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(551, 471);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(86, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Pedido:";
            // 
            // txtPedido
            // 
            this.txtPedido.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(160, 20);
            this.txtPedido.Margin = new System.Windows.Forms.Padding(4);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(132, 26);
            this.txtPedido.TabIndex = 4;
            this.txtPedido.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.nudDescuento.Location = new System.Drawing.Point(160, 267);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(85, 23);
            this.nudDescuento.TabIndex = 1;
            this.nudDescuento.WheelEnabled = true;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudDescuento.Leave += new System.EventHandler(this.nudDescuento_Leave);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(160, 186);
            this.nudCantidad.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 23);
            this.nudCantidad.TabIndex = 0;
            this.nudCantidad.ThousandsSeparator = true;
            this.nudCantidad.WheelEnabled = true;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            this.nudCantidad.Enter += new System.EventHandler(this.Nud_Enter);
            this.nudCantidad.Leave += new System.EventHandler(this.nudCantidad_Leave);
            // 
            // nudUInventario
            // 
            this.nudUInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudUInventario.Location = new System.Drawing.Point(160, 145);
            this.nudUInventario.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudUInventario.Name = "nudUInventario";
            this.nudUInventario.Size = new System.Drawing.Size(90, 23);
            this.nudUInventario.TabIndex = 14;
            this.nudUInventario.TabStop = false;
            this.nudUInventario.ThousandsSeparator = true;
            this.nudUInventario.WheelEnabled = true;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(160, 104);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 23);
            this.nudPrecio.TabIndex = 13;
            this.nudPrecio.TabStop = false;
            this.nudPrecio.ThousandsSeparator = true;
            this.nudPrecio.WheelEnabled = true;
            // 
            // LblImporteConDescunto
            // 
            this.LblImporteConDescunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporteConDescunto.Location = new System.Drawing.Point(46, 342);
            this.LblImporteConDescunto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblImporteConDescunto.Name = "LblImporteConDescunto";
            this.LblImporteConDescunto.Size = new System.Drawing.Size(103, 39);
            this.LblImporteConDescunto.TabIndex = 0;
            this.LblImporteConDescunto.Text = "Importe con descuento $:";
            this.LblImporteConDescunto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 394);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tasa IVA %:";
            // 
            // LblImporteDelIVA
            // 
            this.LblImporteDelIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporteDelIVA.Location = new System.Drawing.Point(46, 424);
            this.LblImporteDelIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblImporteDelIVA.Name = "LblImporteDelIVA";
            this.LblImporteDelIVA.Size = new System.Drawing.Size(103, 39);
            this.LblImporteDelIVA.TabIndex = 0;
            this.LblImporteDelIVA.Text = "Importe del IVA $:";
            this.LblImporteDelIVA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblSubtotal
            // 
            this.LblSubtotal.AutoSize = true;
            this.LblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubtotal.Location = new System.Drawing.Point(62, 478);
            this.LblSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSubtotal.Name = "LblSubtotal";
            this.LblSubtotal.Size = new System.Drawing.Size(87, 17);
            this.LblSubtotal.TabIndex = 0;
            this.LblSubtotal.Text = "Subtotal $:";
            // 
            // nudImporteDelIVA
            // 
            this.nudImporteDelIVA.DecimalPlaces = 2;
            this.nudImporteDelIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporteDelIVA.Location = new System.Drawing.Point(160, 432);
            this.nudImporteDelIVA.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudImporteDelIVA.Name = "nudImporteDelIVA";
            this.nudImporteDelIVA.Size = new System.Drawing.Size(167, 23);
            this.nudImporteDelIVA.TabIndex = 26;
            this.nudImporteDelIVA.TabStop = false;
            this.nudImporteDelIVA.ThousandsSeparator = true;
            this.nudImporteDelIVA.WheelEnabled = true;
            // 
            // nudImporteConDescuento
            // 
            this.nudImporteConDescuento.DecimalPlaces = 2;
            this.nudImporteConDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporteConDescuento.Location = new System.Drawing.Point(160, 350);
            this.nudImporteConDescuento.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudImporteConDescuento.Name = "nudImporteConDescuento";
            this.nudImporteConDescuento.Size = new System.Drawing.Size(167, 23);
            this.nudImporteConDescuento.TabIndex = 27;
            this.nudImporteConDescuento.TabStop = false;
            this.nudImporteConDescuento.ThousandsSeparator = true;
            this.nudImporteConDescuento.WheelEnabled = true;
            // 
            // nudImporteDelDescuento
            // 
            this.nudImporteDelDescuento.DecimalPlaces = 2;
            this.nudImporteDelDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporteDelDescuento.Location = new System.Drawing.Point(160, 309);
            this.nudImporteDelDescuento.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudImporteDelDescuento.Name = "nudImporteDelDescuento";
            this.nudImporteDelDescuento.Size = new System.Drawing.Size(167, 23);
            this.nudImporteDelDescuento.TabIndex = 28;
            this.nudImporteDelDescuento.TabStop = false;
            this.nudImporteDelDescuento.ThousandsSeparator = true;
            this.nudImporteDelDescuento.WheelEnabled = true;
            // 
            // nudSubtotal
            // 
            this.nudSubtotal.DecimalPlaces = 2;
            this.nudSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubtotal.Location = new System.Drawing.Point(160, 473);
            this.nudSubtotal.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSubtotal.Name = "nudSubtotal";
            this.nudSubtotal.Size = new System.Drawing.Size(217, 26);
            this.nudSubtotal.TabIndex = 25;
            this.nudSubtotal.TabStop = false;
            this.nudSubtotal.ThousandsSeparator = true;
            this.nudSubtotal.WheelEnabled = true;
            // 
            // nudTasaIVA
            // 
            this.nudTasaIVA.DecimalPlaces = 2;
            this.nudTasaIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTasaIVA.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTasaIVA.Location = new System.Drawing.Point(160, 391);
            this.nudTasaIVA.Name = "nudTasaIVA";
            this.nudTasaIVA.Size = new System.Drawing.Size(85, 23);
            this.nudTasaIVA.TabIndex = 12;
            this.nudTasaIVA.TabStop = false;
            this.nudTasaIVA.WheelEnabled = true;
            // 
            // LblImporte
            // 
            this.LblImporte.AutoSize = true;
            this.LblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImporte.Location = new System.Drawing.Point(68, 231);
            this.LblImporte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblImporte.Name = "LblImporte";
            this.LblImporte.Size = new System.Drawing.Size(81, 17);
            this.LblImporte.TabIndex = 0;
            this.LblImporte.Text = "Importe $:";
            // 
            // nudImporte
            // 
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudImporte.Location = new System.Drawing.Point(160, 228);
            this.nudImporte.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(167, 23);
            this.nudImporte.TabIndex = 29;
            this.nudImporte.TabStop = false;
            this.nudImporte.ThousandsSeparator = true;
            this.nudImporte.WheelEnabled = true;
            // 
            // pbInfo
            // 
            this.pbInfo.Location = new System.Drawing.Point(260, 186);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(20, 20);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo.TabIndex = 30;
            this.pbInfo.TabStop = false;
            // 
            // pbError
            // 
            this.pbError.Location = new System.Drawing.Point(286, 186);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(20, 20);
            this.pbError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbError.TabIndex = 30;
            this.pbError.TabStop = false;
            // 
            // pbWarning
            // 
            this.pbWarning.Location = new System.Drawing.Point(312, 186);
            this.pbWarning.Name = "pbWarning";
            this.pbWarning.Size = new System.Drawing.Size(20, 20);
            this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarning.TabIndex = 30;
            this.pbWarning.TabStop = false;
            // 
            // pbInfo1
            // 
            this.pbInfo1.Location = new System.Drawing.Point(260, 146);
            this.pbInfo1.Name = "pbInfo1";
            this.pbInfo1.Size = new System.Drawing.Size(20, 20);
            this.pbInfo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo1.TabIndex = 30;
            this.pbInfo1.TabStop = false;
            // 
            // pbError1
            // 
            this.pbError1.Location = new System.Drawing.Point(286, 146);
            this.pbError1.Name = "pbError1";
            this.pbError1.Size = new System.Drawing.Size(20, 20);
            this.pbError1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbError1.TabIndex = 30;
            this.pbError1.TabStop = false;
            // 
            // pbWarning1
            // 
            this.pbWarning1.Location = new System.Drawing.Point(312, 146);
            this.pbWarning1.Name = "pbWarning1";
            this.pbWarning1.Size = new System.Drawing.Size(20, 20);
            this.pbWarning1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWarning1.TabIndex = 30;
            this.pbWarning1.TabStop = false;
            // 
            // FrmVentasDetalleModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 571);
            this.ControlBox = false;
            this.Controls.Add(this.pbWarning1);
            this.Controls.Add(this.pbWarning);
            this.Controls.Add(this.pbError1);
            this.Controls.Add(this.pbError);
            this.Controls.Add(this.pbInfo1);
            this.Controls.Add(this.pbInfo);
            this.Controls.Add(this.nudImporteDelIVA);
            this.Controls.Add(this.nudImporteConDescuento);
            this.Controls.Add(this.nudImporteDelDescuento);
            this.Controls.Add(this.nudImporte);
            this.Controls.Add(this.nudSubtotal);
            this.Controls.Add(this.nudTasaIVA);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.nudUInventario);
            this.Controls.Add(this.nudPrecio);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.LblImporteDelIVA);
            this.Controls.Add(this.LblImporteConDescunto);
            this.Controls.Add(this.LblImporteDelDecuento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblImporte);
            this.Controls.Add(this.LblSubtotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVentasDetalleModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "» Modificar detalle de venta «";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentasDetalleModificar_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVentasDetalleModificar_FormClosed);
            this.Load += new System.EventHandler(this.FrmVentasDetalleModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteDelIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteConDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporteDelDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTasaIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWarning1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblImporteDelDecuento;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Utilities.NudNoWheel nudDescuento;
        private Utilities.NudNoWheel nudCantidad;
        private Utilities.NudNoWheel nudUInventario;
        private Utilities.NudNoWheel nudPrecio;
        private System.Windows.Forms.Label LblImporteDelIVA;
        private System.Windows.Forms.Label LblImporteConDescunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblSubtotal;
        private Utilities.NudNoWheel nudImporteDelIVA;
        private Utilities.NudNoWheel nudImporteConDescuento;
        private Utilities.NudNoWheel nudImporteDelDescuento;
        private Utilities.NudNoWheel nudSubtotal;
        private Utilities.NudNoWheel nudTasaIVA;
        private Utilities.NudNoWheel nudImporte;
        private System.Windows.Forms.Label LblImporte;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.PictureBox pbWarning;
        private System.Windows.Forms.PictureBox pbError;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbWarning1;
        private System.Windows.Forms.PictureBox pbError1;
        private System.Windows.Forms.PictureBox pbInfo1;
    }
}