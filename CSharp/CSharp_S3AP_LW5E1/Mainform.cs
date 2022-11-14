namespace CSharp_S3AP_LW5E1;

public partial class MainForm : Form
{
    PictureBox picture_box;
    Size picture_box_origin_size;
    Bitmap buffered_bitmap;
    bool _mouse_presed;

    Bitmap cutted_bitmap;


    Button load_first_image;
    Button load_second_image;

    Label split_line;

    StatusStrip status_bar;

    Panel right_panel;

    Point old_point;
    Point new_point;
    public MainForm()
    {
        this.Size = new Size(1100, 700);
        this.Text = "Лабораторная работа № 5";
        split_line = new Label();
        split_line.BorderStyle = BorderStyle.Fixed3D;
        split_line.Location = new Point(this.Width/2, 0);
        split_line.Size = new Size(1, this.Height);
        this.Controls.Add(split_line);

        load_first_image = new Button();
        load_first_image.Text = "Загрузить изображение 1";
        load_first_image.Location = new Point(15, 15);
        load_first_image.Size = new Size(180, 25);
        load_first_image.Click += load_first_image_Click;
        this.Controls.Add(load_first_image);

        load_second_image = new Button();
        load_second_image.Text = "Загрузить изображение 2";
        load_second_image.Location = new Point(200, 15);
        load_second_image.Size = new Size(180, 25);
        load_second_image.Click += load_second_image_Click;
        load_second_image.Enabled = false;
        this.Controls.Add(load_second_image);

        picture_box = new PictureBox();
        picture_box.Location = new Point(15, 50);
        picture_box.Size = new Size(450, 450);
        picture_box_origin_size = picture_box.Size;
        picture_box.BorderStyle = BorderStyle.Fixed3D;
        picture_box.MouseDown += picture_box_MouseDown;
        picture_box.MouseMove += picture_box_MouseMove;
        picture_box.MouseUp += picture_box_MouseUp;
        this.Controls.Add(picture_box);

        status_bar = new StatusStrip();
        status_bar.Items.Add("");
        this.Controls.Add(status_bar);

        right_panel = new Panel();
        right_panel.Location = new Point(this.Width/2, 0);
        right_panel.Size = new Size(this.Width/2, this.Height);
        right_panel.MouseDown += right_panel_MouseDown;
        this.Controls.Add(right_panel);
    }

    private Image load_image(){
        OpenFileDialog choose_image = new OpenFileDialog();
        choose_image.InitialDirectory = Environment.CurrentDirectory;
        if (choose_image.ShowDialog() != DialogResult.OK) return null;
        if (choose_image.FileName == null) return null;
        string image_path = choose_image.FileName;
        return Image.FromFile(image_path);
    }

    private void load_first_image_Click(object sender, EventArgs e){
        Image image = load_image();
        if (image == null){
            string message = "Не удалось загрузить изображение";
            string title = "Ошибка загрузки изображения";
            MessageBoxButtons ok_button = MessageBoxButtons.OK;
            MessageBox.Show(message, title, ok_button);
            return;
        }
        picture_box.Size = picture_box_origin_size;
        drawImage(image);
        if (picture_box.Image != null) {load_second_image.Enabled = true;}
    }

    private void load_second_image_Click(object sender, EventArgs e){
        Image image = load_image();
        if (image == null){
            string message = "Не удалось загрузить изображение";
            string title = "Ошибка загрузки изображения";
            MessageBoxButtons ok_button = MessageBoxButtons.OK;
            MessageBox.Show(message, title, ok_button);
            return;
        }
        drawCuttedImage(image);
    }

    private void drawImage(Image image){
        float scale_w = ((float)picture_box.Width / (float)image.Width);
        float scale_h = ((float)picture_box.Height / (float)image.Height);
        float scale;

        if (scale_h < scale_w)
            scale = scale_h;
        else
            scale = scale_w;
        
        int new_width = (int)(image.Width * scale);
        int new_height = (int)(image.Height * scale);
        Bitmap bitmap = new Bitmap(new_width, new_height);
        Graphics g = Graphics.FromImage((System.Drawing.Image)bitmap);
        g.DrawImage(image, 0, 0, new_width, new_height);
        g.Dispose();
        picture_box.Image = (System.Drawing.Image)bitmap;
        buffered_bitmap = bitmap;
        picture_box.Size = bitmap.Size;
    }

