using System;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class BaseImageCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Url { get; protected set; }
        public int Order { get; protected set; }
        public Guid? IdGalery { get; protected set; }
    }
}
