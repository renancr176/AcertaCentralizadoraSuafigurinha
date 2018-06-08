using System;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Events;
using AC.Suafigurinha.IO.Domain.Images;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryRegistredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<Image> Images { get; private set; }

        public GalleryRegistredEvent(Guid id, string name, List<Image> images)
        {
            Id = id;
            Name = name;
            Images = images;
        }
    }
}
