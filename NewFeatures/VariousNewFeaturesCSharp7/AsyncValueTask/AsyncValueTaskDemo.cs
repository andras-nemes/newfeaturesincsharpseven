using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.AsyncValueTask
{
	//C# 7.0
	public class AsyncValueTaskDemo
	{
		//load NuGet package called System.Threading.Tasks.Extensions to get access to the new ValueTask object
		public void RunDemo()
		{
			//The generic ValueTask of T object helps to prevent the creation of a Task if it's not necessary in async functions
			int res = CalculateSum(0, 0).Result;
			Console.WriteLine(res);
		}

		private async ValueTask<int> CalculateSum(int a, int b)
		{
			if (a == 0 && b == 0)
			{
				return 0; //using the return type Task of T would still create a Task object here even if we can quickly "escape" the function with a default solution
			}

			return await Task.Run(() => a + b);
		}
	}
}
