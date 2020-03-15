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

		private char _delimeter;

		private List<BinaryOperation<decimal>> _binaryOperations;

		[SetUp]
		public void Setup()
		{
			_binaryOperations = new List<BinaryOperation<decimal>>
			{
				new BinaryOperation<decimal>("+", 10, (a, b) => a + b),
				new BinaryOperation<decimal>("-", 10, (a, b) => a - b),
				new BinaryOperation<decimal>("*", 21, (a, b) => a * b),
				new BinaryOperation<decimal>("/", 21, (a, b) => a / b),
			};

			_delimeter = ' ';
			_parser = new RPNParser<decimal>(_binaryOperations, _delimeter);
		}

		[Test]
		public void Parse_Expression_With_Two_Operands_Test()
		{
			var expression = "2+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"2{_delimeter}3{_delimeter}+{_delimeter}", result);
		}

		[Test]
		public void Calculate_Expression_With_Two_Operands_Test()
		{
			var expression = "2+3";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(5, result);
		}

		[Test]
		public void Parse_Expression_With_Three_Operands_And_Different_Operations_Test()
		{
			var expression = "1+2-3";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"1 2 + 3 - ".Replace(' ', _delimeter), result);
		}

		[Test]
		public void Calculate_Expression_With_Three_Operands_And_Different_Operations_Test()
		{
			var expression = "1+2-3";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(0, result);
		}

		[Test]
		public void Parse_Long_Expression_Test()
		{
			var expression = "80*0.5-15/3+40/5-(55/11+2)*4";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"80 0.5 * 15 3 / - 40 5 / + 55 11 / 2 + 4 * - ".Replace(' ', _delimeter), result);
		}

		[Test]
		public void Calculate_Long_Expression_Test()
		{
			var expression = "80*0.5-15/3+40/5-(55/11+2)*4";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(15, result);
		}

		[Test]
		public void Parse_Expression_With_Three_Operands_Test()
		{
			var expression = "3-1-2";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"3 1 - 2 - ".Replace(' ', _delimeter), result);
		}

		[Test]
		public void Calculate_Expression_With_Three_Operands_Test()
		{
			var expression = "3-1-2";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(0, result);
		}

		[Test]
		public void Parse_Expression_With_Two_DecimalOperands_Test()
		{
			var expression = "2.0+3.0";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"2.0{_delimeter}3.0{_delimeter}+{_delimeter}", result);
		}

		[Test]
		public void Calculate_Expression_With_Two_DecimalOperands_Test()
		{
			var expression = "2.0+3.0";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(5.0m, result);
		}

		[Test]
		public void Parse_Expression_With_Two_DecimalAndIntegerOperands_Test()
		{
			var expression = "2.0+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"2.0{_delimeter}3{_delimeter}+{_delimeter}", result);
		}

		[Test]
		public void Calculate_Expression_With_Two_DecimalAndIntegerOperands_Test()
		{
			var expression = "2.0+3";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(5.0m, result);
		}

		[Test]
		public void Parse_Expression_With_DoubleDigit_Operand_Test()
		{
			var expression = "26+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"26{_delimeter}3{_delimeter}+{_delimeter}", result);
		}

		[Test]
		public void Parse_Expression_With_Brackets_Test()
		{
			var expression = "(5+2)*123";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"5{_delimeter}2{_delimeter}+{_delimeter}123{_delimeter}*{_delimeter}", result);
		}

		[Test]
		public void Calculate_Expression_With_Brackets_Test()
		{
			var expression = "(5+2)*123";

			var reverseExpression = _parser.Parse(expression);
			var result = _parser.Calculate(reverseExpression);

			Assert.AreEqual(861, result);
		}

		[Test]
		public void Parse_Expression_With_Brackets_And_DifferentPriority_Operators_Test()
		{
			var expression = "17-(54+12*2)/74";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"17 54 12 2 * + 74 / - ".Replace(' ', _delimeter), result);
		}

		[Test]
		public void Parse_Expression_With_DifferentPriority_Operators_Test()
		{
			var expression = "2+3*4";

			var result = _parser.Parse(expression);

			Assert.AreEqual($"2{_delimeter}3{_delimeter}4{_delimeter}*{_delimeter}+{_delimeter}", result);
		}
	}
}