namespace DeliciousRestaurant.Application.Customers.Queries.GetListOfCustomer
{
    public class GetCustomerListQuery : IGetCustomerListQuery
    {
        public GetCustomerListQuery(bool onlyActive)
        {
            OnlyActive = onlyActive;
        }

        public bool OnlyActive { get; }
    }
}
