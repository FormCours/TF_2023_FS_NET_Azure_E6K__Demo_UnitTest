using Demo_Test_01.BLL.Interfaces;
using Demo_Test_01.BLL.Services;

Console.WriteLine("Demo Test 😒");

ICalculatorService service = new CalculatorService();

double res = service.Add(double.MaxValue, double.MaxValue, double.MaxValue);

Console.WriteLine(res);