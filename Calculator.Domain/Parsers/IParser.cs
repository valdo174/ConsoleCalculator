using Calculator.Domain.Operations;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	/// <summary>
	/// Парсер арифметических выражений
	/// </summary>
	/// <typeparam name="T">Тип данных в выражении</typeparam>
	public interface IParser<T>
	{
		/// <summary>
		/// Парсинг входного выражение
		/// </summary>
		/// <param name="expression">Входное выражение</param>
		/// <returns>Обратное выражение</returns>
		string Parse(string expression);

		/// <summary>
		/// Вычисление результата по обратному выражению
		/// </summary>
		/// <param name="reverseExpression">Обратное выражение</param>
		/// <returns>Результат вычислений</returns>
		T Calculate(string reverseExpression);

		/// <summary>
		/// Список доступных операций
		/// </summary>
		IEnumerable<BaseOperation<T>> AvailableOperations { get; }
	}
}
