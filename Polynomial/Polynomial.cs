using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polynomial
{
	public class Polynomial
	{

		private LinkedList<Term> terms;

		public int NumberOfTerms => terms.Count;

		public int Degree => NumberOfTerms == 0 ? 0 : terms.First.Value.Power;

		public Polynomial()
		{
			terms = new LinkedList<Term>();

		}

		public void AddTerm(double coeff, int pow)
		{
			var newTerm = new Term(pow, coeff);

			for(var currentNode = terms.First; currentNode != null; currentNode = currentNode.Next)
			{
				if(currentNode.Value.Power == pow)
				{
					currentNode.Value.Coefficient += coeff;
					if(currentNode.Value.Coefficient == 0)
					{
						terms.Remove(currentNode);
					}
					return;
				}
				else if(currentNode.Value.Power < pow)
				{
					terms.AddBefore(currentNode, newTerm);
					return;
				}
			}
			terms.AddLast(newTerm);
		}

		//TODO
		public override string ToString()
		{
			string result = "";

			if(terms.Count == 0)
			{
				return "0";
			}
			foreach(var term in terms)
			{
				if(term.Coefficient != 0)
				{
					if(term.Power == 0)
					{
						result += term.ToString();
					}
					else
					{
						result += term.ToString() + "+";
					}
				}
				else
				{
					result += "0";
				}
			}

			return result;
		}

		public static Polynomial Add(Polynomial p1, Polynomial p2)
		{
			Polynomial sum = new Polynomial();
			//DO the math

			foreach(var currentTerm in p1.terms)
			{
				sum.AddTerm(currentTerm.Coefficient, currentTerm.Power);
			}
			foreach(var currentTerm in p2.terms)
			{
				sum.AddTerm(currentTerm.Coefficient, currentTerm.Power);
			}

			//Return sum
			return sum;
		}

		//TODO
        public static Polynomial Subtract(Polynomial p1, Polynomial p2)
        {
            Polynomial difference = new Polynomial();
			//DO the math
			Polynomial subtractedPoly = p2;
			subtractedPoly = Negate(subtractedPoly);

			foreach(var term in subtractedPoly.terms)
			{
				difference.AddTerm(term.Coefficient, term.Power);
			}
			foreach(var currentTerm in p1.terms)
			{
				difference.AddTerm(currentTerm.Coefficient, currentTerm.Power);
			}

            return difference;
        }

		//TODO
        public static Polynomial Negate(Polynomial p)
        {
            Polynomial negated = new Polynomial();
            //DO the math
			foreach(var term in p.terms)
			{
				negated.AddTerm(-term.Coefficient, term.Power);
			}

            return negated;
        }

        public static Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
            Polynomial product = new Polynomial();
            //DO the math
			foreach(var term1 in p1.terms)
			{
				foreach(var term2 in p2.terms)
				{
					product.AddTerm(term1.Coefficient * term2.Coefficient, term1.Power + term2.Power);
				}
			}

            return product;
        }
    }
}