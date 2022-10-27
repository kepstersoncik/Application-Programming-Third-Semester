#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QTableWidget>
#include <QLabel>
#include <QPushButton>
#include <QLineEdit>
#include <QMessageBox>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QLabel *table_x_label;
    QTableWidget *table_widget_x;

    QLabel *table_y_label;
    QTableWidget *table_widget_y;
    QPushButton *calculate_y;

    QLabel *table_x_size_label;
    QPushButton *table_x_size_button;
    QLineEdit *table_x_size_line;

    QLabel *table_x_change_label;
    QPushButton *table_x_change_button;
    QLineEdit *table_x_change_line;

    QMessageBox *table_size_err;

    QMessageBox *table_change_err;

    int N;

    QTableWidgetItem *selected;

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
private:
    void _initXAndY();
private slots:
    void getN();
    void saveSelectedCellAndPrint();
    void changeSelectedX();
    void calculateYAndPrint();
};
#endif // MAINWINDOW_H
