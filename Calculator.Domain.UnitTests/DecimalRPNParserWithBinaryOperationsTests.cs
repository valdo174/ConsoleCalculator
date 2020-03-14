using Calculator.Domain.Operations;
using Calculator.Domain.Parsers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Domain.UnitTests
{
	/// <summary>
	/// Ќабор тестов дл€ парсера по алгоритму обратной польской нотации
	/// с набором целых и дес€тичных чисел
	/// </summary>
	public class DecimalRPNParserWithBinaryOperationsTests
	{
		private IParser<decimal> _parser;

		private List<BinaryOperation<decimal>> _binaryOperations;

		[SetUp]
		public void Setup()
		{
			_binaryOperations = new List<BinaryOperation<decimal>>
			{
				new BinaryOperation<decimal>("+", 10, (a, b) => a + b),
				new BinaryOperation<decimal>("*", 11, (a, b) => a * b),
			};

			_parser = new RPNParser<decimal>(_binaryOperations);
		}

		[Test]
		public void Parse_Expression_With_Two_Operands_Test()
		{
			var expression = "2+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "23+");
		}

		[Test]
		public void Parse_Expression_With_DoubleDigit_Operand_Test()
		{
			var expression = "26+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "26 3+" );
		}

		[Test]
		public void Parse_Expression_With_DifferentPriority_Operators_Test()
		{
			var expression = "2+3*4";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "234*+");
		}
	}
}