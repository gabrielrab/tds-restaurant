namespace TodoApi.Data.Repository.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

    }
};
