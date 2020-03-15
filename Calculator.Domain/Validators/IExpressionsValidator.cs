using Calculator.Domain.Operations;
using System.Collections.Generic;

namespace Calculator.Domain.Validators
{
	/// <summary>
	/// Валидатор вычисляемых выражений
	/// </summary>
	/// <typeparam name="T">Тип операндов в выражении</typeparam>
	public interface IExpressionsValidator<T>
	{
		/// <summary>
		/// Провека на допустимые операции в выражении
		/// </summary>
		/// <param name="expression">Проверяемое выражение</param>
		/// <param name="availableOperations">Набор доступных операций</param>
		/// <returns></returns>
		bool ValidateAvailableOperation(string expression, IEnumerable<BaseOperation<T>> availableOperations);

		/// <summary>
		/// Проверка скобочной полноты
		/// </summary>
		/// <param name="expression">Проверяемое выражение</param>
		/// <returns></returns>
		bool BracketsValidation(string expression);
	}
}
