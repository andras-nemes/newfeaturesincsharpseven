using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.Deconstruction
{
	public static class ExtensionMethods
	{
		public static void Deconstruct(this Rectangle2 rectangle, out int w, out int h)
		{
			w = rectangle.Width;
			h = rectangle.Height;
		}
	}
}
