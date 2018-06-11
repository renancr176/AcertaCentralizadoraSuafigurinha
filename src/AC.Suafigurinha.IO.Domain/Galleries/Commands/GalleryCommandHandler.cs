using System;
using AC.Suafigurinha.IO.Domain.Core.Events;
using AC.Suafigurinha.IO.Domain.CommandHandlers;
using AC.Suafigurinha.IO.Domain.Core.Bus;
using AC.Suafigurinha.IO.Domain.Galleries.Repository;
using AC.Suafigurinha.IO.Domain.Interfaces;
using AC.Suafigurinha.IO.Domain.Core.Notifications;
using AC.Suafigurinha.IO.Domain.Galleries.Events;

namespace AC.Suafigurinha.IO.Domain.Galleries.Commands
{
    public class GalleryCommandHandler : CommandHandler, IHandler<InsertGalleryCommand>
    {
        private readonly IBus _bus;
        private readonly IGalleryRepository _galleryRepository;

        public GalleryCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IGalleryRepository galleryRepository)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _galleryRepository = galleryRepository;
        }

        public void Handle(InsertGalleryCommand message)
        {
            var gallery = new Gallery(message.Name, message.Images);

            if (!gallery.IsValid())
            {
                AlertValidationsError(gallery.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar imagem?

            _galleryRepository.Insert(gallery);

            if (Commit())
            {
                _bus.RaiseEvent(new GalleryInsertedEvent(gallery.Id, gallery.Name, gallery.Images));
            }
        }
    }
}
