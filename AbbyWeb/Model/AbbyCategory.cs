using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class AbbyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Display Order")]
        [Range(0,100)]
        public int DisplayOrder { get; set; }
    }
}
