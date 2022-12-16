# Создание GUI с использованием главного меню окна, диалоговых окон выбора файла и списков
## Задание 1:
Создать меню:\
Файл&emsp;&emsp;&emsp;Работа\
Новый&emsp;&emsp;&nbsp;Вычислить\
Загрузить\
Сохранить\
Выход\
При запуске приложения создаются два вещественных массива X[n], Y[n], все значения которых равны 1.0.
При выборе пункта `Новый` формируется массив `X` по индивидуальному варианту задания.
При выборе пункта `Сохранить` открывается диалог сохранения файла и массив `Y` сохраняется в выбранном файле.
При выборе пункта `Загрузить` открывается диалог выбора файла для загрузки и данные считываются в массив `X` из выбранного файла.
При выборе пункта `Выход` приложение завершается.
При выборе пункта `Вычислить` из массива `X` формируется массив `Y` по индивидуальному варианту задания
### Вариант 1:
Для массива `X`:\
$X[0]=sin(1); X[1]=sin(1)*sin(2); ... ; X[i]=sin(1)*...*sin(i+1);...; X[n]=sin(1)*sin(2)*...*sin(n+1)$\
Для массива `Y`:\
Вычислить среднее значение элементов массива `X`. Переставить элементы в массив `Y` так, чтобы в начали были элементы меньше среднего значения, потом элементы с большим значением. Элементы распологаются в том же порядке.

---

- [Реализация на C++](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/CPP/CPP_S3AP_LW3E1)
- [Реализация на C#](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/CSharp/CSharp_S3AP_LW3E1)
- [Реализация на Java](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/Java/Java_S3AP_LW3E1)

---


## Задание 2:
На форму добавить ListBox и ComboBox.
При выполнении пунктов меню `Вычислить` массив `Y` отображается в ComboBox.
Добавить на форму 2 текстовых поля и 2 кнопки. При выборе какого-нибудь элемента в ListBox или ComboBox, он отображается в соответствующем текстовом поле.
После редактирования в текстовом поле и нажатия кнопки измененное число замещает соответствующий элемент в массивах `X` или `Y`, а также строки в ListBox и ComboBox.

---

- [Реализация на C++](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/CPP/CPP_S3AP_LW3E2)
- [Реализация на C#](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/CSharp/CSharp_S3AP_LW3E2)
- [Реализация на Java](https://github.com/kepstersoncik/Application-Programming-Third-Semester/tree/master/Java/Java_S3AP_LW3E2)
