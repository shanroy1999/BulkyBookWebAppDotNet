using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        // properties of the table

        // Use data annotation 'Key' for making Id as primary key and the identity column
        [Key]
        public int Id { get; set; }

        // Make sure Name is a required property - not null property - use 'Required' annotation
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage="Display Order must lie between 1 & 100 only.")]
        public int DisplayOrder { get; set; }

        // set the default value to current date time when object created
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
