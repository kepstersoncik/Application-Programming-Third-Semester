#ifndef MYTEXTEDIT_H
#define MYTEXTEDIT_H

#include <QTextEdit>
#include <QKeyEvent>

class MyTextEdit : public QTextEdit
{
public:
    MyTextEdit(QWidget*);
    void keyReleaseEvent(QKeyEvent* e);
protected:

};

#endif // MYTEXTEDIT_H
