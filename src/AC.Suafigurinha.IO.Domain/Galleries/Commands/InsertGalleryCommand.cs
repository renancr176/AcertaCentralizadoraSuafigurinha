using System;
using AC.Suafigurinha.IO.Domain.Images;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class InsertGalleryCommand : BaseGalleryCommand
    {
        public InsertGalleryCommand(Guid id, string name, IEnumerable<Guid?> idImages)
        {
            Id = id;
            Name = name;
            IdImages = idImages;
        }
    }
}
