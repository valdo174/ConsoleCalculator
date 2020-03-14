using System.Collections.Generic;
using Calculator.Domain.Operations;
using Calculator.Domain.Validators;
using NUnit.Framework;

namespace Calculator.Domain.UnitTests
{
	public class DecimalExpressionsValidatorTests
	{
		private IExpressionsValidator<decimal> _validator;

		private List<BinaryOperation<decimal>> _binaryOperations;

		[SetUp]
		public void SetUp()
		{
			_binaryOperations = new List<BinaryOperation<decimal>>
			{
				new BinaryOperation<decimal>("+", 10, (a, b) => a + b),
				new BinaryOperation<decimal>("-", 11, (a, b) => a - b),
				new BinaryOperation<decimal>("*", 21, (a, b) => a * b),
				new BinaryOperation<decimal>("/", 22, (a, b) => a / b),
			};

			_validator = new ExpressionsValidator<decimal>();
		}

		[Test]
		[TestCase("((())")]
		[TestCase("(((")]
		[TestCase(")")]
		public void Brackets_Validation_Test_With_Bad_Result(string value)
		{
			Assert.AreEqual(false, _validator.BracketsValidation(value));
		}

		[Test]
		[TestCase("((()))")]
		[TestCase("()")]
		[TestCase("")]
		public void Brackets_Validation_Test_With_Good_Result(string value)
		{
			Assert.AreEqual(true, _validator.BracketsValidation(value));
		}

		[Test]
		[TestCase("2+3")]
		[TestCase("2*3+5")]
		[TestCase("2*3")]
		[TestCase("2/3+2")]
		public void AvailableOperations_Validation_Test_With_Good_Result(string value)
		{
			Assert.AreEqual(true, _validator.ValidateAvailableOperation(value, _binaryOperations));
		}

		[Test]
		[TestCase("2^3")]
		public void AvailableOperations_Validation_Test_With_Bad_Result(string value)
		{
			Assert.AreEqual(false, _validator.ValidateAvailableOperation(value, _binaryOperations));
		}
	}
}
