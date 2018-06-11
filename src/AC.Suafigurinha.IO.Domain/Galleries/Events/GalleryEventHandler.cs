using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryEventHandler : IHandler<GalleryInsertedEvent>
    {
        public void Handle(GalleryInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
