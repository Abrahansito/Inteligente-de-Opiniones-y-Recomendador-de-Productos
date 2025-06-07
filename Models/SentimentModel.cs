using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC4PROGRAMACION.Models
{
    public class SentimentModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        public string? Mensaje { get; set; }
        public string? Prediction { get; set; }
        public float Score { get; set; }
        
    }
}