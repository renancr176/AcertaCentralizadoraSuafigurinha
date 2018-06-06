using AC.Suafigurinha.IO.Domain.Core.Commands;
using AC.Suafigurinha.IO.Domain.Interfaces;
using AC.Suafigurinha.IO.Infra.Data.Context;

namespace AC.Suafigurinha.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuafigurinhaContext _context;

        public UnitOfWork(SuafigurinhaContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
