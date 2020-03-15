using Calculator.Domain.Formatters;
using NUnit.Framework;

namespace Calculator.Domain.UnitTests
{
	public class ExpressionFormatterTests
{
		private IExpressionFormatter _formatter;

		[SetUp]
		public void SetUp()
		{
			_formatter = new ExpressionFomatter();
		}

		[Test]
		[TestCase("-3")]
		[TestCase("         -3")]
		[TestCase(" -3")]
		public void Add_Zero_If_FirstOperand_Is_Minus_Test(string experssion)
		{
			var formattedExpression = _formatter.FormatExpression(experssion);

			Assert.AreEqual("0-3", formattedExpression);
		}

		[Test]
		[TestCase("(-3)")]
		[TestCase("         (-3)")]
		public void Add_Zero_If_FirstOperand_Is_Minus_After_OpeningBracket_Test(string experssion)
		{
			var formattedExpression = _formatter.FormatExpression(experssion);

			Assert.AreEqual("(0-3)", formattedExpression);
		}

		[Test]
		[TestCase("5 - 2")]
		[TestCase("         5 -2  ")]
		public void Trim_Expression_Test(string experssion)
		{
			var formattedExpression = _formatter.FormatExpression(experssion);

			Assert.AreEqual("5-2", formattedExpression);
		}
	}
}
