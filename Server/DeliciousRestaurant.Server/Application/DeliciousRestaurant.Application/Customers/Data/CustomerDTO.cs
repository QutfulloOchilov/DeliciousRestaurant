using DeliciousRestaurant.Application.Data;

namespace DeliciousRestaurant.Application.Customers.Data
{
    public class CustomerDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Image { get; set; }
    }
}
