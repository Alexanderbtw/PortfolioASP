using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Database;
using Portfolio.Models;

namespace Portfolio.Pages
{
    public class AboutModel : MyPageModel
    {
        public AboutModel(TgBotInfo info, ClientContext db) : base(info, db)
        {
            
        }

        public void OnGet()
        {
        }
    }
}
