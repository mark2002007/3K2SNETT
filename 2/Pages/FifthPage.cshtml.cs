using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class FifthPageModel : PageModel
    {
        public bool IsCorrect { get; set; }
        [BindProperty]
        public int Start { get; set; }
        [BindProperty]
        public int Stop { get; set; }
        [BindProperty]
        public int Step { get; set; }

        public string Message { get; set; }
        public List<int> Nums { get; set; }
        public void OnGet()
        {
            Message = "Enter Data";
        }

        public void OnPost()
        {
            IsCorrect = true;
            if(Start > Stop || Stop == 0 || Start == 0 || Step < 1)
            {
                IsCorrect = false;
                return;
            }
            Nums = new List<int>();
            for (int i = Start; i <= Stop; i+= Step)
            {
                Nums.Add(i);
            }
        }

    }
}
