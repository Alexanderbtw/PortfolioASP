namespace Portfolio.Models
{
    public class TgBotInfo
    {
        public string Token { get; set; }
        public int Id { get; set; }

        public TgBotInfo(string token, int id)
        {
            Token = token;
            Id = id;
        }
    }
}
