using System;
using System.Collections.Generic;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class UpdateGalleryCommand : BaseGalleryCommand
    {
        public UpdateGalleryCommand(Guid id, string name, IEnumerable<Guid?> idImages)
        {
            Id = id;
            Name = name;
            IdImages = idImages;
        }
    }
}
