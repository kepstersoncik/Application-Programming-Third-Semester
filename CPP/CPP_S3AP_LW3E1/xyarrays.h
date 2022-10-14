#ifndef XYARRAYS_H
#define XYARRAYS_H

#include <vector>
#include <cmath>

std::size_t const N = 10;

class XYArrays
{
    std::vector<double> x_array;
    std::vector<double> y_array;
public:
    XYArrays();
    void makeX();
    void makeYfromX();
    std::vector<double> getX();
    void setY(const std::vector<double> &);
    void setX(const std::vector<double> &);
    std::vector<double> getY();
};

#endif // XYARRAYS_H
