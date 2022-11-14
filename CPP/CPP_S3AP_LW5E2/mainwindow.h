#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QLabel>
#include <QPainter>
#include <QPushButton>
#include <QLineEdit>
#include <QTimer>
#include <QMessageBox>
#include <QColorDialog>

class MainWindow : public QMainWindow
{
    Q_OBJECT

    QLabel *background_label;

    QPixmap *drowable_pixmap;

    QPen *border;
    QBrush *fill;
    QBrush *animation;

    QPushButton *choose_colors;
    QPushButton *start_timer;
    QLineEdit *timer_delay;

    QTimer *timer;
    int timer_counter;

    bool draw_mode;
public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
private:
    void drawBase();
    void drawAnimation();
private slots:
    void chooseColors();
    void startTimer();
    void drawAnimationSlot();
};
#endif // MAINWINDOW_H
