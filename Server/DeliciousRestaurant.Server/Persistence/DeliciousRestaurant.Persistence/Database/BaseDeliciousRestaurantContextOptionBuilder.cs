using Microsoft.EntityFrameworkCore;

namespace DeliciousRestaurant.Persistence.Database
{
    public class BaseDeliciousRestaurantContextOptionBuilder : DbContextOptionsBuilder<DeliciousRestaurantContext>
    {
        public BaseDeliciousRestaurantContextOptionBuilder(string databaseName, bool shouldCreateDatabase = true)
        {
            DatabaseName = databaseName;
            ShouldCreateDatabase = shouldCreateDatabase;
        }

        public virtual string ConnectionString { get; }
        public string DatabaseName { get; }
        public bool ShouldCreateDatabase { get; }
    }
}
