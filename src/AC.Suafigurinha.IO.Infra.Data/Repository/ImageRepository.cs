using System;
using System.Collections.Generic;
using System.Linq;
using AC.Suafigurinha.IO.Domain.Images;
using AC.Suafigurinha.IO.Domain.Images.Repository;
using AC.Suafigurinha.IO.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace AC.Suafigurinha.IO.Infra.Data.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationContext context) : base(context)
        {

        }

        public override IEnumerable<Image> GetAll()
        {
            var sql = "SELECT * " +
                      "FROM Images AS i " +
                      "WHERE i.Deleted = 0 " +
                      "ORDER BY " +
                      "i.Order";

            return Db.Database.GetDbConnection().Query<Image>(sql);
        }

        public override Image GetById(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM Images AS i " +
                      "WHERE i.Deleted = 0 " +
                      "AND i.IdImage = @Id" +
                      "ORDER BY " +
                      "i.Order";

            var image = Db.Database.GetDbConnection().Query<Image>(sql, new { Id = id });

            return image.FirstOrDefault();
        }

        public IEnumerable<Image> GetByCategoryId(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM Images AS i " +
                      "WHERE i.Deleted = 0 " +
                      "i.IdCategory = @Id" +
                      "ORDER BY " +
                      "i.Order";

            return Db.Database.GetDbConnection().Query<Image>(sql, new { Id = id });
        }

        public override void Delete(Guid id)
        {
            var image = GetById(id);
            image.ImageDeleted();
            Update(image);
        }
    }
}
