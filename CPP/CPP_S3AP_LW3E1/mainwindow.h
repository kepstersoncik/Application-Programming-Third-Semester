#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "xyarrays.h"

#include <QMainWindow>

#include <QMenuBar>
#include <QMenu>
#include <QAction>

#include <QListWidget>
#include <QComboBox>
#include <QLabel>

#include <QFileDialog>
#include <QFile>
#include <QTextStream>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    XYArrays *arrays;

    QMenuBar *menu_bar;

    QMenu *file_menu;
    QAction *create_new;
    QAction *load;
    QAction *save;
    QAction *exit;

    QMenu *operation_menu;
    QAction *calculate;

    QLabel *x_list_label;
    QListWidget *x_list;

    QLabel *y_combobox_label;
    QComboBox *y_combobox;
public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
private slots:
    void calculateX();
    void calculateY();
    void load_file();
    void save_file();
public slots:
    void exit_s();
private:
    void printX();
    void printY();
    bool isParseble(QString);
    double parseToDouble(QString);
};
#endif // MAINWINDOW_H
