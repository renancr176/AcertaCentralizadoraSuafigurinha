using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Products.Events
{
    public class ProductEventHandler : IHandler<ProductRegistredEvent>
    {
        public void Handle(ProductRegistredEvent message)
        {
            // TODO: Ação posterior ao insert?
        }
    }
}
