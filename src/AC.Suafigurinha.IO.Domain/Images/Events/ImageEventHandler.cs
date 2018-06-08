using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Images.Events
{
    public class ImageEventHandler : IHandler<ImageRegistredEvent>
    {
        public void Handle(ImageRegistredEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
