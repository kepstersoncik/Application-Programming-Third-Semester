import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;

public class MainForm extends JFrame{
    PictureBox picture_box1;
    PictureBox picture_box2;

    JPanel left_panel;
    PanelWithInsert right_panel;

    JButton choose_image1_button;
    JButton choose_image2_button;

    JFileChooser file_chooser;
    MainForm(int form_width, int form_hight){
        this.setTitle("Лабораторная работа № 5");
        this.setBounds(15, 15, form_width, form_hight);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setLayout(null);
        
        left_panel = new JPanel();
        left_panel.setBounds(0, 0, form_width/2, form_hight-40);
        left_panel.setLayout(null);
        left_panel.setBorder(BorderFactory.createLineBorder(Color.black));
        add(left_panel);

        right_panel = new PanelWithInsert();
        right_panel.setBounds(form_width/2, 0, form_width/2-15, form_hight-40);
        right_panel.setLayout(null);
        right_panel.setBorder(BorderFactory.createLineBorder(Color.black));
        right_panel.addMouseListener(new MouseListener(){

            @Override
            public void mouseClicked(MouseEvent e) {
                BufferedImage insert_image = (BufferedImage) picture_box1.getCutedImage();
                for (int y = 0; y < insert_image.getHeight(); y++) {
                    for (int x = 0; x < insert_image.getWidth(); x++) {
                        int p = insert_image.getRGB(x,y);
                        int r = (p>>16)&0xff;
                        int g = (p>>8)&0xff;
                        int b = p&0xff;
                        int avg = (r+g+b)/3;
                        p = (avg<<16) | (avg<<8) | avg;
                        insert_image.setRGB(x, y, p);
                    }
                }
                PictureBox picture_box = new PictureBox();
                picture_box.setBounds(e.getX(), e.getY(), (int) picture_box1.getCutRectangle().getX(), (int) picture_box1.getCutRectangle().getY());
                picture_box.setImage(insert_image);
                right_panel.add(picture_box);
                right_panel.repaint();
            }

            @Override
            public void mousePressed(MouseEvent e) {
            }

            @Override
            public void mouseReleased(MouseEvent e) {
            }

            @Override
            public void mouseEntered(MouseEvent e) {
            }

            @Override
            public void mouseExited(MouseEvent e) {             
            }
            
        });
        add(right_panel);
        choose_image2_button = new JButton("Изображение 2");
        choose_image2_button.setEnabled(false);;
        choose_image1_button = new JButton("Изображение 1");
        choose_image1_button.setBounds(15, 15, 130, 25);
        choose_image1_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                try{
                    remove(picture_box1);
                }
                catch(Exception ex){}
                picture_box1 = new PictureBox(chooseImagePath());
                picture_box1.setBounds(15, 50, left_panel.getWidth()-30, form_hight-150);
                picture_box1.setScale(PictureBox.AUTO_SCALE);
                left_panel.add(picture_box1, 1);
                choose_image2_button.setEnabled(true);;
                repaint();
            }
        });
        left_panel.add(choose_image1_button);

        choose_image2_button.setBounds(150, 15, 130, 25);
        choose_image2_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                try{
                    remove(picture_box1);
                }
                catch(Exception ex){}
                picture_box1.insertImage(chooseImagePath(), 100, 100, 100, 100, 100, 100, 500, 500);
                left_panel.add(picture_box1);
                repaint();
                revalidate();
            }
        });
        left_panel.add(choose_image2_button);

        setVisible(true);
    }

    private String chooseImagePath(){
        file_chooser = new JFileChooser(System.getProperty("user.dir"));
        getContentPane().add(file_chooser);
        file_chooser.showOpenDialog(this);
        String image_path = file_chooser.getSelectedFile().getPath();
        return image_path;
    }

    public Image getCutedImage(){
        return picture_box1.getCutedImage();
    }
}
