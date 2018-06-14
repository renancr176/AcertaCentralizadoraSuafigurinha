using System;
using AC.Suafigurinha.IO.Domain.Core.Models;
using AC.Suafigurinha.IO.Domain.Galleries;
using AC.Suafigurinha.IO.Domain.Products;
using FluentValidation;

namespace AC.Suafigurinha.IO.Domain.Images
{
    public class Image : Entity<Image>
    {
        public string Url { get; private set; }
        public int Order { get; private set; }
        public Guid? IdGallery { get; private set; }
        public bool Deleted { get; private set; }

        // EF propriedades de navegacao
        public virtual Gallery Gallery { get; private set; }
        public virtual Product Product { get; private set; }

        public Image(string url, int order)
        {
            Id = Guid.NewGuid();
            Url = url;
            Order = order;
            Deleted = false;
        }

        protected Image() { }

        public void ImageDeleted()
        {
            //TODO: Validar se usuário tem permissão
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
            ValidateUrl();
            ValidateOrder();
        }

        private void ValidateUrl()
        {
            RuleFor(c => c.Url)
                .NotEmpty().WithMessage("Imagem não selecionada ou falha no carregamento.")
                .Length(10, 255).WithMessage("Imagem não selecionada ou falha no carregamento.");
        }
        private void ValidateOrder()
        {
            RuleFor(c => c.Order)
                .GreaterThanOrEqualTo(0).WithMessage("A ordem deve iniciar de 0 (zero).");
        }
        #endregion Validations

        public static class ImageFactory
        {
            public static Image NewFullImage(Guid id, string url, int order, Guid? idGalery)
            {
                var image = new Image()
                {
                    Id = id,
                    Url = url,
                    Order = order
                };

                if (idGalery.HasValue)
                    image.IdGallery = idGalery.Value;

                return image;
            }
        }
    }
}
