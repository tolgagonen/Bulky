using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key] //Entity Framework kullanırken bir sınıfın (entity) birincil anahtarını (primary key) belirtmek için kullanılır
              //Entity Framework, veritabanı işlemlerinde hangi sütunun birincil anahtar 
              //olarak kullanılacağını anlamak için bu özniteliği kullanır.
              // Birincil anahtar her kaydı benzersiz bir şekilde tanımlayan sütundur***.
        public int Id { get; set; }
        [Required] // Entity Framework ve ASP.NET MVC'de bir özelliğin boş geçilemez olduğunu belirtmek için kullanılır.
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }

    }
}
