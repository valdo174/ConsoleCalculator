using System.Collections.Generic;

namespace Calculator.Domain.Validators
{
	public interface IExpressionsValidator
	{
		bool Validate(string expression, IEnumerable<string> availableOperations);
	}
}
