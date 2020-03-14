using Calculator.Domain.Operations;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Domain.Validators
{
    public class ExpressionsValidator<T> : IExpressionsValidator<T>
	{
		public bool BracketsValidation(string expression)
		{
            if (string.IsNullOrEmpty(expression))
                return true;

            var brackets = new Stack<char>();

            foreach (var c in expression)
            {
                if ( c == '(')
                    brackets.Push(c);
                else if (c == ')')
                {
                    if (brackets.Count <= 0)
                        return false;

                    char open = brackets.Pop();

                    if (c == ')' && open != '(')
                        return false;
                }
            }

            if (brackets.Count > 0)
                return false;

            return true;
        }

		public bool ValidateAvailableOperation(string expression, IEnumerable<BaseOperation<T>> availableOperations)
		{
			for (int i = 0; i < expression.Length; i++)
            {
                if (IsArithmethicSymbol(expression[i]))
                    continue;

                var operation = availableOperations.FirstOrDefault(oper => oper.Mark.Contains(expression[i]));
                if (operation == null)
                    return false;
            }

            return true;
		}

        private bool IsArithmethicSymbol(char symbol)
        {
            return char.IsDigit(symbol) || ".,()".IndexOf(symbol) != -1;
        }
	}
}
