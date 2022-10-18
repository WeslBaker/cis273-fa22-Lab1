using System;
namespace Polynomial
{
	public class Term
	{
		public int Power { get; set; }
		public double Coeffecient { get; set; }

		public Term(int power, double coeffecient)
		{
			Power = power;
			Coeffecient = coeffecient;
		}

		public override string ToString()
		{
			return $"{Coeffecient}x^{Power}";
		}

		double 
	}
}

