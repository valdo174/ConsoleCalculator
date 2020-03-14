using System.Collections.Generic;

namespace Calculator.Domain.Operations.Extensions
{
	internal static class OperationExtensions
	{
		internal static T GetOperationResultFromOperandsInStack<T>(this BaseOperation<T> operation, Stack<T> stack)
		{
			if (operation is BinaryOperation<T>)
			{
				var oper = (BinaryOperation<T>)operation;

				return oper.Calculate(stack.Pop(), stack.Pop());
			}

			return default(T);
		}
	}
}
