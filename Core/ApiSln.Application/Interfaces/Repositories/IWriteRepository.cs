using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> where T : class, IBaseEntity, new()
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IList<T> entities);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
