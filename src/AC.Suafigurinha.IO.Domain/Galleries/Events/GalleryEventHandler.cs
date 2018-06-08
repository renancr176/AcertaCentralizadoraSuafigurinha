using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Galleries.Events
{
    public class GalleryEventHandler : IHandler<GalleryRegistredEvent>
    {
        public void Handle(GalleryRegistredEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
