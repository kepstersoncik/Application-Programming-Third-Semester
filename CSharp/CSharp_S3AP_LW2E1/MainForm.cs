namespace CSharp_S3AP_LW2E1;

public partial class MainForm : Form
{
    TextBox x_input;
    Button calc_button;
    Label output_label;
    Label discription_label;

    GroupBox rbuttons_group;
    RadioButton first_rbutton;
    RadioButton second_rbutton;
    RadioButton third_rbutton;

    CheckBox double_checkbox;

    private RadioButton _initRButton(int x, int y, int w, int h, string text){
        RadioButton rbutton = new RadioButton();
        rbutton.Location = new Point(x, y);
        rbutton.Size = new Size(w, h);
        rbutton.Text = text;
        rbutton.CheckedChanged += new EventHandler(calc_button_Click);
        return rbutton;
    }

    public MainForm()
    {
        this.Size = new Size(320, 150);
        this.Text = "Лабораторная работа № 2";

        discription_label = new Label();
        discription_label.Location = new Point(15, 15);
        discription_label.Size = new Size(80, 20);
        discription_label.Text = "Значение x:";
        this.Controls.Add(discription_label);

        x_input = new TextBox();
        x_input.Location = new Point(95, 15);
        x_input.Size = new Size(50, 20);
        this.Controls.Add(x_input);

        calc_button = new Button();
        calc_button.Location = new Point(15, 40);
        calc_button.Size = new Size(130, 30);
        calc_button.Text = "Вычислить";
        calc_button.Click += new EventHandler(calc_button_Click);
        this.Controls.Add(calc_button);

        output_label = new Label();
        output_label.Location = new Point(15, 75);
        output_label.Size = new Size(120, 30);
        this.Controls.Add(output_label);

        rbuttons_group = new GroupBox();
        first_rbutton = _initRButton(150, 15, 120, 20, "sin(x)+cos(x)");
        second_rbutton = _initRButton(150, 35, 120, 20, "tg(x)");
        third_rbutton = _initRButton(150, 55, 120, 20, "x^3");
        this.Controls.Add(first_rbutton);
        this.Controls.Add(second_rbutton);
        this.Controls.Add(third_rbutton);

        double_checkbox = new CheckBox();
        double_checkbox.Location = new Point(150, 80);
        double_checkbox.Size = new Size(120, 20);
        double_checkbox.Text = "Удвоить";
        double_checkbox.CheckedChanged += new EventHandler(calc_button_Click);
        this.Controls.Add(double_checkbox);
    }

    private double myPow(double x, int n){
        if (n == 0) { return 1.0; }
        if (n % 2 != 0) { return myPow(x, n-1) * x; }
        double y = myPow(x, n/2);
        return y * y;
    }

    private void printError(string text){
        output_label.Text = "Ошибка! " + text;
    }

    private void printResult(double x){
        if (double_checkbox.Checked) { x *= 2; }
        output_label.Text = string.Format("Результат: {0:0.00}", x);
    }

    private int getActionNumber(){
        if (first_rbutton.Checked){ return 1; }
        else if (second_rbutton.Checked){ return 2; }
        else if (third_rbutton.Checked){ return 3; }
        return 4;
    }

    private double calcXwithParam(double x){
        if (x <= 0) { x = x * (Math.PI / 180); first_rbutton.Checked = true; return Math.Sin(x) + Math.Cos(x); }
        else if (0 < x && x < 1) { x = x * (Math.PI / 180); second_rbutton.Checked = true; return Math.Tan(x); }
        third_rbutton.Checked = true; return myPow(x, 3);
    }

    private void getXandCalc(){
        double x;
        try{
            x = double.Parse(x_input.Text);
        }
        catch (Exception){
            printError("Не удается получить данные!");
            return;
        }
        switch (getActionNumber()){
            case 1: x = x * (Math.PI / 180); printResult(Math.Sin(x) + Math.Cos(x)); break;
            case 2: x = x * (Math.PI / 180); printResult(Math.Tan(x)); break;
            case 3: printResult(myPow(x, 3)); break;
            case 4: printResult(calcXwithParam(x)); break;
        }
    }

    private void calc_button_Click(object sender, System.EventArgs e){
        getXandCalc();
    }
}
