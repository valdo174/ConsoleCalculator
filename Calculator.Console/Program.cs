using Calculator.Domain.Calculators;
using Calculator.Domain.Operations;
using Calculator.Domain.Parsers;
using Calculator.Domain.Validators;
using System.Collections.Generic;

namespace Calculator.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var binaryOperations = new List<BinaryOperation<decimal>>
			{
				new BinaryOperation<decimal>("+", 10, (a, b) => a + b),
				new BinaryOperation<decimal>("-", 10, (a, b) => a - b),
				new BinaryOperation<decimal>("*", 21, (a, b) => a * b),
				new BinaryOperation<decimal>("/", 21, (a, b) => a / b),
			};

			var validator = new ExpressionsValidator<decimal>();
			var parser = new RPNParser<decimal>(binaryOperations);

			var calculator = new Calculator<decimal>(parser, validator);

			while (true)
			{
				try
				{
					System.Console.Write("Введите выражение: ");
					System.Console.WriteLine(calculator.Calculate(System.Console.ReadLine()));
				}
				catch (System.Exception ex)
				{
					System.Console.WriteLine(ex.Message);
				}
			}
		}
	}
}
