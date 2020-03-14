using System;

namespace Calculator.Domain.Operations
{
	public class OperationException : Exception
	{
		public OperationException(string message, Exception innerException) : base (message, innerException)
		{

		}
	}
}
