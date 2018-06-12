using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Commands
{
    public class UpdateCategoryCommand : BaseCategoryCommand
    {
        public UpdateCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
