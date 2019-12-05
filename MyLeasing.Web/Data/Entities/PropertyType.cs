using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyType 
    {
        

        public int Id { get; set; }

        [Display(Name = "Property Type")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more this {1} characters.")]
        [Required(ErrorMessage = "The filed {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
