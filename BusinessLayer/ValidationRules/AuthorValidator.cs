using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar Resmi Boş Bırakılamaz");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar Hakkında Boş Bırakılamaz");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Yazar Hakkında Kısa Bilgi Boş Bırakılamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Yazar Telefon Numarası Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Yazar Maili Boş Bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Yazarın Şifresi Boş Bırakılamaz");
        }
    }
}
