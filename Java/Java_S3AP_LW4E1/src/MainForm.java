import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableColumn;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class MainForm {
    private JFrame main_frame;

    private JLabel table_x_label;
    private JScrollPane scroll_pane_x;
    private JTable table_x;
    private ListSelectionModel table_x_selection_model;
    private DefaultTableModel table_x_model;

    private JLabel table_y_label;
    private JScrollPane scroll_pane_y;
    private JTable table_y;
    private DefaultTableModel table_y_model;
    private JButton calculate_y;

    private JLabel table_x_size_label;
    private JTextField table_x_size_textfield;
    private JButton table_x_size_button;

    private JLabel table_x_change_label;
    private JTextField table_x_change_textfield;
    private JButton table_x_change_button;

    int N;

    int selected_row;
    int selected_column;

    MainForm(){
        selected_column = -1;
        selected_row = -1;

        main_frame = new JFrame();
        main_frame.setBounds(10, 20, 680, 465);
        main_frame.setTitle("Лабораторная работа № 4");
        main_frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        main_frame.setLayout(null);


        table_x_label = new JLabel("Таблица X");
        table_x_label.setBounds(15, 15, 80, 25);
        main_frame.add(table_x_label);

        table_x_model = new DefaultTableModel();

        table_x = new JTable(table_x_model);
        table_x.setTableHeader(null);
        table_x.setCellSelectionEnabled(true);

        table_x_selection_model = table_x.getSelectionModel();
        table_x_selection_model.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        table_x_selection_model.addListSelectionListener(new ListSelectionListener() {
            public void valueChanged(ListSelectionEvent e){
                selected_column = table_x.getSelectedColumn();
                selected_row = table_x.getSelectedRow();
                table_x_change_textfield.setText(
                    table_x_model.getValueAt(selected_row, selected_column).toString());
            }
        });
        
        scroll_pane_x = new JScrollPane(table_x);
        scroll_pane_x.setBounds(15, 40, 305, 305);
        main_frame.add(scroll_pane_x);
        

        table_y_label = new JLabel("Таблица Y");
        table_y_label.setBounds(340, 15, 80, 25);
        main_frame.add(table_y_label);

        table_y_model = new DefaultTableModel();

        table_y = new JTable(table_y_model);
        table_y.setTableHeader(null);
        
        scroll_pane_y = new JScrollPane(table_y);
        scroll_pane_y.setBounds(340, 40, 305, 305);
        main_frame.add(scroll_pane_y);

        calculate_y = new JButton("Вычислить");
        calculate_y.setBounds(340, 350, 100, 25);
        calculate_y.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                for (int i = 0; i < table_x_model.getColumnCount(); i++){
                    for (int j = 0; j < table_x_model.getRowCount(); j++){
                        int temp = Integer.parseInt(table_x_model.getValueAt(j, i).toString());
                        table_y_model.setValueAt(temp + i+1, j, i);
                    }
                }
            }
        });
        main_frame.add(calculate_y);

        table_x_size_label = new JLabel("Размеры N для таблицы X:");
        table_x_size_label.setBounds(15, 350, 160, 25);
        main_frame.add(table_x_size_label);

        table_x_size_textfield = new JTextField("12");
        table_x_size_textfield.setBounds(175, 350, 40, 25);
        main_frame.add(table_x_size_textfield);

        table_x_size_button = new JButton("Установить");
        table_x_size_button.setToolTipText("Установить размер");
        table_x_size_button.setBounds(220, 350, 100, 25);
        table_x_size_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                try{
                    // if (table_x_model.getRowCount() > 0) {table_x_model.setRowCount(0);}
                    // if (table_x_model.getColumnCount() > 0){table_x_model.setColumnCount(0);}
                    if (selected_column != -1 || selected_row != -1
                    || table_x.isCellSelected(selected_row, selected_column)) {
                        table_x.clearSelection();
                        selected_column = -1;
                        selected_row = -1;
                    }
                    N = Integer.parseInt(table_x_size_textfield.getText());
                    if (N <= 0) throw new Exception();
                    
                }
                catch(Exception ex){
                    JOptionPane.showMessageDialog(main_frame,
                    "Недопустимое значение для размера",
                    "Ошибка рамера", JOptionPane.INFORMATION_MESSAGE);
                    return;
                }
                _initX();
            }
        });
        main_frame.add(table_x_size_button);


        table_x_change_label = new JLabel("Выбранная ячейка таблицы:");
        table_x_change_label.setBounds(15, 380, 170, 25);
        main_frame.add(table_x_change_label);

        table_x_change_textfield = new JTextField();
        table_x_change_textfield.setBounds(185, 380, 40, 25);
        main_frame.add(table_x_change_textfield);

        table_x_change_button = new JButton("Заменить");
        table_x_change_button.setBounds(230, 380, 90, 25);
        table_x_change_button.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e){
                try{
                    int temp = Integer.parseInt(table_x_change_textfield.getText());
                    table_x_model.setValueAt(temp, selected_row, selected_column);
                }
                catch(Exception ex){
                    JOptionPane.showMessageDialog(main_frame,
                    "Недопустимое значение для замены",
                    "Ошибка замены", JOptionPane.INFORMATION_MESSAGE);
                }
            }
        });
        main_frame.add(table_x_change_button);


        main_frame.setVisible(true);
    }

    private void _initX(){
        table_x_model.setRowCount(N);
        table_x_model.setColumnCount(N);
        table_x.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
        table_y_model.setRowCount(N);
        table_y_model.setColumnCount(N);
        table_y.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
        for (int i = 0; i < table_x_model.getColumnCount(); i++){
            TableColumn temp_col = table_x.getColumnModel().getColumn(i);
            table_x.setRowHeight(i, 25);
            temp_col.setPreferredWidth(25);
            temp_col = table_y.getColumnModel().getColumn(i);
            table_y.setRowHeight(i, 25);
            temp_col.setPreferredWidth(25);
        }
        for (int i = 0; i < table_x_model.getColumnCount(); i++){
            for (int j = 0; j < table_x_model.getRowCount(); j++){
                if (i+1 == j) {table_x_model.setValueAt(N, j, i);}
                else if (i == j && (i % 2 == 0)) {table_x_model.setValueAt(1, j, i);}
                else if (i == j && !(i % 2 == 0)) {table_x_model.setValueAt(N, j, i);}
                else {table_x_model.setValueAt(0, j, i);}
            }
        }
    }
}
