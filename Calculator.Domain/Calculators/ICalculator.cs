namespace Calculator.Domain.Calculators
{
	public interface ICalculator<T>
	{
		T Calculate(string expression);
	}
}
