using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulkyWeb.Models
{
    public class Product
    {
        [Key] //Entity Framework kullanırken bir sınıfın (entity) birincil anahtarını (primary key) belirtmek için kullanılır
              //Entity Framework, veritabanı işlemlerinde hangi sütunun birincil anahtar 
              //olarak kullanılacağını anlamak için bu özniteliği kullanır.
              // Birincil anahtar her kaydı benzersiz bir şekilde tanımlayan sütundur***.
        public int Id { get; set; }
        [Required] // Entity Framework ve ASP.NET MVC'de bir özelliğin boş geçilemez olduğunu belirtmek için kullanılır.
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]

        [Display(Name = "List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        [Display(Name = "Price for 50+")]//Daha fazla ürün için daha ucuz fiyat
        [Range(1, 1000)]              //Price50 ve Price100 bunun için
        public double Price50 { get; set; }

        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        [ValidateNever]
        public int CategoryId {  get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
