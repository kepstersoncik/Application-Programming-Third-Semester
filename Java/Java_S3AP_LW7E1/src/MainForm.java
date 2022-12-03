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

    private JCheckBox double_checkbox;

    private JRadioButton _initRButton(String text) {
        JRadioButton rbutton = new JRadioButton();
        rbutton.setText(text);
        rbutton.setFont(form_font);
        rbutton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                getXandCalc();
            }
        });
        return rbutton;
    }

    MainForm() {
        main_form = new JFrame();
        main_form.setLocation(10, 20);
        main_form.setMinimumSize(new Dimension(410, 180));
        main_form.setTitle("Лабораторная работа № 2");
        main_form.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        GridBagLayout grid = new GridBagLayout();

        main_form.setLayout(grid);

        GridBagConstraints grid_constraints = new GridBagConstraints();
        grid_constraints.fill = GridBagConstraints.HORIZONTAL;
        grid_constraints.insets = new Insets(5, 5, 5, 5);
        grid_constraints.weightx = .5;
        grid_constraints.weighty = .5;

        discription_label = new JLabel();
        discription_label.setText("Значение x:");
        discription_label.setHorizontalAlignment(SwingConstants.RIGHT);
        discription_label.setFont(form_font);
        grid_constraints.gridx = 0;
        grid_constraints.gridy = 0;
        main_form.add(discription_label, grid_constraints);

        x_input = new JTextField(10);
        x_input.setFont(form_font);
        grid_constraints.gridx = 1;
        grid_constraints.gridy = 0;
        main_form.add(x_input, grid_constraints);

        calc_button = new JButton();
        calc_button.setText("Вычислить");
        calc_button.setFont(form_font);
        calc_button.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                getXandCalc();
            }
        });
        grid_constraints.gridx = 0;
        grid_constraints.gridy = 1;
        main_form.add(calc_button, grid_constraints);

        output_label = new JLabel();
        output_label.setFont(form_font);
        grid_constraints.gridx = 1;
        grid_constraints.gridy = 1;
        main_form.add(output_label, grid_constraints);

        first_rbutton = _initRButton("sin(x)+cos(x)");
        second_rbutton = _initRButton("tg(x)");
        third_rbutton = _initRButton("x^3");
        rbuttons_group = new ButtonGroup();
        rbuttons_group.add(first_rbutton);
        grid_constraints.gridx = 2;
        grid_constraints.gridy = 0;
        main_form.add(first_rbutton, grid_constraints);
        rbuttons_group.add(second_rbutton);
        grid_constraints.gridx = 2;
        grid_constraints.gridy = 1;
        main_form.add(second_rbutton, grid_constraints);
        rbuttons_group.add(third_rbutton);
        grid_constraints.gridx = 2;
        grid_constraints.gridy = 2;
        main_form.add(third_rbutton, grid_constraints);

        double_checkbox = new JCheckBox();
        double_checkbox.setText("Удвоить");
        double_checkbox.setFont(form_font);
        double_checkbox.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                getXandCalc();
            }
        });
        grid_constraints.gridx = 2;
        grid_constraints.gridy = 3;
        main_form.add(double_checkbox, grid_constraints);

        main_form.show();
    }

    private double myPow(double x, int n) {
        if (n == 0) {
            return 1.0;
        }
        if (n % 2 != 0) {
            return myPow(x, n - 1) * x;
        }
        double y = myPow(x, n / 2);
        return y * y;
    }

    private void printError(String text) {
        output_label.setText("Ошибка! " + text);
    }

    private void printResult(Double x) {
        if (double_checkbox.isSelected()) {
            x *= 2;
        }
        output_label.setText("Результат: " + String.format("%.3f", x));
    }

    private int getActionNumber() {
        if (first_rbutton.isSelected()) {
            return 1;
        } else if (second_rbutton.isSelected()) {
            return 2;
        } else if (third_rbutton.isSelected()) {
            return 3;
        }
        return 4;
    }

    private double calcXwithParam(Double x) {
        if (x <= 0) {
            x = Math.toRadians(x);
            first_rbutton.setSelected(true);
            return Math.sin(x) + Math.cos(x);
        } else if (0 < x && x < 1) {
            x = Math.toRadians(x);
            second_rbutton.setSelected(true);
            return Math.tan(x);
        }
        third_rbutton.setSelected(true);
        return myPow(x, 3);
    }

    private void getXandCalc() {
        double x;
        try {
            x = Double.parseDouble(x_input.getText());
        } catch (Exception e) {
            printError("Не удается получить данные!");
            return;
        }
        switch (getActionNumber()) {
            case 1:
                x = Math.toRadians(x);
                printResult(Math.sin(x) + Math.cos(x));
                break;
            case 2:
                x = Math.toRadians(x);
                printResult(Math.tan(x));
                break;
            case 3:
                printResult(myPow(x, 3));
                break;
            case 4:
                printResult(calcXwithParam(x));
                break;
        }
    }
}
