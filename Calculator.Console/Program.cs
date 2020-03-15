using Calculator.Domain.Calculators;
using Calculator.Domain.Formatters;
using Calculator.Domain.Operations;
using Calculator.Domain.Parsers;
using Calculator.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Calculator.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var calculator = InitCalculator();

			while (true)
			{
				try
				{
					System.Console.Write("Введите выражение: ");
					System.Console.WriteLine(calculator.Calculate(System.Console.ReadLine()));
				}
				catch (ExpressionFormatException ex)
				{
					System.Console.WriteLine(ex.Message);
				}
				catch (OperationException oex)
				{
					System.Console.WriteLine(oex.Message);
				}
				catch (Exception)
				{
					System.Console.WriteLine("Произошла ошибка при разборе или вычислении введенного выражения.");
				}
			}
		}

		private static ICalculator<decimal> InitCalculator()
		{
			var formatter = new ExpressionFormatter();

			var binaryOperations = new List<BinaryOperation<decimal>>
			{
				new BinaryOperation<decimal>("+", 10, (a, b) => a + b),
				new BinaryOperation<decimal>("-", 10, (a, b) => a - b),
				new BinaryOperation<decimal>("*", 21, (a, b) => a * b),
				new BinaryOperation<decimal>("/", 21, (a, b) => a / b)
			};

			var validator = new ExpressionsValidator<decimal>();
			var parser = new RPNParser<decimal>(binaryOperations);

			return new Calculator<decimal>(parser, validator, formatter);
		}
	}
}
