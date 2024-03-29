using ApiSln.Application.Interfaces.Repositories;
using ApiSln.Domain.Entities.Common;
using ApiSln.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class, IBaseEntity, new()
	{
		private readonly APIDbContext dbContext;

		public WriteRepository(APIDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public DbSet<T> Table { get => dbContext.Set<T>(); }

		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task AddRangeAsync(IList<T> entities)
		{
			await Table.AddRangeAsync(entities);
		}

		public async Task DeleteAsync(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
		}

		public async Task DeleteRangeAsync(IList<T> entity)
		{
			await Task.Run(() => Table.RemoveRange(entity));
		}

		public async Task<T> UpdateAsync(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;
		}
	}
}
