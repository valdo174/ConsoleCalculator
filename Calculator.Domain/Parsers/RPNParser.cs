using Calculator.Domain.Operations;
using System;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	/// <summary>
	/// Reverse Polish Notation Parser
	/// </summary>
	public sealed class RPNParser<T> : IParser<T>
	{
		public RPNParser(IEnumerable<BaseOperation<T>> availableOperations)
		{
			AvailableOperations = availableOperations;
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
