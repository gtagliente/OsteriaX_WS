using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace  modisAPI.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //[StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }

        public string Tipo { get; set; }

        public string ImgPath { get; set; }
        //public IList<StudenteCorso> StudenteCorsi { get; set; }

    }
}
