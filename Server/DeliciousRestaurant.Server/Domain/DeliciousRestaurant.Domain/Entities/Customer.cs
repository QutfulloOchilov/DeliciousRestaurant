namespace DeliciousRestaurant.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string IdentityUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public bool Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
