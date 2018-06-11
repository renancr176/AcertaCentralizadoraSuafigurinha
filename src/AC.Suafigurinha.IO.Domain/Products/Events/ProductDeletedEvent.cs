using System;

namespace AC.Suafigurinha.IO.Domain.Products.Events
{
    public class ProductDeletedEvent : BaseProductEvent
    {
        public ProductDeletedEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
