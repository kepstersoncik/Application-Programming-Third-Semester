namespace CSharp_S3AP_LW1E1
{
    partial class MainForm
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
            this.description = new System.Windows.Forms.Label();
            this.apex_A_label = new System.Windows.Forms.Label();
            this.apex_B_label = new System.Windows.Forms.Label();
            this.apex_C_label = new System.Windows.Forms.Label();
            this.apex_A_x_tb = new System.Windows.Forms.TextBox();
            this.apex_A_y_tb = new System.Windows.Forms.TextBox();
            this.apex_B_x_tb = new System.Windows.Forms.TextBox();
            this.apex_B_y_tb = new System.Windows.Forms.TextBox();
            this.apex_C_x_tb = new System.Windows.Forms.TextBox();
            this.apex_C_y_tb = new System.Windows.Forms.TextBox();
            this.description1 = new System.Windows.Forms.Label();
            this.description2 = new System.Windows.Forms.Label();
            this.calc_button = new System.Windows.Forms.Button();
            this.result_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(13, 13);
            this.description.MaximumSize = new System.Drawing.Size(320, 30);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(304, 26);
            this.description.TabIndex = 0;
            this.description.Text = "Программа производит расчет периметра треугольника.  Для расчета требуется ввести" +
    " координаты вершин.";
            // 
            // apex_A_label
            // 
            this.apex_A_label.AutoSize = true;
            this.apex_A_label.Location = new System.Drawing.Point(16, 69);
            this.apex_A_label.Name = "apex_A_label";
            this.apex_A_label.Size = new System.Drawing.Size(62, 13);
            this.apex_A_label.TabIndex = 1;
            this.apex_A_label.Text = "Вершина A";
            // 
            // apex_B_label
            // 
            this.apex_B_label.AutoSize = true;
            this.apex_B_label.Location = new System.Drawing.Point(16, 96);
            this.apex_B_label.Name = "apex_B_label";
            this.apex_B_label.Size = new System.Drawing.Size(62, 13);
            this.apex_B_label.TabIndex = 2;
            this.apex_B_label.Text = "Вершина B";
            // 
            // apex_C_label
            // 
            this.apex_C_label.AutoSize = true;
            this.apex_C_label.Location = new System.Drawing.Point(16, 124);
            this.apex_C_label.Name = "apex_C_label";
            this.apex_C_label.Size = new System.Drawing.Size(62, 13);
            this.apex_C_label.TabIndex = 3;
            this.apex_C_label.Text = "Вершина C";
            // 
            // apex_A_x_tb
            // 
            this.apex_A_x_tb.Location = new System.Drawing.Point(85, 69);
            this.apex_A_x_tb.Name = "apex_A_x_tb";
            this.apex_A_x_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_A_x_tb.TabIndex = 4;
            // 
            // apex_A_y_tb
            // 
            this.apex_A_y_tb.Location = new System.Drawing.Point(191, 69);
            this.apex_A_y_tb.Name = "apex_A_y_tb";
            this.apex_A_y_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_A_y_tb.TabIndex = 5;
            // 
            // apex_B_x_tb
            // 
            this.apex_B_x_tb.Location = new System.Drawing.Point(85, 93);
            this.apex_B_x_tb.Name = "apex_B_x_tb";
            this.apex_B_x_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_B_x_tb.TabIndex = 6;
            // 
            // apex_B_y_tb
            // 
            this.apex_B_y_tb.Location = new System.Drawing.Point(191, 93);
            this.apex_B_y_tb.Name = "apex_B_y_tb";
            this.apex_B_y_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_B_y_tb.TabIndex = 7;
            // 
            // apex_C_x_tb
            // 
            this.apex_C_x_tb.Location = new System.Drawing.Point(84, 119);
            this.apex_C_x_tb.Name = "apex_C_x_tb";
            this.apex_C_x_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_C_x_tb.TabIndex = 8;
            // 
            // apex_C_y_tb
            // 
            this.apex_C_y_tb.Location = new System.Drawing.Point(190, 119);
            this.apex_C_y_tb.Name = "apex_C_y_tb";
            this.apex_C_y_tb.Size = new System.Drawing.Size(100, 20);
            this.apex_C_y_tb.TabIndex = 9;
            // 
            // description1
            // 
            this.description1.AutoSize = true;
            this.description1.Location = new System.Drawing.Point(85, 50);
            this.description1.Name = "description1";
            this.description1.Size = new System.Drawing.Size(75, 13);
            this.description1.TabIndex = 10;
            this.description1.Text = "Координата x";
            // 
            // description2
            // 
            this.description2.AutoSize = true;
            this.description2.Location = new System.Drawing.Point(188, 50);
            this.description2.Name = "description2";
            this.description2.Size = new System.Drawing.Size(75, 13);
            this.description2.TabIndex = 11;
            this.description2.Text = "Координата y";
            // 
            // calc_button
            // 
            this.calc_button.Location = new System.Drawing.Point(19, 153);
            this.calc_button.Name = "calc_button";
            this.calc_button.Size = new System.Drawing.Size(117, 23);
            this.calc_button.TabIndex = 12;
            this.calc_button.Text = "Произвести расчет";
            this.calc_button.UseVisualStyleBackColor = true;
            this.calc_button.Click += new System.EventHandler(this.calc_button_Click);
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(142, 158);
            this.result_label.MaximumSize = new System.Drawing.Size(170, 60);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(0, 13);
            this.result_label.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 210);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.calc_button);
            this.Controls.Add(this.description2);
            this.Controls.Add(this.description1);
            this.Controls.Add(this.apex_C_y_tb);
            this.Controls.Add(this.apex_C_x_tb);
            this.Controls.Add(this.apex_B_y_tb);
            this.Controls.Add(this.apex_B_x_tb);
            this.Controls.Add(this.apex_A_y_tb);
            this.Controls.Add(this.apex_A_x_tb);
            this.Controls.Add(this.apex_C_label);
            this.Controls.Add(this.apex_B_label);
            this.Controls.Add(this.apex_A_label);
            this.Controls.Add(this.description);
            this.Name = "MainForm";
            this.Text = "Лабораторная работа № 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label apex_A_label;
        private System.Windows.Forms.Label apex_B_label;
        private System.Windows.Forms.Label apex_C_label;
        private System.Windows.Forms.TextBox apex_A_x_tb;
        private System.Windows.Forms.TextBox apex_A_y_tb;
        private System.Windows.Forms.TextBox apex_B_x_tb;
        private System.Windows.Forms.TextBox apex_B_y_tb;
        private System.Windows.Forms.TextBox apex_C_x_tb;
        private System.Windows.Forms.TextBox apex_C_y_tb;
        private System.Windows.Forms.Label description1;
        private System.Windows.Forms.Label description2;
        private System.Windows.Forms.Button calc_button;
        private System.Windows.Forms.Label result_label;
    }
}

