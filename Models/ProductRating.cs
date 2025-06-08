using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC4PROGRAMACION.Models
{
    public class ProductRating
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public float Label { get; set; } // el rating (de 1 a 5)
    }
}