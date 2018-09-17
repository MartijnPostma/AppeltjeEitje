using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppeltjeEitje.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "min 3")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Emailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Geen valid emailadres")]
        public string Emailadres { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "250 karakters max")]
        public string Bericht { get; set; }
    }
}
