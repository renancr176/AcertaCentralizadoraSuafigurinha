using System;

namespace AC.Suafigurinha.IO.Domain.Categories.Events
{
    public class CategoryDeletedEvent : BaseCategoryEvent
    {
        public CategoryDeletedEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
