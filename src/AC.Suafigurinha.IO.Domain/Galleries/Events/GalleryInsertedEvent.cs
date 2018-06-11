using System;
using System.Collections.Generic;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryInsertedEvent : BaseGalleryEvent
    {
        public GalleryInsertedEvent(Guid id, string name, IEnumerable<Guid?> idImages)
        {
            Id = id;
            Name = name;
            IdImages = idImages;

            AggregateId = id;
        }
    }
}
