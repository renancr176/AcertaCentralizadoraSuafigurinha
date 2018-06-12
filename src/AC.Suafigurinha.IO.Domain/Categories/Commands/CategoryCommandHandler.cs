using System;
using AC.Suafigurinha.IO.Domain.Categories.Events;
using AC.Suafigurinha.IO.Domain.Categories.Repository;
using AC.Suafigurinha.IO.Domain.CommandHandlers;
using AC.Suafigurinha.IO.Domain.Core.Bus;
using AC.Suafigurinha.IO.Domain.Core.Events;
using AC.Suafigurinha.IO.Domain.Core.Notifications;
using AC.Suafigurinha.IO.Domain.Interfaces;

namespace AC.Suafigurinha.IO.Domain.Categories.Commands
{
    public class CategoryCommandHandler :
        CommandHandler,
        IHandler<InsertCategoryCommand>,
        IHandler<UpdateCategoryCommand>,
        IHandler<DeleteCategoryCommand>
    {
        private readonly IBus _bus;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, ICategoryRepository categoryRepository) 
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _categoryRepository = categoryRepository;
        }

        public void Handle(InsertCategoryCommand message)
        {
            var category = Category.CategoryFactory.NewFullCategory(message.Id, message.Name);

            if (!category.IsValid())
            {
                AlertValidationsError(category.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar?

            _categoryRepository.Insert(category);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryInsertedEvent(message.Id,message.Name));
            }
        }

        public void Handle(UpdateCategoryCommand message)
        {
            if (!CategoryExists(message.Id, message.MessageType)) return;

            var category = Category.CategoryFactory.NewFullCategory(message.Id, message.Name);

            if (!category.IsValid())
            {
                AlertValidationsError(category.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar?

            _categoryRepository.Update(category);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryUpdatedEvent(message.Id, message.Name));
            }
        }

        public void Handle(DeleteCategoryCommand message)
        {
            if (!CategoryExists(message.Id, message.MessageType)) return;

            var currentImage = _categoryRepository.GetById(message.Id);

            // TODO:
            // Validacoes de negocio!
            // Usuário pode excluir?

            currentImage.CategoryDeleted();

            _categoryRepository.Update(currentImage);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryDeletedEvent(message.Id));
            }
        }

        public bool CategoryExists(Guid id, string messageType)
        {
            var category = _categoryRepository.GetById(id);

            if (category != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Categoria inexistente."));
            return false;
        }
    }
}
