using Microsoft.AspNetCore.Mvc.RazorPages;

namespace classwork20_12.Models
{
    //[PageRoute("/random", Name = "random")]
    public class RandomLetterModel : PageModel
    {
        public char RandomLetter { get; set; }

        public void OnGet()
        {
            Random random = new Random();
            int index = random.Next(0, 100);
            RandomLetter = (char) index;
        }
    }
}
