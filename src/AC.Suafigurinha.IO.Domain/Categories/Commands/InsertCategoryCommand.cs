using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Commands
{
    public class InsertCategoryCommand : BaseCategoryCommand
    {
        public InsertCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
