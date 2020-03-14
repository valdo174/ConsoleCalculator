using System.Collections.Generic;

namespace Calculator.Domain.Parser
{
	public interface IParser
	{
		string Parse(string expression);

		Dictionary<string, int> OperationPriorities { get; }
	}
}
