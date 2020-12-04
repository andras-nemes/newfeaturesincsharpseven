using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.DefaultLiterals
{
	public class DefaultLiteralsDemo
	{
		public void RunDemo()
		{
			//old
			int a = default(int);

			//new
			int b = default;

			//can also use it in ternary expressions, the compiler will figure out the type, in this case double
			var number = b > 0 ? default : 0.5;
		}
	}
}
