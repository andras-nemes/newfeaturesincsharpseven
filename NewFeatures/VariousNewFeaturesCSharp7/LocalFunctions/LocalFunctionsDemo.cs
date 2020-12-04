using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.LocalFunctions
{
	//C# 7.0
	public class LocalFunctionsDemo
	{
		public void RunDemo()
		{
			//can use private functions BEFORE they are declared within the function
			int dayDiff = GetDiff(DateTime.UtcNow, DateTime.UtcNow.AddHours(10));

			//we can declare functions within a function
			//this private function is not available outside the scope of the containing function
			//can be used as containers of logic that should not be visible outside the public interface of a class but and for which we don't want to create a private method
			int GetDiff(DateTime first, DateTime second)
			{
				TimeSpan ts = (second - first).Duration();
				return Convert.ToInt32(ts.TotalDays);
			}
			
			Console.WriteLine(dayDiff);
		}
	}

	
}
