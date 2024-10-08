﻿using Core.ForEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ForDataAcces
{
    public interface IEntityDao<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
    }
}
