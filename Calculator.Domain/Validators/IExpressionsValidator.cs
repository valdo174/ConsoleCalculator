using Calculator.Domain.Operations;
using System.Collections.Generic;

namespace Calculator.Domain.Validators
{
	public interface IExpressionsValidator<T>
	{
		bool ValidateAvailableOperation(string expression, IEnumerable<BaseOperation<T>> availableOperations);

		bool BracketsValidation(string expression);
	}
}
