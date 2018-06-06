using AC.Suafigurinha.IO.Domain.Core.Events;
using System.Collections.Generic;


namespace AC.Suafigurinha.IO.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
