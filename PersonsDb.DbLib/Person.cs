using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonsDb.DbLib;

[Table("table_persons")]
public class Person
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("last_name")]
    [Required]
    public string LastName { get; set; }
    
    [Column("first_name")]
    [Required]
    public string FirstName { get; set; }
    
    [NotMapped]
    public string FullName => $"{LastName} {FirstName}";
}