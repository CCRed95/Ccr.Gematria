using Ccr.Gematria.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Ccr.Gematria.Data.Core.Extensions;
using Ccr.Gematria.Data.Maps;

namespace Ccr.Gematria.Data.Context
{
	public class CoreContext
		: DbContext
	{
		/// <summary>
		///	The database table <see cref="DbSet{TEntity}"/>, containing <see cref="GematriaResults"/> entities. 
		/// </summary>
		public DbSet<GematriaResult> GematriaResults { get; set; }


		public CoreContext()
		{
		}
		
		//	DbContextOptions options)
		//		: base(options)
		//{
		//}


		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			const string local =
				"Data Source=(localdb)" +
				"\\MSSQLLocalDB;" +
				"Initial Catalog=Ccr.Gematria;" +
				"Integrated Security=True";

			optionsBuilder.UseSqlServer(local);

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(
			ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");

			base.OnModelCreating(modelBuilder);

			modelBuilder
				.WithConfiguration<GematriaResult, GematriaResultMap>();
		}
	}
}
