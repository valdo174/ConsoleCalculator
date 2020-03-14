using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	public interface IParser
	{
		string Parse(string expression);

		Dictionary<string, int> OperationPriorities { get; }
	}
}
