#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    setWindowTitle("Лабораторная работа № 2");
    setMinimumSize(250, 140);

    discription_label = new QLabel("Значение x:", this);
    discription_label->setGeometry(15, 15, 65, 30);

    x_input = new QLineEdit("", this);
    x_input->setGeometry(85, 15, 35, 30);

    calc_button = new QPushButton("Вычислить", this);
    calc_button->setGeometry(15, 60, 105, 30);
    connect(calc_button, SIGNAL(clicked()), this, SLOT(getXandCalc()));

    output_label = new QLabel("", this);
    output_label->setGeometry(15, 95, 220, 30);

    rbuttons_group = new QGroupBox(this);
    rbuttons_group->setGeometry(125, 15, 110, 75);
    box_layout = new QVBoxLayout();

    first_rbutton = new QRadioButton("sin(x)+cos(x)", this);
    first_rbutton->setGeometry(110, 15, 50, 20);
    connect(first_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
    second_rbutton = new QRadioButton("tg(x)", this);
    second_rbutton->setGeometry(110, 40, 50, 20);
    connect(second_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
    third_rbutton = new QRadioButton("x^3", this);
    third_rbutton->setGeometry(110, 65, 50, 20);
    connect(third_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));

    box_layout->addWidget(first_rbutton);
    box_layout->addWidget(second_rbutton);
    box_layout->addWidget(third_rbutton);
    rbuttons_group->setLayout(box_layout);

    double_checkbox = new QCheckBox("Удвоить", this);
    double_checkbox->setGeometry(125, 90, 75, 20);
    connect(double_checkbox, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
}

MainWindow::~MainWindow()
{
}

double MainWindow::myPow(double x, int n){
    if (n == 0) return 1.0;
    if (n % 2 != 0) return myPow(x, n-1) * x;
    double y = myPow(x, n/2);
    return y * y;
}

void MainWindow::getXandCalc(){
    double x;
    try{
        std::string temp = QString(this->x_input->text()).toStdString();
        x = stod(temp);
    }
    catch(std::exception){
        printError("Не удается получить данные!");
        return;
    }
    switch (getActionNumber()){
        case 1: x = x * (3.14 / 180); printResult(std::sin(x)+std::cos(x)); break;
        case 2: x = x * (3.14 / 180); printResult(std::tan(x)); break;
        case 3: printResult(myPow(x, 3)); break;
        case 4: printResult(calcXwithParam(x)); break;
    }
}

void MainWindow::printError(QString text){
    this->output_label->setText("Ошибка! " + text);
}

void MainWindow::printResult(double x){
    if (double_checkbox->isChecked()) { x*= 2; }
    this->output_label->setText(QString("%1").arg(x));
}

int MainWindow::getActionNumber(){
    if(first_rbutton->isChecked()){ return 1; }
    else if(second_rbutton->isChecked()) { return 2; }
    else if(third_rbutton->isChecked()) { return 3; }
    return 4;
}

double MainWindow::calcXwithParam(double x){
    if (x <= 0) { x = x * (3.14 / 180); first_rbutton->setChecked(true); return std::sin(x) + std::cos(x); }
    else if (0 < x && x < 1) { x = x * (3.14 / 180); second_rbutton->setChecked(true); return std::tan(x); }
    third_rbutton->setChecked(true); return myPow(x, 3);
}
