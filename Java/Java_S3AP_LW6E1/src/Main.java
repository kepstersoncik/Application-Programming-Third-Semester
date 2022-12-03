import javax.swing.*;
import javax.swing.border.BevelBorder;
import javax.swing.text.Caret;
import javax.swing.text.SimpleAttributeSet;
import javax.swing.text.StyleConstants;
import javax.swing.text.StyledDocument;

import java.awt.*;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.ActionEvent;

public class Main extends JPanel{
    JScrollPane textarea_scrollpane;
    JTextPane text_area;

    JPanel status_panel;
    JLabel status_label;

    JLabel desired_word_label;
    JTextField desired_word_textfield;

    JLabel replacement_word_label;
    JTextField replacement_word_textfield;
    JButton replacement_button;

    String default_string = "He was a student. Was. was. waswas. fsafwasgasfg";
    String desired_substring = "was";
    String replacement_substring = "will be";

    Font main_font;
    Font select_font;

    Main(){
        main_font = new Font("calibri", 1, 12);
        select_font = new Font("impact", Font.BOLD, 12);

        textarea_scrollpane = new JScrollPane();
        textarea_scrollpane.setBounds(15, 60, 455, 470);

        text_area = new JTextPane();
        text_area.setText(default_string);
        text_area.setFont(main_font);
        textarea_scrollpane.getViewport().add(text_area);
        text_area.setEditable(true);
        text_area.addKeyListener(new KeyListener(){
            @Override
            public void keyTyped(KeyEvent e){} 

            @Override
            public void keyPressed(KeyEvent e) {
                switch(e.getKeyCode()){
                    case KeyEvent.VK_F1:
                        replaceOnCursor();
                        findAndSelectWords(desired_substring);
                        findAndSelectWords(replacement_substring);
                        break;
                    case KeyEvent.VK_F2:
                        replaceDisiredSubstring();
                        findAndSelectWords(replacement_substring);
                        break;
                    case KeyEvent.VK_F3:
                        clearSelectionOnCursor();
                        break;
                    case KeyEvent.VK_F4:
                        clearSelection();
                        break;
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {}
        });
        add(textarea_scrollpane);

        status_panel = new JPanel();
        status_panel.setBorder(new BevelBorder(BevelBorder.LOWERED));
        status_panel.setBounds(0, 540, 500, 20);
        status_panel.setLayout(new BoxLayout(status_panel, BoxLayout.X_AXIS));
        add(status_panel);
        status_label = new JLabel();
        status_label.setHorizontalAlignment(SwingConstants.LEFT);
        status_panel.add(status_label);
        status_panel.setVisible(true);

        desired_word_label = new JLabel("Искомое слово:");
        desired_word_label.setBounds(15, 10, 100, 20);
        add(desired_word_label);
        desired_word_textfield = new JTextField(desired_substring);
        desired_word_textfield.setBounds(15, 35, 100, 20);
        desired_word_textfield.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e){
                desired_substring = desired_word_textfield.getText();
                clearSelection();
                findAndSelectWords(desired_substring);
            }
        });
        add(desired_word_textfield);