    private void drawCuttedImage(Image image){
        Bitmap bitmap = new Bitmap(image);
        bitmap = bitmap.Clone(new Rectangle(250, 250, 500, 500), bitmap.PixelFormat);
        Bitmap origin_bitmap = new Bitmap(picture_box.Image);
        Graphics g = Graphics.FromImage(origin_bitmap);
        g.DrawImage(bitmap, 100, 100, 100, 100);
        g.Dispose();
        picture_box.Image = origin_bitmap;
        buffered_bitmap = origin_bitmap;
    }

    private void picture_box_MouseDown(object sender, MouseEventArgs e){
        if (picture_box.Image == null) {return;}
        if (buffered_bitmap != null) {
            picture_box.Image = buffered_bitmap;
        }
        buffered_bitmap = new Bitmap(picture_box.Image);
        _mouse_presed = true;
        status_bar.Items[0].Text = "Mouse presed";
        old_point.X = e.X;
        old_point.Y = e.Y;
    }

    private void picture_box_MouseMove(object sender, MouseEventArgs e){
        if (!_mouse_presed) {return;}
        new_point.X = e.X;
        new_point.Y = e.Y;
        picture_box.Image = buffered_bitmap;
        Bitmap origin_bitmap = new Bitmap(picture_box.Image);
        Graphics g = Graphics.FromImage(origin_bitmap);
        Rectangle rect = makeRectangle();
        status_bar.Items[0].Text = rect.ToString();
        Pen pen = new Pen(Color.White, 1);
        g.DrawRectangle(pen, rect);
        g.Dispose();
        picture_box.Image = origin_bitmap;
    }

    private Rectangle makeRectangle(){
        Rectangle rect;
        if (new_point.X < old_point.X && new_point.Y < old_point.Y){
            rect = new Rectangle(new_point.X, new_point.Y, old_point.X - new_point.X, old_point.Y - new_point.Y);
        }
        else if (new_point.X < old_point.X){
            rect = new Rectangle(new_point.X, old_point.Y, old_point.X - new_point.X, new_point.Y - old_point.Y);
        }
        else if (new_point.Y < old_point.Y){
            rect = new Rectangle(old_point.X, new_point.Y, new_point.X - old_point.X, old_point.Y - new_point.Y);
        }
        else {
            rect = new Rectangle(old_point.X, old_point.Y, new_point.X - old_point.X, new_point.Y - old_point.Y);
        }
        return rect;
    }

    private void picture_box_MouseUp(object sender, MouseEventArgs e){
        _mouse_presed = false;
        status_bar.Items[0].Text = "Mouse uped";
        new_point.X = e.X;
        new_point.Y = e.Y;
        Rectangle rect = makeRectangle();
        if (rect.Width == 0 || rect.Height == 0) {return;}
        cutted_bitmap = buffered_bitmap.Clone(rect, buffered_bitmap.PixelFormat);
        for (int y = 0; y < cutted_bitmap.Height; y++)
        {
            for (int x = 0; x < cutted_bitmap.Width; x++)
            {
                Color p = cutted_bitmap.GetPixel(x, y);
                int a = p.A;
                int r = p.R;
                int g = p.G;
                int b = p.B;
                int avg = (r+b+g)/3;
                cutted_bitmap.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
            }
        }
    }

    private void right_panel_MouseDown(object sender, MouseEventArgs e){
        PictureBox pasted_image = new PictureBox();
        pasted_image.Location = new Point(e.X, e.Y);
        pasted_image.Size = cutted_bitmap.Size;
        pasted_image.Image = (Image)cutted_bitmap;
        right_panel.Controls.Add(pasted_image);
    }
}