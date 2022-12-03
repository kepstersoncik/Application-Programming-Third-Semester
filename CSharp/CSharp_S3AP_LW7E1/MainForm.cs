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

    TableLayoutPanel panel;


    CheckBox double_checkbox;

    private RadioButton _initRButton(string text){
        RadioButton rbutton = new RadioButton();
        rbutton.Text = text;
        rbutton.CheckedChanged += new EventHandler(calc_button_Click);
        return rbutton;
    }

    public MainForm()
    {
        this.Size = new Size(320, 150);
        this.MinimumSize = new Size(320, 150);
        this.Text = "Лабораторная работа № 2";

        panel = new TableLayoutPanel();
        panel.Dock = DockStyle.Fill;
        panel.AutoSize = true;
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        panel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 100F));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 100F));

        this.Controls.Add(panel);


        discription_label = new Label();
        discription_label.Text = "Значение x:";
        discription_label.Dock = DockStyle.Right;
        discription_label.Anchor = AnchorStyles.Right;      
        panel.Controls.Add(discription_label, 0, 0);

        x_input = new TextBox();
        x_input.Size = new Size(50, 20);
        x_input.Dock = DockStyle.Fill;
        x_input.Anchor = AnchorStyles.Left;
        panel.Controls.Add(x_input, 1, 0);

        calc_button = new Button();
        calc_button.Size = new Size(130, 30);
        calc_button.Text = "Вычислить";
        calc_button.Click += new EventHandler(calc_button_Click);
        calc_button.Dock = DockStyle.Fill;
        panel.Controls.Add(calc_button, 0, 1);

        output_label = new Label();
        output_label.Size = new Size(120, 30);
        output_label.Dock = DockStyle.Fill;
        panel.Controls.Add(output_label, 1, 1);

        rbuttons_group = new GroupBox();
        first_rbutton = _initRButton("sin(x)+cos(x)");
        second_rbutton = _initRButton("tg(x)");
        third_rbutton = _initRButton("x^3");
        first_rbutton.Dock = DockStyle.Fill;
        second_rbutton.Dock = DockStyle.Fill;
        third_rbutton.Dock = DockStyle.Fill;
        panel.Controls.Add(first_rbutton, 2, 0);
        panel.Controls.Add(second_rbutton, 2, 1);
        panel.Controls.Add(third_rbutton, 2, 2);

        double_checkbox = new CheckBox();
        double_checkbox.Text = "Удвоить";
        double_checkbox.CheckedChanged += new EventHandler(calc_button_Click);
        double_checkbox.Dock = DockStyle.Fill;
        panel.Controls.Add(double_checkbox, 2, 3);
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
