using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace MyValidation.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
    }

    //FluentValidation
    public class BookValidator: AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name).NotNull().NotEmpty().WithMessage("باید وارد شود");
            RuleFor(b => b.Price).NotNull().NotEmpty().WithMessage("باید وارد شود");
            RuleFor(b => b.Year).NotNull().NotEmpty().WithMessage("باید وارد شود");

            RuleFor(b => b.Price).InclusiveBetween(0,500).WithMessage("It Must be between 0 & 500");
            RuleFor(b => b.Year).InclusiveBetween(1990,DateTime.Now.Year).WithMessage("It Must be between 1990 & {To}");
        }
    }
}
