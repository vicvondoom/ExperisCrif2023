using HelloRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        // Tipizzo fortemente questa pagina
        [BindProperty]
        public LoginViewModel lvm { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            string email = lvm.Email;
            string password = lvm.Password;

        }
    }
}
