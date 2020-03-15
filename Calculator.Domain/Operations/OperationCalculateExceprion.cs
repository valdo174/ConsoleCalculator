using System;

namespace Calculator.Domain.Operations
{
	/// <summary>
	/// Исключение, возникающее при расчете результата функции оператора
	/// </summary>
	public class OperationCalculateException : OperationException
	{
		public OperationCalculateException(string message, Exception innerException) : base (message, innerException)
		{

		}
	}
}
