using System;
using AC.Suafigurinha.IO.Domain.Core.Events;

namespace AC.Suafigurinha.IO.Domain.Categories.Events
{
    public class BaseCategoryEvent: Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
