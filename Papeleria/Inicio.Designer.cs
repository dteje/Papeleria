﻿namespace Papeleria
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
            this.btn_anyadir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_anyadir
            // 
            this.btn_anyadir.Location = new System.Drawing.Point(137, 12);
            this.btn_anyadir.Name = "btn_anyadir";
            this.btn_anyadir.Size = new System.Drawing.Size(451, 127);
            this.btn_anyadir.TabIndex = 0;
            this.btn_anyadir.Text = "Añadir libro de texto";
            this.btn_anyadir.UseVisualStyleBackColor = true;
            this.btn_anyadir.Click += new System.EventHandler(this.btn_anyadir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(451, 127);
            this.button1.TabIndex = 1;
            this.button1.Text = "Añadir libro de lectura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_anyadir);
            this.Name = "Inicio";
            this.Text = "Papelería Maribel - Gestión web";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_anyadir;
        private System.Windows.Forms.Button button1;
    }
}

