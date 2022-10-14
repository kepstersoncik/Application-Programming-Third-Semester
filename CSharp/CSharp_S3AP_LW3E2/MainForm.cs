namespace CSharp_S3AP_LW3E2;

public partial class MainForm : Form
{
    XYArrays arrays;

    MenuStrip menu_bar;

    ToolStripMenuItem file_menu;
    ToolStripMenuItem create_new;
    ToolStripMenuItem load;
    ToolStripMenuItem save;
    ToolStripMenuItem exit;

    ToolStripMenuItem operation_menu;
    ToolStripMenuItem calculate;

    Label x_label;
    ListBox x_list;

    Label y_label;
    ComboBox y_combobox;

    TextBox x_textbox;
    Button x_change;

    TextBox y_textbox;
    Button y_change;

    int selected_x;
    int selected_y;

    public MainForm()
    {
        this.Size = new Size(300, 355);
        this.Text = "Работа № 2";

        arrays = new XYArrays();

        menu_bar = new MenuStrip();
        file_menu = new ToolStripMenuItem("Файл");
        create_new = new ToolStripMenuItem("Создать");
        create_new.Click += create_new_Click;
        file_menu.DropDownItems.Add(create_new);
        load = new ToolStripMenuItem("Загрузить");
        load.Click += load_Click;
        file_menu.DropDownItems.Add(load);
        save = new ToolStripMenuItem("Сохранить");
        save.Click += save_Click;
        file_menu.DropDownItems.Add(save);
        exit = new ToolStripMenuItem("Выход");
        exit.Click += exit_Click;
        file_menu.DropDownItems.Add(exit);
        menu_bar.Items.Add(file_menu);

        operation_menu = new ToolStripMenuItem("Работа");
        calculate = new ToolStripMenuItem("Вычислить");
        calculate.Click += calculate_Click;
        operation_menu.DropDownItems.Add(calculate);
        menu_bar.Items.Add(operation_menu);

        this.Controls.Add(menu_bar);

        x_label = new Label();
        x_label.Text = "Массив X";
        x_label.Location = new Point(15, 25);
        x_label.Size = new Size(120, 20);
        this.Controls.Add(x_label);

        x_list = new ListBox();
        x_list.Location = new Point(15, 45);
        x_list.Size = new Size(120, 200);
        x_list.SelectedIndexChanged += x_list_SelectedIndexChanged;
        this.Controls.Add(x_list);

        y_label = new Label();
        y_label.Text = "Массив y";
        y_label.Location = new Point(150, 25);
        y_label.Size = new Size(120, 20);
        this.Controls.Add(y_label);

        y_combobox = new ComboBox();
        y_combobox.Location = new Point(150, 45);
        y_combobox.Size = new Size(120, 20);
        y_combobox.SelectedIndexChanged += y_combobox_SelectedIndexChanged;
        this.Controls.Add(y_combobox);

        x_textbox = new TextBox();
        x_textbox.Location = new Point(15, 250);
        x_textbox.Size = new Size(120, 20);
        this.Controls.Add(x_textbox);

        x_change = new Button();
        x_change.Text = "Изменить X";
        x_change.Location = new Point(15, 275);
        x_change.Size = new Size(120, 25);
        x_change.Click += x_change_Click;
        this.Controls.Add(x_change);

        y_textbox = new TextBox();
        y_textbox.Location = new Point(150, 250);
        y_textbox.Size = new Size(120, 20);
        this.Controls.Add(y_textbox);

        y_change = new Button();
        y_change.Text = "Изменить Y";
        y_change.Location = new Point(150, 275);
        y_change.Size = new Size(120, 25);
        y_change.Click += y_change_Click;
        this.Controls.Add(y_change);
    }

    void x_list_SelectedIndexChanged(object sender, EventArgs e){
        selected_x = x_list.SelectedIndex;
        x_textbox.Text = x_list.Items[selected_x].ToString();
    }

    void x_change_Click(object sender, EventArgs e){
        double[] arr = arrays.getX();
        if (!double.TryParse(x_textbox.Text, out arr[selected_x])) return;
        arrays.setX(arr);
        printX();
    }

    void y_combobox_SelectedIndexChanged(object sender, EventArgs e){
        selected_y = y_combobox.SelectedIndex;
        y_textbox.Text = y_combobox.Items[selected_y].ToString();
    }

    void y_change_Click(object sender, EventArgs e){
        double[] arr = arrays.getY();
        if (!double.TryParse(y_textbox.Text, out arr[selected_y])) return;
        arrays.setY(arr);
        printY();
    }

    void create_new_Click(object sender, EventArgs e){
        arrays.makeX();
        printX();
    }

    void calculate_Click(object sender, EventArgs e){
        arrays.makeYfromX();
        printY();
    }

    async void load_Click(object sender, EventArgs e){
        OpenFileDialog open_file = new OpenFileDialog();
        open_file.InitialDirectory = Environment.CurrentDirectory;
        if (open_file.ShowDialog() != DialogResult.OK) return;
        if (open_file.FileName == null) return;
        string file_path = open_file.FileName;
        List<double> arr = new List<double>();
        using(StreamReader read = new StreamReader(file_path)){
            string line;
            double buf;
            while((line = await read.ReadLineAsync()) != null){
                if (double.TryParse(line, out buf)){
                    arr.Add(buf);
                }
            }
        }
        double[] result = arr.ToArray();
        arrays.setX(result);
        printX();
    }

    void save_Click(object sender, EventArgs e){
        FolderBrowserDialog brows_folder = new FolderBrowserDialog();
        brows_folder.InitialDirectory = Environment.CurrentDirectory;
        if (brows_folder.ShowDialog() != DialogResult.OK) return;
        string folder_path = brows_folder.SelectedPath;
        using (StreamWriter writer =
        new StreamWriter(folder_path + "\\file.txt", false)){
            double[] arr = arrays.getY();
            for (int i = 0; i < arr.Length; i++){
                writer.WriteLine("Число №" + (i+1).ToString());
                writer.WriteLine(arr[i].ToString());
            }
        }
    }

    void printX(){
        if (x_list.Items.Count != 0) { x_list.Items.Clear(); }
        double[] arr = arrays.getX();
        foreach (double i in arr){
            x_list.Items.Add(i);
        }
    }

    void printY(){
        if (y_combobox.Items.Count != 0) {y_combobox.Items.Clear(); }
        double[] arr = arrays.getY();
        foreach (double i in arr){
            y_combobox.Items.Add(i);
        }
    }

    void exit_Click(object sender, EventArgs e){
        Application.Exit();
    }
}
