using Calculator.Domain.Parsers;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Domain.UnitTests
{
	public class Tests
	{
		private IParser _parser;

		private Dictionary<string, int> _operations;

		[SetUp]
		public void Setup()
		{
			_operations = new Dictionary<string, int>()
			{
				{ "+", 0},
				{ "-", 1},
				{ "+", 20},
				{ "-", 21}
			};

			_parser = new RPNParser(_operations);
		}

		[Test]
		public void Parse_Expression_With_Two_Operands()
		{
			var expression = "2+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "23+");
		}

		[Test]
		public void Parse_Expression_With_DoubleDigit_Operand()
		{
			var expression = "26+3";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "26 3+" );
		}

		[Test]
		public void Parse_Expression_With_DifferentPriority_Operators()
		{
			var expression = "2+3*4";

			var result = _parser.Parse(expression);

			Assert.AreEqual(result, "234*+");
		}
	}
}