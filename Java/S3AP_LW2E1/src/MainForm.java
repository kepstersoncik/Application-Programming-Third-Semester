import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class MainForm {
    private Font form_font = new Font("Lucida Console", Font.PLAIN, 14); 

    private JFrame main_form;
    private JTextField x_input;
    private JButton calc_button;
    private JLabel output_label;
    private JLabel discription_label;

    private ButtonGroup rbuttons_group;
    private JRadioButton first_rbutton;
    private JRadioButton second_rbutton;
    private JRadioButton third_rbutton;

    private JRadioButton _initRButton(int x, int y, int w, int h, String text){
        JRadioButton rbutton = new JRadioButton();
        rbutton.setBounds(x, y, w, h);
        rbutton.setText(text);
        rbutton.setFont(form_font);
        return rbutton;
    }

    MainForm(){
        main_form = new JFrame();
        main_form.setBounds(10, 20, 350, 170);
        main_form.setTitle("Лабораторная работа № 2");
        main_form.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        main_form.setLayout(null);

        discription_label = new JLabel();
        discription_label.setBounds(15, 15, 90, 30);
        discription_label.setText("Значение x:");
        discription_label.setFont(form_font);
        main_form.add(discription_label);

        x_input = new JTextField();
        x_input.setBounds(110, 15, 55, 30);
        x_input.setFont(form_font);
        main_form.add(x_input);

        calc_button = new JButton();
        calc_button.setBounds(15, 50, 150, 30);
        calc_button.setText("Вычислить");
        calc_button.setFont(form_font);
        calc_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                getXandCalc();
            }
        });
        main_form.add(calc_button);

        output_label = new JLabel();
        output_label.setBounds(15, 85, 300, 30);
        output_label.setFont(form_font);
        main_form.add(output_label);

        final int RBUTTON_W = 155;
        final int RBUTTON_H = 15;
        first_rbutton = _initRButton(170, 15, RBUTTON_W, RBUTTON_H, "sin(x)+cos(x)");
        second_rbutton = _initRButton(170, 35, RBUTTON_W, RBUTTON_H, "tg(x)");
        third_rbutton = _initRButton(170, 55, RBUTTON_W, RBUTTON_H, "x^3");
        rbuttons_group = new ButtonGroup();
        rbuttons_group.add(first_rbutton);
        rbuttons_group.add(second_rbutton);
        rbuttons_group.add(third_rbutton);
        main_form.add(first_rbutton);
        main_form.add(second_rbutton);
        main_form.add(third_rbutton);

        main_form.show();
    }

    private void printError(String text){
        output_label.setText("Ошибка! " + text);
    }

    private void printResult(Double x){
        output_label.setText("Результат: " + String.format("%.3f", x));
    }

    private int getActionNumber(){
        if (first_rbutton.isSelected()){ return 1;}
        else if (second_rbutton.isSelected()){ return 2;}
        else if (third_rbutton.isSelected()){ return 3;}
        return 4;
    }

    private double calcXwithParam(Double x){
        if (x <= 0) {x = Math.toRadians(x); first_rbutton.setSelected(true); return Math.sin(x) + Math.cos(x);}
        else if (0 < x && x < 1){x = Math.toRadians(x); second_rbutton.setSelected(true); return Math.tan(x);}
        third_rbutton.setSelected(true); return Math.pow(x, 3);
    }

    private void getXandCalc(){
        double x;
        try {
            x = Double.parseDouble(x_input.getText());
        }
        catch(Exception e){
            printError("Не удается получить данные!");
            return;
        }
        switch (getActionNumber()){
            case 1: x = Math.toRadians(x); printResult(Math.sin(x) + Math.cos(x)); break;
            case 2: x = Math.toRadians(x); printResult(Math.tan(x)); break;
            case 3: printResult(Math.pow(x, 3)); break;
            case 4: printResult(calcXwithParam(x)); break;
        }
    }
}
