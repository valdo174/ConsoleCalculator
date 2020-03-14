using Calculator.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

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
					while (!IsOperator(expression[i], out BaseOperation<T> oper) 
						&& !IsDelimeter(expression[i])
						&& !IsClosingBracket(expression[i])
						&& !IsOpeningBracket(expression[i]))
					{
						result += expression[i];
						i++;

						if (i == expression.Length) 
							break;
					}

					result += " ";
					i--;
				}
				else if (IsOpeningBracket(expression[i]))
				{
					operationStack.Push(expression[i]);
				}
				else if (IsClosingBracket(expression[i]))
				{
					var pop = operationStack.Pop();

					while (!(IsOpeningBracket(pop)))
					{
						result += pop.ToString() + ' ';
						pop = operationStack.Pop();
					}
				}
				else if (IsOperator(expression[i], out BaseOperation<T> operation))
				{
					if (operationStack.Count > 0 &&
							IsOperator(operationStack.Peek(), out BaseOperation<T> peekOperation))
					{
						if (operation.Priority <= peekOperation.Priority)
						{
							result += operationStack.Pop().ToString() + " ";
						}
					}

					operationStack.Push(char.Parse(expression[i].ToString()));
				}
			}

			while (operationStack.Count > 0)
				result += operationStack.Pop() + " ";

			return result;
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
