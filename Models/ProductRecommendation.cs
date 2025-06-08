using System.Collections.Generic;

namespace PC4PROGRAMACION.Models
{
    public class ProductRecommendation
    {
        public float UserId { get; set; }
        public List<(float ProductId, float Score)> RecommendedProducts { get; set; } = new();
    }
    
}