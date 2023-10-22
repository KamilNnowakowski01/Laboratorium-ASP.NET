using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lab_1.Controllers
{
    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator(Operator op, double a, double b)
        {
            ViewBag.Op = op;
            ViewBag.A = a;
            ViewBag.B = b;

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

            double ResultCalculator(Operator op, double a, double b)
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

            ViewBag.Result = ResultCalculator(op, a, b);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}