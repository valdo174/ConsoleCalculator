using Calculator.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Domain.Validators
{
	public class ExpressionsValidator<T> : IExpressionsValidator<T>
	{
		public bool BracketsValidation(string expression)
		{
			throw new NotImplementedException();
		}

		public bool ValidateAvailableOperation(string expression, IEnumerable<BaseOperation<T>> availableOperations)
		{
			throw new NotImplementedException();
		}
	}
}
