using System.ComponentModel.DataAnnotations;

namespace TesteEf.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        public string Description {get;set;}

        [Range(1,int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price {get;set;}

        [Range(1,int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId{get;set;}
        public Category Category{get;set;}


    }

}