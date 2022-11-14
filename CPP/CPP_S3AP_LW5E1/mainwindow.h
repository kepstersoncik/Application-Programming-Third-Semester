#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QLabel>
#include <QPushButton>
#include <QFileDialog>
#include <QPainter>
#include <QMouseEvent>

class Label : public QLabel{
    Q_OBJECT;

    QPoint *old_point;
    QPoint *new_point;

    QPixmap *buffered_pixmap;
    QRect *cutted_rect;
    QPixmap *cutted_pixmap;

public:
    Label(QWidget *p = nullptr);
    bool isCutted();
    QPixmap getCuttedPixmap();
    QRect getCuttedRect();
    void updateBuffer();
    ~Label();
protected:
    void mousePressEvent(QMouseEvent *event) override;
    void mouseMoveEvent(QMouseEvent *event) override;
    void mouseReleaseEvent(QMouseEvent *event) override;
    void cutFromPixmap();
};

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QPushButton *choose_image1;
    QPushButton *choose_image2;

    Label *image_label;
    QSize image_label_origin_size;
    QPixmap *pixmap;
    QSize *new_pixmap_size;
    QPainter *painter;
public:
    MainWindow(QWidget *parent = nullptr);
    void setCuttedPixmap(const QPixmap &, const QRect &);
    ~MainWindow();
private slots:
    void loadFirstImage();
    void loadSecondImage();
protected:
    void mousePressEvent(QMouseEvent *event) override;
};
#endif // MAINWINDOW_H
