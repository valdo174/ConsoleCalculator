using System;

namespace Calculator.Domain.Operations
{
	/// <summary>
	/// Базовый класс алгебраической операции
	/// </summary>
	/// <typeparam name="T">Тип данных операции</typeparam>
	public abstract class BaseOperation<T>
	{
		public BaseOperation(string mark, int priority)
		{
			Mark = mark;
			Priority = priority;
		}

		/// <summary>
		/// Приоритет операции относиельно других операций в выражении
		/// </summary>
		public int Priority { get; protected set; }

		/// <summary>
		/// Обозначение операции
		/// </summary>
		public string Mark { get; protected set; }

		/// <summary>
		/// Вычислить результат операции
		/// </summary>
		/// <returns></returns>
		public abstract T Calculate();
	}
}
