using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.PatternMatching
{
	//C# 7.0
	public class PatternMatchingDemo
	{
		public void Before()
		{
			MakeAnimalSoundOldWay(new Dog());
		}

		public void After()
		{
			MakeAnimalSoundNewWay(new Cat() { Colour = "White" });
			MakeAnimalSoundNewWayWithGenerics(new Dog());
		}

		//only works with C# 7.1 or above
		//make sure to set the build C# version in project properties accordingly
		//the below code will fail with 7.0
		private void MakeAnimalSoundNewWayWithGenerics<T>(T animal) where T : Animal
		{
			if (animal is Dog d)
			{
				d.Whoof();
			}
		}

		private void MakeAnimalSoundNewWay(Animal animal)
		{
			//combine "is", type checking and assignment
			if (animal is Dog dog)
			{
				dog.Whoof();
			}
			else if (animal is Cat cat)
			{
				cat.Meow();
			}

			//or use switch statement
			//can be combined with the "when" keyword for finegraining
			switch (animal)
			{
				case Dog d:
					d.Whoof();
					break;
				case Cat c when (c.Colour == "white"):
					Console.WriteLine("I am a white cat");
					c.Meow();
					break;
			}
		}

		private void MakeAnimalSoundOldWay(Animal animal)
		{
			//use the "is" keyword to find the correct type
			if (animal is Dog)
			{
				Dog dog = (Dog)animal;
				dog.Whoof();
			}
			else if (animal is Cat)
			{
				Cat cat = (Cat)animal;
				cat.Meow();
			}

			//or use the "as" keyword and check for null
			Dog d = animal as Dog;
			if (d != null)
			{
				d.Whoof();
			}

			Cat c = animal as Cat;
			if (c != null)
			{
				c.Meow();
			}
		}
	}

	public abstract class Animal
	{

	}

	public class Dog : Animal
	{
		public void Whoof()
		{
			Console.WriteLine("The dog is barking");
		}
	}

	public class Cat : Animal
	{
		public void Meow()
		{
			Console.WriteLine("The cat is meowing");
		}

		public String Colour { get; set; }
	}
}
