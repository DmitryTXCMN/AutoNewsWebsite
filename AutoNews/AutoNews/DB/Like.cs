using System.ComponentModel.DataAnnotations;

namespace AutoNews.DB;

public class Like
{
    [Required] public int Id { get; set; }
    [Required] public int WriterId { get; set; }
    [Required] public int NewsId { get; set; }
}
