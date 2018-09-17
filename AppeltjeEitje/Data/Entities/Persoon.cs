using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppeltjeEitje.Data.Entities
{
    public class Persoon
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime Inschrijfdatum { get; set; }
        public string Emailadres { get; set; }
        public string Telefoonnummer { get; set; }
        public string Notities { get; set; }
    }
}