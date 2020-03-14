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
		private readonly Func<decimal, decimal, decimal> _arithmeticFunction;

		/// <summary>
		/// Инициалзиирует класс Бинарной алгебраической операции с десятичными числами
		/// </summary>
		/// <param name="mark">Обозначение операции</param>
		/// <param name="function">Определение операции</param>
		public BinaryOperation(string mark, int priority, Func<decimal, decimal, decimal> function)
			: base(mark, priority)
		{
			_arithmeticFunction = function;
		}

		public T FirstOperand { get; set; }

		public T SecondOperand { get; set; }

		public override T Calculate()
		{
			throw new NotImplementedException();
		}
	}
}