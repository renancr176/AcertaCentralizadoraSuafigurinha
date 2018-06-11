using System;
using AC.Suafigurinha.IO.Domain.Core.Events;


namespace AC.Suafigurinha.IO.Domain.Products.Events
{
    public class ProductRegistredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public Guid? IdImage { get; private set; }
        public Guid? IdGalery { get; private set; }

        public ProductRegistredEvent(Guid id, string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGalery)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ShortDescription = shortDescription;
            Description = description;
            IdImage = idImage;
            IdGalery = idGalery;
        }
    }
}
