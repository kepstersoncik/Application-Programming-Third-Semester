#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    N = -1;
    selected = nullptr;

    setWindowTitle("Лабораторная работа № 4");
    setMinimumSize(900, 550);

    table_x_label = new QLabel("Таблица X", this);
    table_x_label->setGeometry(15, 15, 80, 25);
    table_widget_x = new QTableWidget(this);
    table_widget_x->setGeometry(15, 40, 425, 425);
    connect(table_widget_x, SIGNAL(cellClicked(int,int)), this, SLOT(saveSelectedCellAndPrint()));

    table_y_label = new QLabel("Таблица Y", this);
    table_y_label->setGeometry(460, 15, 80, 25);
    table_widget_y = new QTableWidget(this);
    table_widget_y->setGeometry(460, 40, 425, 425);
    calculate_y = new QPushButton("Вычислить Y", this);
    calculate_y->setGeometry(460, 470, 80, 25);
    connect(calculate_y, SIGNAL(clicked(bool)), this, SLOT(calculateYAndPrint()));

    table_x_size_label = new QLabel("Размеры N для таблицы X:", this);
    table_x_size_label->setGeometry(15, 470, 150, 25);
    table_x_size_line = new QLineEdit("10", this);
    table_x_size_line->setGeometry(165, 470, 40, 25);
    table_x_size_button = new QPushButton("Установить размер", this);
    table_x_size_button->setGeometry(210, 470, 115, 25);
    connect(table_x_size_button, SIGNAL(clicked(bool)), this, SLOT(getN()));

    table_x_change_label = new QLabel("Выбранная ячейка таблицы X:", this);
    table_x_change_label->setGeometry(15, 500, 175, 25);
    table_x_change_line = new QLineEdit(this);
    table_x_change_line->setGeometry(190, 500, 40, 25);
    table_x_change_button = new QPushButton("Заменить", this);
    table_x_change_button->setGeometry(235, 500, 80, 25);
    connect(table_x_change_button, SIGNAL(clicked(bool)), this, SLOT(changeSelectedX()));

    table_size_err = new QMessageBox(this);
    table_size_err->setText("Невозможный размер таблицы");
    table_size_err->setWindowTitle("Ошибка рамера таблицы");

    table_change_err = new QMessageBox(this);
    table_change_err->setText("Неподходящее значение для замены");
    table_change_err->setWindowTitle("Ошибка замены значения");
}

void MainWindow::_initXAndY(){
    table_widget_x->setRowCount(N);
    table_widget_x->setColumnCount(N);
    table_widget_y->setRowCount(N);
    table_widget_y->setColumnCount(N);
    for (int i = 0; i < N; i++){
        table_widget_x->setColumnWidth(i, 40);
        table_widget_x->setRowHeight(i, 40);
        table_widget_y->setColumnWidth(i, 40);
        table_widget_y->setRowHeight(i, 40);
    }
    for (int i = 0; i < N; i++){
        for (int j = 0; j < N; j++){
            if (j+1 == i){table_widget_x->setItem(i, j, new QTableWidgetItem(QString::number(N)));}
            else if (i == j && !(j % 2)){table_widget_x->setItem(i, j, new QTableWidgetItem(QString::number(1)));}
            else if (i == j && j % 2){table_widget_x->setItem(i, j, new QTableWidgetItem(QString::number(N)));}
            else{table_widget_x->setItem(i, j, new QTableWidgetItem(QString::number(0)));}
        }
    }
}

void MainWindow::getN(){
    QString temp = table_x_size_line->text();
    bool parse_flag;
    N = temp.toInt(&parse_flag, 10);
    if (N <= 0 || !parse_flag){
        table_size_err->exec();
        return;
    }
    _initXAndY();
}

void MainWindow::saveSelectedCellAndPrint(){
    if (table_widget_x->selectedItems().count() > 1) return;
    selected = table_widget_x->selectedItems().first();
    table_x_change_line->setText(selected->text());
}

void MainWindow::changeSelectedX(){
    if (selected == nullptr) return;
    bool parse_flag;
    table_x_change_line->text().toInt(&parse_flag, 10);
    if (!parse_flag){
        table_change_err->exec();
        return;
    }
    selected->setText(table_x_change_line->text());
}

void MainWindow::calculateYAndPrint(){
    bool parse_flag;
    for (int i = 0; i < N; i++){
        for (int j = 0; j < N; j++){
            int temp = (table_widget_x->item(i, j)->text().toInt(&parse_flag, 10));
            if (!parse_flag) continue;
            table_widget_y->setItem(i, j, new QTableWidgetItem(QString::number(temp+j+1)));
        }
    }
}

MainWindow::~MainWindow()
{
}

