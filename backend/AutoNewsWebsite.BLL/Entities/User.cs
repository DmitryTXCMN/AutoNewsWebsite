namespace AutoNewsWebsite.BLL.Entities
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Login}: {Password}";
        }
    }
}