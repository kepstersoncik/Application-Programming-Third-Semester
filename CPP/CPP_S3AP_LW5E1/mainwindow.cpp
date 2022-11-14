#include "mainwindow.h"

Label::Label(QWidget *p)
    : QLabel(p)
{
    buffered_pixmap = nullptr;
    cutted_pixmap = nullptr;
    cutted_rect = nullptr;
    old_point == nullptr;
    new_point == nullptr;
}

void Label::updateBuffer(){
    buffered_pixmap = new QPixmap(this->pixmap());
}

bool Label::isCutted(){
    if (cutted_pixmap == nullptr || cutted_rect == nullptr) return false;
    return true;
}

QPixmap Label::getCuttedPixmap(){
    return *cutted_pixmap;
}

QRect Label::getCuttedRect(){
    return *cutted_rect;
}

void Label::mousePressEvent(QMouseEvent *event){
    try{
        if (buffered_pixmap != nullptr) this->setPixmap(*buffered_pixmap);
        old_point = new QPoint(event->pos());
        updateBuffer();
    }
    catch(std::exception e){
        qDebug() << e.what();
    }
}

void Label::mouseMoveEvent(QMouseEvent *event){
    try{
        QPixmap *temp = new QPixmap(*buffered_pixmap);
        QPainter painter(temp);
        QRect rect(*old_point, event->pos());
        painter.drawRect(rect);
        this->setPixmap(*temp);
    }
    catch(std::exception e){
        qDebug() << e.what();
    }
}
void Label::mouseReleaseEvent(QMouseEvent *event){
    try{
        new_point = new QPoint(event->pos());
        if (*old_point == *new_point) return;
        qDebug() << *new_point << *old_point;
        cutFromPixmap();
    }
    catch(std::exception e){
        qDebug() << e.what();
    }
}

void Label::cutFromPixmap(){
    if (old_point->x() > new_point->x() && old_point->y() > new_point->y()){
        cutted_rect = new QRect(*new_point, *old_point);
    }
    else if (old_point->x() > new_point->x()){
        cutted_rect = new QRect(new_point->x(), old_point->y(), old_point->x()-new_point->x(), new_point->y()-old_point->y());
    }
    else if (old_point->y() > new_point->y()){
        cutted_rect = new QRect(old_point->x(), new_point->y(), new_point->x()-old_point->x(), old_point->y()-new_point->y());
    }
    else{
        cutted_rect = new QRect(*old_point, *new_point);
    }

    QImage temp_image = buffered_pixmap->copy(*cutted_rect).toImage();
    for(int i = 0; i < temp_image.width(); i++)
        for (int j = 0; j < temp_image.height(); j++){
            QRgb p = temp_image.pixel(i, j);
            int r = qRed(p);
            int g = qGreen(p);
            int b = qBlue(p);
            int avg = (int)((r+g+b)/3);
            QColor color;
            color.setRgb(avg,avg,avg);
            temp_image.setPixelColor(i,j,color);
        }
    cutted_pixmap = new QPixmap(QPixmap::fromImage(temp_image));
}

Label::~Label(){}


MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    this->setMinimumSize(1100, 700);
    this->setWindowTitle("Лабораторная рабоат № 5");

    choose_image1 = new QPushButton("Изображение 1", this);
    choose_image1->setToolTip("Выбрать изображение 1");
    choose_image1->setGeometry(15, 15, 100, 25);
    connect(choose_image1, SIGNAL(clicked(bool)), this, SLOT(loadFirstImage()));

    choose_image2 = new QPushButton("Изображение 2", this);
    choose_image2->setToolTip("Выбрать изображение 1");
    choose_image2->setGeometry(120, 15, 100, 25);
    connect(choose_image2, SIGNAL(clicked(bool)), this, SLOT(loadSecondImage()));
    choose_image2->setDisabled(true);

    image_label = new Label(this);
    image_label->setGeometry(15, 45, this->width()/2-30, this->height()-70);
    image_label_origin_size = image_label->size();
    image_label->setStyleSheet("QLabel {"
                          "border-style: solid;"
                          "border-width: 1px;"
                          "border-color: black; "
                          "}");
    image_label->setDisabled(true);

    QFrame* line = new QFrame(this);
    line->setFrameShape(QFrame::VLine);
    line->setFrameShadow(QFrame::Sunken);
    line->setGeometry(this->width()/2, 0, line->width(), this->height());
}

void MainWindow::loadFirstImage(){
    auto file_name = QFileDialog::getOpenFileName(this, "Загрузить изображение", QDir::currentPath());
    if (!(pixmap = new QPixmap(file_name))) return;
    image_label->resize(image_label_origin_size);
    float scale_w = ((float)image_label->width()/(float)pixmap->width());
    float scale_h = ((float)image_label->height()/(float)pixmap->height());
    float scale;
    if (scale_h < scale_w){
        scale = scale_h;
    }
    else{
        scale = scale_w;
    }
    int new_width = (int)(pixmap->width() * scale);
    int new_height = (int)(pixmap->height() * scale);
    new_pixmap_size = new QSize(new_width, new_height);
    image_label->setPixmap(pixmap->scaled(*new_pixmap_size, Qt::KeepAspectRatio));
    image_label->resize(new_width, new_height);
    painter = new QPainter(pixmap);
    image_label->setDisabled(false);
    image_label->updateBuffer();
    choose_image2->setDisabled(false);
}

void MainWindow::loadSecondImage(){
    auto file_name = QFileDialog::getOpenFileName(this, "Загрузить изображение", QDir::currentPath());
    QPixmap *second_pixmap;
    if (!(second_pixmap = new QPixmap(file_name))) return;
    *second_pixmap = second_pixmap->copy(QRect(150, 150, 500, 500));
    painter->drawImage(QRect(100, 100, 100, 100), second_pixmap->toImage());
    image_label->setPixmap(pixmap->scaled(*new_pixmap_size, Qt::KeepAspectRatio));
    image_label->updateBuffer();
}

void MainWindow::mousePressEvent(QMouseEvent *event){
    if (event->pos().x() < this->width()/2+50) return;
    if (!(image_label->isCutted())) return;
    QPixmap cutted_pixmap = image_label->getCuttedPixmap();
    QRect cutted_rect = image_label->getCuttedRect();
    QLabel *pasted_pixmap = new QLabel(this);
    pasted_pixmap->setGeometry(event->pos().x(), event->pos().y(), cutted_rect.size().width(), cutted_rect.size().height());
    pasted_pixmap->setPixmap(cutted_pixmap);
    pasted_pixmap->show();
}

MainWindow::~MainWindow()
{
}

