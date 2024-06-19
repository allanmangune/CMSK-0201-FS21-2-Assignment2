using System;
namespace EFAssignment2.Core.Entities
{
	public abstract class TypeBase : EntityBase
	{
		public Status Status { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public TypeBase()
		{
		}
	}
}

