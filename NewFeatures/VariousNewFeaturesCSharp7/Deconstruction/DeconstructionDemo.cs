using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.Deconstruction
{
	//C# 7.0
	public class DeconstructionDemo
	{
		public void RunDemo()
		{
			//we can use deconstruction for tuples, check out the Tuples demo for examples

			//can also use deconstruction for our own custom types, multi-variable declaration
			Rectangle r = new Rectangle { Height = 10, Width = 5 };
			var (w, h) = r;
			Console.WriteLine(w);
			Console.WriteLine(h);

			Rectangle2 r2 = new Rectangle2 { Height = 20, Width = 30 };
			var (w2, h2) = r2;
			Console.WriteLine(w2);
			Console.WriteLine(r2);
		}

		private void ExampleWithIgnoredVariable()
		{
			//if we don't care about a certain deconstructed variable then we can indicate it with an underscore
			Rectangle r = new Rectangle { Height = 10, Width = 5 };
			var (w, _) = r; //cannot refer to a variable called "_"
			Console.WriteLine(w);
		}
	}

	public class Rectangle
	{
		public int Width { get; set; }
		public int Height { get; set; }

		//need to have a Deconstruct method with "out" variables for object deconsruction
		//without this we get a compilation error
		
		public void Deconstruct(out int w, out int h)
		{
			w = Width;
			h = Height;
		}
	}

	public class Rectangle2
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}
}
