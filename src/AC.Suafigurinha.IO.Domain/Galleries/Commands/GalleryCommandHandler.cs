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
    public class GalleryCommandHandler : 
        CommandHandler, 
        IHandler<InsertGalleryCommand>,
        IHandler<UpdateGalleryCommand>,
        IHandler<DeleteGalleryCommand>
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
            var gallery = new Gallery(message.Name, message.IdImages);

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
                _bus.RaiseEvent(new GalleryInsertedEvent(gallery.Id, gallery.Name, gallery.IdImages));
            }
        }

        public void Handle(UpdateGalleryCommand message)
        {
            if (!GalleryExists(message.Id, message.MessageType)) return;

            var gallery = Gallery.GalleryFactory.NewFullGallery(message.Id, message.Name, message.IdImages);

            if (!gallery.IsValid())
            {
                AlertValidationsError(gallery.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar?

            _galleryRepository.Update(gallery);

            if (Commit())
            {
                _bus.RaiseEvent(new GalleryUpdatedEvent(gallery.Id, gallery.Name, gallery.IdImages));
            }
        }

        public void Handle(DeleteGalleryCommand message)
        {
            if (!GalleryExists(message.Id, message.MessageType)) return;

            // TODO:
            // Validacoes de negocio!
            // Usuário pode excluir?

            var currentGallery = _galleryRepository.GetById(message.Id);

            currentGallery.GalleryDeleted();
            _galleryRepository.Update(currentGallery);

            if (Commit())
            {
                _bus.RaiseEvent(new GalleryDeletedEvent(message.Id));
            }

        }

        private bool GalleryExists(Guid id, string messageType)
        {
            var gallery = _galleryRepository.GetById(id);
            if (gallery != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Galeria inexistente"));
            return false;
        }
    }
}
