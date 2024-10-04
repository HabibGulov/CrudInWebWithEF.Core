using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class PersonDbContextFactory : IDesignTimeDbContextFactory<PersonDbContext>
{
    public PersonDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Book_db;Username=postgres;Password=12345;");
        
        return new PersonDbContext(optionsBuilder.Options);
    }
}