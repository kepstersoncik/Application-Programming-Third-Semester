#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QLineEdit>
#include <QPushButton>
#include <QLabel>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QLabel *description, *description1, *description2,
    *apex_A_label, *apex_B_label, *apex_C_label, *result_label;
    QLineEdit *apex_A_x_le, *apex_A_y_le, *apex_B_x_le,
    *apex_B_y_le, *apex_C_x_le, *apex_C_y_le;
    QPushButton *calc_button;


public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
public slots:
    void calcPerimetrNDisplay();
    void endOnButton();
private:
    double calcSide(double, double, double, double);
    void errorDisplay(QString);
};
#endif // MAINWINDOW_H
