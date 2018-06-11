using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class BaseImageEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Url { get; protected set; }
        public int Order { get; protected set; }
        public Guid? IdGallery { get; protected set; }
    }
}
