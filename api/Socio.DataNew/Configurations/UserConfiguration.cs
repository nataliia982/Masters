using Socio.DataNew.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socio.DataNew.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.Login)
                .IsRequired();

            Property(x => x.Password)
                .IsRequired();

            Property(x => x.Email)
                .IsRequired();

            Property(x => x.IsBanned)
                .IsRequired();

            Property(x => x.Role)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();

            Property(x => x.Surname)
                .IsRequired();

            Property(x => x.Position)
                .IsOptional();

            Property(x => x.BirthDate)
                .IsOptional();

            Property(x => x.Phone)
                .IsOptional();

            Property(x => x.ProfileImageUrl)
                .IsOptional();

            Property(x => x.WebsiteLink)
                .IsOptional();

            Property(x => x.FacebookLink)
                .IsOptional();

            Property(x => x.TwitterLink)
                .IsOptional();

            Property(x => x.City)
                .IsOptional();

            HasMany(x => x.Messages)
                .WithRequired(y => y.User)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Conversations)
                .WithMany(y => y.Users);

            HasMany(x => x.EventsCreated)
    .WithRequired(y => y.UserEntity)
                .WillCascadeOnDelete(false);;

            HasMany(x => x.Subscribtions)
    .WithRequired(y => y.User)
                .WillCascadeOnDelete(false); ;

            HasMany(x => x.Comments)
    .WithRequired(y => y.User)
                .WillCascadeOnDelete(false); ;

            HasMany(x => x.ReceivedFeeds)
                .WithRequired(x => x.ToUser)
                .WillCascadeOnDelete(false);

            HasMany(x => x.SentFeeds)
                .WithRequired(x => x.FromUser)
                .WillCascadeOnDelete(false);
        }

    }
}
