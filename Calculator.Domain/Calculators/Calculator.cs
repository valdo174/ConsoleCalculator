using Calculator.Domain.Formatters;
using Calculator.Domain.Parsers;
using Calculator.Domain.Validators;
using System;

namespace Calculator.Domain.Calculators
{
	/// <summary>
	/// Базовая реализация калькулятора
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Calculator<T> : ICalculator<T>
	{
		private readonly IExpressionsValidator<T> _validator;

		private readonly IParser<T> _parser;

		private readonly IExpressionFormatter _formatter;

		public Calculator(IParser<T> parser, IExpressionsValidator<T> validator, IExpressionFormatter formatter)
		{
			_validator = validator;
			_parser = parser;
			_formatter = formatter;
		}

		public T Calculate(string expression)
		{
			try
			{
				if (!_validator.BracketsValidation(expression))
					throw new ExpressionFormatException("В данном выражении не одинаковое количество открытых и закрытых скобок.");

				if (!_validator.ValidateAvailableOperation(expression, _parser.AvailableOperations))
					throw new ExpressionFormatException("В данном выражении обнаружены операции, которые в данный момент не определены.");

				var reverseExpression = _parser.Parse(_formatter.FormatExpression(expression));

				return _parser.Calculate(reverseExpression);
			}
			catch (Exception ex)
			{
				throw ex;
			}			
		}
	}
}
