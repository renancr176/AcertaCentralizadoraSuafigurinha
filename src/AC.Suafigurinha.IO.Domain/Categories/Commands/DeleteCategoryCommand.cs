using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Commands
{
    public class DeleteCategoryCommand : BaseCategoryCommand
    {
        public DeleteCategoryCommand(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
