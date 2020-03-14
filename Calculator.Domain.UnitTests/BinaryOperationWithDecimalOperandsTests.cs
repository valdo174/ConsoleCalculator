using Calculator.Domain.Operations;
using NUnit.Framework;

namespace Calculator.Domain.UnitTests
{
	public class BinaryOperationWithDecimalOperandsTests
	{
		private BinaryOperation<decimal> _addOperation;
		private BinaryOperation<decimal> _divideOperation;

		[SetUp]
		public void SetUp()
		{
			_addOperation = new BinaryOperation<decimal>("+", 0, (a, b) => a + b);
			_divideOperation = new BinaryOperation<decimal>("/", 0, (a, b) => a / b);
		}

		[Test]
		public void Calculate_Two_Operands_Test()
		{
			var firstOperand = 1;
			var secondOperand = 3.56m;

			var result = _addOperation.Calculate(firstOperand, secondOperand);

			Assert.AreEqual(result, 4.56m);
		}

		[Test]
		public void ThrowException_If_Operand_Not_SetUp_Test()
		{
			var firstOperand = 123.1m;

			_addOperation.FirstOperand = firstOperand;

			Assert.Throws<OperationOperandException>(() => _addOperation.Calculate());
		}

		[Test]
		public void ThrowException_If_IncorrectOperation_Test()
		{
			var firstOperand = 123.1m;
			var secondOperand = 0m;

			Assert.Throws<OperationCalculateException>(() => _divideOperation.Calculate(firstOperand, secondOperand));
		}
	}
}
