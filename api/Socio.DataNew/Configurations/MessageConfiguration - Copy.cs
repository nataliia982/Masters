using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class SubscribtionConfiguration : EntityTypeConfiguration<SubscribpitonEntity>
    {
        public SubscribtionConfiguration()
        {
            ToTable("Subscribtions");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();
        }
    }
}
