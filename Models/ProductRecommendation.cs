using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC4PROGRAMACION.Models
{
    public class ProductRecommendation
    {
        public string UserId { get; set; }
        public List<string> RecommendedProductIds { get; set; } = new List<string>();
    }
}