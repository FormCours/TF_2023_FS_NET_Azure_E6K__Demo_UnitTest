using Demo_Test_01.BLL.Exceptions;

namespace Demo_Test_01.BLL.Test.Services
{
    public class CalculatorServiceTest
    {
        #region Setup
        private ICalculatorService CreateDefaultCalculatorService()
        {
            return new CalculatorService();
        }

        #endregion

        #region Method Add
        [Fact]
        public void Add_TwoInteger_Ok()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const int val1 = 2;
            const int val2 = 1;
            const int expected = 3;

            // Action
            int actual = service.Add(val1, val2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_FiveInteger_Ok()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const int val1 = 1;
            const int val2 = 2;
            const int val3 = 3;
            const int val4 = 4;
            const int val5 = 5;
            const int expected = 15;

            // Action
            int actual = service.Add(val1, val2, val3, val4, val5);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoReal_Ok()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const double val1 = 3.14;
            const double val2 = 40.1;
            const double expected = 43.24;

            // Action
            double actual = service.Add(val1, val2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoReal_BugPrecisionIEEE754()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const double val1 = 0.1;
            const double val2 = 0.2;
            const double expected = 0.3;

            // Action
            double actual = service.Add(val1, val2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoVeryBigNumber_test()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const int val1 = int.MaxValue;
            const int val2 = 1;

            // Action + Assert
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                service.Add(val1, val2);
            });
        }
        #endregion

        #region Method Sub
        [Theory]
        [InlineData(60, 18, 42)]
        [InlineData(5.61, 2.48, 3.13)]
        [InlineData(-4, 1, -5)]
        [InlineData(-2.1, 0.9, -3)]
        [InlineData(-22, -20, -2)]
        [InlineData(-0.1, -0.4, 0.3)]
        public void Sub_MultiNumber_Ok(double val1, double val2, double expected)
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();

            // Action
            double actual = service.Sub(val1, val2);

            // Assert
            Assert.Equal(expected, actual);
        }


        public static IEnumerable<object[]> dataOutOfRangeSub = new List<object[]>()
        {
            new object[] { double.MaxValue, -double.MaxValue },
            new object[] { -double.MaxValue, double.MaxValue },
        };

        [Theory]
        [MemberData(nameof(dataOutOfRangeSub))]
        public void Sub_MultiNumber_BugOutOfRange(double val1, double val2)
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();

            // Action + Assert
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                service.Sub(val1, val2);
            });
        }
        #endregion

        #region Methode Div

        [Fact]
        public void Div_Number_Ok()
        {
            //ARRANGE
            ICalculatorService service = new CalculatorService();
            double nb1 = 5;
            double nb2 = 2;
            double result = 2.5;

            //ACT
            double actual = service.Div(nb1, nb2);


            //ASSERT
            Assert.Equal(result, actual);


        }

        [Fact]
        public void Div_ByZero_Bug()
        {
            ICalculatorService service = CreateDefaultCalculatorService();
            double nb1 = 5;
            double nb2 = 0;

            Assert.Throws<DivByZeroCalculatorException>(() =>
            {
                service.Div(nb1, nb2);
            });
        }
        [Fact]
        public void Div_infinity_OutOfRange()
        {
            // Arrange
            ICalculatorService service = CreateDefaultCalculatorService();
            const double nb1 = int.MaxValue;
            const double nb2 = 1 / double.MaxValue;

            // Action + Assert
            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                service.Div(nb1, nb2);
            });
        }
        #endregion

        #region Method Multiplication

        [Theory]
        [InlineData(1.5, 2, 3)]
        [InlineData(-2, 4, -8)]
        [InlineData(-3, -6, 18)]

        public void Multi_Ok(double nb1, double nb2, double expected)
        {

            //arange 
            ICalculatorService service = CreateDefaultCalculatorService();

            //Action

            double resultat = service.Multi(nb1, nb2);

            //Assert
            Assert.Equal(expected, resultat);

        }

        [Fact]
        public void Multi_OutOfRange_Bug()
        {
            ICalculatorService service = CreateDefaultCalculatorService();
            double nb1 = 2;
            double nb2 = double.MaxValue;

            Assert.Throws<OutOfRangeCalculatorException>(() =>
            {
                service.Multi(nb1, nb2);
            });
        }

        #endregion


    }
}