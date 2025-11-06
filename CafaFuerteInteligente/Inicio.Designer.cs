namespace CafaFuerteInteligente
{
    partial class Inicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.btnNada = new FontAwesome.Sharp.IconButton();
            this.panelUsuarios = new System.Windows.Forms.Panel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.panelNuevos = new System.Windows.Forms.Panel();
            this.btnmostarNU = new FontAwesome.Sharp.IconButton();
            this.btnmostrarNT = new FontAwesome.Sharp.IconButton();
            this.gbUN = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContraN = new System.Windows.Forms.TextBox();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.btnver = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNTarjeta = new FontAwesome.Sharp.IconButton();
            this.txtNT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lbluid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelNuevos.SuspendLayout();
            this.gbUN.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.iconButton4);
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 366);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.btnNada);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 75);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.panelNuevos);
            this.panel3.Controls.Add(this.panelUsuarios);
            this.panel3.Location = new System.Drawing.Point(179, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 366);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(188, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrador";
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Portrait;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(174, 52);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.Text = "Usuarios";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 40;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 61);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(173, 52);
            this.iconButton2.TabIndex = 1;
            this.iconButton2.Text = "Tarjetas";
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 40;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 119);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(171, 52);
            this.iconButton3.TabIndex = 2;
            this.iconButton3.Text = "Registros";
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // btnNada
            // 
            this.btnNada.BackColor = System.Drawing.Color.Navy;
            this.btnNada.IconChar = FontAwesome.Sharp.IconChar.UsersRectangle;
            this.btnNada.IconColor = System.Drawing.Color.White;
            this.btnNada.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNada.Location = new System.Drawing.Point(70, 7);
            this.btnNada.Margin = new System.Windows.Forms.Padding(0);
            this.btnNada.Name = "btnNada";
            this.btnNada.Size = new System.Drawing.Size(100, 62);
            this.btnNada.TabIndex = 1;
            this.btnNada.UseVisualStyleBackColor = false;
            // 
            // panelUsuarios
            // 
            this.panelUsuarios.Controls.Add(this.dgvUsuarios);
            this.panelUsuarios.Location = new System.Drawing.Point(15, 17);
            this.panelUsuarios.Name = "panelUsuarios";
            this.panelUsuarios.Size = new System.Drawing.Size(475, 338);
            this.panelUsuarios.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(14, 12);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(446, 176);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // iconButton4
            // 
            this.iconButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton4.IconColor = System.Drawing.Color.Black;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 40;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.Location = new System.Drawing.Point(3, 177);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(171, 52);
            this.iconButton4.TabIndex = 3;
            this.iconButton4.Text = "Nuevo";
            this.iconButton4.UseVisualStyleBackColor = true;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // panelNuevos
            // 
            this.panelNuevos.Controls.Add(this.gbUN);
            this.panelNuevos.Controls.Add(this.btnmostrarNT);
            this.panelNuevos.Controls.Add(this.btnmostarNU);
            this.panelNuevos.Location = new System.Drawing.Point(15, 17);
            this.panelNuevos.Name = "panelNuevos";
            this.panelNuevos.Size = new System.Drawing.Size(475, 338);
            this.panelNuevos.TabIndex = 1;
            // 
            // btnmostarNU
            // 
            this.btnmostarNU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnmostarNU.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnmostarNU.IconColor = System.Drawing.Color.Black;
            this.btnmostarNU.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmostarNU.IconSize = 25;
            this.btnmostarNU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmostarNU.Location = new System.Drawing.Point(50, 12);
            this.btnmostarNU.Name = "btnmostarNU";
            this.btnmostarNU.Size = new System.Drawing.Size(138, 42);
            this.btnmostarNU.TabIndex = 4;
            this.btnmostarNU.Text = "Usuarios";
            this.btnmostarNU.UseVisualStyleBackColor = true;
            this.btnmostarNU.Click += new System.EventHandler(this.btnmostarNU_Click);
            // 
            // btnmostrarNT
            // 
            this.btnmostrarNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnmostrarNT.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnmostrarNT.IconColor = System.Drawing.Color.Black;
            this.btnmostrarNT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmostrarNT.IconSize = 25;
            this.btnmostrarNT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmostrarNT.Location = new System.Drawing.Point(291, 12);
            this.btnmostrarNT.Name = "btnmostrarNT";
            this.btnmostrarNT.Size = new System.Drawing.Size(138, 42);
            this.btnmostrarNT.TabIndex = 5;
            this.btnmostrarNT.Text = "Tarjetas";
            this.btnmostrarNT.UseVisualStyleBackColor = true;
            // 
            // gbUN
            // 
            this.gbUN.BackColor = System.Drawing.Color.Transparent;
            this.gbUN.Controls.Add(this.btnver);
            this.gbUN.Controls.Add(this.btnAgregar);
            this.gbUN.Controls.Add(this.txtContraN);
            this.gbUN.Controls.Add(this.label3);
            this.gbUN.Controls.Add(this.txtUserN);
            this.gbUN.Controls.Add(this.label2);
            this.gbUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUN.Location = new System.Drawing.Point(14, 77);
            this.gbUN.Name = "gbUN";
            this.gbUN.Size = new System.Drawing.Size(446, 236);
            this.gbUN.TabIndex = 6;
            this.gbUN.TabStop = false;
            this.gbUN.Text = "Nuevo Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre: ";
            // 
            // txtUserN
            // 
            this.txtUserN.Location = new System.Drawing.Point(157, 38);
            this.txtUserN.Name = "txtUserN";
            this.txtUserN.Size = new System.Drawing.Size(148, 26);
            this.txtUserN.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña: ";
            // 
            // txtContraN
            // 
            this.txtContraN.Location = new System.Drawing.Point(157, 77);
            this.txtContraN.Name = "txtContraN";
            this.txtContraN.Size = new System.Drawing.Size(148, 26);
            this.txtContraN.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAgregar.IconColor = System.Drawing.Color.Black;
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 25;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(277, 187);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(142, 32);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "agregar usuario";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnver
            // 
            this.btnver.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnver.IconColor = System.Drawing.Color.Black;
            this.btnver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnver.IconSize = 25;
            this.btnver.Location = new System.Drawing.Point(311, 77);
            this.btnver.Name = "btnver";
            this.btnver.Size = new System.Drawing.Size(33, 24);
            this.btnver.TabIndex = 11;
            this.btnver.UseVisualStyleBackColor = true;
            this.btnver.Click += new System.EventHandler(this.btnver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lbluid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.iconButton5);
            this.groupBox1.Controls.Add(this.btnNTarjeta);
            this.groupBox1.Controls.Add(this.txtNT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(848, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 236);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva tarjeta";
            // 
            // btnNTarjeta
            // 
            this.btnNTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNTarjeta.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnNTarjeta.IconColor = System.Drawing.Color.Black;
            this.btnNTarjeta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNTarjeta.IconSize = 25;
            this.btnNTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNTarjeta.Location = new System.Drawing.Point(277, 187);
            this.btnNTarjeta.Name = "btnNTarjeta";
            this.btnNTarjeta.Size = new System.Drawing.Size(142, 32);
            this.btnNTarjeta.TabIndex = 4;
            this.btnNTarjeta.Text = "agregar tarjeta";
            this.btnNTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNTarjeta.UseVisualStyleBackColor = true;
            // 
            // txtNT
            // 
            this.txtNT.Location = new System.Drawing.Point(145, 122);
            this.txtNT.Name = "txtNT";
            this.txtNT.Size = new System.Drawing.Size(148, 26);
            this.txtNT.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre: ";
            // 
            // iconButton5
            // 
            this.iconButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.XmarksLines;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 25;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(37, 25);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(102, 32);
            this.iconButton5.TabIndex = 5;
            this.iconButton5.Text = "Escaneo";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre: ";
            // 
            // lbluid
            // 
            this.lbluid.AutoSize = true;
            this.lbluid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluid.Location = new System.Drawing.Point(141, 75);
            this.lbluid.Name = "lbluid";
            this.lbluid.Size = new System.Drawing.Size(41, 20);
            this.lbluid.TabIndex = 7;
            this.lbluid.Text = "IUD";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 646);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelNuevos.ResumeLayout(false);
            this.gbUN.ResumeLayout(false);
            this.gbUN.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnNada;
        private System.Windows.Forms.Panel panelUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Panel panelNuevos;
        private System.Windows.Forms.GroupBox gbUN;
        private FontAwesome.Sharp.IconButton btnmostrarNT;
        private FontAwesome.Sharp.IconButton btnmostarNU;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private System.Windows.Forms.TextBox txtContraN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserN;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnver;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton btnNTarjeta;
        private System.Windows.Forms.TextBox txtNT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbluid;
        private System.Windows.Forms.Label label4;
    }
}