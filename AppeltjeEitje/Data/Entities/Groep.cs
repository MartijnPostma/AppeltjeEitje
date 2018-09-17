using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppeltjeEitje.Data.Entities
{
    public class Groep
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Persoon> Personen { get; set; }
    }
}