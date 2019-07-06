using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Abstract;

namespace RealEstates.BLL
{
    public abstract class BaseLogicCtx
    {
        protected IDALContext db;

        public BaseLogicCtx(IDALContext ctx)
        {
            db = ctx;
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }
    }
}
