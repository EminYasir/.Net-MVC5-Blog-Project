using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçirilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En az 3 karakterlik kategori adı girişi yapınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("En fazla 50 karakterlik kategori adı girişi yapabilirsiniz!");

        }
    }
}
