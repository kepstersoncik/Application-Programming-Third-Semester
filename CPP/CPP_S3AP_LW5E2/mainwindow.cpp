#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    this->setMinimumSize(1100, 700);
    this->setWindowTitle("Лабораторная работа № 5");

    border = new QPen(Qt::blue, 2);
    fill = new QBrush(Qt::cyan);
    fill->setStyle(Qt::SolidPattern);
    animation = new QBrush(Qt::red);

    choose_colors = new QPushButton("Выбрать цвета", this);
    choose_colors->setGeometry(20, 20, 100, 30);
    connect(choose_colors, SIGNAL(clicked(bool)), this, SLOT(chooseColors()));

    start_timer = new QPushButton("Запустить анимацию", this);
    start_timer->setGeometry(125, 20, 130, 30);
    connect(start_timer, SIGNAL(clicked(bool)), this, SLOT(startTimer()));

    timer_delay = new QLineEdit("500", this);
    timer_delay->setGeometry(260, 20, 60, 30);


    QPixmap background_pixmap("D:\\Semester_3_2022\\AP\\CPP\\CPP_S3AP_LW5E2\\1200px-LubotinPartizanka.JPG");
    background_label = new QLabel(this);
    background_label->setGeometry(15, 15, this->width()-30, this->height()-30);
    background_label->setPixmap(background_pixmap);
    drowable_pixmap = new QPixmap(background_label->pixmap());
    timer_delay->raise();
    start_timer->raise();
    choose_colors->raise();
    drawBase();
}

void MainWindow::drawBase(){
    QPainter painter(drowable_pixmap);
    painter.setBrush(*fill);
    painter.setPen(*border);
    painter.drawPolygon(new QPoint[]{QPoint(550, 400), QPoint(650, 300), QPoint(750, 400)}, 3);
    painter.setBrush(QBrush(Qt::white));
    painter.drawRect(570, 400, 160, 200);
    painter.drawRect(640, 430, 65, 170);
    painter.setBrush(*fill);
    painter.drawEllipse(585, 430, 40, 40);
    background_label->setPixmap(*drowable_pixmap);
    background_label->show();
    draw_mode = false;
    drawAnimation();
}

void MainWindow::drawAnimation(){
    QPixmap frame_pixmap = *drowable_pixmap;
    QPainter painter(&frame_pixmap);
    painter.setPen(*border);
    painter.setBrush(*animation);
    if (draw_mode){
        painter.drawRect(640, 430, 65, 170);
        draw_mode = false;
    }
    else{
        painter.drawPolygon(new QPoint[]{QPoint(640, 430), QPoint(695, 440), QPoint(695, 610), QPoint(640, 600)}, 4);
        draw_mode = true;
    }
    background_label->setPixmap(frame_pixmap);
}

void MainWindow::chooseColors(){
    QColor border_color = QColorDialog::getColor(Qt::blue, this, "Выбирите цвет границы");
    border->setColor(border_color);
    QColor fill_color = QColorDialog::getColor(Qt::cyan, this, "Выбирите цвет заливки");
    fill->setColor(fill_color);
    QColor animation_color = QColorDialog::getColor(Qt::red, this, "Выбирите цвет анимации");
    animation->setColor(animation_color);
    drawBase();
}

void MainWindow::startTimer(){
    timer = new QTimer(this);
    int timer_interval;
    bool ok;
    try{
        timer_interval = timer_delay->text().toInt(&ok, 10);
        if (!ok || timer_interval <= 0){
            throw std::exception();
        }
    }
    catch(std::exception){
        QMessageBox err;
        err.setText("Невозможное значение для задержки таймера");
        err.exec();
        return;
    }

    timer->setInterval(timer_interval);
    connect(timer, SIGNAL(timeout()), this, SLOT(drawAnimationSlot()));
    timer_counter = 0;
    timer->start();
}

void MainWindow::drawAnimationSlot(){
    if (timer_counter == 6) {timer->stop(); return;}
    drawAnimation();
    timer_counter++;
}

MainWindow::~MainWindow()
{
}

