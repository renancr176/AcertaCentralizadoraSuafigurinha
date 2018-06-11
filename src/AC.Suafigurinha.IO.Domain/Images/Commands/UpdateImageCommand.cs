using System;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class UpdateImageCommand : BaseImageCommand
    {
        public UpdateImageCommand(Guid id, string url, int order, Guid? idGalery)
        {
            Id = id;
            Url = url;
            Order = order;
            IdGalery = idGalery;
        }
    }
}
