namespace TodoApi.Data.Repository.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; } = default!;
        public List<CategoryModel>? Categories { get; set; }
    }
}
