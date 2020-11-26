using Socio.DataNew.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.DataNew.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<EventEntity>
    {
        public EventConfiguration()
        {
            ToTable("Events");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.Name)
                .IsOptional();

            Property(x => x.Description)
                .IsOptional();

            Property(x => x.Time)
                .IsOptional();

            Property(x => x.CriteriaList)
                .IsRequired();

            HasMany(x => x.Comments).WithRequired(y=> y.Event);

            HasMany(x => x.Subscribrions)
                .WithRequired(y => y.Event);
        }
    }
}
