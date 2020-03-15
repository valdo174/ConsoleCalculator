using System;

namespace Calculator.Domain.Calculators
{
	/// <summary>
	/// Исключение при разборе формата вычисляемого выражения
	/// </summary>
	public class ExpressionFormatException : Exception
	{
		public ExpressionFormatException(string message) : base(message)
		{

		}
	}
}
