using System;

namespace Calculator.Domain.Operations
{
	public class OperationCalculateException : OperationException
	{
		public OperationCalculateException(string message, Exception innerException) : base (message, innerException)
		{

		}
	}
}
