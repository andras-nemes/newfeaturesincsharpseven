using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariousNewFeaturesCSharp7.PrivateProtectedAccess;

namespace PrivateProtectedDemoInAnotherProject
{
	public class DerivedAnimalInAnotherAssembly : Animal
	{
		public DerivedAnimalInAnotherAssembly()
		{
			//this class has access to all members of Animal except for the private and private protected ones
			Console.WriteLine(base.protectedInternalName);
			Console.WriteLine(base.protectedName);
			Console.WriteLine(base.publicName);
		}
	}
}
