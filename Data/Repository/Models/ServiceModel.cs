namespace TodoApi.Data.Repository.Models
{
    public class ServiceModel
    {
        public ServiceModel (){

        }

        public ServiceModel (int id, int tableId, DateTime StartAt, DateTime? EndAt){
            this.Id = id;
            this.TableId = tableId;
            this.StartAt = StartAt;
            this.EndAt = EndAt;
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime StartAt { get; set; } = default!;

        public DateTime? EndAt { get; set; } = default!;

        public TableModel? Table { get; set; }
        public List<ServiceLineModel>? ServiceLines { get; set; }
    }
}
