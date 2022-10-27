import java.io.File;
import java.io.FileFilter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.math.BigDecimal;
import java.text.DecimalFormat;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;

public class MainForm {
    int ARRAY_SIZE = 10;

    DefaultListModel<Double> x_array;
    DefaultComboBoxModel y_array;

    private JFrame main_frame;

    private JMenuBar menu_bar;
    
    private JMenu file_menu;
    private JMenuItem create_new;
    private JMenuItem load;
    private JMenuItem save;
    private JMenuItem exit;

    private JMenu operation_menu;
    private JMenuItem calculate;

    private JLabel x_list_label;
    private JList<Double> x_list;

    private JLabel y_combobox_label;
    private JComboBox<Double> y_combobox;

    private JFileChooser file_chooser;

    MainForm(){
        main_frame = new JFrame();
        main_frame.setBounds(10, 20, 365, 340);
        main_frame.setTitle("Работа № 3");
        main_frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        main_frame.setLayout(null);

        x_array = new DefaultListModel<Double>();
        y_array = new DefaultComboBoxModel<Double>();
        for(int i = 0; i < ARRAY_SIZE; i++){
            x_array.addElement(1.0);
            y_array.addElement(1.0);
        }

        menu_bar = new JMenuBar();
        menu_bar.setBounds(0, 0, 400, 25);

        file_menu = new JMenu("Файл");
        create_new = new JMenuItem("Новый");
        create_new.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                makeX();
            }
        });
        file_menu.add(create_new);
        load = new JMenuItem("Загрузить");
        load.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                loadFile();
            }
        });
        file_menu.add(load);
        save = new JMenuItem("Сохранить");
        save.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                saveFile();
            }
        });
        file_menu.add(save);
        exit = new JMenuItem("Выйти");
        exit.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                System.exit(0);
            }
        });
        file_menu.add(exit);
        menu_bar.add(file_menu);

        operation_menu = new JMenu("Работа");
        calculate = new JMenuItem("Вычислить");
        calculate.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                makeYfromX();
            }
        });
        operation_menu.add(calculate);
        menu_bar.add(operation_menu);

        main_frame.add(menu_bar);

        x_list_label = new JLabel("Массив X");
        x_list_label.setBounds(15, 30, 150, 25);
        main_frame.add(x_list_label);
        x_list = new JList<Double>(x_array);
        x_list.setBounds(15, 55, 150, 200);
        main_frame.add(x_list);

        y_combobox_label = new JLabel("Массив Y");
        y_combobox_label.setBounds(185, 30, 150, 25);
        main_frame.add(y_combobox_label);
        y_combobox = new JComboBox<Double>(y_array);
        y_combobox.setBounds(185, 55, 150, 25);
        main_frame.add(y_combobox);

        main_frame.setVisible(true);
    }

    void makeX(){
        this.x_array.clear();
        double temp = 1;
        for (int i = 0; i < ARRAY_SIZE; i++){
            this.x_array.addElement(Math.sin(i + 1) * temp);
            temp *= Math.sin(i + 1);
        }
    }

    void makeYfromX(){
        double sum = 0;
        double mean;
        double temp[] = new double[ARRAY_SIZE];
        int temp_counter = 0;
        this.y_array.removeAllElements();
        for (int i = 0; i < ARRAY_SIZE; i++){
            sum += x_array.getElementAt(i);
        }
        mean = sum / ARRAY_SIZE;
        for (int i = 0; i < ARRAY_SIZE; i++){
            if(x_array.getElementAt(i) < mean){
                y_array.addElement(x_array.getElementAt(i));
            }
            else{
                temp[temp_counter++] = x_array.getElementAt(i);
            }
        }
        for (int i = 0; i < temp_counter; i++){
            y_array.addElement(temp[i]);
        }
    }

    private void saveFile(){
        file_chooser = new JFileChooser(System.getProperty("user.dir"));
        file_chooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        main_frame.getContentPane().add(file_chooser);
        file_chooser.showOpenDialog(main_frame);
        String path = file_chooser.getSelectedFile().getPath();
        try (FileWriter writer = new FileWriter(path + "\\file.txt")){
            for (int i = 0; i < ARRAY_SIZE; i++){
                writer.write("Число № " + Integer.toString(i+1) + '\n');
                writer.write('[' + y_array.getElementAt(i).toString() + ']' + '\n');
            }
        }
        catch (IOException ex){}
    }

    private void loadFile(){
        file_chooser = new JFileChooser(System.getProperty("user.dir"));
        main_frame.getContentPane().add(file_chooser);
        file_chooser.showOpenDialog(calculate);
        String file = file_chooser.getSelectedFile().getPath();
        String buf;
        DefaultListModel<Double> temp = new DefaultListModel<Double>();
        try(FileReader reader = new FileReader(file)){
            Scanner scan = new Scanner(reader);
            while (scan.hasNextLine()){
                buf = scan.nextLine();
                if (buf.contains("[") && buf.contains("]")
                && isParseble(buf.substring(1, buf.length()-1))){
                    temp.addElement(Double.parseDouble(buf.substring(1, buf.length()-1)));
                }
            }
        }
        catch(IOException ex){}
        x_array = temp;
        x_list.setModel(x_array);
    }

    private boolean isParseble(String str){
        try {
            Double.parseDouble(str);
        }
        catch(Exception ex){
            return false;
        }
        return true;
    }
}   
