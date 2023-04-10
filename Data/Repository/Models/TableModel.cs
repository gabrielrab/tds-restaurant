namespace TodoApi.Data.Repository.Models
{
    public class TableModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public bool Status { get; set; } = default!;
        public DateTime StartAt { get; set; } = default!;
    }
}
