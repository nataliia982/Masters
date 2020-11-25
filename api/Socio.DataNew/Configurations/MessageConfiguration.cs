using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class MessageConfiguration : EntityTypeConfiguration<MessageEntity>
    {
        public MessageConfiguration()
        {
            ToTable("Messages");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.Body)
                .IsRequired();
        }
    }
}
