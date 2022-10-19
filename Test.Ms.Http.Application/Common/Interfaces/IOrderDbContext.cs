using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Ms.Http.Order.Domain;

namespace Test.Ms.Http.Application.Common.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Http.Order.Domain.Order> Orders { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
