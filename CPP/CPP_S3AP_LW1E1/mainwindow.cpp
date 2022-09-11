#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QString>
#include <string>
#include <cmath>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

double MainWindow::calcSide(double x1, double x2, double y1, double y2){
    return std::abs(sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2)));
}

void MainWindow::calcPerimetrNDisplay(){
    double A_x, A_y, B_x, B_y, C_x, C_y;
    std::string temp;
    try{
        temp = QString(ui->apex_A_x_le->text()).toStdString();
        A_x = stod(temp);
        temp = QString(ui->apex_A_y_le->text()).toStdString();
        A_y = stod(temp);
        temp = QString(ui->apex_B_x_le->text()).toStdString();
        B_x = stod(temp);
        temp = QString(ui->apex_B_y_le->text()).toStdString();
        B_y = stod(temp);
        temp = QString(ui->apex_C_x_le->text()).toStdString();
        C_x = stod(temp);
        temp = QString(ui->apex_C_y_le->text()).toStdString();
        C_y = stod(temp);
    }
    catch (std::exception){
        errorDisplay("Не удалось считать данные! Проверьте правильность ввода!");
        return;
    }
    double AB = calcSide(A_x, B_x, A_y, B_y);
    double BC = calcSide(B_x, C_x, B_y, C_y);
    double CA = calcSide(C_x, A_x, C_y, A_y);
    if (AB + BC <= CA || AB + CA <= BC || BC + CA <= AB){
        errorDisplay("Треугольник не существует!");
    }
    else{
        QString result = QString("%1").arg(AB + BC + CA);
        ui->result_label->setText(result);
    }
}

void MainWindow::errorDisplay(QString text){
    ui->result_label->setText("Ошибка! " + text);
}




