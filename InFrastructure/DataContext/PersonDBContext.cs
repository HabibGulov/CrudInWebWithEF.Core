using Microsoft.EntityFrameworkCore;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    { 

    }
    public DbSet<Person> People { get; set; }
}