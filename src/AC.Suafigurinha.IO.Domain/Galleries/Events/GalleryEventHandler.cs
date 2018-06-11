using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryEventHandler : 
        IHandler<GalleryInsertedEvent>,
        IHandler<GalleryUpdatedEvent>,
        IHandler<GalleryDeletedEvent>
    {
        public void Handle(GalleryInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }

        public void Handle(GalleryUpdatedEvent message)
        {
            // TODO: Ação posterior ao update?
        }

        public void Handle(GalleryDeletedEvent message)
        {
            // TODO: Ação posterior ao delete?
        }
    }
}
