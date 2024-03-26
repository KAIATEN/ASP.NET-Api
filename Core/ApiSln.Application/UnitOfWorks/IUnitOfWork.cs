using ApiSln.Application.Interfaces.Repositories;
using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new();
		IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
		Task<int> SaveAsync();
		int Save();
	}
}
