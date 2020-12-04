using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VariousNewFeaturesCSharp7.AsyncValueTask;
using VariousNewFeaturesCSharp7.Deconstruction;
using VariousNewFeaturesCSharp7.ExpressionBodiedMembers;
using VariousNewFeaturesCSharp7.Literals;
using VariousNewFeaturesCSharp7.ThrowExpressions;
using VariousNewFeaturesCSharp7.Tuples;

namespace VariousNewFeaturesCSharp7
{
	class Program
	{
		//can now have a Main that's async and returns a Task (new feature in 7.1)
		static async Task Main(string[] args)
		{

			DeconstructionDemo deconstructionDemo = new DeconstructionDemo();
			deconstructionDemo.RunDemo();

			TupleDemo tupleDemo = new TupleDemo();
			tupleDemo.OtherBitsAndPiecesWithNewTuples();

			ExpressionBodiedMembersDemo expressionBodiedMembersDemo = new ExpressionBodiedMembersDemo();
			expressionBodiedMembersDemo.RunDemo();

			ThrowExpressionsDemo throwExpressionsDemo = new ThrowExpressionsDemo();
			//throwExpressionsDemo.RunDemo();

			AsyncValueTaskDemo asyncValueTaskDemo = new AsyncValueTaskDemo();
			asyncValueTaskDemo.RunDemo();

			LiteralsDemo literalsDemo = new LiteralsDemo();
			literalsDemo.RunDemo();

			//before C# 7.1 we would write (function that returns Task).GetAwaiter().GetResult() as Main functions coulnd't have an async signature
			//PROBLEM in the Visual Studio IDE: this Main method is not listed as the Startup object under project properties -> application
			//if there are multiple Main methods then we cannot select this one specifically as the startup Main method
			await Task.Run(() =>
			{
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine($"Counter: {i}");
				}
			});

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
