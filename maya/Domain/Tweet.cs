using System;
using System.ComponentModel.DataAnnotations;

namespace maya.Domain
{
	public class Tweet
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}