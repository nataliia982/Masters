using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class FeedMessageConfiguration : EntityTypeConfiguration<FeedMessageEntity>
    {
        public FeedMessageConfiguration()
        {
            ToTable("FeedMessages");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.WasEdited)
                .IsRequired();

            Property(x => x.FeedText)
                .IsRequired();
        }
    }
}
