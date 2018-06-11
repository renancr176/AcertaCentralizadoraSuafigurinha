using System;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageDeletedEvent : BaseImageEvent
    {
        public ImageDeletedEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
