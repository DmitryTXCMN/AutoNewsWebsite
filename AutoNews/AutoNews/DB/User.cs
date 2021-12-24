using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AutoNews.DB;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class User
{
    public int Id { get; set; }
    [Required] public string Login { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string NickName { get; set; }
    [Required] public string Name { get; set; }
    [Required] public int Age { get; set; }
    [Required] public string AboutMe { get; set; }
    [Required] public string AvatarUrl { get; set; }
    
    public override string ToString() => $"{Login} {Password} {Name} {NickName} {Age}";
}
