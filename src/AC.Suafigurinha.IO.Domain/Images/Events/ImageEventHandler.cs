using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageEventHandler : 
        IHandler<ImageInsertedEvent>,
        IHandler<ImageUpdatedEvent>,
        IHandler<ImageDeletedEvent>
    {
        public void Handle(ImageInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }

        public void Handle(ImageUpdatedEvent message)
        {
            // TODO: Ação posterior ao update?
        }

        public void Handle(ImageDeletedEvent message)
        {
            // TODO: Ação posterior ao delete?
        }
    }
}
