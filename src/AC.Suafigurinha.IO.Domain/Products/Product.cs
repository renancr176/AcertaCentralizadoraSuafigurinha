using System;
using AC.Suafigurinha.IO.Domain.Core.Models;
using AC.Suafigurinha.IO.Domain.Galleries;
using AC.Suafigurinha.IO.Domain.Images;

namespace AC.Suafigurinha.IO.Domain.Products
{
    public class Product : Entity<Product>
    {
        public Product(string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGallery)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Quantity = quantity;
            ShortDescription = shortDescription;
            Description = description;
            IdImage = idImage;
            IdGalery = idGallery;
        }

        protected Product() { }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public Guid? IdImage { get; private set; }
        public Guid? IdGalery { get; private set; }

        // EF propriedades de navegacao
        public virtual Image ThumbNail { get; private set; }
        public virtual Gallery Gallery { get; private set; }

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

        #region Validation
        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
        #endregion Validation

        public static class ProductFactory
        {
            public static Product NewFullProduct(Guid id, string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGalery)
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

                return product;
            }
        }
    }
}
