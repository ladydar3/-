using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public class Standard
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
}