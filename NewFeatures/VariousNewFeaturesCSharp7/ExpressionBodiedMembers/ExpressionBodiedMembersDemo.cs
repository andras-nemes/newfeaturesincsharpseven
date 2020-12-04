using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.ExpressionBodiedMembers
{
	//C# 7.0
	public class ExpressionBodiedMembersDemo
	{
		public void RunDemo()
		{
			Dog dog = new Dog("Doge");
			Console.WriteLine(dog.NameFormatted);
			dog.NameFormatted = "wildboy";
			Console.WriteLine(dog.Name);
		}
	}

	public class Dog
	{
		private string name;

		//expression bodied members are available for constructors as well in C#7
		public Dog(String name) => this.name = name;	

		//properties with expr.bodied members
		public string NameFormatted
		{
			get => name.ToUpper();
			set => name = value.ToUpper();
		}

		public string Name
		{
			get => name;
		}
	}
}
