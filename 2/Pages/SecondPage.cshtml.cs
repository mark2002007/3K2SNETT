using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class SecondPageModel : PageModel
    {
        public bool IsCorrect { get; set; }
        [BindProperty]
        public int Start { get; set; }
        [BindProperty]
        public int Stop { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Enter Data";
        }
        public void OnPost()
        {
            IsCorrect = true;
            if(Start > Stop || Start == 0 || Stop == 0)
            {
                IsCorrect = false;
                return;
            }
            Message = "";
            for (int i = Start; i <= Stop; i++)
            {
                Message += $"{i}";
                if(i != Stop)
                {
                    Message += ", ";
                } 
            }
        }
    }
}
