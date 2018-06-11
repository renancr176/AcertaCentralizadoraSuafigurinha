using System;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageUpdatedEvent : BaseImageEvent
    {
        public ImageUpdatedEvent(Guid id, string url, int order, Guid? idGallery)
        {
            Id = id;
            Url = url;
            Order = order;
            IdGallery = idGallery;

            AggregateId = id;
        }
    }
}
