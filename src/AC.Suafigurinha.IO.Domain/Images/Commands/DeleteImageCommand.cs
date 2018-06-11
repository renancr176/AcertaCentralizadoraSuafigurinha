using System;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class DeleteImageCommand : BaseImageCommand
    {
        public DeleteImageCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
