﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind2.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}