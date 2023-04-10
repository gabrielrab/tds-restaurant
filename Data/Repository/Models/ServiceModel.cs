namespace TodoApi.Data.Repository.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }

        public List<ProductModel>? Products { get; set; }

        public WaiterModel? Waiter { get; set; }

        public DateTime StartAt { get; set; } = default!;

        public DateTime EndAt { get; set; } = default!;
    }
}
