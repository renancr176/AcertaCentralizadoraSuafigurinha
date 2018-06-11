using System;
using System.Collections.Generic;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class BaseGalleryEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public virtual IEnumerable<Guid?> IdImages { get; protected set; }
    }
}
