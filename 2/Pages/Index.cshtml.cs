using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _3K2SNETT.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Person person { get; set; }

        public void OnGet()
        {
            Message = "Enter data";
        }

        public void OnPost()
        {
            Message = $"{person.Name} : {person.Age}";
        }
    }
}