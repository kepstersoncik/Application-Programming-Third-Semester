#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    this->setWindowTitle("Лабораторная работа № 6");
    this->setGeometry(50, 50, 500, 600);
    this->setMinimumSize(this->size());
    this->setMaximumSize(this->size());

    menu_bar = new QMenuBar(this);
    menu_bar->setGeometry(0, 0, this->width(), 25);

    file_menu = new QMenu("Файл");
    find_and_select_action = new QAction("Найти и выделить слово");
    connect(find_and_select_action, SIGNAL(triggered()), this, SLOT(findAndChangeFont()));
    file_menu->addAction(find_and_select_action);
    replace_words = new QAction("Заменить искомое слово");
    connect(replace_words, SIGNAL(triggered()), this, SLOT(findAndReplace()));
    file_menu->addAction(replace_words);

    font_menu = new QMenu("Шрифт");
    pick_main_font_action = new QAction("Выбрать основной шрифт");
    connect(pick_main_font_action, SIGNAL(triggered()), this, SLOT(pickAndSetMainFont()));
    font_menu->addAction(pick_main_font_action);
    pick_select_font_action = new QAction("Выбрать шрифт выделения");
    connect(pick_select_font_action, SIGNAL(triggered()), this, SLOT(pickAndSetSelectFont()));
    font_menu->addAction(pick_select_font_action);

    menu_bar->addMenu(file_menu);
    menu_bar->addMenu(font_menu);

    desired_word_label = new QLabel("Искомое слово:", this);
    desired_word_label->setGeometry(15, 30, 100, 25);

    desired_word_lineedit = new QLineEdit(desired_substring, this);
    desired_word_lineedit->setGeometry(120, 30, 50, 25);

    replacement_word_label = new QLabel("Слово для замены:", this);
    replacement_word_label->setGeometry(180, 30, 110, 25);

    replacement_word_lineedit = new QLineEdit(replacement_substring, this);
    replacement_word_lineedit->setGeometry(295, 30, 50, 25);

    main_font = this->font();
    main_font = pickFont();

    select_font = QFont("impact");

    text_edit = new QTextEdit(this);
    text_edit->setGeometry(15, 60, 470, 505);
    text_edit->setFont(main_font);
    text_edit->setText(default_string);
    text_edit->installEventFilter(this);
    findAndSelect("was");
}

QFont MainWindow::pickFont(){
    bool font_is_picked;
    QFont font = QFontDialog::getFont(
                &font_is_picked,
                QFont("calibri"),
                this,
                "Выбор шрифта"
                );
    if (font_is_picked){
        this->statusBar()->showMessage("Шрифт выбран");
        return font;
    }
    else{
        this->statusBar()->showMessage("Шрифт не выбран");
        return QFont("calibri");
    }
}

void MainWindow::pickAndSetMainFont(){
    main_font = pickFont();
    text_edit->setFont(main_font);
}

void MainWindow::pickAndSetSelectFont(){
    select_font = pickFont();
    findAndChangeFont();
}

void MainWindow::findAndSelect(const QString &str){
    bool found = false;
    QTextDocument *document = text_edit->document();
    QTextCursor cursor(document);
    QTextCharFormat format;
    format.setFont(select_font);
    while (!cursor.isNull() && !cursor.atEnd()){
        cursor = document->find(str, cursor, QTextDocument::FindWholeWords);
        if (!cursor.isNull()){
            found = true;
            cursor.movePosition(QTextCursor::WordRight,
                                QTextCursor::KeepAnchor);
            cursor.mergeCharFormat(format);
        }
        if (found == false){
            this->statusBar()->showMessage("Искомое слово не найдено");
        }
    }
}

void MainWindow::replaceOnCursor(){
    bool found = false;
    replacement_substring = replacement_word_lineedit->text();
    QTextDocument *document = text_edit->document();
    QTextCursor cursor(document);
    cursor.setPosition(text_edit->textCursor().position());
    cursor = document->find(desired_substring, cursor, QTextDocument::FindWholeWords);
    if (!cursor.isNull()){
        found = true;
        cursor.insertText(replacement_substring);
    }
    if (found == false){
        this->statusBar()->showMessage("Искомое слово не найдено");
    }
}

void MainWindow::setMainFontOnCursor(){
    QTextCursor cursor = text_edit->textCursor();
    if (!cursor.atEnd()){
        cursor.setPosition(cursor.position()+1, QTextCursor::KeepAnchor);
    }
    while(cursor.selectedText().back() != ' ' && !cursor.atEnd()){
        cursor.setPosition(cursor.position()+1, QTextCursor::KeepAnchor);
    }
    QTextCharFormat format;
    format.setFont(main_font);
    cursor.mergeCharFormat(format);
}

void MainWindow::findAndChangeFont(){
    QString temp = desired_word_lineedit->text();
    if (temp == ""){
        this->statusBar()->showMessage("Выделение убрано!");
        removeSelection();
        return;
    }
    desired_substring = temp;
    removeSelection();
    findAndSelect(desired_substring);
}

void MainWindow::removeSelection(){
    QTextCursor temp = text_edit->textCursor();
    text_edit->selectAll();
    QTextCharFormat format;
    format.setFont(main_font);
    text_edit->textCursor().mergeCharFormat(format);
    text_edit->setTextCursor(temp);
    text_edit->textCursor().clearSelection();
}

bool MainWindow::eventFilter(QObject *obj, QEvent *e){
    if (obj != this->text_edit || e->type() != QEvent::KeyRelease) return false;
    QKeyEvent *key_event = static_cast<QKeyEvent *>(e);
    if (key_event->key() == Qt::Key_F1){
        replaceOnCursor();
    }
    else if (key_event->key() == Qt::Key_F2){
        findAndReplace();
    }
    else if (key_event->key() == Qt::Key_F3){
        setMainFontOnCursor();
    }
    else if (key_event->key() != Qt::Key_Left && key_event->key() != Qt::Key_Right){
        removeSelection();
    }
    return true;
}

void MainWindow::findAndReplace(){
    bool found = false;
    replacement_substring = replacement_word_lineedit->text();
    QTextDocument *document = text_edit->document();
    QTextCursor cursor(document);
    while (!cursor.isNull() && !cursor.atEnd()){
        cursor = document->find(desired_substring, cursor, QTextDocument::FindWholeWords);
        if (!cursor.isNull()){
            found = true;
            cursor.insertText(replacement_substring);
        }
        if (found == false){
            this->statusBar()->showMessage("Искомое слово не найдено");
        }
    }
}

MainWindow::~MainWindow()
{
}

