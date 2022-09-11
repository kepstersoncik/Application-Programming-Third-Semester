using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_S3AP_LW1E2
{
    internal class MainForm : Form
    {
        Label discription, discription1, discription2,
            apex_A_label, apex_B_label, apex_C_label,
            result_label;
        TextBox apex_A_x_tb, apex_A_y_tb,
            apex_B_x_tb, apex_B_y_tb,
            apex_C_x_tb, apex_C_y_tb;
        Button calc_button;

        private Label initLabel(int x, int y, int w, int h, string text)
        {
            Label label = new Label();
            label.Location = new Point(x, y);
            label.Size = new Size(w, h);
            label.Text = text;
            return label;
        }

        private TextBox initTextBox(int x, int y, int w, int h, string text = "")
        {
            TextBox text_box = new TextBox();
            text_box.Location = new Point(x, y);
            text_box.Size = new Size(w, h);
            text_box.Text = text;
            text_box.Leave += new EventHandler(text_box_Leave);
            return text_box;
        }

        public MainForm()
        {
            this.Size = new Size(385, 265);


            discription = initLabel(15, 15, 470, 30, "Программа производит расчет периметра треугольника.");
            this.Controls.Add(discription);

            discription1 = initLabel(165, 55, 90, 15, "Координата x");
            this.Controls.Add(discription1);

            discription2 = initLabel(260, 55, 90, 15, "Координата y");
            this.Controls.Add(discription2);

            apex_A_label = initLabel(15, 75, 145, 30, "Координаты вершины А");
            this.Controls.Add(apex_A_label);

            apex_A_x_tb = initTextBox(165, 75, 90, 30);
            this.Controls.Add(apex_A_x_tb);

            apex_A_y_tb = initTextBox(260, 75, 90, 30);
            this.Controls.Add(apex_A_y_tb);

            apex_B_label = initLabel(15, 110, 145, 30, "Координаты вершины B");
            this.Controls.Add(apex_B_label);

            apex_B_x_tb = initTextBox(165, 110, 90, 30);
            this.Controls.Add(apex_B_x_tb);

            apex_B_y_tb = initTextBox(260, 110, 90, 30);
            this.Controls.Add(apex_B_y_tb);

            apex_C_label = initLabel(15, 145, 145, 30, "Координаты вершины B");
            this.Controls.Add(apex_C_label);

            apex_C_x_tb = initTextBox(165, 145, 90, 30);
            this.Controls.Add(apex_C_x_tb);

            apex_C_y_tb = initTextBox(260, 145, 90, 30);
            this.Controls.Add(apex_C_y_tb);

            calc_button = new Button();
            calc_button.Location = new Point(15, 180);
            calc_button.Size = new Size(145, 30);
            calc_button.Text = "Заверение программы";
            calc_button.Click += new EventHandler(calc_button_Click);
            this.Controls.Add(calc_button);

            result_label = initLabel(165, 180, 180, 30, "");
            this.Controls.Add(result_label);

            this.Text = "Лабораторная работа № 1";
        }

        private void errorDisplay(string error)
        {
            result_label.Text = "Ошибка! " + error;
        }

        private void text_box_Leave(object sender, System.EventArgs e)
        {
                calcPerimetrNDisplay();
        }

        private double calcSide(double x1, double x2, double y1, double y2)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }

        private void calcPerimetrNDisplay()
        {
            double A_x = 0, A_y = 0, B_x = 0, B_y = 0, C_x = 0, C_y = 0;
            bool flag = true;
            try
            {
                A_x = Convert.ToDouble(apex_A_x_tb.Text);
            }
            catch (Exception)
            {
                if (apex_A_x_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_A_x_tb.Focus();
                    return;
                }
            }
            try
            {
                A_y = Convert.ToDouble(apex_A_y_tb.Text);
            }
            catch (Exception)
            {
                if (apex_A_y_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_A_y_tb.Focus();
                    return;
                }
            }
            try
            {
                B_x = Convert.ToDouble(apex_B_x_tb.Text);
            }
            catch (Exception)
            {
                if (apex_B_x_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_B_x_tb.Focus();
                    return;
                }
            }
            try
            {
                B_y = Convert.ToDouble(apex_B_y_tb.Text);
            }
            catch (Exception)
            {
                if (apex_B_y_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_B_y_tb.Focus();
                    return;
                }
            }
            try
            {
                C_x = Convert.ToDouble(apex_C_x_tb.Text);
            }
            catch (Exception)
            {
                if (apex_C_x_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_C_x_tb.Focus();
                    return;
                }
            }
            try {
                C_y = Convert.ToDouble(apex_C_y_tb.Text);
            }
            catch (Exception)
            {
                if (apex_C_y_tb.Text == "")
                {
                    errorDisplay("Не все поля заполнены!");
                    flag = false;
                }
                else
                {
                    errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                    apex_C_y_tb.Focus();
                    return;
                }
            }
            if (!flag) return;
            double AB = calcSide(A_x, B_x, A_y, B_y);
            double BC = calcSide(B_x, C_x, B_y, C_y);
            double CA = calcSide(C_x, A_x, C_y, A_y);
            if (AB + BC <= CA || AB + CA <= BC || BC + CA <= AB)
            {
                errorDisplay("Треугольник не существует!");
            }
            else
            {
                string result = string.Format("{0:0.00}", AB + BC + CA);
                result_label.Text = result;
            }
        }

        private void calc_button_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
