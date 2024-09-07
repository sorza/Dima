using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Categories;
public class CreateCategoryRequest : Request
{
    [Required(ErrorMessage ="O título é obrigatório")]
    [MaxLength(80, ErrorMessage ="O Título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Description { get; set; } = string.Empty;
}
