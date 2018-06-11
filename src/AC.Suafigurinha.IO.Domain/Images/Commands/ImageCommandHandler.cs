using System;
using System.Linq;
using AC.Suafigurinha.IO.Domain.CommandHandlers;
using AC.Suafigurinha.IO.Domain.Core.Bus;
using AC.Suafigurinha.IO.Domain.Core.Events;
using AC.Suafigurinha.IO.Domain.Core.Notifications;
using AC.Suafigurinha.IO.Domain.Images.Events;
using AC.Suafigurinha.IO.Domain.Images.Repository;
using AC.Suafigurinha.IO.Domain.Interfaces;

namespace AC.Suafigurinha.IO.Domain.Images.Commands
{
    public class ImageCommandHandler : 
        CommandHandler, 
        IHandler<InsertImageCommand>,
        IHandler<UpdateImageCommand>,
        IHandler<DeleteImageCommand>
    {
        private readonly IBus _bus;
        private readonly IImageRepository _imageRepository;

        public ImageCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IImageRepository imageRepository) 
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _imageRepository = imageRepository;
        }

        public void Handle(InsertImageCommand message)
        {
            var image = Image.ImageFactory.NewFullImage(message.Id, message.Url, message.Order, message.IdGalery);

            if (!image.IsValid())
            {
                AlertValidationsError(image.ValidationResult);
                return;
            }

            var existsImage = _imageRepository.Find(i => i.Url == image.Url);

            if (existsImage.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Imagem já cadastrada."));
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar imagem?

            _imageRepository.Insert(image);

            if (Commit())
            {
                _bus.RaiseEvent(new ImageInsertedEvent(image.Id, image.Url, image.Order, image.IdGallery));
            }
        }

        public void Handle(UpdateImageCommand message)
        {
            if (!ImageExists(message.Id, message.MessageType)) return;

            var image = Image.ImageFactory.NewFullImage(message.Id, message.Url, message.Order, message.IdGalery);

            if (!image.IsValid())
            {
                AlertValidationsError(image.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar imagem?

            _imageRepository.Update(image);

            if (Commit())
            {
                _bus.RaiseEvent(new ImageUpdatedEvent(image.Id, image.Url, image.Order, image.IdGallery));
            }

        }

        public void Handle(DeleteImageCommand message)
        {
            if (!ImageExists(message.Id, message.MessageType)) return;

            var currentImage = _imageRepository.GetById(message.Id);

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar imagem?

            currentImage.ImageDeleted();

            _imageRepository.Update(currentImage);

            if (Commit())
            {
                _bus.RaiseEvent(new ImageDeletedEvent(message.Id));
            }
        }

        private bool ImageExists(Guid id, string messageType)
        {
            var image = _imageRepository.GetById(id);

            if (image != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Imagem inexistente."));
            return false;
        }
    }
}
