using System;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class BaseGalleryCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Guid?> IdImages { get; protected set; }
    }
}
