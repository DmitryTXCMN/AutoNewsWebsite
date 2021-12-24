using System.Text;

namespace AutoNews;

public static class Config
{
    private const string JwtSecret = "123123123123123123123123123123";
    public static readonly byte[] JwtKey = Encoding.ASCII.GetBytes(JwtSecret);

    public const string AutoNewsCatalog = "autonewssite";
}
