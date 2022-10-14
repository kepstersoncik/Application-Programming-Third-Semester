#include "xyarrays.h"

XYArrays::XYArrays()
{
    this->x_array = std::vector<double>(N, 1.0);
    this->y_array = std::vector<double>(N, 1.0);
}

void XYArrays::makeX(){
    this->x_array[0] = std::sin(1);
    double temp = x_array[0];
    for (std::size_t i = 1; i < x_array.size(); i++){
        x_array[i] = std::sin(i+1) * temp;
        temp = x_array[i];
    }
}

void XYArrays::makeYfromX(){
    double sum = 0.0;
    double mean;
    std::vector<double> temp, result;
    for (auto el : this->x_array){
        sum += el;
    }
    mean = sum / this->x_array.size();
    for (auto el : this->x_array){
        if (el < mean){
            result.push_back(el);
        }
        else{
            temp.push_back(el);
        }
    }
    result.insert(result.end(), temp.begin(), temp.end());
    setY(result);
}

std::vector<double> XYArrays::getX(){
    return this->x_array;
}

void XYArrays::setY(const std::vector<double> &y_array){
    this->y_array = y_array;
}

void XYArrays::setX(const std::vector<double> &x_array){
    this->x_array = x_array;
}

std::vector<double> XYArrays::getY(){
    return this->y_array;
}
