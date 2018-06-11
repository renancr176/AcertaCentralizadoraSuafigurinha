using System;
using AC.Suafigurinha.IO.Domain.Core.Commands;

namespace AC.Suafigurinha.IO.Domain.Categories.Commands
{
    public class BaseCategoryCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
