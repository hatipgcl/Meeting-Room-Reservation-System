using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {// IDispossable pattern ipmlemention of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                addedEntity.State = EntityState.Added; //Bu eklenen entitym
                context.SaveChanges(); //Bunu Ekle
            }//bellekte işlem sonrası siliniyor northwind
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                deletedEntity.State = EntityState.Deleted; //Bu silinecek entitym
                context.SaveChanges(); //Bunu sil
            }//bellekte işlem sonrası siliniyor northwind
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);//tek b,r veri getirri
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                //null ise sol, null değil ise sağ taraf çalışır.yukarıda tüm veriyi getirir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                updatedEntity.State = EntityState.Modified; //Bu Günecellenen olacak entitym
                context.SaveChanges(); //Bunu Güncelle
            }//bellekte işlem sonrası siliniyor northwind
        }

    }
}
