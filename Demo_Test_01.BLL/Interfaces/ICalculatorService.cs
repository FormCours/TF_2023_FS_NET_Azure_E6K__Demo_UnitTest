namespace Demo_Test_01.BLL.Interfaces
{
    public interface ICalculatorService
    {
        double Add(double nb, params double[] nbs);
        int Add(int nb, params int[] nbs);

        double Sub(double nb1, double nb2);

        double Multi(double nb, params double[] nbs);

        double Div(double nb1, double nb2);
        
    }
}
