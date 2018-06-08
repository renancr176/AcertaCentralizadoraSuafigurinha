using System;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Models;
using AC.Suafigurinha.IO.Domain.Images;
using FluentValidation;

namespace AC.Suafigurinha.IO.Domain.Galleries
{
    public class Gallery : Entity<Gallery>
    {
        public string Name { get; private set; }
        public virtual List<Image> Images { get; private set; }

        public Gallery(string name, List<Image> images)
        {
            Id = Guid.NewGuid();
            Name = name;
            Images = images;
        }

        #region Validations

        public override bool IsValid() 
        {
            Validate();

            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome da galeria deve ser informada.")
                .Length(10, 255).WithMessage("O nome da galeria deve ser ter entre 10 a 255 caracteres.");
        }

        #endregion Validations
    }
}
