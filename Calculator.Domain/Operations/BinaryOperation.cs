﻿using System;

namespace Calculator.Domain.Operations
{
	/// <summary>
	/// Класс бинарной алгебраической операции с десятичными числами
	/// </summary>
	public class BinaryOperation<T> : BaseOperation<T>
	{
		/// <summary>
		/// Определение операции
		/// </summary>
		private readonly Func<T, T, T> _arithmeticFunction;

		/// <summary>
		/// Инициалзиирует класс Бинарной алгебраической операции с десятичными числами
		/// </summary>
		/// <param name="mark">Обозначение операции</param>
		/// <param name="priority">Приоритет операции</param>
		/// <param name="function">Определение операции</param>
		public BinaryOperation(string mark, int priority, Func<T, T, T> function)
			: base(mark, priority)
		{
			_arithmeticFunction = function;
		}

		/// <summary>
		/// Первый (левый) операнд
		/// </summary>
		public T FirstOperand { get; set; }

		/// <summary>
		/// Второй (правый) операнд
		/// </summary>
		public T SecondOperand { get; set; }

		/// <summary>
		/// Вычислить результат операции
		/// </summary>
		/// <returns></returns>
		public T Calculate(T firstOperand, T secondOperand)
		{
			try
			{
				return _arithmeticFunction(firstOperand, secondOperand);
			}
			catch (DivideByZeroException zex)
			{
				throw new OperationCalculateException("Ошибка при делении на ноль.", zex);
			}
			catch (NotFiniteNumberException fex)
			{
				throw new OperationCalculateException("Ошибка при вычислении результата функции. Результат являет собой значение с плюс бесконечностью, минус бесконечностью или не является числовым.",
														fex);
			}
			catch (OverflowException oex)
			{
				throw new OperationCalculateException("При вычислении функции произошло переполнение переменной.", oex);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Вычислить результат операции
		/// </summary>
		/// <returns></returns> 
		public override T Calculate()
		{
			if (FirstOperand == null)
				throw new OperationOperandException($"Не задан первый (левый) операнд операции {Mark}");

			if (SecondOperand == null)
				throw new OperationOperandException($"Не задан второй (правый) операнд операции {Mark}");

			var result = Calculate(FirstOperand, SecondOperand);

			if (result == null)
				throw new OperationOperandException($"Неправильно заданы операнды для операции {Mark}");

			return result;
		}
	}
}
