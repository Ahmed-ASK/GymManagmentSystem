﻿using GymManagementDAL.Entities.Base;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositiry.Interfaces
{
    public interface IUnitOfWork
    {
        public ISessionRepository SessionRepository { get; }

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity , new();
        int SaveChanges();
    }
}
