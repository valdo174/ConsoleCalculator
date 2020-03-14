using System;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	/// <summary>
	/// Reverse Polish Notation Parser
	/// </summary>
	public sealed class RPNParser : IParser
	{
		public RPNParser(Dictionary<string, int> operationPriorities)
		{
			OperationPriorities = operationPriorities;
		}

		public Dictionary<string, int> OperationPriorities
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
