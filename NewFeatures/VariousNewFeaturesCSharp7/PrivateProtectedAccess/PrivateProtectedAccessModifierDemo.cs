using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousNewFeaturesCSharp7.PrivateProtectedAccess
{
	//new from C# 7.2: access modifier "private protected" to provide access for derived classes in the current assembly
	public class PrivateProtectedAccessModifierDemo
	{
		public void RunDemo()
		{
			DerivedAnimalInSameAssembly animal = new DerivedAnimalInSameAssembly();
			//the PrivateProtectedAccessModifierDemo class will have access to the following properties:
			//public
			//protected internal: PrivateProtectedAccessModifierDemo doesn't derive from Animal but has access to a protected internal member
			//protected is missing since PrivateProtectedAccessModifierDemo doesn't derive from Animal			
			Console.WriteLine(animal.protectedInternalName);
			Console.WriteLine(animal.publicName);
		}
	}

	public abstract class Animal
	{
		private String privateName = "Private name"; //available only within the containing class Animal
		protected String protectedName = "Protected name"; //available in containing class and derived classes
		protected internal String protectedInternalName = "Protected internal name"; //available in containing class, derived classes in any assembly and any class in the same assembly that intantiates this object
		private protected String privateProtectedName = "Private protected name"; //
		public String publicName = "Public name";
	}

	public class DerivedAnimalInSameAssembly : Animal
	{
		public DerivedAnimalInSameAssembly()
		{
			//this class has access to all members of Animal except for the private one
			Console.WriteLine(base.privateProtectedName);
			Console.WriteLine(base.protectedInternalName);
			Console.WriteLine(base.protectedName);
			Console.WriteLine(base.publicName);
		}
	}
}
