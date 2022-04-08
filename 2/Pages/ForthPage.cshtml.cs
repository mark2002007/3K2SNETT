using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;

namespace MyApp.Namespace
{
    public class ForthPageModel : PageModel
    {
        public bool IsCorrect { get; set; }
        [BindProperty]
        public int Start { get; set; }
        [BindProperty]
        public int Stop { get; set; }

        public string Message { get; set; }
        public List<int> Nums { get; set; }
        
        public void OnGet()
        {
            Message = "Enter data";
        }        
        public void OnPost()
        {
            IsCorrect = true;
            if(Start > Stop || Start == 0 || Stop == 0) 
            {
                IsCorrect = false;
                return;
            }
            Nums = Enumerable.Range(Start, Stop-Start+1).ToList();
        }
    }
}
