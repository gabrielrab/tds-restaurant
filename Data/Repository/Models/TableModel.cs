namespace TodoApi.Data.Repository.Models {
    public class TableModel {
        public int Id {get; set; }
        public int Code  {get; set; }
        public bool Status {get; set; } = default!;
        public int StartAt {get; set; } = default!;
    }
}
