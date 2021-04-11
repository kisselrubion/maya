using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maya.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace maya.Data
{
	public class DataContext : IdentityDbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		public DbSet<Tweet> Tweets { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
