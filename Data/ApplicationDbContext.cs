using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC4PROGRAMACION.Models;

namespace PC4PROGRAMACION.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }



    
    public DbSet<SentimentModel> Sentimiento { get; set; }
}


