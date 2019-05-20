namespace Papeleria
{
    partial class AnyadirLibro
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
            this.label15 = new System.Windows.Forms.Label();
            this.cb_editorial = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_curso = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_idioma = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_imagenes = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtxt_descripcion = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_anyadirImagen = new System.Windows.Forms.Button();
            this.tv_categories = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(430, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Editorial";
            // 
            // cb_editorial
            // 
            this.cb_editorial.FormattingEnabled = true;
            this.cb_editorial.Location = new System.Drawing.Point(386, 103);
            this.cb_editorial.MaxDropDownItems = 5;
            this.cb_editorial.Name = "cb_editorial";
            this.cb_editorial.Size = new System.Drawing.Size(134, 21);
            this.cb_editorial.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(565, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "ISBN";
            // 
            // txt_isbn
            // 
            this.txt_isbn.Location = new System.Drawing.Point(603, 50);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(119, 20);
            this.txt_isbn.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(644, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Curso";
            // 
            // cb_curso
            // 
            this.cb_curso.FormattingEnabled = true;
            this.cb_curso.Location = new System.Drawing.Point(627, 103);
            this.cb_curso.Name = "cb_curso";
            this.cb_curso.Size = new System.Drawing.Size(95, 21);
            this.cb_curso.TabIndex = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(531, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Idioma";
            // 
            // cb_idioma
            // 
            this.cb_idioma.FormattingEnabled = true;
            this.cb_idioma.Location = new System.Drawing.Point(526, 103);
            this.cb_idioma.Name = "cb_idioma";
            this.cb_idioma.Size = new System.Drawing.Size(95, 21);
            this.cb_idioma.Sorted = true;
            this.cb_idioma.TabIndex = 60;
            this.cb_idioma.SelectedIndexChanged += new System.EventHandler(this.cb_idioma_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Estado";
            // 
            // cb_estado
            // 
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Location = new System.Drawing.Point(251, 103);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(129, 21);
            this.cb_estado.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(457, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Imágenes";
            // 
            // lb_imagenes
            // 
            this.lb_imagenes.FormattingEnabled = true;
            this.lb_imagenes.Location = new System.Drawing.Point(251, 302);
            this.lb_imagenes.Name = "lb_imagenes";
            this.lb_imagenes.Size = new System.Drawing.Size(390, 56);
            this.lb_imagenes.TabIndex = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Descripción";
            // 
            // rtxt_descripcion
            // 
            this.rtxt_descripcion.Location = new System.Drawing.Point(251, 157);
            this.rtxt_descripcion.Name = "rtxt_descripcion";
            this.rtxt_descripcion.Size = new System.Drawing.Size(471, 99);
            this.rtxt_descripcion.TabIndex = 80;
            this.rtxt_descripcion.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Categorías";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 38);
            this.button1.TabIndex = 100;
            this.button1.Text = "Añadir producto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_add_product);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Cantidad";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(312, 48);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(31, 20);
            this.txt_cantidad.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Precio";
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(412, 50);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(71, 20);
            this.txt_precio.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(77, 12);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(645, 20);
            this.txt_nombre.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(590, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 28);
            this.button2.TabIndex = 120;
            this.button2.Text = "Fake data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_fakedata);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(647, 335);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 190;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_del_img);
            // 
            // btn_anyadirImagen
            // 
            this.btn_anyadirImagen.Location = new System.Drawing.Point(647, 302);
            this.btn_anyadirImagen.Name = "btn_anyadirImagen";
            this.btn_anyadirImagen.Size = new System.Drawing.Size(75, 23);
            this.btn_anyadirImagen.TabIndex = 90;
            this.btn_anyadirImagen.Text = "Añadir";
            this.btn_anyadirImagen.UseVisualStyleBackColor = true;
            this.btn_anyadirImagen.Click += new System.EventHandler(this.btn_add_img);
            // 
            // tv_categories
            // 
            this.tv_categories.Location = new System.Drawing.Point(30, 64);
            this.tv_categories.Name = "tv_categories";
            this.tv_categories.Size = new System.Drawing.Size(180, 294);
            this.tv_categories.TabIndex = 110;
            // 
            // AnyadirLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 424);
            this.Controls.Add(this.tv_categories);
            this.Controls.Add(this.btn_anyadirImagen);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_imagenes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtxt_descripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cb_editorial);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_isbn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_curso);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_idioma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_estado);
            this.Name = "AnyadirLibro";
            this.Text = "Añadir libro a la base de datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cb_editorial;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_curso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_idioma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lb_imagenes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtxt_descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_anyadirImagen;
        private System.Windows.Forms.TreeView tv_categories;
    }
}