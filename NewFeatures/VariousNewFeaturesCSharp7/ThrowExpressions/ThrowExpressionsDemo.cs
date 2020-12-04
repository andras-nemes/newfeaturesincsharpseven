using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.ThrowExpressions
{
	//C# 7.0
	public class ThrowExpressionsDemo
	{
		public void RunDemo()
		{
			//double res = Divide(10, 0);
			Dog dog = new Dog(null);
		}

		//we can now throw exceptions in ternary operators
		private double Divide(double what, double withWhat)
		{
			return withWhat != 0 ? what / withWhat : throw new ArgumentException("nono");
		}
	}

public class Dog
{
	private string name;
	//we can also apply the same construct with null-coalescing operators
	public Dog(string name) => this.name = name ?? throw new ArgumentNullException("Dog name");
}
}
