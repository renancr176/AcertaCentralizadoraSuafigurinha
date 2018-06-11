using System;
using System.Collections.Generic;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryUpdatedEvent : BaseGalleryEvent
    {
        public GalleryUpdatedEvent(Guid id, string name, IEnumerable<Guid?> idImages)
        {
            Id = id;
            Name = name;
            IdImages = idImages;

            AggregateId = id;
        }
    }
}
