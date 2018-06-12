using System;
using AC.Suafigurinha.IO.Domain.Core.Models;
using FluentValidation;

namespace AC.Suafigurinha.IO.Domain.Categories
{
    public class Category : Entity<Category>
    {
        public string Name { get; private set; }
        public bool Deleted { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Deleted = false;
        }

        protected Category() { }

        public void CategoryDeleted()
        {
            Deleted = true;
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
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto deve ser informado.")
                .MinimumLength(10).WithMessage("O nome do produto deve ter pelo menos 10 caracteres.")
                .MaximumLength(255).WithMessage("O nome do produto deve ter até 255 caracteres.");
        }
        #endregion Validations

        public static class CategoryFactory
        {
            public static Category NewFullCategory(Guid id, string name)
            {
                var category = new Category()
                {
                    Id = id,
                    Name = name
                };

                return category;
            }
        }
    }
}