using System;

namespace AC.Suafigurinha.IO.Domain.Products.Commands
{
    public class InsertProductCommand : BaseProductCommand
    {
        public InsertProductCommand(Guid id, string name, decimal price, bool haveQuantity, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGalery, Guid? idCategory)
        {
            Id = id;
            Name = name;
            Price = price;
            HaveQuantity = haveQuantity;
            Quantity = quantity;
            ShortDescription = shortDescription;
            Description = description;
            IdImage = idImage;
            IdGalery = idGalery;
            IdCategory = idCategory;
        }
    }
}
