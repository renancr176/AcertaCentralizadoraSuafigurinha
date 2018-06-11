using System;

namespace AC.Suafigurinha.IO.Domain.Products.Commands
{
    public class DeleteProductCommand : BaseProductCommand
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
