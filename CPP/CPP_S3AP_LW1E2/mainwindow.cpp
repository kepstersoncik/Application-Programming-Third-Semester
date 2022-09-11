#include "mainwindow.h"



MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    setWindowTitle("Лабораторная работа № 1");
    setMinimumSize(365, 195);

    description = new QLabel("Программа производит расчет периметра"
                             " треугольника\nпо координатам его вершин.", this);
    description->setGeometry(15, 15, 470, 30);

    description1 = new QLabel("Координата x", this);
    description1->setGeometry(165, 50, 90, 20);

    description2 = new QLabel("Координата y", this);
    description2->setGeometry(260, 50, 90, 20);

    apex_A_label = new QLabel("Координаты вершины А", this);
    apex_A_label->setGeometry(15, 75, 145, 20);

    apex_A_x_le = new QLineEdit(this);
    apex_A_x_le->setGeometry(165, 75, 90, 20);
    connect(apex_A_x_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    apex_A_y_le = new QLineEdit(this);
    apex_A_y_le->setGeometry(260, 75, 90, 20);
    connect(apex_A_y_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    apex_B_label = new QLabel("Координаты вершины B", this);
    apex_B_label->setGeometry(15, 100, 145, 20);

    apex_B_x_le = new QLineEdit(this);
    apex_B_x_le->setGeometry(165, 100, 90, 20);
    connect(apex_B_x_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    apex_B_y_le = new QLineEdit(this);
    apex_B_y_le->setGeometry(260, 100, 90, 20);
    connect(apex_B_y_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    apex_C_label = new QLabel("Координаты вершины C", this);
    apex_C_label->setGeometry(15, 125, 145, 20);

    apex_C_x_le = new QLineEdit(this);
    apex_C_x_le->setGeometry(165, 125, 90, 20);
    connect(apex_C_x_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    apex_C_y_le = new QLineEdit(this);
    apex_C_y_le->setGeometry(260, 125, 90, 20);
    connect(apex_C_y_le, SIGNAL(editingFinished()), this, SLOT(calcPerimetrNDisplay()));

    calc_button = new QPushButton("Завершение программы", this);
    QFont font = calc_button->font();
    font.setPointSize(7);
    calc_button->setFont(font);
    calc_button->setGeometry(15, 150, 115, 30);
    connect(calc_button, SIGNAL(clicked()), this, SLOT(endOnButton()));

    result_label = new QLabel(this);
    result_label->setGeometry(135, 150, 350, 30);
}

MainWindow::~MainWindow()
{
}

double MainWindow::calcSide(double x1, double x2, double y1, double y2){
    return std::abs(sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2)));
}

void MainWindow::calcPerimetrNDisplay(){
    double A_x, A_y, B_x, B_y, C_x, C_y;
    std::string temp;
    bool flag = true;
    try{
        temp = QString(this->apex_A_x_le->text()).toStdString();
        A_x = stod(temp);
    }
    catch (std::exception){
        if (this->apex_A_x_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_A_x_le->setFocus();
        return;
        }
    }
    try{
        temp = QString(this->apex_A_y_le->text()).toStdString();
        A_y = stod(temp);
    }
    catch (std::exception){
        if (this->apex_A_y_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_A_y_le->setFocus();
        return;
        }
    }
    try{
        temp = QString(this->apex_B_x_le->text()).toStdString();
        B_x = stod(temp);
    }
    catch (std::exception){
        if (this->apex_B_x_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_B_x_le->setFocus();
        return;
        }
    }
    try{
        temp = QString(this->apex_B_y_le->text()).toStdString();
        if (temp == "") errorDisplay("Не все поля запонены!");
        B_y = stod(temp);
    }
    catch (std::exception){
        if (this->apex_B_y_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_B_y_le->setFocus();
        return;
        }
    }
    try{
        temp = QString(this->apex_C_x_le->text()).toStdString();
        if (temp == "") errorDisplay("Не все поля запонены!");
        C_x = stod(temp);
    }
    catch (std::exception){
        if (this->apex_C_x_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_C_x_le->setFocus();
        return;
        }
    }
    try{
        temp = QString(this->apex_C_y_le->text()).toStdString();
        if (temp == "") errorDisplay("Не все поля запонены!");
        C_y = stod(temp);
    }
    catch (std::exception){
        if (this->apex_C_y_le->text() == ""){
            errorDisplay("Не все поля запонены!");
            flag = false;
        }
        else{
        errorDisplay("Не удалось считать данные!\n"
                     "Проверьте правильность ввода!");
        this->apex_C_y_le->setFocus();
        return;
        }
    }
    if (!flag) return;
    double AB = calcSide(A_x, B_x, A_y, B_y);
    double BC = calcSide(B_x, C_x, B_y, C_y);
    double CA = calcSide(C_x, A_x, C_y, A_y);
    if (AB + BC <= CA || AB + CA <= BC || BC + CA <= AB){
        errorDisplay("Треугольник не существует!");
    }
    else{
        QString result = QString("%1").arg(AB + BC + CA);
        this->result_label->setText(result);
    }
}

void MainWindow::errorDisplay(QString text){
    this->result_label->setText("Ошибка! " + text);
}

void MainWindow::endOnButton(){
    exit(0);
}

