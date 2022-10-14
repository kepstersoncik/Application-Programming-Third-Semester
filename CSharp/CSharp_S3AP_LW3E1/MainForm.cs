namespace CSharp_S3AP_LW3E1;

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

    public MainForm()
    {
        this.Size = new Size(300, 310);
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
        this.Controls.Add(x_list);

        y_label = new Label();
        y_label.Text = "Массив y";
        y_label.Location = new Point(150, 25);
        y_label.Size = new Size(120, 20);
        this.Controls.Add(y_label);

        y_combobox = new ComboBox();
        y_combobox.Location = new Point(150, 45);
        y_combobox.Size = new Size(120, 20);
        this.Controls.Add(y_combobox);
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
