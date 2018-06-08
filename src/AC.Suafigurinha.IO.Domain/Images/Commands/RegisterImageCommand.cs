using System;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class RegisterImageCommand : Command
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public int Order { get; private set; }
        public Guid IdGalery { get; private set; }

        public RegisterImageCommand(Guid id, string url, int order, Guid idGalery)
        {
            Id = id;
            Url = url;
            Order = order;
            IdGalery = idGalery;
        }
    }
}
