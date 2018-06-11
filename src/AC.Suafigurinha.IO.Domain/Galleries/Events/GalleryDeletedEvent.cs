using System;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryDeletedEvent : BaseGalleryEvent
    {
        public GalleryDeletedEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
