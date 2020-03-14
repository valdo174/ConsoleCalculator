using Calculator.Domain.Operations;
using System;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	/// <summary>
	/// Парсер арифметических выражений по алгоритму обратной польской нотации
	/// </summary>
	public sealed class RPNParser<T> : IParser<T>
	{
		private readonly char _delimeter;

		public RPNParser(IEnumerable<BaseOperation<T>> availableOperations, char delimeter = ' ')
		{
			AvailableOperations = availableOperations;
			_delimeter = delimeter;
		}

		public IEnumerable<BaseOperation<T>> AvailableOperations
		{
			get { throw new NotImplementedException(); }
			private set { }
		}

		public string Parse(string expression)
		{
			throw new NotImplementedException();
		}
	}
}