        replacement_word_label = new JLabel("Слово для подстановки:");
        replacement_word_label.setFont(new Font(replacement_word_label.getFont().getFontName(), 1, 9));
        replacement_word_label.setBounds(125, 10, 120, 20);
        add(replacement_word_label);
        replacement_word_textfield = new JTextField(replacement_substring);
        replacement_word_textfield.setBounds(125, 35, 120, 20);
        add(replacement_word_textfield);
        replacement_button = new JButton("Заменить Искомое слово");
        replacement_button.setBounds(265, 35, 205, 20);
        replacement_button.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e){
                replaceDisiredSubstring();
                findAndSelectWords(replacement_substring);
            }
        });
        add(replacement_button);


        String[] font_names = GraphicsEnvironment.getLocalGraphicsEnvironment().getAvailableFontFamilyNames();
        JComboBox main_font_combobox = new JComboBox<String>(font_names);
        main_font_combobox.setBounds(265, 5, 100, 20);
        main_font_combobox.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e){
                main_font = new Font(main_font_combobox.getSelectedItem().toString(), 1, text_area.getFont().getSize());
                text_area.setFont(main_font);
                status_label.setText("Шрифт " + main_font.getFontName() + " выбран");
                findAndSelectWords(desired_substring);
            }
        });
        add(main_font_combobox);
        JComboBox select_font_combobox = new JComboBox<String>(font_names);
        select_font_combobox.setBounds(370, 5, 100, 20);
        select_font_combobox.addActionListener(new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent e){
                select_font = new Font(select_font_combobox.getSelectedItem().toString(), Font.BOLD, select_font.getSize());
                status_label.setText("Шрифт " + main_font.getFontName() + " выбран");
                findAndSelectWords(desired_substring);
            }
        });
        add(select_font_combobox);

        findAndSelectWords(desired_substring);
    }

    void replaceOnCursor(){
        int pos = text_area.getCaretPosition();
        String text = text_area.getText();
        if (text.toUpperCase().indexOf(desired_substring.toUpperCase()) != pos){ return; }
        if ((text.charAt(pos+desired_substring.length()) != ' ' && text.charAt(pos+desired_substring.length()) != '.')){ return; }
        if (pos-1 < 0 || text.charAt(pos-1) != ' '){ return; }
        text = text.substring(0, pos) + replacement_substring + text.substring(pos+desired_substring.length());
        text_area.setText(text);
        text_area.setCaretPosition(pos);;
    }

    void replaceDisiredSubstring(){
        String text = text_area.getText();
        int pos = 0;
        while ((pos = text.toUpperCase().indexOf(desired_substring.toUpperCase(), pos)) >= 0){
            if ((text.charAt(pos+desired_substring.length()) == ' ' || text.charAt(pos+desired_substring.length()) == '.')){
                if (pos-1 < 0 || text.charAt(pos-1) != ' '){ pos += desired_substring.length(); continue; }
                text = text.substring(0, pos) + replacement_substring + text.substring(pos+desired_substring.length());
            }
            pos += desired_substring.length();
        }
        text_area.setText(text);
    }

    void clearSelectionOnCursor(){
        int pos = text_area.getCaretPosition();
        int end_pos = pos+1;
        StyledDocument style_document = text_area.getStyledDocument();
        SimpleAttributeSet atribute_set = new SimpleAttributeSet();
        StyleConstants.setFontSize(atribute_set, main_font.getSize());
        StyleConstants.setBold(atribute_set, main_font.isBold());
        StyleConstants.setFontFamily(atribute_set, main_font.getFamily());
        while(end_pos != text_area.getText().length() && text_area.getText().charAt(end_pos) != ' ' && text_area.getText().charAt(end_pos) != '.'){
            end_pos++;
        }
        style_document.setCharacterAttributes(pos, end_pos-pos, atribute_set, true);
    }

    void clearSelection(){
        StyledDocument style_document = text_area.getStyledDocument();
        SimpleAttributeSet atribute_set = new SimpleAttributeSet();
        StyleConstants.setFontSize(atribute_set, main_font.getSize());
        StyleConstants.setBold(atribute_set, main_font.isBold());
        StyleConstants.setFontFamily(atribute_set, main_font.getFamily());
        style_document.setCharacterAttributes(0, text_area.getText().length(), atribute_set, true);
    }

    void findAndSelectWords(String str){
        StyledDocument style_document = text_area.getStyledDocument();
        SimpleAttributeSet atribute_set = new SimpleAttributeSet();
        StyleConstants.setFontSize(atribute_set, select_font.getSize());
        StyleConstants.setBold(atribute_set, true);
        StyleConstants.setFontFamily(atribute_set, select_font.getFamily());
        int pos = 0;
        while ((pos=text_area.getText().toUpperCase().indexOf(str.toUpperCase(), pos)) >= 0){
            if ((text_area.getText().charAt(pos+str.length()) == ' ' || text_area.getText().charAt(pos+str.length()) == '.')){
                if (pos-1 < 0 || text_area.getText().charAt(pos-1) == ' '){
                    style_document.setCharacterAttributes(pos, str.length(), atribute_set, true);
                }
            }
            pos += str.length();
        }
    }

    public static void main(String[] args){
        try{
            JFrame main = new JFrame();
            main.setBounds(15, 15, 500, 600);
            main.setTitle("Лабораторная работа № 6");
            main.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            main.setLayout(null);

            Main main_panel = new Main();
            main_panel.setBounds(0, 0, main.getWidth(), main.getHeight());
            main_panel.setLayout(null);
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