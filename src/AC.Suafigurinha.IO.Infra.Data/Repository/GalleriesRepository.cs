using System;
using System.Collections.Generic;
using System.Linq;
using AC.Suafigurinha.IO.Domain.Galleries;
using AC.Suafigurinha.IO.Domain.Galleries.Repository;
using AC.Suafigurinha.IO.Domain.Images;
using AC.Suafigurinha.IO.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace AC.Suafigurinha.IO.Infra.Data.Repository
{
    public class GalleriesRepository : Repository<Gallery>, IGalleryRepository
    {
        public GalleriesRepository(ApplicationContext context) : base(context)
        {

        }

        public override IEnumerable<Gallery> GetAll()
        {
            var sql = "SELECT * " +
                      "FROM Galleries AS g " +
                      "WHERE g.Deleted = 0 ";

            return Db.Database.GetDbConnection().Query<Gallery>(sql);
        }

        public override Gallery GetById(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM Galleries AS g " +
                      "WHERE g.Deleted = 0 " +
                      "g.IdGallery = @Id";

            var gallery = Db.Database.GetDbConnection().Query<Gallery>(sql, new { Id = id });

            return gallery.FirstOrDefault();
        }

        public IEnumerable<Image> GetAllImagesByGalleryId(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM Images AS i " +
                      "WHERE i.Deleted = 0 " +
                      "i.IdCategory = @Id";

            return Db.Database.GetDbConnection().Query<Image>(sql, new { Id = id });
        }

        public override void Delete(Guid id)
        {
            var gallery = GetById(id);
            gallery.GalleryDeleted();
            Update(gallery);
        }
    }
}
