using System;

namespace Calculator.Domain.Operations
{
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
