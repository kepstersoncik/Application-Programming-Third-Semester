import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class MainForm {
    private Font frame_font = new Font("Lucida Console", Font.PLAIN, 14); 

    private JFrame main_frame;
    private JLabel discription_label;
    private JLabel param_label;
    private JLabel x_label;
    private JTextField param_input;
    private JTextField x_input;
    private JButton calc_button;
    private JLabel output_label;
    ButtonGroup rbuttons_group;
    private JRadioButton e_rbutton;
    private JRadioButton n_rbutton;

    MainForm(){
        main_frame = new JFrame();
        main_frame.setBounds(10, 20, 320, 300);
        main_frame.setTitle("Лабораторная работа № 2");
        main_frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        main_frame.setLayout(null);

        discription_label = new JLabel();
        discription_label.setBounds(15, 15, 350, 30);
        discription_label.setText("Выбирите режим работы");
        discription_label.setFont(frame_font);
        main_frame.add(discription_label);

        param_label = new JLabel();
        param_label.setBounds(15, 50, 20, 30);
        param_label.setText(" :");
        param_label.setFont(frame_font);
        main_frame.add(param_label);

        param_input = new JTextField();
        param_input.setBounds(40, 50, 50, 30);
        main_frame.add(param_input);
        
        x_label = new JLabel();
        x_label.setBounds(15, 85, 20, 30);
        x_label.setText("x:");
        x_label.setFont(frame_font);
        main_frame.add(x_label);

        x_input = new JTextField();
        x_input.setBounds(40, 85, 50, 30);
        main_frame.add(x_input);

        calc_button = new JButton();
        calc_button.setBounds(15, 120, 110, 30);
        calc_button.setText("Вычислить");
        calc_button.setFont(frame_font);
        calc_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                chooseFuncAndCalc();
            }
        });
        main_frame.add(calc_button);

        output_label = new JLabel();
        output_label.setBounds(15, 155, 290, 30);
        output_label.setFont(frame_font);
        main_frame.add(output_label);

        rbuttons_group = new ButtonGroup();

        e_rbutton = new JRadioButton();
        e_rbutton.setBounds(95, 50, 210, 30);
        e_rbutton.setText("По заданной точности e");
        e_rbutton.setFont(frame_font);
        e_rbutton.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                param_label.setText("e:");
                discription_label.setText("Введите параметр e");
            }
        });
        rbuttons_group.add(e_rbutton);
        main_frame.add(e_rbutton);

        n_rbutton = new JRadioButton();
        n_rbutton.setBounds(95, 85, 210, 30);
        n_rbutton.setText("По количеству сумм N");
        n_rbutton.setFont(frame_font);
        n_rbutton.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                param_label.setText("N:");
                discription_label.setText("Введите параметр N");
            }
        });
        rbuttons_group.add(n_rbutton);
        main_frame.add(n_rbutton);

        main_frame.show();
    }

    private void printError(String text){
        output_label.setText("<html>Ошибка! " + text);
    }

    private void printResult(Double x){
        output_label.setText("Результат: " + Double.toString(x));
    }

    private double myPow(double x, int n){
        double res = x;
        for (int i = 0; i < n-1; i++){
            res *= x;
        }
        return res;
    }

    private void calcWithE(double e, double x){
        double result = Math.PI / 2, temp;
        temp = x;
        for(int n = 0; Math.abs(temp) > e; n++){
            temp = (myPow(-1, n+1) / ((2 * n + 1) * myPow(Math.abs(x), 2 * n + 1)));
            result += temp;
        }
        if (x < 0) { result = -result; }
        printResult(result);
    }

    private void calcWithN(double n, double x){
        double result = Math.PI / 2;
        for (int i = 0; i < n; i++){
            result += (myPow(-1, i+1) / ((2 * i + 1) * myPow(Math.abs(x), 2 * i + 1)));
        }
        if (x < 0) { result = -result; }
        printResult(result);
    }

    private void chooseFuncAndCalc(){
        double param, x;
        try{
            param = Double.parseDouble(param_input.getText());
            x = Double.parseDouble(x_input.getText());
        }
        catch (Exception ex){
            printError("Не удается получить данные!");
            return;
        }
        if (param < 0) { printError("Недопустимое значение параметра!"); return; }
        if (e_rbutton.isSelected()){ calcWithE(param, x); }
        else if (n_rbutton.isSelected()){ calcWithN(param, x); }
        else { printError("Требуется выбрать режим!");}
    }
}
