using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


public class Recomendacion
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El usuario es obligatorio.")]
    public float UserId { get; set; }

    public float ProductId { get; set; }

    public float Score { get; set; }
}