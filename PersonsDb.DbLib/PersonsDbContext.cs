using Microsoft.EntityFrameworkCore;

namespace PersonsDb.DbLib;

public class PersonsDbContext : DbContext
{
    private readonly string _connectionString;
    
    public DbSet<Person> Persons { get; set; }

    public PersonsDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}