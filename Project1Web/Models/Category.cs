using System.ComponentModel.DataAnnotations;

namespace Project1Web.Models
{
    public class Category { 
    
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //this property is use to cutomize the name of the controller
        [Display(Name = "Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be in between 1 and 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
