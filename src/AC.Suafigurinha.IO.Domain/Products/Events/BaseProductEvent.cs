using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Products.Events
{
    public class BaseProductEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public bool HaveQuantity { get; protected set; }
        public int Quantity { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string Description { get; protected set; }
        public Guid? IdImage { get; protected set; }
        public Guid? IdGalery { get; protected set; }
    }
}
