using System;
using RealEstates.Abstract;
using AutoMapper;

namespace RealEstates.BLL
{
    public abstract class BaseLogic<T, TEntity> : BaseLogicCtx, IBaseLogic<T, TEntity> where TEntity : class where T : class
    {
        public BaseLogic(IDALContext ctx) : base (ctx)
        {
        }

        public virtual T Get(int id)
        {
            var itemEntity = db.Set<TEntity>().Find(id);

            var config = new MapperConfiguration(cfg=>cfg.CreateMap<TEntity, T>());
            var mapper = config.CreateMapper();

            var item = mapper.Map<T>(itemEntity);

            return item;
        }

        public virtual void Create(T item)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, TEntity>());
            var mapper = config.CreateMapper();

            var itemEntity = mapper.Map<TEntity>(item);

            db.Set<TEntity>().Add(itemEntity);
            base.Save();
        }

        public virtual void Update(T item)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, TEntity>());
            var mapper = config.CreateMapper();

            var itemEntity = mapper.Map<TEntity>(item);

            db.Set<TEntity>().Update(itemEntity);
            base.Save();
        }

        public virtual bool Delete(int id)
        {
            var item = db.Set<TEntity>().Find(id);
            if (item != null)
            {
                db.Set<TEntity>().Remove(item);
                base.Save();
                return true;
            }
            return false;

        }
    }
}
