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

		private readonly char[] _brackets;

		public RPNParser(IEnumerable<BaseOperation<T>> availableOperations, char delimeter = ' ')
		{
			AvailableOperations = availableOperations;
			_delimeter = delimeter;

			_brackets = new char[] { '(', ')' };
		}

		public IEnumerable<BaseOperation<T>> AvailableOperations { get; set; }

		public string Parse(string expression)
		{
			throw new NotImplementedException();
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

		private bool IsBracket(char symbol)
		{
			return _brackets.Contains(symbol);
		}
	}
}
