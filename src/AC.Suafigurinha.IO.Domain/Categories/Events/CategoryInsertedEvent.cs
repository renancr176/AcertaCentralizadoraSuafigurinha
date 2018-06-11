using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Events
{
    public class CategoryInsertedEvent : BaseCategoryEvent
    {
        public CategoryInsertedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;

            AggregateId = id;
        }
    }
}
