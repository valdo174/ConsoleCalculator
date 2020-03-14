using System;

namespace Calculator.Domain.Calculators
{
	public class ExpressionFormatException : Exception
	{
		public ExpressionFormatException(string message) : base(message)
		{

		}
	}
}
