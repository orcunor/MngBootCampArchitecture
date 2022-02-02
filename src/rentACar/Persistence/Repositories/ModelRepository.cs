﻿using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {
        }

       
    }
}
