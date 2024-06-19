using System;
namespace EFAssignment2.Core.Entities
{
	public class User : EntityBase
	{
		public string Name { get; set; }

		public string EmailAddress { get; set; }

		public string PhoneNumber { get; set; }

		public User()
		{
		}
	}
}

