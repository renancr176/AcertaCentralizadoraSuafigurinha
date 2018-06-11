using System;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class InsertImageCommand : BaseImageCommand
    {
        
        public InsertImageCommand(Guid id, string url, int order, Guid? idGalery)
        {
            Id = id;
            Url = url;
            Order = order;
            IdGalery = idGalery;
        }
    }
}
