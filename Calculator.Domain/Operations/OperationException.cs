using System;

namespace Calculator.Domain.Operations
{
	/// <summary>
	/// Общее исключение для работы с алгкбраическими операторами
	/// </summary>
	public class OperationException : Exception
	{
		public OperationException(string message) : base(message)
		{

		}

		public OperationException(string message, Exception innerException) : base (message, innerException)
		{

		}
	}
}
