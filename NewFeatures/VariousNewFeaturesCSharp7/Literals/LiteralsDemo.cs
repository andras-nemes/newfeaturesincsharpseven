using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.Literals
{
	//C# 7.0
	public class LiteralsDemo
	{
		public void RunDemo()
		{
			//use underscores for delimiters, will be ignored at runtime
			int number = 3_452_123;
			Console.Write(number);
		}
	}
}
