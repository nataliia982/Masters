using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class CommentConfiguration : EntityTypeConfiguration<CommentEntity>
    {
        public CommentConfiguration()
        {
            ToTable("Comments");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.Text)
                .IsRequired();
        }
    }
}
