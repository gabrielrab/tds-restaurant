using System.ComponentModel.DataAnnotations;

namespace TodoApi.Data.Repository.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
        }

        public ProductModel(int id, string name, string description, double price, CategoryModel? category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "A descrição do produto é obrigatória")]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "O preço é obrigatório")]
        public double Price { get; set; } = default!;

        public int? CategoryId { get; set; }

        public CategoryModel? Category { get; set; }
    }
}
