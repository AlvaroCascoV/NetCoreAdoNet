namespace NetCoreAdoNet.Forms
{
    partial class Form13ParametrosSalida
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
            label1 = new Label();
            cmbDepartamentos = new ComboBox();
            lstEmpleados = new ListBox();
            label2 = new Label();
            btnMostrarDatos = new Button();
            label3 = new Label();
            txtSumaSalarial = new TextBox();
            txtMediaSalarial = new TextBox();
            label4 = new Label();
            txtPersonas = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 27);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Departamentos";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(42, 45);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(121, 23);
            cmbDepartamentos.TabIndex = 1;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(196, 45);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(208, 274);
            lstEmpleados.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(196, 27);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Empleados";
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(42, 74);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(121, 42);
            btnMostrarDatos.TabIndex = 4;
            btnMostrarDatos.Text = "Mostrar Datos";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += this.btnMostrarDatos_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 128);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Suma salarial";
            // 
            // txtSumaSalarial
            // 
            txtSumaSalarial.Location = new Point(42, 148);
            txtSumaSalarial.Name = "txtSumaSalarial";
            txtSumaSalarial.Size = new Size(118, 23);
            txtSumaSalarial.TabIndex = 6;
            // 
            // txtMediaSalarial
            // 
            txtMediaSalarial.Location = new Point(42, 198);
            txtMediaSalarial.Name = "txtMediaSalarial";
            txtMediaSalarial.Size = new Size(118, 23);
            txtMediaSalarial.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 178);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 7;
            label4.Text = "Media salarial";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(45, 250);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(118, 23);
            txtPersonas.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 230);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 9;
            label5.Text = "Personas";
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPersonas);
            Controls.Add(label5);
            Controls.Add(txtMediaSalarial);
            Controls.Add(label4);
            Controls.Add(txtSumaSalarial);
            Controls.Add(label3);
            Controls.Add(btnMostrarDatos);
            Controls.Add(label2);
            Controls.Add(lstEmpleados);
            Controls.Add(cmbDepartamentos);
            Controls.Add(label1);
            Name = "Form13ParametrosSalida";
            Text = "From13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbDepartamentos;
        private ListBox lstEmpleados;
        private Label label2;
        private Button btnMostrarDatos;
        private Label label3;
        private TextBox txtSumaSalarial;
        private TextBox txtMediaSalarial;
        private Label label4;
        private TextBox txtPersonas;
        private Label label5;
    }
}