namespace Store.Web.Application
{
    public class Cart
    {
        public int OrderId { get; }

        public int TotalCount { get; }

        public decimal TotalPrice { get; }


        public Cart(int orderid, int totalCount, decimal totalPrice) 
        {
            this.OrderId = orderid;
            TotalCount = totalCount;
            TotalPrice = totalPrice;
        }
        
    }
}
