package src;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
public class Main extends JPanel{
    BufferedImage background_image;

    Color fill;
    Color border;
    Color animated_part;

    boolean draw_flag;
    JButton start_animate;
    javax.swing.Timer animation_timer;
    int animation_delay;
    int animation_counter;
    JTextField animation_delay_textfield;

    JButton choose_color;
    JColorChooser color_chooser;
 
    Main(){
        super();
        this.setLayout(null);


        try{
        background_image = ImageIO.read(new File("D:\\Semester_3_2022\\AP\\Java\\Java_S3AP_LW5E2\\res\\1200px-LubotinPartizanka.JPG"));
        }
        catch (IOException ex){
            System.err.println("Can't find image!");
        }


        choose_color = new JButton("Выбрать цвет");
        choose_color.setBounds(30, 30, 120, 25);
        choose_color.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                colorsChoose();
                repaint();
            }
        });
        add(choose_color);

        colorsChoose();


        animation_delay = 500;

        animation_delay_textfield = new JTextField(Integer.toString(animation_delay));
        animation_delay_textfield.setToolTipText("Установить время задержки анимации");
        animation_delay_textfield.setBounds(350, 30, 50, 25);
        add(animation_delay_textfield);

        draw_flag = true;

        animation_counter = 0;
        animation_timer = new javax.swing.Timer(animation_delay, new ActionListener(){
            public void actionPerformed(ActionEvent e){
                repaint();
                animation_counter++;
                if (animation_counter == 6){
                    animation_timer.stop();
                }
            }
        });

        start_animate = new JButton("Восроизвести анимацию");
        start_animate.setBounds(155, 30, 190, 25);
        start_animate.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                try{
                    int temp = animation_delay;
                    animation_delay = Integer.parseInt(animation_delay_textfield.getText());
                    if (animation_delay <= 0){
                        animation_delay = temp;
                        throw new Exception("Delay must be positive!");
                    }
                }
                catch(Exception ex){
                    JOptionPane.showMessageDialog(null,
                    "Недопустимое значение\n" + ex.getMessage() ,
                    "Ошибка значения", JOptionPane.INFORMATION_MESSAGE);
                    return;
                }
                animation_counter = 0;
                animation_timer.setDelay(animation_delay);
                animation_timer.start();
            }
        });
        add(start_animate);

        setVisible(true);
    }

    private void colorsChoose() {
        border = color_chooser.showDialog(this, "Выбор цвета линии", Color.BLACK);
        fill = color_chooser.showDialog(this, "Выбор цвета заливки", Color.BLACK);
        animated_part = color_chooser.showDialog(this, "Выбор цвета движущегося фрагмента", Color.BLACK);
    }

    public void paintComponent(Graphics gr){
        Graphics2D g = (Graphics2D) gr;
        g.drawImage(background_image, 0, 0, getWidth(), getHeight(), null);
        g.setColor(Color.white);
        g.fillPolygon(new int[] {570, 830, 830, 570}, new int[] {300, 300, 590, 590}, 4);
        g.setColor(border);
        g.setStroke(new BasicStroke(5));
        g.drawRect(570, 290, 260, 300);
        g.setColor(fill);
        g.fillPolygon(new int[] {550, 700, 850}, new int[] {300, 150, 300}, 3);
        g.setColor(border);
        g.drawPolygon(new int[] {550, 700, 850}, new int[] {300, 150, 300}, 3);
        g.setColor(fill);
        g.fillOval(610, 320, 70, 70);
        g.setColor(border);
        g.drawOval(610, 320, 70, 70);
        g.setColor(border);
        g.drawRect(710, 350, 100, 240);
        if (draw_flag){
            g.setColor(border);
            g.drawPolygon(new int[] {710, 810, 810, 710}, new int[] {350, 350, 590, 590}, 4);
            g.setColor(animated_part);
            g.fillPolygon(new int[] {710, 810, 810, 710}, new int[] {350, 350, 590, 590}, 4);
            draw_flag = false;
        }
        else{
            g.setColor(border);
            g.drawPolygon(new int[] {710, 790, 790, 710}, new int[] {350, 365, 605, 590}, 4);
            g.setColor(animated_part);
            g.fillPolygon(new int[] {710, 790, 790, 710}, new int[] {350, 365, 605, 590}, 4);
            draw_flag = true;
        }

    }

    public static void main(String[] args){
        try{
            JFrame main = new JFrame();
            main.setBounds(15, 15, 1000, 700);
            main.setTitle("Лабораторная работа № 5");
            main.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            main.setLayout(null);

            Main main_panel = new Main();
            main_panel.setBounds(15, 15, main.getWidth()-45, main.getHeight()-75);
            main.add(main_panel);

            main.setVisible(true);
        }
        catch (Exception ex){
            System.err.println("Something went wrong...");
            System.err.println(ex.getMessage());
            System.exit(ABORT);
        }
    }
}
