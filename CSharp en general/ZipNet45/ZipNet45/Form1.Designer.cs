namespace ZipNet45
{
    partial class Form1
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
            this.btVerContenido = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btAgregarArchivo = new System.Windows.Forms.Button();
            this.btExtraerTodo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btVerContenido
            // 
            this.btVerContenido.Location = new System.Drawing.Point(11, 12);
            this.btVerContenido.Name = "btVerContenido";
            this.btVerContenido.Size = new System.Drawing.Size(135, 23);
            this.btVerContenido.TabIndex = 0;
            this.btVerContenido.Text = "Ver Contenido";
            this.btVerContenido.UseVisualStyleBackColor = true;
            this.btVerContenido.Click += new System.EventHandler(this.BtVerContenidoClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(259, 129);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btAgregarArchivo
            // 
            this.btAgregarArchivo.Location = new System.Drawing.Point(12, 176);
            this.btAgregarArchivo.Name = "btAgregarArchivo";
            this.btAgregarArchivo.Size = new System.Drawing.Size(123, 23);
            this.btAgregarArchivo.TabIndex = 2;
            this.btAgregarArchivo.Text = "Agregar Archivo";
            this.btAgregarArchivo.UseVisualStyleBackColor = true;
            this.btAgregarArchivo.Click += new System.EventHandler(this.BtAgregarArchivoClick);
            // 
            // btExtraerTodo
            // 
            this.btExtraerTodo.Location = new System.Drawing.Point(12, 205);
            this.btExtraerTodo.Name = "btExtraerTodo";
            this.btExtraerTodo.Size = new System.Drawing.Size(123, 23);
            this.btExtraerTodo.TabIndex = 3;
            this.btExtraerTodo.Text = "Extrater Todo";
            this.btExtraerTodo.UseVisualStyleBackColor = true;
            this.btExtraerTodo.Click += new System.EventHandler(this.BtExtraerTodoClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 279);
            this.Controls.Add(this.btExtraerTodo);
            this.Controls.Add(this.btAgregarArchivo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btVerContenido);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btVerContenido;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btAgregarArchivo;
        private System.Windows.Forms.Button btExtraerTodo;
    }
}

