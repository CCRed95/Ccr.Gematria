using Ccr.Gematria.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ccr.Gematria.Data.Maps
{
	public class GematriaResultMap
		: IEntityTypeConfiguration<GematriaResult>
	{
		public void Configure(
			EntityTypeBuilder<GematriaResult> builder)
		{
			builder.ToTable("GematriaResults");

			builder.HasKey(t => t.GematriaResultID);
			builder.Property(t => t.GematriaResultID)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder.Property(t => t.Text)
				.IsRequired()
				.HasMaxLength(300);

			builder.Property(t => t.EnglishOrdinal)
				.IsRequired();

			builder.Property(t => t.ReverseOrdinal)
				.IsRequired();

			builder.Property(t => t.FullReduction)
				.IsRequired();

			builder.Property(t => t.ReverseFullReduction)
				.IsRequired();

			builder.Property(t => t.Jewish)
				.IsRequired();

			builder.Property(t => t.FibonacciSequence)
				.IsRequired();
		}
	}
}
