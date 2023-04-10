namespace TodoApi.Data.Repository.Models {
    public class WaiterModel {
        public int Id {get; set; }
        public string FirstName {get; set; } = default!;
        public string LastName {get; set; } = default!;
        public int Code {get; set; } = default!;
        public string Phone {get; set; } = default!;
    }
}
