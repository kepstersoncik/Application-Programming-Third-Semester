import javax.swing.*;

public class Main {
    public static void main(String[] args){
        JFrame main_frame = new JFrame("Лабораторная работа № 1");
        main_frame.setContentPane(new LW1E1_MainFrame().main_panel);
        main_frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        main_frame.pack();
        main_frame.setVisible(true);
    }
}
