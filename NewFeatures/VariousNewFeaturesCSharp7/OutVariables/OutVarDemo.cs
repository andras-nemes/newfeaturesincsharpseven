using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.OutVariables
{
	//C# 7.0
	public class OutVarDemo
	{
		public void OldWay()
		{
			int number;
			if (int.TryParse("1234", out number))
			{
				Console.WriteLine(number);
			}
		}

public void NewWay()
{
	//include out param in expression
	if (int.TryParse("1234", out int number)) //works with "var" as well as with the concrete object type
	{
		Console.WriteLine(number);
	}
	//works out of scope as well
	//reference types will be null if parsing fails, otherwise default value is assigned after the parse
	Console.WriteLine(number);
}
	}
}
