using DeliciousRestaurant.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace DeliciousRestaurant.API.Persistence
{
    public class DeliciousRestaurantContextOptionBuilder : BaseDeliciousRestaurantContextOptionBuilder
    {
        public DeliciousRestaurantContextOptionBuilder() : base("DeliciousRestaurant", true)
        {
            this.UseSqlServer(ConnectionString);
        }
    }
}