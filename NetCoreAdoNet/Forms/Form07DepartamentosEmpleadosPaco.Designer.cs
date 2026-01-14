namespace NetCoreAdoNet.Forms
{
    partial class Form07DepartamentosEmpleadosPaco
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
            label4 = new Label();
            label3 = new Label();
            btnEliminar = new Button();
            lstEmpleados = new ListBox();
            lstDepartamentos = new ListBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 211);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 13;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 211);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 12;
            label3.Text = "label3";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(301, 62);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(175, 48);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(120, 139);
            lstEmpleados.TabIndex = 10;
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(33, 48);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(120, 139);
            lstDepartamentos.TabIndex = 9;
            lstDepartamentos.SelectedIndexChanged += lstDepartamentos_SelectedIndexChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 27);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 8;
            label2.Text = "Empleados";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 27);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 7;
            label1.Text = "Departamentos";
            // 
            // Form07DepartamentosEmpleadosPaco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnEliminar);
            Controls.Add(lstEmpleados);
            Controls.Add(lstDepartamentos);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form07DepartamentosEmpleadosPaco";
            Text = "Form07DepartamentosEmpleadosPaco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button btnEliminar;
        private ListBox lstEmpleados;
        private ListBox lstDepartamentos;
        private Label label2;
        private Label label1;
    }
}