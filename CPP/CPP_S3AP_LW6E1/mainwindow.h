#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFontDialog>
#include <QStatusBar>
#include <QTextEdit>
#include <QLabel>
#include <QLineEdit>
#include <QKeyEvent>

#include <QMenuBar>
#include <QMenu>
#include <QAction>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QMenuBar *menu_bar;

    QMenu *file_menu;
    QAction *find_and_select_action;
    QAction *replace_words;

    QMenu *font_menu;
    QAction *pick_main_font_action;
    QAction *pick_select_font_action;

    QLabel *desired_word_label;
    QLineEdit *desired_word_lineedit;

    QLabel *replacement_word_label;
    QLineEdit *replacement_word_lineedit;

    QFont main_font;
    QFont select_font;

    QString default_string = "He was a student. Was. was. waswas. fsafwasgasfg";
    QString desired_substring = "was";
    QString replacement_substring = "will be";
    QTextEdit *text_edit;
public:
    MainWindow(QWidget *parent = nullptr);
    QFont pickFont();
    void findAndSelect(const QString &);
    void removeSelection();
    void replaceOnCursor();
    void setMainFontOnCursor();
    bool eventFilter(QObject*, QEvent*);
    ~MainWindow();
private slots:
    void findAndChangeFont();
    void findAndReplace();
    void pickAndSetMainFont();
    void pickAndSetSelectFont();
};
#endif // MAINWINDOW_H
