using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.Tuples
{
	//C# 7.0
	public class TupleDemo
	{
		public void OldWay()
		{
			var t = AnalyseDatesOld(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
			//it's not easy to know what Item 1 and Item 2 refer to in the Tuple
			//not good from a readability and library usage perspective
			Console.WriteLine(t.Item1);
			Console.WriteLine(t.Item2);
		}

		public void NewWay()
		{
			var t = AnalyseDatesNew(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
			Console.WriteLine(t.TotalDays);
			Console.WriteLine(t.TotalHours);

			//more syntactic sugar
			//override property names
			//this is called deconstruction
			(int days, int hours) t2 = AnalyseDatesNew(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
			Console.WriteLine(t2.days);
			Console.WriteLine(t2.hours);

			//use the variables directly without assignment to a tuple
			(int d, int h) = AnalyseDatesNew(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
			Console.WriteLine(d);
			Console.WriteLine(h);

			//the above is equivalent to the following
			int d2, h2;
			(d2, h2) = AnalyseDatesNew(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));

			//another way of deconstruction using "var"
			var (dateDays, dateHours) = AnalyseDatesNew(DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
			Console.WriteLine(dateDays);
			Console.WriteLine(dateHours);
		}

		public void OtherBitsAndPiecesWithNewTuples()
		{
			//inline Tuple creation
			var dog = (Name: "Doge", Colour: "Black", Age: 5);
			Console.WriteLine($"Name: {dog.Name}, Colour: {dog.Colour}, Age: {dog.Age}");
			Console.WriteLine(dog); //pretty print, sort of...

			//tuple property names carried over to other tuples: tuple name inference
			var myCat = (Name: "Missy", Colour: "White", Age: 4);
			var myOtherCat = (myCat.Name, Colour: "Black", myCat.Age);
			Console.WriteLine(myOtherCat.Name);
			Console.WriteLine(myOtherCat.Colour);
			Console.WriteLine(myOtherCat.Age);

			//create tuples from an array using LINQ Select
			//note the lack of identifier for the Length. The property name will be transferred to the tuple property name
			//this is not valid for functions like ToUpper(), those property names will be the default Item1, Item2 etc.
			string[] colours = new[] { "Black", "White", "Blue", "Red" };
			var colourTuples = colours.Select(c => (c.ToUpper(), c.ToLower(), c.Length));
			foreach (var item in colourTuples)
			{
				Console.WriteLine(item.Item1);
				Console.WriteLine(item.Item2);
				Console.WriteLine(item.Length);
			}
		}

		private Tuple<int, int> AnalyseDatesOld(DateTime first, DateTime second)
		{
			TimeSpan timespan = (second - first).Duration();
			return Tuple.Create(Convert.ToInt32(timespan.TotalDays), Convert.ToInt32(timespan.TotalHours));
			//return new Tuple<int, int>(Convert.ToInt32(timespan.TotalDays), Convert.ToInt32(timespan.TotalHours));
		}

		//we can include property names in the return types
		//we can also ignore them, we'll get the same "Item1" and "Item2" properties as with old fashioned Tuples
		//return type is System.ValueTuple, i.e. not the same as the Tuple type
		private (int TotalDays, int TotalHours) AnalyseDatesNew(DateTime first, DateTime second)
		{
			//get compilation error if not on .NET framework 4.7
			//make sure to set the targeted framework to 4.7 or higher
			//for versions below .NET 4.7 that we need to install a NuGet package called "System.ValueTuple", mistake by Microsoft not to include it in 4.6.2
			TimeSpan timespan = (second - first).Duration();
			return (Convert.ToInt32(timespan.TotalDays), Convert.ToInt32(timespan.TotalHours));
		}
	}
}
