using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace maya.Contracts.V1.Requests
{
	public class CreatePostRequest
	{
		public Guid Id { get; set; }
	}
}