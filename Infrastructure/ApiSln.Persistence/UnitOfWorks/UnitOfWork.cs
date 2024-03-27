using ApiSln.Application.Interfaces.Repositories;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Persistence.Context;
using ApiSln.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly APIDbContext dbContext;

		public UnitOfWork(APIDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public ValueTask DisposeAsync() => dbContext.DisposeAsync();

		public int Save() => dbContext.SaveChanges();

		public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

		IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

		IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
	}
}
