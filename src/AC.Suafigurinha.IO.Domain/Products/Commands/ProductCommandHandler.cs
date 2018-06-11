using AC.Suafigurinha.IO.Domain.CommandHandlers;
using AC.Suafigurinha.IO.Domain.Core.Bus;
using AC.Suafigurinha.IO.Domain.Core.Events;
using AC.Suafigurinha.IO.Domain.Core.Notifications;
using AC.Suafigurinha.IO.Domain.Interfaces;
using AC.Suafigurinha.IO.Domain.Products.Events;
using AC.Suafigurinha.IO.Domain.Products.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AC.Suafigurinha.IO.Domain.Products.Commands
{
    public class ProductCommandHandler : CommandHandler, IHandler<InsertProductCommand>
    {
        public readonly IBus _bus;
        public readonly IProductRepository _productRepository;

        public ProductCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification, IProductRepository productRepository)
            : base(uow, bus, notification)
        {
            _bus = bus;
            _productRepository = productRepository;
        }

        public void Handle(InsertProductCommand message)
        {
            var product = Product.ProductFactory.NewFullProduct(message.Id, message.Name, message.Price, message.Quantity, message.ShortDescription, message.Description, message.IdImage, message.IdGalery);

            if (!product.IsValid())
            {
                AlertValidationsError(product.ValidationResult);
                return;
            }

            var existsProduct = _productRepository.Find(p => p.Id == product.Id);

            if (existsProduct.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto já cadastrado."));
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar produto?

            _productRepository.Insert(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductInsertedEvent(product.Id, product.Name, product.Price, product.Quantity, product.ShortDescription, product.Description, product.IdImage, product.IdGalery));
            }
        }
    }
}
