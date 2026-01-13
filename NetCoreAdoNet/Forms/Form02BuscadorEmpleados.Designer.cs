namespace NetCoreAdoNet.Forms
{
    partial class Form02BuscadorEmpleados
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
            txtSalario = new TextBox();
            btnBuscar = new Button();
            label2 = new Label();
            lstEmpleados = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "Introduzca Salario:";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(16, 34);
            txtSalario.Name = "txtSalario";
            txtSalario.PlaceholderText = "0";
            txtSalario.Size = new Size(113, 23);
            txtSalario.TabIndex = 1;
            txtSalario.Text = "0";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(12, 63);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(117, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar Empleados";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 3;
            label2.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(12, 121);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(156, 229);
            lstEmpleados.TabIndex = 4;
            // 
            // Form02BuscadorEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstEmpleados);
            Controls.Add(label2);
            Controls.Add(btnBuscar);
            Controls.Add(txtSalario);
            Controls.Add(label1);
            Name = "Form02BuscadorEmpleados";
            Text = "Form02BuscadorEmpleados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSalario;
        private Button btnBuscar;
        private Label label2;
        private ListBox lstEmpleados;
    }
}