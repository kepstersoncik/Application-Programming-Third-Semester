#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

#include <QLineEdit>
#include <QPushButton>
#include <QLabel>
#include <QRadioButton>
#include <QGroupBox>
#include <QVBoxLayout>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QLineEdit *x_input;
    QPushButton *calc_button;
    QLabel *output_label;
    QLabel *discription_label;

    QGroupBox *rbuttons_group;
    QVBoxLayout *box_layout;
    QRadioButton *first_rbutton;
    QRadioButton *second_rbutton;
    QRadioButton *third_rbutton;

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
public slots:
    void getXandCalc();
private:
    void printError(QString);
    void printResult(double);
    int getActionNumber();
    double calcXwithParam(double);
};
#endif // MAINWINDOW_H
