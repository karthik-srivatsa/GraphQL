using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models;

[GraphQLDescription("Represents any s/w or service that has command line interface")]
public class Platform
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [GraphQLDescription("Represents purchased, valid license for the platform")]
    public string? LicenseKey { get; set; }
    public ICollection<Command> Commands { get; set; } = new List<Command>();

}