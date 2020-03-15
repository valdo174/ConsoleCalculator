using System;

namespace Calculator.Domain.Operations
{
	/// <summary>
	/// Исключение, возникающее при определении операндов оператора
	/// </summary>
	public class OperationOperandException : OperationException
	{
		public OperationOperandException(string message) : base(message)
		{

		}

		public OperationOperandException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
