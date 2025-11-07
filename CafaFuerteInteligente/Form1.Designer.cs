namespace CafaFuerteInteligente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnver = new FontAwesome.Sharp.IconButton();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContra = new System.Windows.Forms.MaskedTextBox();
            this.txtUsuario = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnver);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtContra);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Location = new System.Drawing.Point(183, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 404);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(63, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "Registrarse";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnver
            // 
            this.btnver.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btnver.IconColor = System.Drawing.Color.Black;
            this.btnver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnver.IconSize = 25;
            this.btnver.Location = new System.Drawing.Point(303, 183);
            this.btnver.Name = "btnver";
            this.btnver.Size = new System.Drawing.Size(33, 24);
            this.btnver.TabIndex = 10;
            this.btnver.UseVisualStyleBackColor = true;
            this.btnver.Click += new System.EventHandler(this.btnver_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(193, 269);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(113, 36);
            this.btnIniciar.TabIndex = 9;
            this.btnIniciar.Text = "Iniciar ";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contraseña: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario: ";
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(182, 186);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(115, 20);
            this.txtContra.TabIndex = 4;
            this.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(182, 108);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(115, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(17, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 44);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(74, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio de sesion";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.iconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(17, 90);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(333, 54);
            this.iconButton1.TabIndex = 5;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 30;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(17, 168);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(333, 54);
            this.iconButton2.TabIndex = 7;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(38)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(733, 428);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Iniciar Sesion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtUsuario;
        private System.Windows.Forms.MaskedTextBox txtContra;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton btnver;
        private System.Windows.Forms.Button button1;
    }
}

