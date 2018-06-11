using System;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class DeleteGalleryCommand : BaseGalleryCommand
    {
        public DeleteGalleryCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
