using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Database;
using TelegramBotApiLib;
using TelegramBotApiLib.Models;

namespace Portfolio.Models
{
    public abstract class MyPageModel : PageModel
    {
        [BindProperty]
        public ClientInfo Info { get; set; } = new();
        protected TgBotInfo BotInfo { get; init; }
        protected ClientContext DbContext { get; set; }

        public MyPageModel(TgBotInfo info, ClientContext db)
        {
            this.BotInfo = info;
            this.DbContext = db;
        }

        public async Task OnPost()
        {
            Info.Date = DateTime.Now;

            await DbContext.ClientsInfo.AddAsync(Info);
            await DbContext.SaveChangesAsync();

            int maxRetries = 3;
            int attempts = 0;
            while (attempts < maxRetries)
            {
                try
                {
                    var client = new TelegramClient(BotInfo.Token);
                    var request_mes = new RequestMessage(BotInfo.Id, "You have a new potential client!\n" + Info.ToString());
                    var res = await client.SendMessageAsync(request_mes);

                    if (res)
                    {
                        Info.IsProcessed = true;
                        DbContext.SaveChanges();
                        return;
                    }
                }
                catch (Exception)
                {
                    attempts++;
                    if (attempts > maxRetries)
                    {
                        throw new InvalidOperationException("Failed to send message after multiple attempts. Check the outbox for unprocessed messages.");
                    }
                }
            }
        }
    }
}
