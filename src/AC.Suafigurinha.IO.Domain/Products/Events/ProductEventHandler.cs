using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Products.Events
{
    public class ProductEventHandler : IHandler<ProductInsertedEvent>
    {
        public void Handle(ProductInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
