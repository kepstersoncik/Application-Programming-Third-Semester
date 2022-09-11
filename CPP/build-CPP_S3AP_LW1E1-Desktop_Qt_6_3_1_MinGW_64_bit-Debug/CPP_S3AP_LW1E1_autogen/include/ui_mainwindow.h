/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 6.3.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QLabel *description;
    QLabel *apex_A_label;
    QLabel *apex_B_label;
    QLabel *apex_C_label;
    QLineEdit *apex_A_x_le;
    QLineEdit *apex_B_x_le;
    QLineEdit *apex_C_x_le;
    QLineEdit *apex_A_y_le;
    QLineEdit *apex_B_y_le;
    QLineEdit *apex_C_y_le;
    QPushButton *calc_button;
    QLabel *result_label;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(500, 228);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        description = new QLabel(centralwidget);
        description->setObjectName(QString::fromUtf8("description"));
        description->setGeometry(QRect(20, 10, 461, 31));
        apex_A_label = new QLabel(centralwidget);
        apex_A_label->setObjectName(QString::fromUtf8("apex_A_label"));
        apex_A_label->setGeometry(QRect(20, 60, 141, 16));
        apex_B_label = new QLabel(centralwidget);
        apex_B_label->setObjectName(QString::fromUtf8("apex_B_label"));
        apex_B_label->setGeometry(QRect(20, 90, 141, 16));
        apex_C_label = new QLabel(centralwidget);
        apex_C_label->setObjectName(QString::fromUtf8("apex_C_label"));
        apex_C_label->setGeometry(QRect(20, 120, 141, 16));
        apex_A_x_le = new QLineEdit(centralwidget);
        apex_A_x_le->setObjectName(QString::fromUtf8("apex_A_x_le"));
        apex_A_x_le->setGeometry(QRect(170, 60, 113, 21));
        apex_B_x_le = new QLineEdit(centralwidget);
        apex_B_x_le->setObjectName(QString::fromUtf8("apex_B_x_le"));
        apex_B_x_le->setGeometry(QRect(170, 90, 113, 21));
        apex_C_x_le = new QLineEdit(centralwidget);
        apex_C_x_le->setObjectName(QString::fromUtf8("apex_C_x_le"));
        apex_C_x_le->setGeometry(QRect(170, 120, 113, 21));
        apex_A_y_le = new QLineEdit(centralwidget);
        apex_A_y_le->setObjectName(QString::fromUtf8("apex_A_y_le"));
        apex_A_y_le->setGeometry(QRect(290, 60, 113, 21));
        apex_B_y_le = new QLineEdit(centralwidget);
        apex_B_y_le->setObjectName(QString::fromUtf8("apex_B_y_le"));
        apex_B_y_le->setGeometry(QRect(290, 90, 113, 21));
        apex_C_y_le = new QLineEdit(centralwidget);
        apex_C_y_le->setObjectName(QString::fromUtf8("apex_C_y_le"));
        apex_C_y_le->setGeometry(QRect(290, 120, 113, 21));
        calc_button = new QPushButton(centralwidget);
        calc_button->setObjectName(QString::fromUtf8("calc_button"));
        calc_button->setGeometry(QRect(20, 160, 121, 24));
        result_label = new QLabel(centralwidget);
        result_label->setObjectName(QString::fromUtf8("result_label"));
        result_label->setGeometry(QRect(170, 160, 311, 31));
        result_label->setWordWrap(true);
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 500, 21));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);
        QObject::connect(calc_button, SIGNAL(clicked()), MainWindow, SLOT(calcPerimetrNDisplay()));

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "\320\233\320\260\320\261\320\276\321\200\320\260\321\202\320\276\321\200\320\275\320\260\321\217 \321\200\320\260\320\261\320\276\321\202\320\260 \342\204\226 1", nullptr));
        description->setText(QCoreApplication::translate("MainWindow", "\320\237\321\200\320\276\320\263\321\200\320\260\320\274\320\274\320\260 \320\277\321\200\320\276\320\270\320\267\320\262\320\276\320\264\320\270\321\202 \321\200\320\260\321\201\321\207\320\265\321\202 \320\277\320\265\321\200\320\270\320\274\320\265\321\202\321\200\320\260 \321\202\321\200\320\265\321\203\320\263\320\276\320\273\321\214\320\275\320\270\320\272\320\260 \320\277\320\276 \320\272\320\276\320\276\321\200\320\264\320\270\320\275\320\260\321\202\320\260\320\274 \320\262\320\265\321\200\321\210\320\270\320\275.", nullptr));
        apex_A_label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\276\320\276\321\200\320\264\320\270\320\275\320\260\321\202\321\213 \320\262\320\265\321\200\321\210\320\270\320\275\321\213 A", nullptr));
        apex_B_label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\276\320\276\321\200\320\264\320\270\320\275\320\260\321\202\321\213 \320\262\320\265\321\200\321\210\320\270\320\275\321\213 B", nullptr));
        apex_C_label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\276\320\276\321\200\320\264\320\270\320\275\320\260\321\202\321\213 \320\262\320\265\321\200\321\210\320\270\320\275\321\213 C", nullptr));
        calc_button->setText(QCoreApplication::translate("MainWindow", "\320\237\321\200\320\276\320\270\320\267\320\262\320\265\321\201\321\202\320\270 \321\200\320\260\321\201\321\207\320\265\321\202", nullptr));
        result_label->setText(QString());
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
