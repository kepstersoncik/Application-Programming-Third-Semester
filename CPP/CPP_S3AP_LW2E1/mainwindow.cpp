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
    second_rbutton = new QRadioButton("tg(x)", this);
    second_rbutton->setGeometry(110, 40, 50, 20);
    third_rbutton = new QRadioButton("x^3", this);
    third_rbutton->setGeometry(110, 65, 50, 20);

    box_layout->addWidget(first_rbutton);
    box_layout->addWidget(second_rbutton);
    box_layout->addWidget(third_rbutton);
    rbuttons_group->setLayout(box_layout);
}

MainWindow::~MainWindow()
{
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
        case 3: printResult(std::pow(x, 3)); break;
        case 4: printResult(calcXwithParam(x)); break;
    }
}

void MainWindow::printError(QString text){
    this->output_label->setText("Ошибка! " + text);
}

void MainWindow::printResult(double x){
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
    third_rbutton->setChecked(true); return std::pow(x, 3);
}
