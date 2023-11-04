using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Database;
using Portfolio.Models;

namespace Portfolio.Pages
{
    public class IndexModel : MyPageModel
    {
        public IndexModel(TgBotInfo info, ClientContext db) : base(info, db)
        {

        }

        public void OnGet()
        {
        }
    }
}