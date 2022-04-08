using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ThirdPageModel : PageModel
    {
        public bool IsCorrect { get; set; }
        [BindProperty]
        public int Start { get; set; }
        [BindProperty]
        public int Stop { get; set; }
        [BindProperty]
        public int Step { get; set; }

        public string Message { get; set; }
        public void OnGet(int start, int stop, int step)
        {
            Message = "Enter data";
        }

        public void OnPost()
        {
            IsCorrect = true;
            if(Start > Stop || Start == 0 || Stop == 0 || Step < 1)
            {
                IsCorrect = false;
                return;
            }
            Message = "";
            for (int i = Start; i <= Stop; i+=Step)
            {
                Message += $"{i}";
                if(i < Stop - Step)
                {
                    Message += ", ";
                } 
            }
        }
    }
}
