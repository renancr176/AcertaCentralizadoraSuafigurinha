﻿using System;

namespace AC.Suafigurinha.IO.Domain.Products.Commands
{
    public class InsertProductCommand : BaseProductCommand
    {
        public InsertProductCommand(Guid id, string name, decimal price, int quantity, string shortDescription, string description, Guid? idImage, Guid? idGalery)
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
