using System.ComponentModel.DataAnnotations;

namespace TodoApi.Data.Repository.Models
{
    public class CategoryModel
    {
        public CategoryModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public CategoryModel()
        {
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "A descrição é obrigatória")]

        public string Description { get; set; } = default!;

        public List<ProductModel>? Products { get; set; }


    }
};
