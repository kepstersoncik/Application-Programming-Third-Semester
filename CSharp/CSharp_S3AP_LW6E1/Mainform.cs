namespace CSharp_S3AP_LW6E1;

public partial class MainForm : Form
{
    RichTextBox text_box;

    Font main_font;
    Font select_font;

    MenuStrip menu_bar;

    ToolStripMenuItem file_menu;
    ToolStripMenuItem font_menu;
    ToolStripMenuItem choose_main_font_menu;
    ToolStripMenuItem choose_select_font_menu;
    ToolStripMenuItem find_and_select_menu;
    ToolStripMenuItem replace_words_menu;

    Label desired_word_label;
    TextBox desired_word_textbox;
    Label replacement_word_label;
    TextBox replacement_word_textbox;

    String default_string = "He was a student. Was. was. waswas. fsafwasgasfg";
    String desired_substring = "was";
    String replacement_substring = "will be";
    public MainForm()
    {
        this.Size = new Size(500, 600);
        this.Text = "Лабораторная работа № 6";
        this.Load += new EventHandler(MainForm_Load);

        main_font = new Font("calibri", 12.0f, FontStyle.Regular);
        select_font = new Font("Impact", 12.0f, FontStyle.Bold);

        text_box = new RichTextBox();
        text_box.Size = new Size(455, 450);
        text_box.Location = new Point(15, 80);
        text_box.Multiline = true;
        text_box.Font = main_font;
        text_box.Text = default_string;
        text_box.KeyUp += new KeyEventHandler(textboxKeyHandler);
        this.Controls.Add(text_box);

        menu_bar = new MenuStrip();

        file_menu = new ToolStripMenuItem("Файл");
        find_and_select_menu = new ToolStripMenuItem("Выделить искомые слова");
        find_and_select_menu.Click += new EventHandler(findAndSelectMenuClick);
        file_menu.DropDownItems.Add(find_and_select_menu);
        replace_words_menu = new ToolStripMenuItem("Заменить искомые слова");
        replace_words_menu.Click += new EventHandler(replaceDesiredWord);
        file_menu.DropDownItems.Add(replace_words_menu);
        menu_bar.Items.Add(file_menu);

        font_menu = new ToolStripMenuItem("Шрифт");
        choose_main_font_menu = new ToolStripMenuItem("Выбрать основной шрифт");
        choose_main_font_menu.Click += new EventHandler(chooseMainFont);
        font_menu.DropDownItems.Add(choose_main_font_menu);
        choose_select_font_menu = new ToolStripMenuItem("Выбрать шрифт выделения");
        choose_select_font_menu.Click += new EventHandler(chooseSelectFont);
        font_menu.DropDownItems.Add(choose_select_font_menu);
        menu_bar.Items.Add(font_menu);

        this.Controls.Add(menu_bar);

        desired_word_label = new Label();
        desired_word_label.Text = "Искомое слово:";
        desired_word_label.Size = new Size(100, 25);
        desired_word_label.Location = new Point(15, 25);
        this.Controls.Add(desired_word_label);

        desired_word_textbox = new TextBox();
        desired_word_textbox.Text = desired_substring;
        desired_word_textbox.Size = new Size(100, 25);
        desired_word_textbox.Location = new Point(15, 50);
        this.Controls.Add(desired_word_textbox);

        replacement_word_label = new Label();
        replacement_word_label.Text = "Слово замены:";
        replacement_word_label.Size = new Size(100, 25);
        replacement_word_label.Location = new Point(125, 25);
        this.Controls.Add(replacement_word_label);

        replacement_word_textbox = new TextBox();
        replacement_word_textbox.Text = replacement_substring;
        replacement_word_textbox.Size = new Size(100, 25);
        replacement_word_textbox.Location = new Point(125, 50);
        this.Controls.Add(replacement_word_textbox);
    }

