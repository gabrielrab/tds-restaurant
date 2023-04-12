namespace TodoApi.Data.Repository.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }

        public List<ProductModel>? Products { get; set; }

        public DateTime StartAt { get; set; } = default!;

        public DateTime EndAt { get; set; } = default!;

        public TableModel? Table { get; set; }

        public List<WaiterModel>? Waiters { get; set; }
    }
}
