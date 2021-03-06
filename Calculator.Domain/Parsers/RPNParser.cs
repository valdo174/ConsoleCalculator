﻿using Calculator.Domain.Operations;
using Calculator.Domain.Operations.Extensions;
using System;
using System.Collections.Generic;

namespace Calculator.Domain.Parsers
{
	/// <summary>
	/// Парсер арифметических выражений по алгоритму обратной польской нотации
	/// </summary>
	public sealed class RPNParser<T> : IParser<T>
	{
		private readonly char _delimeter;

		private const char _openingBracket = '(';
		private const char _closingBracket = ')';

		/// <summary>
		/// Инициалзизирует парсер для обратной польской нотации
		/// </summary>
		/// <param name="availableOperations">Список досупных операций</param>
		/// <param name="delimeter">Разделитель для результирующих выражений</param>
		public RPNParser(IEnumerable<BaseOperation<T>> availableOperations, char delimeter = ' ')
		{
			AvailableOperations = availableOperations;
			_delimeter = delimeter;
		}

		public IEnumerable<BaseOperation<T>> AvailableOperations { get; set; }

		public string Parse(string expression)
		{
			var result = string.Empty;
			var operationStack = new Stack<char>();

			for(int i = 0; i < expression.Length; i++)
			{
				if (IsDelimeter(expression[i]))
				{
					continue;
				}
				else if (char.IsDigit(expression[i]))
				{
					while (!IsOperator(expression[i], out _) 
						&& !IsDelimeter(expression[i])
						&& !IsClosingBracket(expression[i])
						&& !IsOpeningBracket(expression[i]))
					{
						result += expression[i];
						i++;

						if (i == expression.Length) 
							break;
					}

					result += _delimeter;
					i--;
				}
				else if (IsOpeningBracket(expression[i]))
				{
					operationStack.Push(expression[i]);
				}
				else if (IsClosingBracket(expression[i]))
				{
					var pop = operationStack.Pop();

					while (!IsOpeningBracket(pop))
					{
						result += pop.ToString();
						result += _delimeter;

						pop = operationStack.Pop();
					}
				}
				else if (IsOperator(expression[i], out BaseOperation<T> operation))
				{
					// Если в стеке остались операции с приоритетом выше текущей операции,
					// то добавляем их в результирующее выражение
					while (operationStack.Count != 0
							&& IsOperator(operationStack.Peek(), out BaseOperation<T> lastOperation)
							&& lastOperation.Priority >= operation.Priority)
					{
						result += operationStack.Pop();
						result += _delimeter;
					}

					operationStack.Push(expression[i]);
				}
			}

			while (operationStack.Count > 0)
			{
				result += operationStack.Pop();
				result += _delimeter;
			}

			return result;
		}

		public T Calculate(string reverseExpression)
		{
			var operationStack = new Stack<T>();

			for (int i = 0; i < reverseExpression.Length; i++)
			{
				if (char.IsDigit(reverseExpression[i]))
				{
					var number = string.Empty;

					while (!IsDelimeter(reverseExpression[i]) 
						&& !IsOperator(reverseExpression[i], out BaseOperation<T> oper))
					{
						number += reverseExpression[i];
						i++;

						if (i == reverseExpression.Length) 
							break;
					}

					operationStack.Push((T)Convert.ChangeType(number.Replace('.', ','), typeof(T)));
					i--;
				}
				else if (IsOperator(reverseExpression[i], out BaseOperation<T> operation))
				{
					var result = operation.GetOperationResultFromOperandsInStack(operationStack);

					operationStack.Push(result);
				}
			}

			return operationStack.Peek();
		}

		private bool IsDelimeter(char symbol)
		{
			return symbol.Equals(_delimeter);
		}

		private bool IsOperator(char symbol, out BaseOperation<T> operation)
		{
			foreach(var oper in AvailableOperations)
			{
				if (oper.Mark.Equals(new string(symbol, 1)))
				{
					operation = oper;
					return true;
				}
			}

			operation = null;
			return false;
		}

		private bool IsOpeningBracket(char symbol)
		{
			return symbol.Equals(_openingBracket);
		}

		private bool IsClosingBracket(char symbol)
		{
			return symbol.Equals(_closingBracket);
		}
	}
}
