using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyValidation.Models;

namespace MyValidation.Pages.Books
{
    public class CreateModel : PageModel
    {

        private readonly IValidator<Book> _bookValidator;
        public CreateModel(IValidator<Book> bookValidator)
        {
            _bookValidator = bookValidator;
        }

        [BindProperty]
        public Book Book { get; set; }
        public IActionResult OnPost()
        {
            var result= _bookValidator.Validate(Book);
            if (result.IsValid)
            {
                TempData["bookName"] = Book.Name;
                //save to database
                return RedirectToPage("./index");
            }
            //foreach (var Error in result.Errors)
            //{
            //    ModelState.AddModelError("Book."+ Error.PropertyName, Error.ErrorMessage);
            //}
            return Page();
        }
    }
}
