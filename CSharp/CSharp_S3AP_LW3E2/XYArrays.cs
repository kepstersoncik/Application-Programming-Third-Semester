//namespace CSharp_S3AP_LW3E1;

public class XYArrays{
    double[] x_array;
    double[] y_array;

    public XYArrays(){
        x_array = new double[10];
        for (int i = 0; i < x_array.Length; i++){
            x_array[i] = 1.0;
        }
        y_array = new double[10];
        for (int i = 0; i < y_array.Length; i++){
            y_array[i] = 1.0;
        }
    }

    public void makeX(){
        double temp = 1;
        for (int i = 0; i < x_array.Length; i++){
            x_array[i] = Math.Round(Math.Sin(i + 1) * temp, 3);
            temp = x_array[i];
        }
    }

    public void makeYfromX(){
        double sum = 0.0;
        double mean;
        double[] temp = new double[x_array.Length];
        int temp_counter = 0;
        double[] result = new double[x_array.Length];
        int result_counter = 0;
        foreach (double i in x_array){
            sum += i;
        }
        mean = sum / x_array.Length;
        foreach (double i in x_array){
            if (i < mean){
                result[result_counter++] = i;
            }
            else {
                temp[temp_counter++] = i;
            }
        }
        for (int i = 0; i < temp_counter &&
        result_counter < result.Length; i++){
            result[result_counter++] = temp[i];
        }
        setY(result);
    }

    public double[] getX(){
        return x_array;
    }

    public void setY(double[] y_array){
        this.y_array = y_array;
    }

    public void setX(double[] x_array){
        this.x_array = x_array;
    }

    public double[] getY(){
        return y_array;
    }
}