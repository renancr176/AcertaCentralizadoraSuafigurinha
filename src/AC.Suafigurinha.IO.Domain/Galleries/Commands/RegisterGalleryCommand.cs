using System;
using AC.Suafigurinha.IO.Domain.Images;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class RegisterGalleryCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual IEnumerable<Guid> Images { get; private set; }

        public RegisterGalleryCommand(Guid id, string name, IEnumerable<Guid> images)
        {
            Id = id;
            Name = name;
            Images = images;
        }
    }
}
