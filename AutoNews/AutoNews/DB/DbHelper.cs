using player.DB;

namespace AutoNews.DB;

public static class DbHelper
{
    public static User? GetUserWithId(string login, string password, PlayerContext dataContext) =>
        dataContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
}
