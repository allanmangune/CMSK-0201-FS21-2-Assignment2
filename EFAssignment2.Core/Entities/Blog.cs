using System;
namespace EFAssignment2.Core.Entities
{
	public class Blog : EntityBase
	{
		public bool IsPublic { get; set; }

		public string Url { get; set; }

		public long BlogTypeId {get;set;}

		public BlogType BlogType { get; set; }

		public Blog()
		{
		}
	}
}

