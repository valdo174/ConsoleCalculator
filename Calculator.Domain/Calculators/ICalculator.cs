namespace Calculator.Domain.Calculators
{
	/// <summary>
	/// Интерфейс калькулятора выражений
	/// </summary>
	/// <typeparam name="T">Тип возвращаемого значения</typeparam>
	public interface ICalculator<T>
	{
		/// <summary>
		/// Вычисление результата выражения
		/// </summary>
		/// <param name="expression">Вычисляемое выражение</param>
		/// <returns></returns>
		T Calculate(string expression);
	}
}
