namespace TodoApi.Data.Repository.Models
{
    public class ServiceLineModel
    {
        public ServiceLineModel (){

        }

        public ServiceLineModel (int id, int serviceId, int tableId, int waiterId, int productId, int Quantity){
            this.Id = id;
            this.ServiceId = serviceId;
            this.TableId = tableId;
            this.WaiterId = waiterId;
            this.ProductId = productId;
            this.Quantity = Quantity;
        }
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public ServiceModel? Service { get; set; }
        public int TableId { get; set; }
        public TableModel? Table { get; set; }
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int WaiterId { get; set; }
        public WaiterModel? Waiter { get; set; }
        public int Quantity { get; set; }

    }
}
