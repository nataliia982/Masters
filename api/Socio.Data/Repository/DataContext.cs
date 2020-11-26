using Socio.Data.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Socio.Data.Repository
{
    public class DataContext : DbContext
    {

        public static string ConString = ConfigurationManager.ConnectionStrings["DataContext1"].ConnectionString;
        public DataContext()
            : base(ConString)
        {
            Database.SetInitializer<DataContext>(new DataInitialisation());

            //DbContext c = new DataContext();
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<FeedMessage> FeedMessages { get; set; }
    }

}
