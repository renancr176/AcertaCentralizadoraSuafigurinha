using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Events
{
    public class CategoryUpdatedEvent : BaseCategoryEvent
    {
        public CategoryUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;

            AggregateId = id;
        }
    }
}
