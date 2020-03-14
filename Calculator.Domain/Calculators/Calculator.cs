using Calculator.Domain.Parsers;
using Calculator.Domain.Validators;
using System;

namespace Calculator.Domain.Calculators
{
	public class Calculator<T> : ICalculator<T>
	{
		private readonly IExpressionsValidator<T> _validator;

		private readonly IParser<T> _parser;

		public Calculator(IParser<T> parser, IExpressionsValidator<T> validator)
		{
			_validator = validator;
			_parser = parser;
		}

		public T Calculate(string expression)
		{
			try
			{
				if (_validator.BracketsValidation(expression))
					throw new ExpressionFormatException("В данном выражении не одинаковое количество открытых и закрытых скобок.");

				if (_validator.ValidateAvailableOperation(expression, _parser.AvailableOperations))
					throw new ExpressionFormatException("В данном выражении обнаружены операции, которые в данный момент не определены.");

				var reverseExpression = _parser.Parse(expression);

				return _parser.Calculate(reverseExpression);
			}
			catch (Exception ex)
			{
				throw ex;
			}			
		}
	}
}
