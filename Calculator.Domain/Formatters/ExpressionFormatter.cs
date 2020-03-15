namespace Calculator.Domain.Formatters
{
	/// <summary>
	/// Базовый форматтер
	/// </summary>
	public class ExpressionFormatter : IExpressionFormatter
	{
		public string FormatExpression(string expression)
		{
			if (expression.Contains(" "))
				expression = expression.Replace(" ", "");

			if (expression.StartsWith("-"))
				expression = "0" + expression;

			if (expression.Contains("(-"))
				expression = expression.Replace("(-", "(0-");

			return expression;
		}
	}
}
