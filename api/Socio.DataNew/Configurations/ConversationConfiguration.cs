using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class ConversationConfiguration : EntityTypeConfiguration<ConversationEntity>
    {
        public ConversationConfiguration()
        {
            ToTable("Conversations");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            HasMany(x => x.Messages)
                .WithRequired(y => y.Conversation)
                .WillCascadeOnDelete(false);
        }
    }
}