    private void textboxKeyHandler(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.F1:
                replaceOnCursor();
                break;
            case Keys.F2:
                replaceDesiredWord(null, null);
                break;
            case Keys.F3:
                clearSelectionOnCursor();
                break;
            case Keys.F4:
                clearSelection();
                break;
        }
    }

    private void clearSelectionOnCursor(){
        while (text_box.Text[text_box.SelectionStart + text_box.SelectionLength] != ' ' && text_box.Text[text_box.SelectionStart + text_box.SelectionLength] != '.'){
            if (text_box.TextLength == text_box.SelectionStart + text_box.SelectionLength+1){ break; }
            text_box.SelectionLength += 1;
        }
        text_box.SelectionFont = main_font;
    }

    private void replaceOnCursor()
    {
        String temp = replacement_word_textbox.Text;
        if (temp == "") { return; }
        replacement_substring = temp;
        temp = desired_word_textbox.Text;
        if (temp == "") { return; }
        desired_substring = temp;
        int index = text_box.SelectionStart;
        String substr = text_box.Text.Substring(index, desired_substring.Length);
        if (substr.ToLower() != desired_substring.ToLower()) { return; }
        int caret_pos = 0;
        if (index != 0)
        {
            if (text_box.Text[index - 1] != ' ') { return; }
        }
        if (text_box.Text[index + desired_substring.Length] != ' ' && text_box.Text[index + desired_substring.Length] != '.' && text_box.Text[index + desired_substring.Length] != ',') { return; }
        text_box.SelectionStart = index;
        text_box.SelectionLength = desired_substring.Length;
        text_box.SelectedText = replacement_substring;
        caret_pos = index + replacement_substring.Length;
        text_box.Select(caret_pos, 0);
    }

    private void replaceDesiredWord(object sender, EventArgs e)
    {
        String temp = replacement_word_textbox.Text;
        if (temp == "") { return; }
        replacement_substring = temp;
        temp = desired_word_textbox.Text;
        if (temp == "") { return; }
        desired_substring = temp;
        int index = 0;
        int caret_pos = 0;
        while (index < text_box.Text.LastIndexOf(desired_substring))
        {
            int pos = text_box.Find(desired_substring, index, RichTextBoxFinds.None);
            if (pos == -1) { break; }
            index = pos + desired_substring.Length;
            if (pos != 0)
            {
                if (text_box.Text[pos - 1] != ' ') { continue; }
            }
            if (text_box.Text[pos + desired_substring.Length] != ' ' && text_box.Text[pos + desired_substring.Length] != '.' && text_box.Text[pos + desired_substring.Length] != ',') { continue; }
            text_box.SelectionStart = pos;
            text_box.SelectionLength = desired_substring.Length;
            text_box.SelectedText = replacement_substring;
            caret_pos = pos + replacement_substring.Length;
        }
        text_box.Select(caret_pos, 0);
    }

    private void findAndSelectMenuClick(object sender, EventArgs e)
    {
        String temp = desired_word_textbox.Text;
        if (temp == "")
        {
            clearSelection();
        }
        desired_substring = temp;
        clearSelection();
        findAndSelectWords(desired_substring);
    }

    private void clearSelection()
    {
        text_box.Select(0, text_box.TextLength);
        text_box.SelectionFont = main_font;
    }

    private void findAndSelectWords(String str)
    {
        int index = 0;
        int caret_pos = 0;
        while (index < text_box.Text.LastIndexOf(str))
        {
            int pos = text_box.Find(str, index, RichTextBoxFinds.None);
            if (pos == -1) { break; }
            index = pos + str.Length;
            if (pos != 0)
            {
                if (text_box.Text[pos - 1] != ' ') { continue; }
            }
            if (text_box.Text[pos + str.Length] != ' ' && text_box.Text[pos + str.Length] != '.' && text_box.Text[pos + str.Length] != ',') { continue; }
            text_box.SelectionStart = pos;
            text_box.SelectionLength = str.Length;
            text_box.SelectionFont = select_font;
            caret_pos = index;
        }
        text_box.Select(caret_pos, 0);
    }

    private void chooseMainFont(object sender, EventArgs e)
    {
        Font temp = getFont();
        if (temp != null)
        {
            main_font = temp;
            text_box.Font = main_font;
        }
    }

    private void chooseSelectFont(object sender, EventArgs e)
    {
        Font temp = getFont();
        if (temp != null)
        {
            select_font = temp;
            findAndSelectWords(desired_substring);
        }
    }

    private Font getFont()
    {
        FontDialog dialog = new FontDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            return dialog.Font;
        }
        return null;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Font temp = getFont();
        if (temp != null)
        {
            main_font = temp;
            text_box.Font = main_font;
        }
        findAndSelectWords(desired_substring);
    }
}
