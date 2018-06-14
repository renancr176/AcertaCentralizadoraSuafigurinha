using System;
using System.Collections.Generic;
using System.Linq;
using AC.Suafigurinha.IO.Domain.Core.Models;
using AC.Suafigurinha.IO.Domain.Images;
using AC.Suafigurinha.IO.Domain.Products;
using FluentValidation;

namespace AC.Suafigurinha.IO.Domain.Galleries
{
    public class Gallery : Entity<Gallery>
    {
        public string Name { get; private set; }
        public IEnumerable<Guid?> IdImages { get; private set; }
        public bool Deleted { get; private set; }

        // EF propriedades de navegacao
        public virtual ICollection<Image> Images { get; private set; }
        public virtual Product Product { get; private set; }

        public Gallery(string name, IEnumerable<Guid?> idImages)
        {
            Id = Guid.NewGuid();
            Name = name;
            if (!idImages.Where(i => !i.HasValue).Any())
                IdImages = idImages;
            else
                IdImages = new List<Guid?>();
            Deleted = false;
        }

        protected Gallery() { }

        public void GalleryDeleted()
        {
            Deleted = true;
        }

        public void AddIdImages(List<Guid?> idImages)
        {
            if (idImages.Where(i => !i.HasValue).Any()) return;
            IdImages = idImages;
        }

        public void AddImages(List<Image> images)
        {
            if (images.Where(i => !i.IsValid()).Any()) return;
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
        private void ValidateImages()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome da galeria deve ser informada.")
                .Length(10, 255).WithMessage("O nome da galeria deve ser ter entre 10 a 255 caracteres.");
        }
        #endregion Validations

        public static class GalleryFactory
        {
            public static Gallery NewFullGallery(Guid id, string name, IEnumerable<Guid?> idImage)
            {
                var gallery = new Gallery()
                {
                    Id = id,
                    Name = name,
                    IdImages = idImage
                };

                return gallery;
            }
        }
    }
}
