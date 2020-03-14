using Calculator.Domain.Operations;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	public interface IParser<T>
	{
		string Parse(string expression);

		IEnumerable<BaseOperation<T>> AvailableOperations { get; }
	}
}
