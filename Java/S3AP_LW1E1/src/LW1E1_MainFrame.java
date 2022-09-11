import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LW1E1_MainFrame {
    public JPanel main_panel;
    private JLabel apex_A_label;
    private JLabel apex_B_label;
    private JLabel apex_C_label;
    private JTextField apex_A_x_tf;
    private JTextField apex_B_x_tf;
    private JTextField apex_C_x_tf;
    private JButton calc_button;
    private JLabel result_label;
    private JTextField apex_A_y_tf;
    private JTextField apex_B_y_tf;
    private JTextField apex_C_y_tf;
    private JLabel description;

    public void errorDisplay(String error){
        result_label.setText("<html>Ошибка! " + error + "</html>");
    }

    private Double calcSide(Double x1, Double x2, Double y1, Double y2){
        return Math.abs(Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2)));
    }

    private void calcPerimetrNDisplay(){
        String temp;
        Double A_x, A_y, B_x, B_y, C_x, C_y;
        try {
            temp = apex_A_x_tf.getText();
            A_x = Double.parseDouble(temp);
            temp = apex_A_y_tf.getText();
            A_y = Double.parseDouble(temp);
            temp = apex_B_x_tf.getText();
            B_x = Double.parseDouble(temp);
            temp = apex_B_y_tf.getText();
            B_y = Double.parseDouble(temp);
            temp = apex_C_x_tf.getText();
            C_x = Double.parseDouble(temp);
            temp = apex_C_y_tf.getText();
            C_y = Double.parseDouble(temp);
        }
        catch (Exception e){
            errorDisplay("Не удалось считать поля координат!<br>Проверьте правильность ввода!");
            return;
        }
        Double AB = calcSide(A_x, B_x, A_y, B_y);
        Double BC = calcSide(B_x, C_x, B_y, C_y);
        Double CA = calcSide(C_x, A_x, C_y, A_y);
        if (AB + BC <= CA || AB + CA <= BC || BC + CA <= AB){
            errorDisplay("Треугольник не существует!");
        }
        else {
            String result = String.format("%.3f", AB + BC + CA);
            result_label.setText("Периметр треугольника: " + result);
        }
    }

    public LW1E1_MainFrame() {
        calc_button.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                calcPerimetrNDisplay();
            }
        });
    }
}
