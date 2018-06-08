using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageRegistredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public int Order { get; private set; }

        public ImageRegistredEvent(Guid id, string url, int order)
        {
            Id = id;
            Url = url;
            Order = order;
        }
    }
}
