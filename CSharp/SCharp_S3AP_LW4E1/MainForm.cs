namespace SCharp_S3AP_LW4E1;

public partial class MainForm : Form
{
    Label table_x_label;
    DataGridView table_x;

    Label table_y_label;
    DataGridView table_y;
    Button claculate_y;

    Label table_x_size_label;
    TextBox table_x_size_textbox;
    Button table_x_size_button;

    Label table_x_change_label;
    TextBox table_x_change_textbox;
    Button table_x_change_button;

    DataGridViewCell selected;

    int N;
    public MainForm()
    {
        N = -1;

        this.Size = new Size(705, 465);
        this.Text = "Лабораторная работа № 4";

        table_x_label = new Label();
        table_x_label.Text = "Таблица X";
        table_x_label.Location = new Point(15, 15);
        table_x_label.Size = new Size(80, 25);
        this.Controls.Add(table_x_label);

        table_x = new DataGridView();
        table_x.Location = new Point(15, 40);
        table_x.Size = new Size(320, 305);
        table_x.ColumnHeadersVisible = false;
        table_x.RowHeadersVisible = false;
        table_x.SelectionMode = DataGridViewSelectionMode.CellSelect;
        table_x.CellClick += table_x_CellClick;
        this.Controls.Add(table_x);


        table_y_label = new Label();
        table_y_label.Text = "Таблица Y";
        table_y_label.Location = new Point(355, 15);
        table_y_label.Size = new Size(80, 25);
        this.Controls.Add(table_y_label);

        table_y = new DataGridView();
        table_y.Location = new Point(355, 40);
        table_y.Size = new Size(320, 305);
        table_y.ColumnHeadersVisible = false;
        table_y.RowHeadersVisible = false;
        this.Controls.Add(table_y);

        claculate_y = new Button();
        claculate_y.Text = "Вычислить Y";
        claculate_y.Location = new Point(355, 355);
        claculate_y.Size = new Size(80, 25);
        claculate_y.Click += claculate_y_Click;
        this.Controls.Add(claculate_y);


        table_x_size_label = new Label();
        table_x_size_label.Text = "Размеры N для таблицы X:";
        table_x_size_label.Location = new Point(15, 355);
        table_x_size_label.Size = new Size(155, 20);
        this.Controls.Add(table_x_size_label);

        table_x_size_textbox = new TextBox();
        table_x_size_textbox.Text = "15";
        table_x_size_textbox.Location = new Point(170, 355);
        table_x_size_textbox.Size = new Size(40, 20);
        this.Controls.Add(table_x_size_textbox);

        table_x_size_button = new Button();
        table_x_size_button.Text = "Установить размер";
        table_x_size_button.Location = new Point(215, 355);
        table_x_size_button.Size = new Size(120, 25);
        table_x_size_button.Click += table_x_size_button_Click;
        this.Controls.Add(table_x_size_button);


        table_x_change_label = new Label();
        table_x_change_label.Text = "Выбранная ячейка таблицы X:";
        table_x_change_label.Location = new Point(15, 380);
        table_x_change_label.Size = new Size(175, 25);
        this.Controls.Add(table_x_change_label);

        table_x_change_textbox = new TextBox();
        table_x_change_textbox.Location = new Point(190, 380);
        table_x_change_textbox.Size = new Size(40, 25);
        this.Controls.Add(table_x_change_textbox);

        table_x_change_button = new Button();
        table_x_change_button.Text = "Заменить";
        table_x_change_button.Location = new Point(235, 380);
        table_x_change_button.Size = new Size(80, 25);
        table_x_change_button.Click += table_x_change_button_Click;
        this.Controls.Add(table_x_change_button);
    }

    private void _initX(){
        table_x.RowCount = N;
        table_x.ColumnCount = N;
        table_x.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        table_x.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        table_y.RowCount = N;
        table_y.ColumnCount = N;
        table_y.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        table_y.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        for (int i = 0; i < table_x.ColumnCount; i++){
            for (int j = 0; j < table_x.RowCount; j++){
                if (i+1 == j){table_x[i,j].Value = N;}
                else if (i == j && (i % 2 == 0)){table_x[i,j].Value = 1;}
                else if (i == j && !(i % 2 == 0)){table_x[i, j].Value = N;}
                else {table_x[i,j].Value = 0;}
            }
        }
    }

    private void table_x_size_button_Click(object sender, EventArgs e){
        int temp = -1;
        bool parse_flag;
        parse_flag = int.TryParse(table_x_size_textbox.Text, out temp);
        if (temp <= 0 || !parse_flag){
            string message = "Невозможный размер таблицы";
            string title = "Ошибка размера таблицы";
            MessageBoxButtons ok_button = MessageBoxButtons.OK;
            MessageBox.Show(message, title, ok_button);
            return;
        }
        N = temp;
        _initX();
    }

    private void table_x_CellClick(object sender, DataGridViewCellEventArgs e){
        selected = table_x.CurrentCell;
        table_x_change_textbox.Text = selected.Value.ToString();
    }

    private void table_x_change_button_Click(object sender, EventArgs e){
        int temp;
        bool parse_flag;
        parse_flag = int.TryParse(table_x_change_textbox.Text, out temp);
        if (!parse_flag){
            string message = "Неподходящее значение таблицы";
            string title = "Ошибка замены значения";
            MessageBoxButtons ok_button = MessageBoxButtons.OK;
            MessageBox.Show(message, title, ok_button);
            return;
        }
        selected.Value = temp;
    }

    private void claculate_y_Click(object sender, EventArgs e){
        for (int i = 0; i < table_x.ColumnCount; i++){
            for (int j = 0; j < table_x.RowCount; j++){
                try{
                    string temp = table_x[i,j].Value.ToString();
                    table_y[i,j].Value = int.Parse(temp) + i;
                }
                catch{
                    continue;
                }
            }
        }
    }
}
