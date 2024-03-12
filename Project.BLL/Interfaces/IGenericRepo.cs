﻿using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Interfaces
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}