#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    setWindowTitle("Лабораторная работа № 2");
    setMinimumSize(250, 140);
    grid = new QGridLayout();
    QWidget *window = new QWidget();
            window->setLayout(grid);
            setCentralWidget(window);


    discription_label = new QLabel("Значение x:");
    grid->addWidget(discription_label, 0, 0);

    x_input = new QLineEdit("");
    grid->addWidget(x_input, 0, 1);

    calc_button = new QPushButton("Вычислить", this);
    connect(calc_button, SIGNAL(clicked()), this, SLOT(getXandCalc()));
    grid->addWidget(calc_button, 1, 0);

    output_label = new QLabel("", this);
    grid->addWidget(output_label, 1, 1);

    rbuttons_group = new QGroupBox(this);
    box_layout = new QVBoxLayout();

    first_rbutton = new QRadioButton("sin(x)+cos(x)", this);
    connect(first_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
    second_rbutton = new QRadioButton("tg(x)", this);
    connect(second_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
    third_rbutton = new QRadioButton("x^3", this);
    connect(third_rbutton, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));

    box_layout->addWidget(first_rbutton);
    box_layout->addWidget(second_rbutton);
    box_layout->addWidget(third_rbutton);
    rbuttons_group->setLayout(box_layout);
    grid->addWidget(rbuttons_group, 0, 3, 3, 1);


    double_checkbox = new QCheckBox("Удвоить", this);
    connect(double_checkbox, SIGNAL(toggled(bool)), this, SLOT(getXandCalc()));
    grid->addWidget(double_checkbox, 3, 3);
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
