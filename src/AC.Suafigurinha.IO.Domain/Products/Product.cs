using System;
using FluentValidation;
using AC.Suafigurinha.IO.Domain.Core.Models;
using AC.Suafigurinha.IO.Domain.Galleries;
using AC.Suafigurinha.IO.Domain.Images;
using AC.Suafigurinha.IO.Domain.Categories;

namespace AC.Suafigurinha.IO.Domain.Products
{
    public class Product : Entity<Product>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool HaveQuantity { get; private set; }
        public int Quantity { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public Guid? IdImage { get; private set; }
        public Guid? IdGalery { get; private set; }
        public Guid? IdCategory { get; private set; }
        public bool Deleted { get; private set; }

        // EF propriedades de navegacao
        public virtual Image ThumbNail { get; private set; }
        public virtual Gallery Gallery { get; private set; }
        public virtual Category Category { get; private set; }

        public Product(string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGallery, Guid? idCategory)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Quantity = quantity;
            ShortDescription = shortDescription;
            Description = description;
            IdImage = idImage;
            IdGalery = idGallery;
            IdCategory = idCategory;
            Deleted = false;
        }

        protected Product() { }

        public void AddThumbNail(Image thumbNail)
        {
            if (!thumbNail.IsValid()) return;
            ThumbNail = thumbNail;
        }

        public void AddGalery(Gallery gallery)
        {
            if (gallery.IsValid()) return;
            Gallery = gallery;
        }

        public void ProductDeleted()
        {
            Deleted = true;
        }

        #region Validation
        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidatePrice();
            ValidateHaveQuantity();
            ValidateQuantity();
            ValidateShortDescription();
        }

        private void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto deve ser informado.")
                .MinimumLength(10).WithMessage("O nome do produto deve ter pelo menos 10 caracteres.")
                .MaximumLength(255).WithMessage("O nome do produto deve ter até 255 caracteres.");
        }
        private void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("O valor do produto deve ser informado.")
                .GreaterThan(0).WithMessage("O valor do produto deve ser maior que 0 (zero).");
        }
        private void ValidateHaveQuantity()
        {
            RuleFor(p => p.HaveQuantity)
               .NotEmpty().WithMessage("Deve ser informado se o produto tem ou não quantidade.");
        }
        private void ValidateQuantity()
        {
            if (HaveQuantity)
            {
                RuleFor(p => p.Quantity)
                    .NotEmpty().WithMessage("A aquantidade do produto deve ser informada")
                    .GreaterThanOrEqualTo(1).WithMessage("A quantidade do produto deve ser maior ou igual a 1.");
            }
            else
            {
                RuleFor(p => p.Quantity)
                    .NotEmpty().WithMessage("A aquantidade do produto deve ser informada.")
                    .Equal(0).WithMessage("A quandiade do produto deve ser 0 (zero).");
            }
        }
        private void ValidateShortDescription()
        {
            RuleFor(p => p.ShortDescription)
                .NotEmpty().WithMessage("A descrição curta deve ser informada.")
                .MinimumLength(10).WithMessage("A descrição curta deve ter pelo menos 10 caracteres.")
                .MaximumLength(255).WithMessage("A descrição curta deve ter no máximo 255 caracteres.");
        }
        private void ValidateDescription()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("A descrição deve ser informada.")
                .MinimumLength(50).WithMessage("A descrição deve ter pelo menos 50 caracteres.");
        }
        #endregion Validation

        public static class ProductFactory
        {
            public static Product NewFullProduct(Guid id, string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGalery, Guid? idCategory)
            {
                var product = new Product()
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    ShortDescription = shortDescription,
                    Description = description
                };

                if (idImage.HasValue)
                    product.IdImage = idImage;
                if (idGalery.HasValue)
                    product.IdGalery = idGalery;
                if (idCategory.HasValue)
                    product.IdCategory = idCategory;

                return product;
            }
        }
    }
}
