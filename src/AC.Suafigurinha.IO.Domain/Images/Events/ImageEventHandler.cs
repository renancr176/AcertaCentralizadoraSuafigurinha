using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageEventHandler : IHandler<ImageInsertedEvent>
    {
        public void Handle(ImageInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
