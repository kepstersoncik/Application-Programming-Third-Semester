namespace CSharp_S3AP_LW5E2;

public partial class MainForm : Form
{
    PictureBox background;
    Bitmap buffered_bitmap;

    Color border;
    Color fill;
    Color animation;

    bool drawning_mode;

    Button choose_color_button;
    Button start_timer_button;
    TextBox timer_delay;
    System.Windows.Forms.Timer timer;
    int tick_counter;
    public MainForm()
    {
        drawning_mode = false;
        border = Color.Blue;
        fill = Color.Cyan;
        animation = Color.Pink;

        this.Size = new Size(1030, 771);
        this.Text = "Лабораторная работа 5";

        background = new PictureBox();
        background.Location = new Point(15, 15);
        background.Size = new Size(this.Width - 45, this.Height - 70);
        drawImage();
        this.Controls.Add(background);

        choose_color_button = new Button();
        choose_color_button.Location = new Point(20, 20);
        choose_color_button.Size = new Size(120, 25);
        choose_color_button.Text = "Сменить цвета";
        choose_color_button.Click += choose_color_button_Click;
        this.Controls.Add(choose_color_button);
        choose_color_button.BringToFront();

        start_timer_button = new Button();
        start_timer_button.Location = new Point(145, 20);
        start_timer_button.Size = new Size(140, 25);
        start_timer_button.Text = "Запустить анимацию";
        start_timer_button.Click += start_timer_button_Click;
        this.Controls.Add(start_timer_button);
        start_timer_button.BringToFront();

        timer_delay = new TextBox();
        timer_delay.Location = new Point(290, 20);
        timer_delay.Size = new Size(40, 25);
        timer_delay.Text = "500";
        this.Controls.Add(timer_delay);
        timer_delay.BringToFront();

        timer = new System.Windows.Forms.Timer();
        timer.Tick += timer_Tick;
    }

    private void choose_color_button_Click(object sender, EventArgs e){
        chooseColors();
        drawImage();
    }

    private void start_timer_button_Click(object sender, EventArgs e){
        int delay = 500;
        try{
            int temp_delay = delay;
            delay = int.Parse(timer_delay.Text);
            if (delay <= 0){
                delay = temp_delay;
                throw new Exception();
            }
        }
        catch(Exception){
            MessageBox.Show("Невозможное значение задержки таймера!", "Невозможное значение", MessageBoxButtons.OK);
        }
        timer.Interval = delay;
        tick_counter = 0;
        timer.Start();
    }

    private void timer_Tick(object sender, EventArgs e){
        if (tick_counter > 6) {timer.Stop(); return;}
        if (drawning_mode){
            drawning_mode = false;
        }
        else{
            drawning_mode = true;
        }
        drawAnimation();
        tick_counter++;
    }

    private void chooseColors(){
        ColorDialog dialog = new ColorDialog();
        MessageBox.Show("Выбирите цвет обводки", "Цвет обводки", MessageBoxButtons.OK);
        if (dialog.ShowDialog() != DialogResult.OK) {border = Color.Blue;}
        border = dialog.Color;
        MessageBox.Show("Выбирите цвет заливки", "Цвет заливки", MessageBoxButtons.OK);
        if (dialog.ShowDialog() != DialogResult.OK) {fill = Color.Cyan;}
        fill = dialog.Color;
        MessageBox.Show("Выбирите цвет движущегося элемента", "Цвет движущегося элемента", MessageBoxButtons.OK);
        if (dialog.ShowDialog() != DialogResult.OK) {animation = Color.Pink;}
        animation = dialog.Color;
    }

    private void drawImage(){
        Image image = Image.FromFile("D:\\Semester_3_2022\\AP\\CSharp\\CSharp_S3AP_LW5E2\\1200px-LubotinPartizanka.JPG");
        Bitmap bitmap = new Bitmap(background.Width, background.Height);
        Graphics g = Graphics.FromImage((System.Drawing.Image)bitmap);
        g.DrawImage(image, 0, 0, background.Width, background.Height);
        g.Dispose();
        background.Image = (System.Drawing.Image)bitmap;
        drawOnImage();
    }

    private void drawOnImage(){
        Bitmap bitmap = new Bitmap(background.Image);
        Graphics g = Graphics.FromImage(bitmap);
        Pen pen = new Pen(border, 2);
        SolidBrush brush = new SolidBrush(fill);

        g.FillPolygon(brush, new Point[] {new Point(650, 150), new Point(550, 250), new Point(750, 250)});
        g.FillRectangle(Brushes.White, new Rectangle(565, 250, 170, 200));
        g.DrawRectangle(pen, new Rectangle(565, 250, 170, 200));
        g.DrawPolygon(pen, new Point[] {new Point(650, 150), new Point(550, 250), new Point(750, 250)});
        g.FillEllipse(brush, 575, 270, 50, 50);
        g.DrawEllipse(pen, 575, 270, 50, 50);
        g.DrawRectangle(pen, 655, 280, 60, 170);
        g.Dispose();
        buffered_bitmap = bitmap;
        drawAnimation();
    }

    private void drawAnimation(){
        background.Image = (Image)buffered_bitmap;
        Bitmap bitmap = new Bitmap(background.Image);
        Graphics g = Graphics.FromImage(bitmap);
        Pen pen = new Pen(border, 2);
        SolidBrush brush = new SolidBrush(animation);
        if (drawning_mode){
            g.FillPolygon(brush, new Point[] {new Point(655, 280), new Point(655, 450), new Point(695, 460), new Point(695, 290)});
            g.DrawPolygon(pen, new Point[] {new Point(655, 280), new Point(655, 450), new Point(695, 460), new Point(695, 290)});
        }
        else{
            g.FillRectangle(brush, 655, 280, 60, 170);
            g.DrawRectangle(pen, 655, 280, 60, 170);
        }
        background.Image = (Image)bitmap;
    }
}
