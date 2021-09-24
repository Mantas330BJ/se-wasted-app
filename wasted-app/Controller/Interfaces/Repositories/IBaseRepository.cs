﻿using System;
using System.Collections.Generic;
using wasted_app.Controller.Entities;

namespace console_wasted_app.Controller.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}