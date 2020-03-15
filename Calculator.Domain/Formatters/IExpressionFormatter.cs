namespace Calculator.Domain.Formatters
{
	/// <summary>
	/// Форматтер для вычисляемых выражений
	/// </summary>
	public interface IExpressionFormatter
	{
		/// <summary>
		/// Форматирование введенного выражения
		/// </summary>
		/// <param name="expression">Введенное выражение</param>
		/// <returns></returns>
		string FormatExpression(string expression);
	}
}
