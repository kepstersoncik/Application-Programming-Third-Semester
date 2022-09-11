using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_S3AP_LW1E1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void errorDisplay(string error)
        {
            result_label.Text = "Ошибка! " + error;
        }

        private double calcSide(double x1, double x2, double y1, double y2)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }

        private void calcPerimetrNDisplay()
        {
            double A_x, A_y, B_x, B_y, C_x, C_y;
            try
            {
                A_x = Convert.ToDouble(apex_A_x_tb.Text);
                A_y = Convert.ToDouble(apex_A_y_tb.Text);
                B_x = Convert.ToDouble(apex_B_x_tb.Text);
                B_y = Convert.ToDouble(apex_B_y_tb.Text);
                C_x = Convert.ToDouble(apex_C_x_tb.Text);
                C_y = Convert.ToDouble(apex_C_y_tb.Text);
            }
            catch (Exception e)
            {
                errorDisplay("Не удалось корректно получить данные! Проверьте правильность ввода!");
                return;
            }

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

        private void calc_button_Click(object sender, EventArgs e)
        {
            calcPerimetrNDisplay();
        }
    }
}
