namespace Lab_2.Models
{
    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
    }
    public class Calculator
    {
        public Operator? Op { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public string OperatorSign()
        {
            switch (Op)
            {
                case Operator.Add:
                    return "+";
                case Operator.Mul:
                    return "*";
                case Operator.Sub:
                    return "-";
                case Operator.Div:
                    return "/";
                default:
                    return "_unknow_";
            }
        }

        public bool IsValid()
        {
            return Op != null && A != null && B != null;
        }

        double Add(double a, double b)
        {
            return a + b;
        }

        double Multiply(double a, double b)
        {
            return a * b;
        }

        double Subtract(double a, double b)
        {
            return a - b;
        }

        double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return a / b;
        }

        public double ResultCalculator(Operator op, double a, double b)
        {
            switch (op)
            {
                case Operator.Add:
                    return Add(a, b);
                case Operator.Mul:
                    return Multiply(a, b);
                case Operator.Sub:
                    return Subtract(a, b);
                case Operator.Div:
                    return Divide(a, b);
                default:
                    throw new InvalidOperationException("Unknown operator");
            }
        }

        public double ParamsResultCalculator() => ResultCalculator((Operator)Op, (double)A, (double)B);
    }
}
